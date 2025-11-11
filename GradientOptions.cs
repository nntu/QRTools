using SkiaSharp;

namespace QRTools
{
    public enum AppGradientDirection
    {
        TopToBottom,
        LeftToRight,
        TopLeftToBottomRight,
        TopRightToBottomLeft,
        Radial,
        Diagonal,
        Sweep
    }

    public class AppGradientOptions
    {
        public SKColor[] Colors { get; set; }
        public AppGradientDirection Direction { get; set; }
        public float[]? Positions { get; set; }

        public AppGradientOptions(SKColor[] colors, AppGradientDirection direction, float[]? positions = null)
        {
            Colors = colors;
            Direction = direction;
            Positions = positions;
        }
    }

    public static class GradientPresets
    {
        // Load gradients from file or return built-in ones
        public static List<GradientPreset> LoadAllPresets()
        {
            return GradientPresetsManager.LoadPresets();
        }

        // Get specific preset by name
        public static AppGradientOptions? GetPreset(string name)
        {
            var presets = LoadAllPresets();
            var preset = presets.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return preset != null ? GradientPresetsManager.PresetToGradientOptions(preset) : null;
        }

        // Save a new preset
        public static void SavePreset(string name, AppGradientOptions gradientOptions)
        {
            var preset = GradientPresetsManager.GradientOptionsToPreset(gradientOptions, name);
            GradientPresetsManager.AddPreset(preset);
        }

        // Delete a preset
        public static void DeletePreset(string name)
        {
            GradientPresetsManager.DeletePreset(name);
        }

        // Built-in presets for backward compatibility
        public static AppGradientOptions Instagram => GetPreset("Instagram") ?? CreateDefaultInstagram();
        public static AppGradientOptions Sunset => GetPreset("Sunset") ?? CreateDefaultSunset();
        public static AppGradientOptions Ocean => GetPreset("Ocean") ?? CreateDefaultOcean();
        public static AppGradientOptions Rainbow => GetPreset("Rainbow") ?? CreateDefaultRainbow();
        public static AppGradientOptions Forest => GetPreset("Forest") ?? CreateDefaultForest();
        public static AppGradientOptions Galaxy => GetPreset("Galaxy") ?? CreateDefaultGalaxy();
        public static AppGradientOptions Fire => GetPreset("Fire") ?? CreateDefaultFire();

        // Custom 2-color gradient
        public static AppGradientOptions CreateTwoColor(SKColor startColor, SKColor endColor, AppGradientDirection direction = AppGradientDirection.LeftToRight)
        {
            return new AppGradientOptions([startColor, endColor], direction);
        }

        // Custom 3-color gradient
        public static AppGradientOptions CreateThreeColor(SKColor startColor, SKColor middleColor, SKColor endColor, AppGradientDirection direction = AppGradientDirection.LeftToRight)
        {
            return new AppGradientOptions([startColor, middleColor, endColor], direction, [0f, 0.5f, 1f]);
        }

        // Fallback methods
        private static AppGradientOptions CreateDefaultInstagram()
        {
            return new AppGradientOptions(
            [
                SKColor.Parse("FCAF45"),  // Orange
                SKColor.Parse("F77737"),  // Orange-Red
                SKColor.Parse("E1306C"),  // Pink
                SKColor.Parse("C13584"),  // Purple
                SKColor.Parse("833AB4")   // Deep Purple
            ],
            AppGradientDirection.TopLeftToBottomRight,
            [0f, 0.25f, 0.5f, 0.75f, 1f]);
        }

        private static AppGradientOptions CreateDefaultSunset()
        {
            return new AppGradientOptions(
            [
                SKColor.Parse("FF6B6B"),  // Red
                SKColor.Parse("FF8E53"),  // Orange
                SKColor.Parse("FFD93D")   // Yellow
            ],
            AppGradientDirection.LeftToRight,
            [0f, 0.5f, 1f]);
        }

        private static AppGradientOptions CreateDefaultOcean()
        {
            return new AppGradientOptions(
            [
                SKColor.Parse("0077BE"),  // Blue
                SKColor.Parse("00A8CC"),  // Light Blue
                SKColor.Parse("5CDB95")   // Cyan
            ],
            AppGradientDirection.TopToBottom,
            [0f, 0.5f, 1f]);
        }

        private static AppGradientOptions CreateDefaultRainbow()
        {
            return new AppGradientOptions(
            [
                SKColor.Parse("#FF0000"),  // Red
                SKColor.Parse("#FFA500"),  // Orange
                SKColor.Parse("#FFFF00"),  // Yellow
                SKColor.Parse("#00FF00"),  // Green
                SKColor.Parse("#0000FF"),  // Blue
                SKColor.Parse("#4B0082"),  // Indigo
                SKColor.Parse("#9400D3")   // Violet
            ],
            AppGradientDirection.LeftToRight,
            [0f, 0.17f, 0.33f, 0.5f, 0.67f, 0.83f, 1f]);
        }

        private static AppGradientOptions CreateDefaultForest()
        {
            return new AppGradientOptions(
            [
                SKColor.Parse("#2D6A4F"),  // Dark Green
                SKColor.Parse("#52B788"),  // Light Green
                SKColor.Parse("#95D5B2"),  // Mint
                SKColor.Parse("#B7E4C7")   // Pale Green
            ],
            AppGradientDirection.TopToBottom,
            [0f, 0.33f, 0.67f, 1f]);
        }

        private static AppGradientOptions CreateDefaultGalaxy()
        {
            return new AppGradientOptions(
            [
                SKColor.Parse("#2D1B69"),  // Deep Purple
                SKColor.Parse("#0F3460"),  // Blue
                SKColor.Parse("#E94560"),  // Pink
                SKColor.Parse("#F47068")   // Light Pink
            ],
            AppGradientDirection.Radial,
            [0f, 0.3f, 0.7f, 1f]);
        }

        private static AppGradientOptions CreateDefaultFire()
        {
            return new AppGradientOptions(
            [
                SKColor.Parse("#FF0000"),  // Red
                SKColor.Parse("#FF6600"),  // Orange-Red
                SKColor.Parse("#FFCC00"),  // Yellow
                SKColor.Parse("#FFFFFF")   // White
            ],
            AppGradientDirection.TopToBottom,
            [0f, 0.3f, 0.7f, 1f]);
        }
    }
}