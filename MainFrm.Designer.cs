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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.mainOpenFile = new System.Windows.Forms.ToolStripButton();
            this.mainScanFile = new System.Windows.Forms.ToolStripButton();
            this.RegexEditor = new System.Windows.Forms.ToolStripButton();
            this.mainCropBtn = new System.Windows.Forms.ToolStripButton();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainCropBox = new System.Windows.Forms.PictureBox();
            this.cropContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cropSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cropColourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cropWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sep1 = new System.Windows.Forms.Splitter();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cropBoxPanel = new System.Windows.Forms.Panel();
            this.mainToolStrip.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainCropBox)).BeginInit();
            this.cropContext.SuspendLayout();
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
            this.mainScanFile,
            this.RegexEditor,
            this.mainCropBtn});
            this.mainToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.mainToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mainToolStrip.Size = new System.Drawing.Size(51, 456);
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
            // RegexEditor
            // 
            this.RegexEditor.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.RegexEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RegexEditor.Image = global::windows_ui.Properties.Resources.regex;
            this.RegexEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RegexEditor.Name = "RegexEditor";
            this.RegexEditor.Padding = new System.Windows.Forms.Padding(5);
            this.RegexEditor.Size = new System.Drawing.Size(50, 44);
            this.RegexEditor.ToolTipText = "Regex Editor...";
            // 
            // mainCropBtn
            // 
            this.mainCropBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mainCropBtn.Image = global::windows_ui.Properties.Resources.crop;
            this.mainCropBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mainCropBtn.Name = "mainCropBtn";
            this.mainCropBtn.Padding = new System.Windows.Forms.Padding(5);
            this.mainCropBtn.Size = new System.Drawing.Size(50, 44);
            this.mainCropBtn.ToolTipText = "Crop Mode";
            this.mainCropBtn.Click += new System.EventHandler(this.cropModeBtn_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.mainCropBox);
            this.mainPanel.Controls.Add(this.cropBoxPanel);
            this.mainPanel.Controls.Add(this.sep1);
            this.mainPanel.Controls.Add(this.mainToolStrip);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(926, 456);
            this.mainPanel.TabIndex = 1;
            this.mainPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainFrm_MouseUp);
            // 
            // mainCropBox
            // 
            this.mainCropBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainCropBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainCropBox.ContextMenuStrip = this.cropContext;
            this.mainCropBox.Location = new System.Drawing.Point(63, 12);
            this.mainCropBox.Name = "mainCropBox";
            this.mainCropBox.Size = new System.Drawing.Size(851, 432);
            this.mainCropBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mainCropBox.TabIndex = 1;
            this.mainCropBox.TabStop = false;
            this.mainCropBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainCropBox_MouseDown);
            this.mainCropBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainCropBox_MouseMove);
            this.mainCropBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainFrm_MouseUp);
            // 
            // cropContext
            // 
            this.cropContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cropSettingsToolStripMenuItem});
            this.cropContext.Name = "cropContext";
            this.cropContext.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cropContext.Size = new System.Drawing.Size(146, 26);
            // 
            // cropSettingsToolStripMenuItem
            // 
            this.cropSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cropColourToolStripMenuItem,
            this.cropWidthToolStripMenuItem});
            this.cropSettingsToolStripMenuItem.Name = "cropSettingsToolStripMenuItem";
            this.cropSettingsToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.cropSettingsToolStripMenuItem.Text = "Crop Settings";
            // 
            // cropColourToolStripMenuItem
            // 
            this.cropColourToolStripMenuItem.Name = "cropColourToolStripMenuItem";
            this.cropColourToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.cropColourToolStripMenuItem.Text = "Crop Colour";
            // 
            // cropWidthToolStripMenuItem
            // 
            this.cropWidthToolStripMenuItem.Name = "cropWidthToolStripMenuItem";
            this.cropWidthToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.cropWidthToolStripMenuItem.Text = "Crop Width";
            // 
            // sep1
            // 
            this.sep1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.sep1.Location = new System.Drawing.Point(51, 0);
            this.sep1.Name = "sep1";
            this.sep1.Size = new System.Drawing.Size(1, 456);
            this.sep1.TabIndex = 2;
            this.sep1.TabStop = false;
            // 
            // fileDialog
            // 
            this.fileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            // 
            // cropBoxPanel
            // 
            this.cropBoxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cropBoxPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cropBoxPanel.Location = new System.Drawing.Point(51, 0);
            this.cropBoxPanel.Name = "cropBoxPanel";
            this.cropBoxPanel.Size = new System.Drawing.Size(875, 456);
            this.cropBoxPanel.TabIndex = 3;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 456);
            this.Controls.Add(this.mainPanel);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyDoc Scanner";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainFrm_MouseUp);
            this.Resize += new System.EventHandler(this.MainFrm_Resize);
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainCropBox)).EndInit();
            this.cropContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolStrip;
        private ToolStripButton mainScanFile;
        private ToolStripButton mainOpenFile;
        private Panel mainPanel;
        private Splitter sep1;
        private PictureBox mainCropBox;
        private OpenFileDialog fileDialog;
        private ToolStripButton RegexEditor;
        private ToolStripButton mainCropBtn;
        private ContextMenuStrip cropContext;
        private ToolStripMenuItem cropSettingsToolStripMenuItem;
        private ToolStripMenuItem cropColourToolStripMenuItem;
        private ToolStripMenuItem cropWidthToolStripMenuItem;
        private Panel cropBoxPanel;
    }
}