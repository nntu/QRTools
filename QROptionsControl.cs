using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SkiaSharp;

namespace QRTools
{
    public partial class QROptionsControl : UserControl
    {
        private SKBitmap? logoImage;

        public QROptionsControl()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Set default colors
            btnQRColor.BackColor = Color.Black;
            btnBGColor.BackColor = Color.White;
        }

        // Public properties to access the control values
        public bool UseLogo => rbWithLogo.Checked;
        public SKBitmap? LogoImage => logoImage;
        public Color QRColor => btnQRColor.BackColor;
        public Color BackgroundColor => btnBGColor.BackColor;
        public OpenFileDialog LogoDialog => openFileDialogLogo;

        // Event handlers
        public event EventHandler? LogoChanged;
        public event EventHandler? QRColorChanged;
        public event EventHandler? BackgroundColorChanged;

        private void rbWithLogo_CheckedChanged(object? sender, EventArgs e)
        {
            if (rbWithLogo.Checked)
            {
                if (openFileDialogLogo.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using var fileStream = System.IO.File.OpenRead(openFileDialogLogo.FileName);
                        logoImage = SKBitmap.Decode(fileStream);
                        LogoChanged?.Invoke(this, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi load logo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        rbNoLogo.Checked = true;
                    }
                }
                else
                {
                    rbNoLogo.Checked = true;
                }
            }
        }

        private void btnQRColor_Click(object? sender, EventArgs e)
        {
            if (colorDialogQR.ShowDialog() == DialogResult.OK)
            {
                btnQRColor.BackColor = colorDialogQR.Color;
                QRColorChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnBGColor_Click(object? sender, EventArgs e)
        {
            if (colorDialogBG.ShowDialog() == DialogResult.OK)
            {
                btnBGColor.BackColor = colorDialogBG.Color;
                BackgroundColorChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}