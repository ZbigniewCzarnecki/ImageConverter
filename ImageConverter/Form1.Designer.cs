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
            label4 = new Label();
            numericWidth = new NumericUpDown();
            numericQuality = new NumericUpDown();
            comboBoxFormat = new ComboBox();
            flowLayoutPanelImages = new FlowLayoutPanel();
            progressBarConversion = new ProgressBar();
            btnClear = new Button();
            groupBox1 = new GroupBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericQuality).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(20, 401);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(113, 37);
            btnInsert.TabIndex = 0;
            btnInsert.Text = "Wstaw Obrazy";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnConvert
            // 
            btnConvert.Location = new Point(663, 401);
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
            label2.Location = new Point(21, 86);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 3;
            label2.Text = "Max Wymiar X/Y";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 140);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 5;
            label4.Text = "Jakość";
            // 
            // numericWidth
            // 
            numericWidth.Location = new Point(21, 104);
            numericWidth.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericWidth.Name = "numericWidth";
            numericWidth.Size = new Size(113, 23);
            numericWidth.TabIndex = 6;
            numericWidth.Value = new decimal(new int[] { 1920, 0, 0, 0 });
            // 
            // numericQuality
            // 
            numericQuality.Location = new Point(21, 158);
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
            flowLayoutPanelImages.Location = new Point(215, 49);
            flowLayoutPanelImages.Name = "flowLayoutPanelImages";
            flowLayoutPanelImages.Size = new Size(550, 289);
            flowLayoutPanelImages.TabIndex = 13;
            flowLayoutPanelImages.DragDrop += flowLayoutPanelImages_DragDrop;
            flowLayoutPanelImages.DragEnter += flowLayoutPanelImages_DragEnter;
            // 
            // progressBarConversion
            // 
            progressBarConversion.Location = new Point(215, 344);
            progressBarConversion.Name = "progressBarConversion";
            progressBarConversion.Size = new Size(550, 24);
            progressBarConversion.TabIndex = 14;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(139, 401);
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
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(numericWidth);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(numericQuality);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(20, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(158, 207);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ustawienia";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(215, 20);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 17;
            label3.Text = "Wybrane Obrazy";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(groupBox1);
            Controls.Add(btnClear);
            Controls.Add(progressBarConversion);
            Controls.Add(flowLayoutPanelImages);
            Controls.Add(btnConvert);
            Controls.Add(btnInsert);
            Name = "Form1";
            Text = "Image Converter";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericQuality).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
    }
}
