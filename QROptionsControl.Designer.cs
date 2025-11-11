namespace QRTools
{
    partial class QROptionsControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBoxOptions = new GroupBox();
            rbNoLogo = new RadioButton();
            rbWithLogo = new RadioButton();
            chkUseGradient = new CheckBox();
            lblGradientType = new Label();
            cmbGradientPreset = new ComboBox();
            btnCustomGradient = new Button();
            lblQRColor = new Label();
            lblBGColor = new Label();
            lblGradientEnd = new Label();
            btnQRColor = new Button();
            btnBGColor = new Button();
            btnGradientEnd = new Button();
            openFileDialogLogo = new OpenFileDialog();
            colorDialogQR = new ColorDialog();
            colorDialogBG = new ColorDialog();
            colorDialogGradient = new ColorDialog();
            groupBoxOptions.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxOptions
            // 
            groupBoxOptions.Controls.Add(rbNoLogo);
            groupBoxOptions.Controls.Add(rbWithLogo);
            groupBoxOptions.Controls.Add(chkUseGradient);
            groupBoxOptions.Controls.Add(lblGradientType);
            groupBoxOptions.Controls.Add(cmbGradientPreset);
            groupBoxOptions.Controls.Add(btnCustomGradient);
            groupBoxOptions.Controls.Add(lblQRColor);
            groupBoxOptions.Controls.Add(lblBGColor);
            groupBoxOptions.Controls.Add(lblGradientEnd);
            groupBoxOptions.Controls.Add(btnQRColor);
            groupBoxOptions.Controls.Add(btnBGColor);
            groupBoxOptions.Controls.Add(btnGradientEnd);
            groupBoxOptions.Dock = DockStyle.Fill;
            groupBoxOptions.Location = new Point(0, 0);
            groupBoxOptions.Name = "groupBoxOptions";
            groupBoxOptions.Size = new Size(414, 229);
            groupBoxOptions.TabIndex = 0;
            groupBoxOptions.TabStop = false;
            groupBoxOptions.Text = "Tùy chọn";
            // 
            // rbNoLogo
            // 
            rbNoLogo.AutoSize = true;
            rbNoLogo.Checked = true;
            rbNoLogo.Location = new Point(10, 20);
            rbNoLogo.Name = "rbNoLogo";
            rbNoLogo.Size = new Size(87, 19);
            rbNoLogo.TabIndex = 0;
            rbNoLogo.TabStop = true;
            rbNoLogo.Text = "Không logo";
            rbNoLogo.UseVisualStyleBackColor = true;
            // 
            // rbWithLogo
            // 
            rbWithLogo.AutoSize = true;
            rbWithLogo.Location = new Point(10, 45);
            rbWithLogo.Name = "rbWithLogo";
            rbWithLogo.Size = new Size(80, 19);
            rbWithLogo.TabIndex = 1;
            rbWithLogo.Text = "Chèn logo";
            rbWithLogo.UseVisualStyleBackColor = true;
            rbWithLogo.CheckedChanged += rbWithLogo_CheckedChanged;
            // 
            // chkUseGradient
            // 
            chkUseGradient.AutoSize = true;
            chkUseGradient.Location = new Point(10, 70);
            chkUseGradient.Name = "chkUseGradient";
            chkUseGradient.Size = new Size(118, 19);
            chkUseGradient.TabIndex = 2;
            chkUseGradient.Text = "Sử dụng Gradient";
            chkUseGradient.UseVisualStyleBackColor = true;
            chkUseGradient.CheckedChanged += chkUseGradient_CheckedChanged;
            // 
            // lblGradientType
            // 
            lblGradientType.AutoSize = true;
            lblGradientType.Location = new Point(10, 95);
            lblGradientType.Name = "lblGradientType";
            lblGradientType.Size = new Size(79, 15);
            lblGradientType.TabIndex = 3;
            lblGradientType.Text = "Loại gradient:";
            lblGradientType.Visible = false;
            // 
            // cmbGradientPreset
            // 
            cmbGradientPreset.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGradientPreset.FormattingEnabled = true;
            cmbGradientPreset.Items.AddRange(new object[] { "Instagram", "Sunset", "Ocean", "Rainbow", "Forest", "Galaxy", "Fire", "Tùy chỉnh 2 màu", "Tùy chỉnh 3 màu" });
            cmbGradientPreset.Location = new Point(100, 92);
            cmbGradientPreset.Name = "cmbGradientPreset";
            cmbGradientPreset.Size = new Size(120, 23);
            cmbGradientPreset.TabIndex = 4;
            cmbGradientPreset.Visible = false;
            cmbGradientPreset.SelectedIndexChanged += cmbGradientPreset_SelectedIndexChanged;
            // 
            // btnCustomGradient
            // 
            btnCustomGradient.Location = new Point(225, 92);
            btnCustomGradient.Name = "btnCustomGradient";
            btnCustomGradient.Size = new Size(70, 23);
            btnCustomGradient.TabIndex = 5;
            btnCustomGradient.Text = "Tùy chỉnh";
            btnCustomGradient.UseVisualStyleBackColor = true;
            btnCustomGradient.Visible = false;
            btnCustomGradient.Click += btnCustomGradient_Click;
            // 
            // lblQRColor
            // 
            lblQRColor.AutoSize = true;
            lblQRColor.Location = new Point(10, 120);
            lblQRColor.Name = "lblQRColor";
            lblQRColor.Size = new Size(53, 15);
            lblQRColor.TabIndex = 6;
            lblQRColor.Text = "Màu QR:";
            // 
            // lblBGColor
            // 
            lblBGColor.AutoSize = true;
            lblBGColor.Location = new Point(10, 145);
            lblBGColor.Name = "lblBGColor";
            lblBGColor.Size = new Size(57, 15);
            lblBGColor.TabIndex = 7;
            lblBGColor.Text = "Màu nền:";
            // 
            // lblGradientEnd
            // 
            lblGradientEnd.AutoSize = true;
            lblGradientEnd.Location = new Point(10, 170);
            lblGradientEnd.Name = "lblGradientEnd";
            lblGradientEnd.Size = new Size(81, 15);
            lblGradientEnd.TabIndex = 8;
            lblGradientEnd.Text = "Màu gradient:";
            lblGradientEnd.Visible = false;
            // 
            // btnQRColor
            // 
            btnQRColor.BackColor = Color.Black;
            btnQRColor.Location = new Point(75, 115);
            btnQRColor.Name = "btnQRColor";
            btnQRColor.Size = new Size(60, 23);
            btnQRColor.TabIndex = 9;
            btnQRColor.Text = "Chọn";
            btnQRColor.UseVisualStyleBackColor = false;
            btnQRColor.Click += btnQRColor_Click;
            // 
            // btnBGColor
            // 
            btnBGColor.BackColor = Color.White;
            btnBGColor.Location = new Point(75, 140);
            btnBGColor.Name = "btnBGColor";
            btnBGColor.Size = new Size(60, 23);
            btnBGColor.TabIndex = 10;
            btnBGColor.Text = "Chọn";
            btnBGColor.UseVisualStyleBackColor = false;
            btnBGColor.Click += btnBGColor_Click;
            // 
            // btnGradientEnd
            // 
            btnGradientEnd.BackColor = Color.Blue;
            btnGradientEnd.Location = new Point(95, 165);
            btnGradientEnd.Name = "btnGradientEnd";
            btnGradientEnd.Size = new Size(60, 23);
            btnGradientEnd.TabIndex = 11;
            btnGradientEnd.Text = "Chọn";
            btnGradientEnd.UseVisualStyleBackColor = false;
            btnGradientEnd.Visible = false;
            btnGradientEnd.Click += btnGradientEnd_Click;
            // 
            // openFileDialogLogo
            // 
            openFileDialogLogo.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialogLogo.Title = "Chọn file logo";
            // 
            // QROptionsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxOptions);
            Name = "QROptionsControl";
            Size = new Size(414, 229);
            groupBoxOptions.ResumeLayout(false);
            groupBoxOptions.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.RadioButton rbNoLogo;
        private System.Windows.Forms.RadioButton rbWithLogo;
        private System.Windows.Forms.CheckBox chkUseGradient;
        private System.Windows.Forms.Label lblGradientType;
        private System.Windows.Forms.ComboBox cmbGradientPreset;
        private System.Windows.Forms.Button btnCustomGradient;
        private System.Windows.Forms.Label lblQRColor;
        private System.Windows.Forms.Label lblBGColor;
        private System.Windows.Forms.Label lblGradientEnd;
        private System.Windows.Forms.Button btnQRColor;
        private System.Windows.Forms.Button btnBGColor;
        private System.Windows.Forms.Button btnGradientEnd;
        private System.Windows.Forms.OpenFileDialog openFileDialogLogo;
        private System.Windows.Forms.ColorDialog colorDialogQR;
        private System.Windows.Forms.ColorDialog colorDialogBG;
        private System.Windows.Forms.ColorDialog colorDialogGradient;
    }
}