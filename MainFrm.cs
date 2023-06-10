using System;
using System.Drawing;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace windows_ui
{
    struct CropData
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public Pen pen;
        public int changesSinceCheck;

        public CropData(int init)
        {
            this.x = init;
            this.y = init;
            this.width = init;
            this.height = init;

            this.pen = new Pen(Color.Red, 1);
            this.pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            this.changesSinceCheck = init;
        }

        public void setX(int x)
        {
            this.x = x;
            this.changesSinceCheck++;
        }

        public void setY(int y)
        {
            this.y = y;
            this.changesSinceCheck++;
        }

        public void setXY(int x, int y) { 
            setX(x); setY(y);
        }

        public void setWidth(int width)
        {
            this.width = width;
            this.changesSinceCheck++;
        }

        public void setHeight(int height)
        {
            this.height = height;
            this.changesSinceCheck++;
        }

        public void setDim(int x2, int y2) { 
            setWidth(x2 - this.x); setHeight(y2 - this.y);
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
                this.mainCropBox.Image = openPDF.getPage(
                        0,
                        this.mainCropBox.Width,
                        this.mainCropBox.Height
                );
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

        private void mainCropBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.isValidCrop(e.Button))
            {
                Cursor = Cursors.Cross;
                cropData.setXY(e.X, e.Y);
                refreshCropBox();
            }
            
        }

        private void mainCropBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isValidCrop(e.Button))
            {
                refreshCropBox();
                cropData.setDim(e.X, e.Y);
                mainCropBox.CreateGraphics().DrawRectangle(
                    cropData.pen, 
                    cropData.x,
                    cropData.y, 
                    cropData.width, 
                    cropData.height
                );
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
