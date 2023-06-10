using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;
using IronPdf;
using IronSoftware.Drawing;
using Microsoft.Win32;
using SixLabors.ImageSharp.Processing;

namespace windows_ui
{
    internal class PDF
    {
        private AnyBitmap[] pages;

        public PDF(string filePath)
        {
            this.Load(filePath);
        }

        public AnyBitmap getPage(int index, int maxWidth=-1, int maxHeight=-1)
        {
            if (pages == null) { throw new InvalidOperationException(); }
            if (maxHeight <= 0 && maxWidth <= 0) { return pages[index]; }
            return this.resizePage(pages[index], maxWidth, maxHeight);
        }

        private AnyBitmap resizePage(AnyBitmap page, int maxWidth, int maxHeight)
        {
            decimal determineScaling(AnyBitmap p, int mW, int mH) {
                if (p.Width >= p.Height) return Decimal.Divide(mW, page.Width);
                return Decimal.Divide(mH, page.Height);
            }

            decimal scaling = determineScaling(page, maxWidth, maxHeight);

            Bitmap bitmap = new Bitmap((int)(scaling * page.Width), (int)(scaling * page.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            bitmap.SetResolution((float)page.HorizontalResolution, (float)page.VerticalResolution);

            Graphics bitmapDrawable = Graphics.FromImage(bitmap);
            bitmapDrawable.InterpolationMode = InterpolationMode.HighQualityBicubic;

            bitmapDrawable.DrawImage(page,
                new Rectangle(
                    0, 
                    0, 
                    (int)(scaling * page.Width), 
                    (int)(scaling * page.Height)
                )
            );

            bitmapDrawable.Dispose();

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
