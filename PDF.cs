using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using IronPdf;
using IronSoftware.Drawing;

namespace windows_ui
{
    internal class PDF
    {
        internal struct Scaling {
            public decimal scalingPercentage { get; set; }
            private int maxWidth, maxHeight;
            private AnyBitmap page;
            public Scaling(AnyBitmap p, int maxWidth, int maxHeight)
            {
                this.maxWidth = maxWidth;
                this.maxHeight = maxHeight;

                if (p.Width >= p.Height) {
                    this.scalingPercentage = Decimal.Divide(this.maxWidth, p.Width);
                    if ((p.Height * this.scalingPercentage) > this.maxHeight) {
                        this.scalingPercentage = Decimal.Divide(this.maxHeight, p.Height);
                    }
                } else {
                    this.scalingPercentage = Decimal.Divide(this.maxHeight, p.Height);
                    if ((p.Width * this.scalingPercentage) > this.maxWidth) {
                        this.scalingPercentage = Decimal.Divide(this.maxWidth, p.Width);
                    }
                }
                this.page = p;
            }

            public (int width, int height) scaleWH()
            {
                return ((int)(this.page.Width * this.scalingPercentage), (int)(this.page.Height * this.scalingPercentage));
            }
        }

        private AnyBitmap[] pages;

        public PDF(string filePath)
        {
            this.Load(filePath);
        }

        public AnyBitmap getPage(int index, int maxWidth=-1, int maxHeight=-1, Action<AnyBitmap, int, int> resizingCallback = null)
        {
            if (pages == null) throw new InvalidOperationException();

            AnyBitmap page = pages[index];
            
            if (maxHeight <= 0 && maxWidth <= 0) return page; 
            if (resizingCallback == null) throw new InvalidOperationException();
            Scaling scaling = new Scaling(page, maxWidth, maxHeight);
            return this.resizePage(page, scaling, resizingCallback);
        }

        private AnyBitmap resizePage(AnyBitmap page, Scaling scaling, Action<AnyBitmap, int, int> callback)
        {
            (int newWidth, int newHeight) = scaling.scaleWH();

            Bitmap bitmap = new Bitmap(newWidth, newHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            bitmap.SetResolution((float)page.HorizontalResolution, (float)page.VerticalResolution);

            Graphics bitmapDrawable = Graphics.FromImage(bitmap);
            bitmapDrawable.InterpolationMode = InterpolationMode.HighQualityBicubic;

            bitmapDrawable.DrawImage(page,
                new Rectangle(
                    0, 
                    0, 
                    newWidth, 
                    newHeight
                )
            );

            bitmapDrawable.Dispose();

            callback(bitmap, newWidth, newHeight);
            return bitmap;
        }

        public void Load(String path)
        {
            var pdf = PdfDocument.FromFile(path);
            this.pages = pdf.ToBitmap();
            pdf.Dispose();
        }

        public void Dispose() { 
            foreach (var page in this.pages) { page.Dispose(); }
        }

        public void Save(String outPath)
        {
            ImageToPdfConverter.ImageToPdf(this.pages).SaveAs(outPath);
        }
    }
}
