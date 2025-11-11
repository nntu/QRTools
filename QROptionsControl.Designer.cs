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
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.rbNoLogo = new System.Windows.Forms.RadioButton();
            this.rbWithLogo = new System.Windows.Forms.RadioButton();
            this.lblQRColor = new System.Windows.Forms.Label();
            this.lblBGColor = new System.Windows.Forms.Label();
            this.btnQRColor = new System.Windows.Forms.Button();
            this.btnBGColor = new System.Windows.Forms.Button();
            this.openFileDialogLogo = new System.Windows.Forms.OpenFileDialog();
            this.colorDialogQR = new System.Windows.Forms.ColorDialog();
            this.colorDialogBG = new System.Windows.Forms.ColorDialog();
            this.groupBoxOptions.SuspendLayout();
            this.SuspendLayout();
            //
            // groupBoxOptions
            //
            this.groupBoxOptions.Controls.Add(this.rbNoLogo);
            this.groupBoxOptions.Controls.Add(this.rbWithLogo);
            this.groupBoxOptions.Controls.Add(this.chkUseGradient);
            this.groupBoxOptions.Controls.Add(this.lblQRColor);
            this.groupBoxOptions.Controls.Add(this.lblBGColor);
            this.groupBoxOptions.Controls.Add(this.lblGradientEnd);
            this.groupBoxOptions.Controls.Add(this.btnQRColor);
            this.groupBoxOptions.Controls.Add(this.btnBGColor);
            this.groupBoxOptions.Controls.Add(this.btnGradientEnd);
            this.groupBoxOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOptions.Location = new System.Drawing.Point(0, 0);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(250, 180);
            this.groupBoxOptions.TabIndex = 0;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Tùy chọn";
            //
            // rbNoLogo
            //
            this.rbNoLogo.AutoSize = true;
            this.rbNoLogo.Checked = true;
            this.rbNoLogo.Location = new System.Drawing.Point(10, 20);
            this.rbNoLogo.Name = "rbNoLogo";
            this.rbNoLogo.Size = new System.Drawing.Size(87, 19);
            this.rbNoLogo.TabIndex = 0;
            this.rbNoLogo.TabStop = true;
            this.rbNoLogo.Text = "Không logo";
            this.rbNoLogo.UseVisualStyleBackColor = true;
            //
            // rbWithLogo
            //
            this.rbWithLogo.AutoSize = true;
            this.rbWithLogo.Location = new System.Drawing.Point(10, 45);
            this.rbWithLogo.Name = "rbWithLogo";
            this.rbWithLogo.Size = new System.Drawing.Size(80, 19);
            this.rbWithLogo.TabIndex = 1;
            this.rbWithLogo.Text = "Chèn logo";
            this.rbWithLogo.UseVisualStyleBackColor = true;
            this.rbWithLogo.CheckedChanged += new System.EventHandler(this.rbWithLogo_CheckedChanged);
            //
            // chkUseGradient
            //
            this.chkUseGradient.AutoSize = true;
            this.chkUseGradient.Location = new System.Drawing.Point(10, 70);
            this.chkUseGradient.Name = "chkUseGradient";
            this.chkUseGradient.Size = new System.Drawing.Size(95, 19);
            this.chkUseGradient.TabIndex = 2;
            this.chkUseGradient.Text = "Sử dụng Gradient";
            this.chkUseGradient.UseVisualStyleBackColor = true;
            this.chkUseGradient.CheckedChanged += new System.EventHandler(this.chkUseGradient_CheckedChanged);
            //
            // lblQRColor
            //
            this.lblQRColor.AutoSize = true;
            this.lblQRColor.Location = new System.Drawing.Point(10, 75);
            this.lblQRColor.Name = "lblQRColor";
            this.lblQRColor.Size = new System.Drawing.Size(53, 15);
            this.lblQRColor.TabIndex = 2;
            this.lblQRColor.Text = "Màu QR:";
            //
            // lblBGColor
            //
            this.lblBGColor.AutoSize = true;
            this.lblBGColor.Location = new System.Drawing.Point(10, 100);
            this.lblBGColor.Name = "lblBGColor";
            this.lblBGColor.Size = new System.Drawing.Size(57, 15);
            this.lblBGColor.TabIndex = 3;
            this.lblBGColor.Text = "Màu nền:";
            //
            // btnQRColor
            //
            this.btnQRColor.BackColor = System.Drawing.Color.Black;
            this.btnQRColor.Location = new System.Drawing.Point(75, 70);
            this.btnQRColor.Name = "btnQRColor";
            this.btnQRColor.Size = new System.Drawing.Size(60, 23);
            this.btnQRColor.TabIndex = 4;
            this.btnQRColor.Text = "Chọn";
            this.btnQRColor.UseVisualStyleBackColor = false;
            this.btnQRColor.Click += new System.EventHandler(this.btnQRColor_Click);
            //
            // btnBGColor
            //
            this.btnBGColor.BackColor = System.Drawing.Color.White;
            this.btnBGColor.Location = new System.Drawing.Point(75, 95);
            this.btnBGColor.Name = "btnBGColor";
            this.btnBGColor.Size = new System.Drawing.Size(60, 23);
            this.btnBGColor.TabIndex = 5;
            this.btnBGColor.Text = "Chọn";
            this.btnBGColor.UseVisualStyleBackColor = false;
            this.btnBGColor.Click += new System.EventHandler(this.btnBGColor_Click);
            //
            // openFileDialogLogo
            //
            this.openFileDialogLogo.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            this.openFileDialogLogo.Title = "Chọn file logo";
            //
            // QROptionsControl
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxOptions);
            this.Name = "QROptionsControl";
            this.Size = new System.Drawing.Size(250, 140);
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.RadioButton rbNoLogo;
        private System.Windows.Forms.RadioButton rbWithLogo;
        private System.Windows.Forms.Label lblQRColor;
        private System.Windows.Forms.Label lblBGColor;
        private System.Windows.Forms.Button btnQRColor;
        private System.Windows.Forms.Button btnBGColor;
        private System.Windows.Forms.OpenFileDialog openFileDialogLogo;
        private System.Windows.Forms.ColorDialog colorDialogQR;
        private System.Windows.Forms.ColorDialog colorDialogBG;
    }
}