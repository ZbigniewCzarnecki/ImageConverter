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
            btnInsert = new Button();
            btnConvert = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            numericWidth = new NumericUpDown();
            numericHeight = new NumericUpDown();
            numericQuality = new NumericUpDown();
            comboBoxFormat = new ComboBox();
            chkMaintainAspectRatio = new CheckBox();
            pictureBoxPreview = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)numericWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericQuality).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).BeginInit();
            SuspendLayout();
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(266, 401);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(113, 37);
            btnInsert.TabIndex = 0;
            btnInsert.Text = "Wstaw obraz";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnConvert
            // 
            btnConvert.Location = new Point(385, 401);
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
            label1.Location = new Point(143, 301);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 2;
            label1.Text = "Format";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(294, 301);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 3;
            label2.Text = "Szerokość";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(434, 301);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 4;
            label3.Text = "Wysokość";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(600, 301);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 5;
            label4.Text = "Jakość";
            // 
            // numericWidth
            // 
            numericWidth.Location = new Point(266, 319);
            numericWidth.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericWidth.Name = "numericWidth";
            numericWidth.Size = new Size(113, 23);
            numericWidth.TabIndex = 6;
            numericWidth.Value = new decimal(new int[] { 1920, 0, 0, 0 });
            numericWidth.ValueChanged += numericWidth_ValueChanged;
            // 
            // numericHeight
            // 
            numericHeight.Location = new Point(385, 319);
            numericHeight.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericHeight.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericHeight.Name = "numericHeight";
            numericHeight.Size = new Size(113, 23);
            numericHeight.TabIndex = 7;
            numericHeight.Value = new decimal(new int[] { 1080, 0, 0, 0 });
            numericHeight.ValueChanged += numericHeight_ValueChanged;
            // 
            // numericQuality
            // 
            numericQuality.Location = new Point(544, 319);
            numericQuality.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericQuality.Name = "numericQuality";
            numericQuality.Size = new Size(113, 23);
            numericQuality.TabIndex = 9;
            numericQuality.Value = new decimal(new int[] { 80, 0, 0, 0 });
            // 
            // comboBoxFormat
            // 
            comboBoxFormat.FormattingEnabled = true;
            comboBoxFormat.Location = new Point(109, 319);
            comboBoxFormat.Name = "comboBoxFormat";
            comboBoxFormat.Size = new Size(113, 23);
            comboBoxFormat.TabIndex = 10;
            comboBoxFormat.SelectedIndexChanged += comboBoxFormat_SelectedIndexChanged;
            // 
            // chkMaintainAspectRatio
            // 
            chkMaintainAspectRatio.AutoSize = true;
            chkMaintainAspectRatio.Checked = true;
            chkMaintainAspectRatio.CheckState = CheckState.Checked;
            chkMaintainAspectRatio.Location = new Point(315, 348);
            chkMaintainAspectRatio.Name = "chkMaintainAspectRatio";
            chkMaintainAspectRatio.Size = new Size(131, 19);
            chkMaintainAspectRatio.TabIndex = 11;
            chkMaintainAspectRatio.Text = "Zachowaj proporcje";
            chkMaintainAspectRatio.TextAlign = ContentAlignment.BottomCenter;
            chkMaintainAspectRatio.UseVisualStyleBackColor = true;
            // 
            // pictureBoxPreview
            // 
            pictureBoxPreview.Location = new Point(37, 37);
            pictureBoxPreview.Name = "pictureBoxPreview";
            pictureBoxPreview.Size = new Size(720, 222);
            pictureBoxPreview.TabIndex = 12;
            pictureBoxPreview.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBoxPreview);
            Controls.Add(chkMaintainAspectRatio);
            Controls.Add(comboBoxFormat);
            Controls.Add(numericQuality);
            Controls.Add(numericHeight);
            Controls.Add(numericWidth);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnConvert);
            Controls.Add(btnInsert);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericQuality).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnInsert;
        private Button btnConvert;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown numericWidth;
        private NumericUpDown numericHeight;
        private NumericUpDown numericQuality;
        private ComboBox comboBoxFormat;
        private CheckBox chkMaintainAspectRatio;
        private PictureBox pictureBoxPreview;
    }
}
