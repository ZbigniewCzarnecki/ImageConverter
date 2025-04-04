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
            ((System.ComponentModel.ISupportInitialize)numericWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericQuality).BeginInit();
            SuspendLayout();
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(23, 346);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(113, 37);
            btnInsert.TabIndex = 0;
            btnInsert.Text = "Wstaw obraz";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnConvert
            // 
            btnConvert.Location = new Point(23, 389);
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
            label1.Location = new Point(23, 20);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 2;
            label1.Text = "Format";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 77);
            label2.Name = "label2";
            label2.Size = new Size(140, 15);
            label2.TabIndex = 3;
            label2.Text = "Maksymalny Wymiar X/Y";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 134);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 5;
            label4.Text = "Jakość";
            // 
            // numericWidth
            // 
            numericWidth.Location = new Point(23, 95);
            numericWidth.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericWidth.Name = "numericWidth";
            numericWidth.Size = new Size(113, 23);
            numericWidth.TabIndex = 6;
            numericWidth.Value = new decimal(new int[] { 1920, 0, 0, 0 });
            // 
            // numericQuality
            // 
            numericQuality.Location = new Point(23, 152);
            numericQuality.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericQuality.Name = "numericQuality";
            numericQuality.Size = new Size(113, 23);
            numericQuality.TabIndex = 9;
            numericQuality.Value = new decimal(new int[] { 80, 0, 0, 0 });
            // 
            // comboBoxFormat
            // 
            comboBoxFormat.FormattingEnabled = true;
            comboBoxFormat.Location = new Point(23, 38);
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
            flowLayoutPanelImages.Location = new Point(226, 20);
            flowLayoutPanelImages.Name = "flowLayoutPanelImages";
            flowLayoutPanelImages.Size = new Size(550, 406);
            flowLayoutPanelImages.TabIndex = 13;
            flowLayoutPanelImages.DragDrop += flowLayoutPanelImages_DragDrop;
            flowLayoutPanelImages.DragEnter += flowLayoutPanelImages_DragEnter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayoutPanelImages);
            Controls.Add(comboBoxFormat);
            Controls.Add(numericQuality);
            Controls.Add(numericWidth);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnConvert);
            Controls.Add(btnInsert);
            Name = "Form1";
            Text = "Image Converter";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericQuality).EndInit();
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
    }
}
