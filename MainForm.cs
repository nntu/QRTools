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
using SkiaSharp.QrCode;
using SkiaSharp.QrCode.Image;
using System.IO;

namespace QRTools
{
    public partial class MainForm : Form
    {
        private SKBitmap? currentQRCode;

        public MainForm()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Set default WiFi security type
            cmbWiFiSecurity.SelectedIndex = 0;
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            // Set PictureBox SizeMode to center images
            pictureBoxQR_URL.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxQR_WIFI.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void btnGenerateQR_URL_Click(object? sender, EventArgs e)
        {
            string url = txtURL.Text.Trim();
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Vui lòng nhập URL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                GenerateQRCode(url, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo QR Code: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerateQR_WIFI_Click(object? sender, EventArgs e)
        {
            string ssid = txtWiFiSSID.Text.Trim();
            string password = txtWiFiPassword.Text;
            string security = cmbWiFiSecurity.SelectedItem?.ToString() ?? "WPA";

            if (string.IsNullOrEmpty(ssid))
            {
                MessageBox.Show("Vui lòng nhập SSID!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string wifiString = $"WIFI:T:{security};S:{ssid};P:{password};;";
                GenerateQRCode(wifiString, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo QR Code: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateQRCode(string text, bool isWifiTab = false)
        {
            try
            {
                // Get the appropriate QROptionsControl and PictureBox
                var optionsControl = isWifiTab ? qrOptionsControl_WIFI : qrOptionsControl_URL;
                var pictureBox = isWifiTab ? pictureBoxQR_WIFI : pictureBoxQR_URL;

                // Get colors from QROptionsControl
                var qrColor = ConvertToSKColor(optionsControl.QRColor);
                var bgColor = ConvertToSKColor(optionsControl.BackgroundColor);

                // Calculate size to fit PictureBox with some padding
                int padding = 10;
                int qrSize = Math.Min(pictureBox.Width - padding * 2, pictureBox.Height - padding * 2);
                qrSize = Math.Max(qrSize, 100); // Minimum size

                // Generate QR code using SkiaSharp.QrCode QRCodeImageBuilder
                var qrBytes = new QRCodeImageBuilder(text)
                    .WithSize(qrSize, qrSize)
                    .WithColors(qrColor, bgColor)
                    .ToByteArray();

                // Convert bytes to SKImage
                using var data = SKData.CreateCopy(qrBytes);
                using var qrImage = SKImage.FromEncodedData(data);

                // Create a surface to draw on
                var info = new SKImageInfo(qrSize, qrSize);
                using var surface = SKSurface.Create(info);
                using var canvas = surface.Canvas;

                // Clear with background color
                canvas.Clear(bgColor);

                // Draw the QR code
                canvas.DrawImage(qrImage, 0, 0);

                // Add logo if selected
                if (optionsControl.UseLogo && optionsControl.LogoImage != null)
                {
                    // Calculate logo size based on QR code size (about 20% of QR size)
                    var logoSize = Math.Max(qrSize / 5, 30);
                    var logoRect = new SKRect(
                        (info.Width - logoSize) / 2,
                        (info.Height - logoSize) / 2,
                        (info.Width + logoSize) / 2,
                        (info.Height + logoSize) / 2);

                    // Draw white background for logo
                    using var whitePaint = new SKPaint { Color = SKColors.White };
                    canvas.DrawRoundRect(logoRect, 5, 5, whitePaint);

                    // Draw logo (resize if needed)
                    var scaledLogo = ResizeLogo(optionsControl.LogoImage, logoSize);
                    canvas.DrawBitmap(scaledLogo, logoRect, new SKPaint());
                }

                // Convert to display format
                currentQRCode = SKBitmap.FromImage(surface.Snapshot());
                var bitmap = ConvertToBitmap(currentQRCode);

                // Display in PictureBox (will be centered automatically)
                pictureBox.Image = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo QR Code: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private SKBitmap ResizeLogo(SKBitmap originalLogo, int targetSize)
        {
            // Calculate scale to maintain aspect ratio
            float scaleX = (float)targetSize / originalLogo.Width;
            float scaleY = (float)targetSize / originalLogo.Height;
            float scale = Math.Min(scaleX, scaleY);

            int newWidth = (int)(originalLogo.Width * scale);
            int newHeight = (int)(originalLogo.Height * scale);

            var resized = new SKBitmap(newWidth, newHeight);
            using (var canvas = new SKCanvas(resized))
            {
                canvas.Clear(SKColors.Transparent);
                var destRect = new SKRect(0, 0, newWidth, newHeight);
                canvas.DrawBitmap(originalLogo, destRect);
            }

            return resized;
        }

        private SKColor ConvertToSKColor(Color color)
        {
            return new SKColor(color.R, color.G, color.B, color.A);
        }

        private Bitmap ConvertToBitmap(SKBitmap skBitmap)
        {
            using var image = SKImage.FromBitmap(skBitmap);
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            using var stream = new MemoryStream(data.ToArray());
            return new Bitmap(stream);
        }

        
        private void btnSaveQR_Click(object? sender, EventArgs e)
        {
            if (currentQRCode == null)
            {
                MessageBox.Show("Vui lòng tạo QR Code trước khi lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (saveFileDialogQR.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using var image = SKImage.FromBitmap(currentQRCode);
                    var format = Path.GetExtension(saveFileDialogQR.FileName).ToLower() switch
                    {
                        ".jpg" or ".jpeg" => SKEncodedImageFormat.Jpeg,
                        _ => SKEncodedImageFormat.Png
                    };

                    using var data = image.Encode(format, 100);
                    using var fileStream = File.Create(saveFileDialogQR.FileName);
                    data.SaveTo(fileStream);

                    MessageBox.Show("QR Code đã được lưu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu QR Code: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
