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

                // Calculate base size to fit PictureBox with some padding
                int padding = 10;
                int baseQRSize = Math.Min(pictureBox.Width - padding * 2, pictureBox.Height - padding * 2);
                baseQRSize = Math.Max(baseQRSize, 100); // Minimum size

                // Apply quality multiplier for higher resolution generation
                int qualityMultiplier = optionsControl.Quality.GetResolutionMultiplier();
                int qrSize = baseQRSize * qualityMultiplier;

                // Create a surface to draw on
                var info = new SKImageInfo(qrSize, qrSize);
                using var surface = SKSurface.Create(info);
                using var canvas = surface.Canvas;

                // Clear with background color
                canvas.Clear(bgColor);

                // Anti-aliasing is handled per drawing operation

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
                        ApplyGradientToQR(canvas, qrImage, optionsControl.SelectedGradient, qrSize, optionsControl.UseAntiAliasing);
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

                        // Draw normal QR code with anti-aliasing if enabled
                        if (optionsControl.UseAntiAliasing)
                        {
                            using var paint = new SKPaint
                            {
                                IsAntialias = true
                            };
                            canvas.DrawImage(qrImage, 0, 0, paint);
                        }
                        else
                        {
                            canvas.DrawImage(qrImage, 0, 0);
                        }
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
                    using var whitePaint = new SKPaint
                    {
                        Color = SKColors.White,
                        IsAntialias = optionsControl.UseAntiAliasing
                    };
                    canvas.DrawRoundRect(logoRect, 5, 5, whitePaint);

                    // Draw logo (resize if needed)
                    var scaledLogo = ResizeLogo(optionsControl.LogoImage, logoSize);

                    using var logoPaint = new SKPaint
                    {
                        IsAntialias = optionsControl.UseAntiAliasing
                    };
                    canvas.DrawBitmap(scaledLogo, logoRect, logoPaint);
                }

                // Create the high-resolution QR code for saving
                currentQRCode = SKBitmap.FromImage(surface.Snapshot());

                // Create a properly scaled version for display in PictureBox
                var displayBitmap = CreateDisplayBitmap(currentQRCode, pictureBox.Width - padding * 2, pictureBox.Height - padding * 2);

                // Display in PictureBox (will be centered automatically)
                pictureBox.Image = displayBitmap;
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

                // Use high-quality filtering for better logo scaling
                using var paint = new SKPaint
                {
                    IsAntialias = true
                };
                canvas.DrawBitmap(originalLogo, destRect, paint);
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

        private Bitmap CreateDisplayBitmap(SKBitmap highResBitmap, int maxWidth, int maxHeight)
        {
            // Calculate scale to fit within the PictureBox dimensions
            float scaleX = (float)maxWidth / highResBitmap.Width;
            float scaleY = (float)maxHeight / highResBitmap.Height;
            float scale = Math.Min(scaleX, scaleY);

            // Calculate the display size
            int displayWidth = Math.Max((int)(highResBitmap.Width * scale), 50); // Minimum 50px
            int displayHeight = Math.Max((int)(highResBitmap.Height * scale), 50); // Minimum 50px

            // Create a new bitmap at display size
            using var displayBitmap = new SKBitmap(displayWidth, displayHeight);
            using var canvas = new SKCanvas(displayBitmap);

            // Clear with transparent background
            canvas.Clear(SKColors.Transparent);

            // Use high-quality scaling for the display image
            using var paint = new SKPaint
            {
                IsAntialias = true
            };

            // Draw the scaled QR code
            var destRect = new SKRect(0, 0, displayWidth, displayHeight);
            canvas.DrawBitmap(highResBitmap, destRect, paint);

            // Convert to System.Drawing.Bitmap for PictureBox
            return ConvertToBitmap(displayBitmap);
        }

        
        private void ApplyGradientToQR(SKCanvas canvas, SKImage qrImage, AppGradientOptions gradientOptions, int size, bool useAntiAliasing)
        {
            // Convert QR image to bitmap to access pixels
            using var originalBitmap = SKBitmap.FromImage(qrImage);
            if (originalBitmap == null) return;

            // Create gradient shader
            var colors = gradientOptions.Colors;
            var positions = gradientOptions.Positions ?? GenerateDefaultPositions(colors.Length);

            // Use gradient direction based on gradient options
            SKPoint startPoint, endPoint;
            switch (gradientOptions.Direction)
            {
                case AppGradientDirection.TopToBottom:
                    startPoint = new SKPoint(0, 0);
                    endPoint = new SKPoint(0, size);
                    break;
                case AppGradientDirection.LeftToRight:
                    startPoint = new SKPoint(0, 0);
                    endPoint = new SKPoint(size, 0);
                    break;
                case AppGradientDirection.TopLeftToBottomRight:
                    startPoint = new SKPoint(0, 0);
                    endPoint = new SKPoint(size, size);
                    break;
                case AppGradientDirection.TopRightToBottomLeft:
                    startPoint = new SKPoint(size, 0);
                    endPoint = new SKPoint(0, size);
                    break;
                case AppGradientDirection.Radial:
                default:
                    startPoint = new SKPoint(size / 2, size / 2);
                    endPoint = new SKPoint(size / 2, size / 2);
                    break;
            }

            using var shader = startPoint == endPoint && gradientOptions.Direction == AppGradientDirection.Radial
                ? SKShader.CreateRadialGradient(startPoint, size / 2, colors, positions, SKShaderTileMode.Clamp)
                : SKShader.CreateLinearGradient(startPoint, endPoint, colors, positions, SKShaderTileMode.Clamp);

            // Create final bitmap with gradient applied to QR parts only
            using var finalBitmap = new SKBitmap(size, size);
            using var finalCanvas = new SKCanvas(finalBitmap);

            // Clear with transparent background
            finalCanvas.Clear(SKColors.Transparent);

            // Draw QR image first
            if (useAntiAliasing)
            {
                using var paint = new SKPaint
                {
                    IsAntialias = true
                };
                finalCanvas.DrawImage(qrImage, 0, 0, paint);
            }
            else
            {
                finalCanvas.DrawImage(qrImage, 0, 0);
            }

            // Apply gradient with proper blend mode to only affect black parts
            using var gradientMaskPaint = new SKPaint
            {
                Shader = shader,
                BlendMode = SKBlendMode.SrcIn, // Only apply gradient where QR exists
                IsAntialias = useAntiAliasing
            };

            finalCanvas.DrawRect(0, 0, size, size, gradientMaskPaint);

            // Draw the final result with anti-aliasing if enabled
            if (useAntiAliasing)
            {
                using var paint = new SKPaint
                {
                    IsAntialias = true
                };
                canvas.DrawBitmap(finalBitmap, 0, 0, paint);
            }
            else
            {
                canvas.DrawBitmap(finalBitmap, 0, 0);
            }
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
                    // Determine which tab this save button belongs to
                    var isWifiTab = (sender as Button)?.Name == "btnSaveQR_WIFI";
                    var optionsControl = isWifiTab ? qrOptionsControl_WIFI : qrOptionsControl_URL;
                    var qualityMultiplier = optionsControl.Quality.GetResolutionMultiplier();

                    // If quality is higher than medium, offer to save at full resolution
                    if (qualityMultiplier > 1)
                    {
                        var result = MessageBox.Show(
                            $"Đã phát hiện cài đặt chất lượng cao. Bạn có muốn lưu ở độ phân giải đầy đủ ({currentQRCode.Width}x{currentQRCode.Height}) không?\n\n" +
                            "Chọn 'Yes' để lưu ở độ phân giải đầy đủ (tốt cho in ấn).\n" +
                            "Chọn 'No' để lưu ở độ phân giải hiển thị (nhỏ hơn).",
                            "Chất lượng lưu", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        if (result == DialogResult.Cancel)
                            return;

                        if (result == DialogResult.Yes)
                        {
                            // Save at full resolution
                            using var image = SKImage.FromBitmap(currentQRCode);
                            var format = Path.GetExtension(saveFileDialogQR.FileName).ToLower() switch
                            {
                                ".jpg" or ".jpeg" => SKEncodedImageFormat.Jpeg,
                                _ => SKEncodedImageFormat.Png
                            };

                            using var data = image.Encode(format, 100);
                            using var fileStream = File.Create(saveFileDialogQR.FileName);
                            data.SaveTo(fileStream);

                            MessageBox.Show($"QR Code đã được lưu thành công ở độ phân giải {currentQRCode.Width}x{currentQRCode.Height}!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    // Save at display resolution (existing behavior)
                    using var displayImage = SKImage.FromBitmap(currentQRCode);
                    var displayFormat = Path.GetExtension(saveFileDialogQR.FileName).ToLower() switch
                    {
                        ".jpg" or ".jpeg" => SKEncodedImageFormat.Jpeg,
                        _ => SKEncodedImageFormat.Png
                    };

                    using var displayData = displayImage.Encode(displayFormat, 100);
                    using var displayFileStream = File.Create(saveFileDialogQR.FileName);
                    displayData.SaveTo(displayFileStream);

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
