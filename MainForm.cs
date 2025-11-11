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

                // Create a surface to draw on
                var info = new SKImageInfo(qrSize, qrSize);
                using var surface = SKSurface.Create(info);
                using var canvas = surface.Canvas;

                // Clear with background color
                canvas.Clear(bgColor);

                // Generate QR code using SkiaSharp.QrCode QRCodeImageBuilder
                try
                {
                    byte[] qrBytes;
                    SKImage qrImage;

                    if (optionsControl.UseGradient && optionsControl.SelectedGradient != null)
                    {
                        // Generate QR code with gradient
                        qrBytes = new QRCodeImageBuilder(text)
                            .WithSize(qrSize, qrSize)
                            .WithColors(SKColors.Black, SKColors.Transparent)
                            .ToByteArray();

                        using var data = SKData.CreateCopy(qrBytes);
                        qrImage = SKImage.FromEncodedData(data);

                        if (qrImage == null)
                        {
                            MessageBox.Show("Failed to create QR image!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Apply gradient to QR code
                        ApplyGradientToQR(canvas, qrImage, optionsControl.SelectedGradient, qrSize);
                    }
                    else
                    {
                        // Generate normal QR code
                        qrBytes = new QRCodeImageBuilder(text)
                            .WithSize(qrSize, qrSize)
                            .WithColors(qrColor, SKColors.Transparent)
                            .ToByteArray();

                        using var data = SKData.CreateCopy(qrBytes);
                        qrImage = SKImage.FromEncodedData(data);

                        if (qrImage == null)
                        {
                            MessageBox.Show("Failed to create QR image!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Draw normal QR code
                        canvas.DrawImage(qrImage, 0, 0);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating QR: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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

        
        private void ApplyGradientToQR(SKCanvas canvas, SKImage qrImage, AppGradientOptions gradientOptions, int size)
        {
            // Convert QR image to bitmap to access pixels
            using var originalBitmap = SKBitmap.FromImage(qrImage);
            if (originalBitmap == null) return;

            // Create gradient shader
            var colors = gradientOptions.Colors;
            var positions = gradientOptions.Positions ?? GenerateDefaultPositions(colors.Length);

            // Use simple linear gradient for now (left to right)
            using var shader = SKShader.CreateLinearGradient(
                new SKPoint(0, 0),
                new SKPoint(size, 0),
                colors,
                positions,
                SKShaderTileMode.Clamp);

            using var gradientPaint = new SKPaint { Shader = shader };

            // Create final bitmap with gradient applied to QR parts only
            using var finalBitmap = new SKBitmap(size, size);
            using var finalCanvas = new SKCanvas(finalBitmap);

            // Clear with transparent background
            finalCanvas.Clear(SKColors.Transparent);

            // Draw QR image first
            finalCanvas.DrawImage(qrImage, 0, 0);

            // Apply gradient with proper blend mode to only affect black parts
            using var gradientMaskPaint = new SKPaint
            {
                Shader = shader,
                BlendMode = SKBlendMode.SrcIn // Only apply gradient where QR exists
            };

            finalCanvas.DrawRect(0, 0, size, size, gradientMaskPaint);

            // Draw the final result
            canvas.DrawBitmap(finalBitmap, 0, 0);
        }

        private float[] GenerateDefaultPositions(int colorCount)
        {
            var positions = new float[colorCount];
            for (int i = 0; i < colorCount; i++)
            {
                positions[i] = (float)i / (colorCount - 1);
            }
            return positions;
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
