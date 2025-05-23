﻿namespace ImageConverter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnInsert = new Button();
            btnConvert = new Button();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            numericWidth = new NumericUpDown();
            numericQuality = new NumericUpDown();
            comboBoxFormat = new ComboBox();
            flowLayoutPanelImages = new FlowLayoutPanel();
            label3 = new Label();
            progressBarConversion = new ProgressBar();
            btnClear = new Button();
            groupBox1 = new GroupBox();
            lblImageCount = new Label();
            chkCustomDimensions = new CheckBox();
            panelCustomDimensions = new Panel();
            numericUpDown4 = new NumericUpDown();
            numericUpDown5 = new NumericUpDown();
            numericUpDown6 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericQuality).BeginInit();
            flowLayoutPanelImages.SuspendLayout();
            groupBox1.SuspendLayout();
            panelCustomDimensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // btnInsert
            // 
            btnInsert.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnInsert.Location = new Point(12, 384);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(113, 37);
            btnInsert.TabIndex = 0;
            btnInsert.Text = "Wstaw Obrazy";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnConvert
            // 
            btnConvert.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConvert.Location = new Point(689, 384);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(113, 37);
            btnConvert.TabIndex = 1;
            btnConvert.Text = "Konwertuj";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += btnConvert_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 29);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 2;
            label1.Text = "Format";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 83);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 3;
            label2.Text = "Max Wymiar X/Y";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 136);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 5;
            label4.Text = "Jakość";
            // 
            // numericWidth
            // 
            numericWidth.Location = new Point(21, 101);
            numericWidth.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericWidth.Name = "numericWidth";
            numericWidth.Size = new Size(113, 23);
            numericWidth.TabIndex = 6;
            numericWidth.Value = new decimal(new int[] { 1920, 0, 0, 0 });
            // 
            // numericQuality
            // 
            numericQuality.Location = new Point(21, 154);
            numericQuality.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericQuality.Name = "numericQuality";
            numericQuality.Size = new Size(113, 23);
            numericQuality.TabIndex = 9;
            numericQuality.Value = new decimal(new int[] { 80, 0, 0, 0 });
            // 
            // comboBoxFormat
            // 
            comboBoxFormat.FormattingEnabled = true;
            comboBoxFormat.Location = new Point(21, 47);
            comboBoxFormat.Name = "comboBoxFormat";
            comboBoxFormat.Size = new Size(113, 23);
            comboBoxFormat.TabIndex = 10;
            // 
            // flowLayoutPanelImages
            // 
            flowLayoutPanelImages.AllowDrop = true;
            flowLayoutPanelImages.AutoScroll = true;
            flowLayoutPanelImages.BackColor = SystemColors.Window;
            flowLayoutPanelImages.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanelImages.Controls.Add(label3);
            flowLayoutPanelImages.Location = new Point(189, 13);
            flowLayoutPanelImages.Name = "flowLayoutPanelImages";
            flowLayoutPanelImages.Size = new Size(446, 233);
            flowLayoutPanelImages.TabIndex = 13;
            flowLayoutPanelImages.DragDrop += flowLayoutPanelImages_DragDrop;
            flowLayoutPanelImages.DragEnter += flowLayoutPanelImages_DragEnter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(97, 15);
            label3.TabIndex = 17;
            label3.Text = "Wybrane Obrazy:";
            // 
            // progressBarConversion
            // 
            progressBarConversion.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            progressBarConversion.Location = new Point(455, 384);
            progressBarConversion.Name = "progressBarConversion";
            progressBarConversion.Size = new Size(228, 37);
            progressBarConversion.TabIndex = 14;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClear.Location = new Point(131, 384);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(113, 37);
            btnClear.TabIndex = 15;
            btnClear.Text = "Wyczyść Obrazy";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBoxFormat);
            groupBox1.Controls.Add(lblImageCount);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(numericWidth);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(numericQuality);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(12, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(156, 233);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ustawienia";
            // 
            // lblImageCount
            // 
            lblImageCount.Anchor = AnchorStyles.Bottom;
            lblImageCount.AutoSize = true;
            lblImageCount.Location = new Point(21, 199);
            lblImageCount.Name = "lblImageCount";
            lblImageCount.Size = new Size(82, 15);
            lblImageCount.TabIndex = 18;
            lblImageCount.Text = "Liczba zdjęć: 0";
            lblImageCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // chkCustomDimensions
            // 
            chkCustomDimensions.AutoSize = true;
            chkCustomDimensions.Location = new Point(12, 261);
            chkCustomDimensions.Name = "chkCustomDimensions";
            chkCustomDimensions.Size = new Size(136, 19);
            chkCustomDimensions.TabIndex = 17;
            chkCustomDimensions.Text = "Dodatkowe Wymiary";
            chkCustomDimensions.UseVisualStyleBackColor = true;
            chkCustomDimensions.CheckedChanged += chkCustomDimensions_CheckedChanged;
            // 
            // panelCustomDimensions
            // 
            panelCustomDimensions.Controls.Add(numericUpDown4);
            panelCustomDimensions.Controls.Add(numericUpDown5);
            panelCustomDimensions.Controls.Add(numericUpDown6);
            panelCustomDimensions.Controls.Add(numericUpDown3);
            panelCustomDimensions.Controls.Add(numericUpDown2);
            panelCustomDimensions.Controls.Add(numericUpDown1);
            panelCustomDimensions.Location = new Point(12, 286);
            panelCustomDimensions.Name = "panelCustomDimensions";
            panelCustomDimensions.Size = new Size(265, 81);
            panelCustomDimensions.TabIndex = 18;
            panelCustomDimensions.Visible = false;
            // 
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(143, 58);
            numericUpDown4.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(120, 23);
            numericUpDown4.TabIndex = 5;
            // 
            // numericUpDown5
            // 
            numericUpDown5.Location = new Point(143, 29);
            numericUpDown5.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(120, 23);
            numericUpDown5.TabIndex = 4;
            // 
            // numericUpDown6
            // 
            numericUpDown6.Location = new Point(143, 0);
            numericUpDown6.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(120, 23);
            numericUpDown6.TabIndex = 3;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(0, 58);
            numericUpDown3.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(120, 23);
            numericUpDown3.TabIndex = 2;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(0, 29);
            numericUpDown2.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(120, 23);
            numericUpDown2.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(0, 0);
            numericUpDown1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 433);
            Controls.Add(panelCustomDimensions);
            Controls.Add(chkCustomDimensions);
            Controls.Add(groupBox1);
            Controls.Add(btnClear);
            Controls.Add(progressBarConversion);
            Controls.Add(flowLayoutPanelImages);
            Controls.Add(btnConvert);
            Controls.Add(btnInsert);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(672, 354);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WPForge - Image Converter";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericQuality).EndInit();
            flowLayoutPanelImages.ResumeLayout(false);
            flowLayoutPanelImages.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panelCustomDimensions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Button btnInsert;
        private Button btnConvert;
        private Label label1;
        private Label label2;
        private Label label4;
        private NumericUpDown numericWidth;
        private NumericUpDown numericQuality;
        private ComboBox comboBoxFormat;
        private CheckBox chkMaintainAspectRatio;
        private FlowLayoutPanel flowLayoutPanelImages;
        private ProgressBar progressBarConversion;
        private Button btnClear;
        private GroupBox groupBox1;
        private Label label3;
        private Label lblImageCount;
        private CheckBox chkCustomDimensions;
        private Panel panelCustomDimensions;
        private NumericUpDown numericUpDown4;
        private NumericUpDown numericUpDown5;
        private NumericUpDown numericUpDown6;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
    }
}
