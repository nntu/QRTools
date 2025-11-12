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
            LoadGradientPresets();
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
        public bool UseGradient => chkUseGradient.Checked;
        public Color GradientEndColor => btnGradientEnd.BackColor;
        public AppGradientOptions? SelectedGradient { get; private set; }
        public OpenFileDialog LogoDialog => openFileDialogLogo;

        // Quality properties
        public QRQuality Quality => (QRQuality)cmbQuality.SelectedIndex;
        public QRErrorCorrection ErrorCorrection => (QRErrorCorrection)cmbErrorCorrection.SelectedIndex;
        public bool UseAntiAliasing => chkAntiAliasing.Checked;

        // Event handlers
        public event EventHandler? LogoChanged;
        public event EventHandler? QRColorChanged;
        public event EventHandler? BackgroundColorChanged;
        public event EventHandler? GradientChanged;
        public event EventHandler? QualityChanged;
        public event EventHandler? ErrorCorrectionChanged;
        public event EventHandler? AntiAliasingChanged;

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

        private void chkUseGradient_CheckedChanged(object? sender, EventArgs e)
        {
            // Show/hide gradient controls
            lblGradientType.Visible = chkUseGradient.Checked;
            cmbGradientPreset.Visible = chkUseGradient.Checked;
            btnCustomGradient.Visible = chkUseGradient.Checked;

            if (!chkUseGradient.Checked)
            {
                // Hide all color controls when gradient is disabled
                lblQRColor.Visible = true;
                lblBGColor.Visible = true;
                btnQRColor.Visible = true;
                btnBGColor.Visible = true;
                lblGradientEnd.Visible = false;
                btnGradientEnd.Visible = false;
            }
            else
            {
                // Show gradient-specific controls when gradient is enabled
                lblQRColor.Visible = false;
                lblBGColor.Visible = true;
                btnQRColor.Visible = false;
                btnBGColor.Visible = true;

                // Select the first gradient preset by default
                if (cmbGradientPreset.Items.Count > 0)
                {
                    cmbGradientPreset.SelectedIndex = 0;
                    LoadGradientPreset(cmbGradientPreset.SelectedIndex);
                }
            }

            GradientChanged?.Invoke(this, EventArgs.Empty);
        }

        private void btnGradientEnd_Click(object? sender, EventArgs e)
        {
            if (colorDialogGradient.ShowDialog() == DialogResult.OK)
            {
                btnGradientEnd.BackColor = colorDialogGradient.Color;
                GradientChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void cmbGradientPreset_SelectedIndexChanged(object? sender, EventArgs e)
        {
            int selectedIndex = cmbGradientPreset.SelectedIndex;
            var itemCount = cmbGradientPreset.Items.Count;

            if (selectedIndex == itemCount - 1 && cmbGradientPreset.Items[selectedIndex]?.ToString().StartsWith("+") == true)
            {
                // "Create New" selected - open custom gradient dialog
                btnCustomGradient_Click(btnCustomGradient, EventArgs.Empty);
                cmbGradientPreset.SelectedIndex = Math.Max(0, selectedIndex - 1);
            }
            else
            {
                // Regular preset selected
                LoadGradientPreset(selectedIndex);
                GradientChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnCustomGradient_Click(object? sender, EventArgs e)
        {
            // Show dialog to configure custom gradient
            using var customForm = new Form();
            customForm.Text = "Tùy chỉnh Gradient";
            customForm.Size = new Size(400, 300);
            customForm.StartPosition = FormStartPosition.CenterParent;

            var lblInstructions = new Label
            {
                Text = "Chọn số màu và màu sắc cho gradient (tối đa 5 màu):",
                Location = new Point(10, 10),
                Width = 380,
                Height = 20
            };

            var btnAddColor = new Button
            {
                Text = "Thêm màu",
                Location = new Point(10, 40),
                Width = 80,
                Height = 30
            };

            var flowColors = new FlowLayoutPanel
            {
                Location = new Point(10, 80),
                Width = 380,
                Height = 150,
                BorderStyle = BorderStyle.FixedSingle,
                AutoScroll = true
            };

            var btnOK = new Button
            {
                Text = "OK",
                Location = new Point(315, 230),
                Width = 60,
                Height = 30,
                DialogResult = DialogResult.OK
            };

            var btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(250, 230),
                Width = 60,
                Height = 30,
                DialogResult = DialogResult.Cancel
            };

            var colors = new List<Color>();
            var colorButtons = new List<Button>();

            btnAddColor.Click += (s, e) =>
            {
                using var colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    if (colors.Count >= 5)
                    {
                        MessageBox.Show("Tối đa 5 màu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    colors.Add(colorDialog.Color);
                    var colorBtn = new Button
                    {
                        BackColor = colorDialog.Color,
                        Width = 50,
                        Height = 30,
                        Text = "X"
                    };

                    colorBtn.Click += (cs, ce) =>
                    {
                        var btn = (Button)cs!;
                        if (colorDialogQR.ShowDialog() == DialogResult.OK)
                        {
                            int index = colorButtons.IndexOf(btn);
                            if (index >= 0)
                            {
                                colors[index] = colorDialogQR.Color;
                                btn.BackColor = colorDialogQR.Color;
                                GradientChanged?.Invoke(this, EventArgs.Empty);
                            }
                        }
                    };

                    colorButtons.Add(colorBtn);
                    flowColors.Controls.Add(colorBtn);

                    if (colors.Count >= 2)
                    {
                        btnOK.Enabled = true;
                    }
                }
            };

            customForm.Controls.AddRange(new Control[]
            {
                lblInstructions, btnAddColor, flowColors, btnCancel, btnOK
            });

            btnOK.Enabled = false;

            if (customForm.ShowDialog() == DialogResult.OK && colors.Count >= 2)
            {
                // Create custom gradient
                var skColors = colors.Select(c => ConvertToSKColor(c)).ToArray();
                var directions = new[] { "Trên xuống", "Trái sang phải", "Chéo trái-phải", "Chéo phải-trái", "Từ tâm" };

                using var directionForm = new Form();
                directionForm.Text = "Chọn hướng gradient";
                directionForm.Size = new Size(200, 150);

                var lblDirection = new Label
                {
                    Text = "Chọn hướng gradient:",
                    Location = new Point(10, 10)
                };

                var cmbDirection = new ComboBox
                {
                    Location = new Point(10, 40),
                    Width = 150
                };
                cmbDirection.Items.AddRange(directions);

                var btnDirOK = new Button
                {
                    Text = "OK",
                    Location = new Point(65, 100),
                    DialogResult = DialogResult.OK
                };

                directionForm.Controls.AddRange(new Control[] { lblDirection, cmbDirection, btnDirOK });

                if (directionForm.ShowDialog() == DialogResult.OK)
                {
                    var direction = (AppGradientDirection)cmbDirection.SelectedIndex;
                    SelectedGradient = new AppGradientOptions(skColors, direction);

                    // Hide single color controls when using custom gradient
                    lblQRColor.Visible = false;
                    btnQRColor.Visible = false;
                    lblGradientEnd.Visible = false;
                    btnGradientEnd.Visible = false;

                    GradientChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void LoadGradientPreset(int index)
        {
            var presets = GradientPresets.LoadAllPresets();
            if (index >= 0 && index < presets.Count)
            {
                var preset = presets[index];
                SelectedGradient = GradientPresetsManager.PresetToGradientOptions(preset);
            }
            else
            {
                // Fallback to Instagram if index out of range
                SelectedGradient = GradientPresets.Instagram;
            }
        }

        private SKColor ConvertToSKColor(Color color)
        {
            return new SKColor(color.R, color.G, color.B, color.A);
        }

        private void LoadGradientPresets()
        {
            try
            {
                var presets = GradientPresets.LoadAllPresets();
                cmbGradientPreset.Items.Clear();

                foreach (var preset in presets)
                {
                    cmbGradientPreset.Items.Add(preset.Name);
                }

                // Add "Create New" option
                cmbGradientPreset.Items.Add("+ Tạo gradient mới");

                // Select first preset by default
                if (cmbGradientPreset.Items.Count > 1)
                {
                    cmbGradientPreset.SelectedIndex = 0;
                    LoadGradientPreset(0);
                }
            }
            catch (Exception)
            {
                // Fallback to basic gradient options
                cmbGradientPreset.Items.Clear();
                cmbGradientPreset.Items.AddRange(new object[] {
                    "Instagram",
                    "Sunset",
                    "Ocean",
                    "Rainbow",
                    "Forest",
                    "Galaxy",
                    "Fire"
                });

                if (cmbGradientPreset.Items.Count > 0)
                {
                    cmbGradientPreset.SelectedIndex = 0;
                    LoadGradientPreset(0);
                }
            }
        }

        private void cmbQuality_SelectedIndexChanged(object? sender, EventArgs e)
        {
            QualityChanged?.Invoke(this, EventArgs.Empty);
        }

        private void cmbErrorCorrection_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ErrorCorrectionChanged?.Invoke(this, EventArgs.Empty);
        }

        private void chkAntiAliasing_CheckedChanged(object? sender, EventArgs e)
        {
            AntiAliasingChanged?.Invoke(this, EventArgs.Empty);
        }

        private void lblQuality_Click(object sender, EventArgs e)
        {

        }

        private void lblErrorCorrection_Click(object sender, EventArgs e)
        {

        }
    }
}