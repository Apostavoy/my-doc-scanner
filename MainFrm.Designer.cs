using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Xml.Schema;

namespace windows_ui
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.mainOpenFile = new System.Windows.Forms.ToolStripButton();
            this.mainScanFile = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cropModeBtn = new System.Windows.Forms.Button();
            this.mainCropBox = new System.Windows.Forms.PictureBox();
            this.sep1 = new System.Windows.Forms.Splitter();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mainToolStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainCropBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.AutoSize = false;
            this.mainToolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.mainToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.mainToolStrip.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.mainToolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainOpenFile,
            this.mainScanFile});
            this.mainToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.mainToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mainToolStrip.Size = new System.Drawing.Size(51, 380);
            this.mainToolStrip.Stretch = true;
            this.mainToolStrip.TabIndex = 0;
            this.mainToolStrip.Text = "toolStrip1";
            this.mainToolStrip.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainFrm_MouseUp);
            // 
            // mainOpenFile
            // 
            this.mainOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mainOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("mainOpenFile.Image")));
            this.mainOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mainOpenFile.Name = "mainOpenFile";
            this.mainOpenFile.Padding = new System.Windows.Forms.Padding(5);
            this.mainOpenFile.Size = new System.Drawing.Size(50, 44);
            this.mainOpenFile.ToolTipText = "Open File...";
            this.mainOpenFile.Click += new System.EventHandler(this.mainOpenFile_Click);
            this.mainOpenFile.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainFrm_MouseUp);
            // 
            // mainScanFile
            // 
            this.mainScanFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mainScanFile.Image = global::windows_ui.Properties.Resources.scanner;
            this.mainScanFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mainScanFile.Name = "mainScanFile";
            this.mainScanFile.Padding = new System.Windows.Forms.Padding(5);
            this.mainScanFile.Size = new System.Drawing.Size(50, 44);
            this.mainScanFile.ToolTipText = "Scan File...";
            this.mainScanFile.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainFrm_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.mainCropBox);
            this.panel1.Controls.Add(this.sep1);
            this.panel1.Controls.Add(this.mainToolStrip);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 380);
            this.panel1.TabIndex = 1;
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainFrm_MouseUp);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.cropModeBtn);
            this.panel2.Location = new System.Drawing.Point(58, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(266, 356);
            this.panel2.TabIndex = 4;
            // 
            // cropModeBtn
            // 
            this.cropModeBtn.Location = new System.Drawing.Point(3, 3);
            this.cropModeBtn.Name = "cropModeBtn";
            this.cropModeBtn.Size = new System.Drawing.Size(260, 23);
            this.cropModeBtn.TabIndex = 3;
            this.cropModeBtn.Text = "Crop Mode";
            this.cropModeBtn.UseVisualStyleBackColor = true;
            this.cropModeBtn.Click += new System.EventHandler(this.cropModeBtn_Click);
            this.cropModeBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainFrm_MouseUp);
            // 
            // mainCropBox
            // 
            this.mainCropBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainCropBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainCropBox.Location = new System.Drawing.Point(330, 12);
            this.mainCropBox.Name = "mainCropBox";
            this.mainCropBox.Size = new System.Drawing.Size(274, 357);
            this.mainCropBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mainCropBox.TabIndex = 1;
            this.mainCropBox.TabStop = false;
            this.mainCropBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainCropBox_MouseDown);
            this.mainCropBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainCropBox_MouseMove);
            this.mainCropBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainFrm_MouseUp);
            // 
            // sep1
            // 
            this.sep1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.sep1.Location = new System.Drawing.Point(51, 0);
            this.sep1.Name = "sep1";
            this.sep1.Size = new System.Drawing.Size(1, 380);
            this.sep1.TabIndex = 2;
            this.sep1.TabStop = false;
            // 
            // fileDialog
            // 
            this.fileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 380);
            this.Controls.Add(this.panel1);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainFrm";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainFrm_MouseUp);
            this.Resize += new System.EventHandler(this.MainFrm_Resize);
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainCropBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolStrip;
        private ToolStripButton mainScanFile;
        private ToolStripButton mainOpenFile;
        private Panel panel1;
        private Splitter sep1;
        private PictureBox mainCropBox;
        private OpenFileDialog fileDialog;
        private Button cropModeBtn;
        private Panel panel2;
    }
}