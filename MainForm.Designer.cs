namespace QRTools
{
    partial class MainForm
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
            tabControl1 = new TabControl();
            tabPageQR_URL = new TabPage();
            label1 = new Label();
            txtURL = new TextBox();
            btnGenerateQR_URL = new Button();
            pictureBoxQR_URL = new PictureBox();
            qrOptionsControl_URL = new QROptionsControl();
            btnSaveQR_URL = new Button();
            tabPageQR_WIFI = new TabPage();
            lblWiFiSSID = new Label();
            lblWiFiPassword = new Label();
            lblWiFiSecurity = new Label();
            txtWiFiSSID = new TextBox();
            txtWiFiPassword = new TextBox();
            cmbWiFiSecurity = new ComboBox();
            btnGenerateQR_WIFI = new Button();
            pictureBoxQR_WIFI = new PictureBox();
            qrOptionsControl_WIFI = new QROptionsControl();
            btnSaveQR_WIFI = new Button();
            tabPageAbout = new TabPage();
            linkLabel1 = new LinkLabel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            saveFileDialogQR = new SaveFileDialog();
            tabControl1.SuspendLayout();
            tabPageQR_URL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR_URL).BeginInit();
            tabPageQR_WIFI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR_WIFI).BeginInit();
            tabPageAbout.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageQR_URL);
            tabControl1.Controls.Add(tabPageQR_WIFI);
            tabControl1.Controls.Add(tabPageAbout);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 499);
            tabControl1.TabIndex = 0;
            // 
            // tabPageQR_URL
            // 
            tabPageQR_URL.Controls.Add(label1);
            tabPageQR_URL.Controls.Add(txtURL);
            tabPageQR_URL.Controls.Add(btnGenerateQR_URL);
            tabPageQR_URL.Controls.Add(pictureBoxQR_URL);
            tabPageQR_URL.Controls.Add(qrOptionsControl_URL);
            tabPageQR_URL.Controls.Add(btnSaveQR_URL);
            tabPageQR_URL.Location = new Point(4, 24);
            tabPageQR_URL.Name = "tabPageQR_URL";
            tabPageQR_URL.Padding = new Padding(3);
            tabPageQR_URL.Size = new Size(792, 408);
            tabPageQR_URL.TabIndex = 0;
            tabPageQR_URL.Text = "QR_URL";
            tabPageQR_URL.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 0;
            label1.Text = "URL:";
            // 
            // txtURL
            // 
            txtURL.Location = new Point(47, 12);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(300, 23);
            txtURL.TabIndex = 1;
            // 
            // btnGenerateQR_URL
            // 
            btnGenerateQR_URL.Location = new Point(353, 11);
            btnGenerateQR_URL.Name = "btnGenerateQR_URL";
            btnGenerateQR_URL.Size = new Size(100, 25);
            btnGenerateQR_URL.TabIndex = 2;
            btnGenerateQR_URL.Text = "Tạo QR Code";
            btnGenerateQR_URL.UseVisualStyleBackColor = true;
            btnGenerateQR_URL.Click += btnGenerateQR_URL_Click;
            // 
            // pictureBoxQR_URL
            // 
            pictureBoxQR_URL.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxQR_URL.Location = new Point(515, 26);
            pictureBoxQR_URL.Name = "pictureBoxQR_URL";
            pictureBoxQR_URL.Size = new Size(200, 200);
            pictureBoxQR_URL.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxQR_URL.TabIndex = 3;
            pictureBoxQR_URL.TabStop = false;
            // 
            // qrOptionsControl_URL
            // 
            qrOptionsControl_URL.Location = new Point(12, 46);
            qrOptionsControl_URL.Name = "qrOptionsControl_URL";
            qrOptionsControl_URL.Size = new Size(468, 282);
            qrOptionsControl_URL.TabIndex = 11;
            // 
            // btnSaveQR_URL
            // 
            btnSaveQR_URL.Location = new Point(515, 232);
            btnSaveQR_URL.Name = "btnSaveQR_URL";
            btnSaveQR_URL.Size = new Size(100, 25);
            btnSaveQR_URL.TabIndex = 12;
            btnSaveQR_URL.Text = "Lưu QR Code";
            btnSaveQR_URL.UseVisualStyleBackColor = true;
            btnSaveQR_URL.Click += btnSaveQR_Click;
            // 
            // tabPageQR_WIFI
            // 
            tabPageQR_WIFI.Controls.Add(lblWiFiSSID);
            tabPageQR_WIFI.Controls.Add(lblWiFiPassword);
            tabPageQR_WIFI.Controls.Add(lblWiFiSecurity);
            tabPageQR_WIFI.Controls.Add(txtWiFiSSID);
            tabPageQR_WIFI.Controls.Add(txtWiFiPassword);
            tabPageQR_WIFI.Controls.Add(cmbWiFiSecurity);
            tabPageQR_WIFI.Controls.Add(btnGenerateQR_WIFI);
            tabPageQR_WIFI.Controls.Add(pictureBoxQR_WIFI);
            tabPageQR_WIFI.Controls.Add(qrOptionsControl_WIFI);
            tabPageQR_WIFI.Controls.Add(btnSaveQR_WIFI);
            tabPageQR_WIFI.Location = new Point(4, 24);
            tabPageQR_WIFI.Name = "tabPageQR_WIFI";
            tabPageQR_WIFI.Padding = new Padding(3);
            tabPageQR_WIFI.Size = new Size(792, 471);
            tabPageQR_WIFI.TabIndex = 1;
            tabPageQR_WIFI.Text = "QR_WIFI";
            tabPageQR_WIFI.UseVisualStyleBackColor = true;
            // 
            // lblWiFiSSID
            // 
            lblWiFiSSID.AutoSize = true;
            lblWiFiSSID.Location = new Point(12, 15);
            lblWiFiSSID.Name = "lblWiFiSSID";
            lblWiFiSSID.Size = new Size(33, 15);
            lblWiFiSSID.TabIndex = 4;
            lblWiFiSSID.Text = "SSID:";
            // 
            // lblWiFiPassword
            // 
            lblWiFiPassword.AutoSize = true;
            lblWiFiPassword.Location = new Point(12, 45);
            lblWiFiPassword.Name = "lblWiFiPassword";
            lblWiFiPassword.Size = new Size(60, 15);
            lblWiFiPassword.TabIndex = 5;
            lblWiFiPassword.Text = "Password:";
            // 
            // lblWiFiSecurity
            // 
            lblWiFiSecurity.AutoSize = true;
            lblWiFiSecurity.Location = new Point(12, 75);
            lblWiFiSecurity.Name = "lblWiFiSecurity";
            lblWiFiSecurity.Size = new Size(52, 15);
            lblWiFiSecurity.TabIndex = 6;
            lblWiFiSecurity.Text = "Security:";
            // 
            // txtWiFiSSID
            // 
            txtWiFiSSID.Location = new Point(80, 12);
            txtWiFiSSID.Name = "txtWiFiSSID";
            txtWiFiSSID.Size = new Size(200, 23);
            txtWiFiSSID.TabIndex = 7;
            // 
            // txtWiFiPassword
            // 
            txtWiFiPassword.Location = new Point(80, 42);
            txtWiFiPassword.Name = "txtWiFiPassword";
            txtWiFiPassword.Size = new Size(200, 23);
            txtWiFiPassword.TabIndex = 8;
            txtWiFiPassword.UseSystemPasswordChar = true;
            // 
            // cmbWiFiSecurity
            // 
            cmbWiFiSecurity.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWiFiSecurity.FormattingEnabled = true;
            cmbWiFiSecurity.Items.AddRange(new object[] { "WPA", "WEP", "nopass" });
            cmbWiFiSecurity.Location = new Point(80, 72);
            cmbWiFiSecurity.Name = "cmbWiFiSecurity";
            cmbWiFiSecurity.Size = new Size(121, 23);
            cmbWiFiSecurity.TabIndex = 9;
            // 
            // btnGenerateQR_WIFI
            // 
            btnGenerateQR_WIFI.Location = new Point(220, 70);
            btnGenerateQR_WIFI.Name = "btnGenerateQR_WIFI";
            btnGenerateQR_WIFI.Size = new Size(100, 25);
            btnGenerateQR_WIFI.TabIndex = 10;
            btnGenerateQR_WIFI.Text = "Tạo QR Code";
            btnGenerateQR_WIFI.UseVisualStyleBackColor = true;
            btnGenerateQR_WIFI.Click += btnGenerateQR_WIFI_Click;
            // 
            // pictureBoxQR_WIFI
            // 
            pictureBoxQR_WIFI.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxQR_WIFI.Location = new Point(531, 15);
            pictureBoxQR_WIFI.Name = "pictureBoxQR_WIFI";
            pictureBoxQR_WIFI.Size = new Size(200, 200);
            pictureBoxQR_WIFI.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxQR_WIFI.TabIndex = 13;
            pictureBoxQR_WIFI.TabStop = false;
            // 
            // qrOptionsControl_WIFI
            // 
            qrOptionsControl_WIFI.Location = new Point(12, 110);
            qrOptionsControl_WIFI.Name = "qrOptionsControl_WIFI";
            qrOptionsControl_WIFI.Size = new Size(447, 312);
            qrOptionsControl_WIFI.TabIndex = 14;
            // 
            // btnSaveQR_WIFI
            // 
            btnSaveQR_WIFI.Location = new Point(584, 235);
            btnSaveQR_WIFI.Name = "btnSaveQR_WIFI";
            btnSaveQR_WIFI.Size = new Size(100, 25);
            btnSaveQR_WIFI.TabIndex = 15;
            btnSaveQR_WIFI.Text = "Lưu QR Code";
            btnSaveQR_WIFI.UseVisualStyleBackColor = true;
            btnSaveQR_WIFI.Click += btnSaveQR_Click;
            // 
            // tabPageAbout
            // 
            tabPageAbout.Controls.Add(linkLabel1);
            tabPageAbout.Controls.Add(label4);
            tabPageAbout.Controls.Add(label3);
            tabPageAbout.Controls.Add(label2);
            tabPageAbout.Location = new Point(4, 24);
            tabPageAbout.Name = "tabPageAbout";
            tabPageAbout.Padding = new Padding(3);
            tabPageAbout.Size = new Size(192, 72);
            tabPageAbout.TabIndex = 2;
            tabPageAbout.Text = "About";
            tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(334, 101);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(125, 15);
            linkLabel1.TabIndex = 3;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Ngoctuct@gmail.com";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(289, 103);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 2;
            label4.Text = "Email: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(289, 79);
            label3.Name = "label3";
            label3.Size = new Size(141, 15);
            label3.TabIndex = 1;
            label3.Text = "Tác giả: Nguyễn Ngọc Tú";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(275, 3);
            label2.Name = "label2";
            label2.Size = new Size(225, 65);
            label2.TabIndex = 0;
            label2.Text = "QR Tools";
            // 
            // saveFileDialogQR
            // 
            saveFileDialogQR.Filter = "PNG Files|*.png|JPEG Files|*.jpg";
            saveFileDialogQR.Title = "Lưu QR Code";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 499);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "QR Tools";
            Load += MainForm_Load;
            tabControl1.ResumeLayout(false);
            tabPageQR_URL.ResumeLayout(false);
            tabPageQR_URL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR_URL).EndInit();
            tabPageQR_WIFI.ResumeLayout(false);
            tabPageQR_WIFI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR_WIFI).EndInit();
            tabPageAbout.ResumeLayout(false);
            tabPageAbout.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageQR_URL;
        private System.Windows.Forms.TabPage tabPageQR_WIFI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnGenerateQR_URL;
        private System.Windows.Forms.PictureBox pictureBoxQR_URL;
        private System.Windows.Forms.PictureBox pictureBoxQR_WIFI;
        private System.Windows.Forms.Label lblWiFiSSID;
        private System.Windows.Forms.Label lblWiFiPassword;
        private System.Windows.Forms.Label lblWiFiSecurity;
        private System.Windows.Forms.TextBox txtWiFiSSID;
        private System.Windows.Forms.TextBox txtWiFiPassword;
        private System.Windows.Forms.ComboBox cmbWiFiSecurity;
        private System.Windows.Forms.Button btnGenerateQR_WIFI;
        private QROptionsControl qrOptionsControl_URL;
        private QROptionsControl qrOptionsControl_WIFI;
        private System.Windows.Forms.Button btnSaveQR_URL;
        private System.Windows.Forms.Button btnSaveQR_WIFI;
        private System.Windows.Forms.SaveFileDialog saveFileDialogQR;
        private TabPage tabPageAbout;
        private Label label3;
        private Label label2;
        private LinkLabel linkLabel1;
        private Label label4;
    }
}