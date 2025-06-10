namespace ImageConverter
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
            progressBarConversion = new ProgressBar();
            btnClear = new Button();
            groupBox1 = new GroupBox();
            chkCustomDimensions = new CheckBox();
            lblImageCount = new Label();
            panelCustomDimensions = new Panel();
            numericUpDown6 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)numericWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericQuality).BeginInit();
            groupBox1.SuspendLayout();
            panelCustomDimensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnInsert
            // 
            btnInsert.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnInsert.BackColor = Color.FromArgb(42, 42, 48);
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Poppins", 9F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(12, 299);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(113, 37);
            btnInsert.TabIndex = 0;
            btnInsert.Text = "Wstaw";
            btnInsert.UseVisualStyleBackColor = false;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnConvert
            // 
            btnConvert.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConvert.BackColor = Color.FromArgb(58, 101, 255);
            btnConvert.FlatAppearance.BorderSize = 0;
            btnConvert.FlatStyle = FlatStyle.Flat;
            btnConvert.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnConvert.ForeColor = Color.White;
            btnConvert.Location = new Point(566, 299);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(113, 37);
            btnConvert.TabIndex = 1;
            btnConvert.Text = "Konwertuj";
            btnConvert.UseVisualStyleBackColor = false;
            btnConvert.Click += btnConvert_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 28);
            label1.Name = "label1";
            label1.Size = new Size(56, 22);
            label1.TabIndex = 2;
            label1.Text = "Format";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 82);
            label2.Name = "label2";
            label2.Size = new Size(115, 22);
            label2.TabIndex = 3;
            label2.Text = "Max Wymiar X/Y";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 135);
            label4.Name = "label4";
            label4.Size = new Size(54, 22);
            label4.TabIndex = 5;
            label4.Text = "Jakość";
            // 
            // numericWidth
            // 
            numericWidth.BackColor = Color.FromArgb(42, 42, 48);
            numericWidth.ForeColor = Color.White;
            numericWidth.Location = new Point(18, 103);
            numericWidth.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericWidth.Name = "numericWidth";
            numericWidth.Size = new Size(113, 25);
            numericWidth.TabIndex = 6;
            numericWidth.Value = new decimal(new int[] { 1920, 0, 0, 0 });
            // 
            // numericQuality
            // 
            numericQuality.BackColor = Color.FromArgb(42, 42, 48);
            numericQuality.ForeColor = Color.White;
            numericQuality.Location = new Point(18, 156);
            numericQuality.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericQuality.Name = "numericQuality";
            numericQuality.Size = new Size(113, 25);
            numericQuality.TabIndex = 9;
            numericQuality.Value = new decimal(new int[] { 80, 0, 0, 0 });
            // 
            // comboBoxFormat
            // 
            comboBoxFormat.BackColor = Color.FromArgb(42, 42, 48);
            comboBoxFormat.FlatStyle = FlatStyle.Flat;
            comboBoxFormat.ForeColor = Color.White;
            comboBoxFormat.FormattingEnabled = true;
            comboBoxFormat.Location = new Point(18, 49);
            comboBoxFormat.Name = "comboBoxFormat";
            comboBoxFormat.Size = new Size(113, 30);
            comboBoxFormat.TabIndex = 10;
            // 
            // flowLayoutPanelImages
            // 
            flowLayoutPanelImages.AllowDrop = true;
            flowLayoutPanelImages.AutoScroll = true;
            flowLayoutPanelImages.BackColor = Color.FromArgb(42, 42, 48);
            flowLayoutPanelImages.Location = new Point(19, 29);
            flowLayoutPanelImages.Name = "flowLayoutPanelImages";
            flowLayoutPanelImages.Size = new Size(450, 200);
            flowLayoutPanelImages.TabIndex = 13;
            flowLayoutPanelImages.DragDrop += flowLayoutPanelImages_DragDrop;
            flowLayoutPanelImages.DragEnter += flowLayoutPanelImages_DragEnter;
            // 
            // progressBarConversion
            // 
            progressBarConversion.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            progressBarConversion.BackColor = Color.FromArgb(42, 42, 48);
            progressBarConversion.ForeColor = Color.White;
            progressBarConversion.Location = new Point(250, 299);
            progressBarConversion.Name = "progressBarConversion";
            progressBarConversion.Size = new Size(310, 37);
            progressBarConversion.Step = 1;
            progressBarConversion.Style = ProgressBarStyle.Continuous;
            progressBarConversion.TabIndex = 14;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClear.BackColor = Color.FromArgb(42, 42, 48);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Poppins", 9F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(131, 299);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(113, 37);
            btnClear.TabIndex = 15;
            btnClear.Text = "Wyczyść";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBoxFormat);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(numericWidth);
            groupBox1.Controls.Add(chkCustomDimensions);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(numericQuality);
            groupBox1.Controls.Add(label4);
            groupBox1.Font = new Font("Poppins", 9F, FontStyle.Bold);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(12, 12);
            groupBox1.Margin = new Padding(0);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(0);
            groupBox1.Size = new Size(150, 250);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ustawienia";
            // 
            // chkCustomDimensions
            // 
            chkCustomDimensions.AutoSize = true;
            chkCustomDimensions.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            chkCustomDimensions.ForeColor = Color.White;
            chkCustomDimensions.ImageAlign = ContentAlignment.MiddleLeft;
            chkCustomDimensions.Location = new Point(19, 189);
            chkCustomDimensions.Name = "chkCustomDimensions";
            chkCustomDimensions.Size = new Size(60, 26);
            chkCustomDimensions.TabIndex = 17;
            chkCustomDimensions.Text = "Sizes";
            chkCustomDimensions.TextAlign = ContentAlignment.BottomLeft;
            chkCustomDimensions.UseVisualStyleBackColor = true;
            chkCustomDimensions.CheckedChanged += chkCustomDimensions_CheckedChanged;
            // 
            // lblImageCount
            // 
            lblImageCount.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblImageCount.AutoSize = true;
            lblImageCount.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblImageCount.ForeColor = Color.White;
            lblImageCount.Location = new Point(581, 274);
            lblImageCount.Name = "lblImageCount";
            lblImageCount.Size = new Size(98, 22);
            lblImageCount.TabIndex = 18;
            lblImageCount.Text = "Liczba zdjęć: 0";
            lblImageCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelCustomDimensions
            // 
            panelCustomDimensions.Controls.Add(numericUpDown6);
            panelCustomDimensions.Controls.Add(numericUpDown3);
            panelCustomDimensions.Controls.Add(numericUpDown2);
            panelCustomDimensions.Controls.Add(numericUpDown1);
            panelCustomDimensions.Location = new Point(185, 237);
            panelCustomDimensions.Name = "panelCustomDimensions";
            panelCustomDimensions.Size = new Size(490, 25);
            panelCustomDimensions.TabIndex = 18;
            // 
            // numericUpDown6
            // 
            numericUpDown6.BackColor = Color.FromArgb(28, 28, 33);
            numericUpDown6.BorderStyle = BorderStyle.None;
            numericUpDown6.Font = new Font("Poppins Medium", 9F, FontStyle.Bold);
            numericUpDown6.ForeColor = Color.White;
            numericUpDown6.InterceptArrowKeys = false;
            numericUpDown6.Location = new Point(369, 0);
            numericUpDown6.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.RightToLeft = RightToLeft.Yes;
            numericUpDown6.Size = new Size(120, 21);
            numericUpDown6.TabIndex = 3;
            numericUpDown6.TextAlign = HorizontalAlignment.Right;
            numericUpDown6.UpDownAlign = LeftRightAlignment.Left;
            // 
            // numericUpDown3
            // 
            numericUpDown3.BackColor = Color.FromArgb(28, 28, 33);
            numericUpDown3.BorderStyle = BorderStyle.None;
            numericUpDown3.Font = new Font("Poppins Medium", 9F, FontStyle.Bold);
            numericUpDown3.ForeColor = Color.White;
            numericUpDown3.InterceptArrowKeys = false;
            numericUpDown3.Location = new Point(246, 0);
            numericUpDown3.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.RightToLeft = RightToLeft.Yes;
            numericUpDown3.Size = new Size(120, 21);
            numericUpDown3.TabIndex = 2;
            numericUpDown3.TextAlign = HorizontalAlignment.Right;
            numericUpDown3.UpDownAlign = LeftRightAlignment.Left;
            numericUpDown3.Value = new decimal(new int[] { 736, 0, 0, 0 });
            // 
            // numericUpDown2
            // 
            numericUpDown2.BackColor = Color.FromArgb(28, 28, 33);
            numericUpDown2.BorderStyle = BorderStyle.None;
            numericUpDown2.Font = new Font("Poppins Medium", 9F, FontStyle.Bold);
            numericUpDown2.ForeColor = Color.White;
            numericUpDown2.InterceptArrowKeys = false;
            numericUpDown2.Location = new Point(123, 0);
            numericUpDown2.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.RightToLeft = RightToLeft.Yes;
            numericUpDown2.Size = new Size(120, 21);
            numericUpDown2.TabIndex = 1;
            numericUpDown2.TextAlign = HorizontalAlignment.Right;
            numericUpDown2.UpDownAlign = LeftRightAlignment.Left;
            numericUpDown2.Value = new decimal(new int[] { 1024, 0, 0, 0 });
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = Color.FromArgb(28, 28, 33);
            numericUpDown1.BorderStyle = BorderStyle.None;
            numericUpDown1.Font = new Font("Poppins Medium", 9F, FontStyle.Bold);
            numericUpDown1.ForeColor = Color.White;
            numericUpDown1.InterceptArrowKeys = false;
            numericUpDown1.Location = new Point(0, 0);
            numericUpDown1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.RightToLeft = RightToLeft.Yes;
            numericUpDown1.Size = new Size(120, 21);
            numericUpDown1.TabIndex = 0;
            numericUpDown1.TextAlign = HorizontalAlignment.Right;
            numericUpDown1.UpDownAlign = LeftRightAlignment.Left;
            numericUpDown1.Value = new decimal(new int[] { 1536, 0, 0, 0 });
            // 
            // groupBox2
            // 
            groupBox2.AutoSize = true;
            groupBox2.Controls.Add(flowLayoutPanelImages);
            groupBox2.Font = new Font("Poppins", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(185, 12);
            groupBox2.Margin = new Padding(0);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(0);
            groupBox2.Size = new Size(490, 250);
            groupBox2.TabIndex = 20;
            groupBox2.TabStop = false;
            groupBox2.Text = "Wybrane Obrazy";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 17);
            ClientSize = new Size(691, 348);
            Controls.Add(groupBox2);
            Controls.Add(lblImageCount);
            Controls.Add(panelCustomDimensions);
            Controls.Add(groupBox1);
            Controls.Add(btnClear);
            Controls.Add(progressBarConversion);
            Controls.Add(btnConvert);
            Controls.Add(btnInsert);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(707, 387);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WPForge - Image Converter";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericQuality).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panelCustomDimensions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox2.ResumeLayout(false);
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
        private Label lblImageCount;
        private CheckBox chkCustomDimensions;
        private Panel panelCustomDimensions;
        private NumericUpDown numericUpDown6;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private GroupBox groupBox2;
    }
}
