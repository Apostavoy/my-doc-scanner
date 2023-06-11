using IronSoftware.Drawing;
using System;
using System.Drawing;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace windows_ui
{
    struct CropData
    {
        private int x1;
        private int y1;
        private int x2;
        private int y2;
        private decimal scaling;
        private int changesSinceCheck;

        public CropData(int init)
        {
            this.x1 = init;
            this.y1 = init;
            this.x2 = init;
            this.y2 = init;
            this.scaling = init;
            this.changesSinceCheck = init;
        }

        public void setX1(int x)
        {
            this.x1 = x;
            this.changesSinceCheck++;
        }

        public void setY1(int y)
        {
            this.y1 = y;
            this.changesSinceCheck++;
        }

        public void setXY1(int x, int y) { 
            setX1(x); setY1(y);
        }


        public void setX2(int x)
        {
            this.x2 = x;
            this.changesSinceCheck++;
        }

        public void setY2(int y)
        {
            this.y2 = y;
            this.changesSinceCheck++;
        }

        public void setXY2(int x, int y)
        {
            setX2(x); setY2(y);
        }

        public void setScaling(decimal scaling) { 
            this.scaling = scaling;
        }

        public void scaleVals(decimal scaling=-1) {
            if (scaling < 0) scaling = this.scaling;

            setXY1((int)(scaling * this.x1), (int)(scaling * this.y1));
            setXY2((int)(scaling * this.x2), (int)(scaling * this.y2));
        }

        public void drawCropRect(Control canvas, Pen pen) {
            canvas.CreateGraphics().DrawRectangle(
                        pen,
                        this.x1 > this.x2 ? this.x2 : this.x1,
                        this.y1 > this.y2 ? this.y2 : this.y1,
                        this.x1 > this.x2 ? this.x1 - this.x2 : this.x2 - this.x1,
                        this.y1 > this.y2 ? this.y1 - this.y2 : this.y2 - this.y1
                    );
        }

        public bool changed()
        {
            bool isChanged = this.changesSinceCheck >= 0;
            this.changesSinceCheck = 0;
            return isChanged;
        }
    }


    public partial class MainFrm : Form
    {
        protected enum Modes {
            Std = 0,
            Crp = 1
        }

        Modes mode = Modes.Std;
        CropData cropData = new CropData(0);
        PDF openPDF = null;

        public MainFrm()
        {
            InitializeComponent();
        }

        private void mainOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult dr = fileDialog.ShowDialog();
            if (dr == DialogResult.OK) {
                if (openPDF != null) openPDF.Dispose();
                openPDF = new PDF(fileDialog.FileName);
                setImageToFirstPage();
            } else {
                MessageBox.Show("file open cancelled.");
            }
        }

        private void setImageToFirstPage() {
            if (openPDF != null)
            {
                (AnyBitmap image, decimal scaling) = openPDF.getPage(
                        0,
                        this.mainPanel.Width - 342,
                        this.mainPanel.Height - 24,
                        resizeCropBoxOnImageResize
                ) ;

                this.mainCropBox.Image = image;
                this.cropData.setScaling(scaling);
            }        
        }

        private bool validChange(Modes newMode) {
            switch (newMode) {
                case Modes.Std:
                    return true;
                case Modes.Crp:
                    return mainCropBox.Image != null;
            }
            return false;
        }


        private void switchMode(Modes newMode) {
            if (!validChange(newMode)) { return; }    
            mode = newMode;

            switch (mode) {
                case Modes.Std:
                    mainToolStrip.Enabled = true;
                    cropModeBtn.Text = "Crop Mode";
                    break;
                case Modes.Crp:
                    mainToolStrip.Enabled = false;
                    cropModeBtn.Text = "Complete Crop";
                    break;
            }
        }

        private void cropModeBtn_Click(object sender, EventArgs e)
        {
            if (this.mode != Modes.Crp) this.switchMode(Modes.Crp);
            else this.switchMode(Modes.Std);
        }

        private bool isValidCrop(MouseButtons btn)
        {
            return btn == MouseButtons.Left 
                && mainCropBox.Image != null
                && this.mode == Modes.Crp;
        }

        private void refreshCropBox() {
            if (cropData.changed()) {
                mainCropBox.Refresh();
            }
        }

        private void resizeCropBoxOnImageResize(int width, int height)
        {
            mainCropBox.Width = width; mainCropBox.Height = height;
            refreshCropBox();
            cropData.scaleVals();
            using (Pen pen = new Pen(Color.Black, 2)) {
                cropData.drawCropRect(mainCropBox, pen);
            }
        }

        private void mainCropBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.isValidCrop(e.Button))
            {
                Cursor = Cursors.Cross;
                cropData.setXY1(e.X, e.Y);
                refreshCropBox();
            }
            
        }

        private void mainCropBox_MouseMove(object sender, MouseEventArgs e)
        {
            using (Pen cropPen = new Pen(Color.Black, 2)) {
                if (this.isValidCrop(e.Button)) {
                    cropPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    refreshCropBox();
                    cropData.setXY2(e.X, e.Y);
                    cropData.drawCropRect(mainCropBox, cropPen);
                }
            }
        }

        private void MainFrm_MouseUp(object sender, MouseEventArgs e)
        {
            if (Cursor != Cursors.Arrow) Cursor = Cursors.Arrow;
        }

        private void MainFrm_Resize(object sender, EventArgs e)
        {
            setImageToFirstPage();
        }
    }
}
