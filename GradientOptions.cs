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
        // Instagram gradient colors (orange -> pink -> purple)
        public static readonly AppGradientOptions Instagram = new AppGradientOptions(
        [
            SKColor.Parse("FCAF45"),  // Orange
            SKColor.Parse("F77737"),  // Orange-Red
            SKColor.Parse("E1306C"),  // Pink
            SKColor.Parse("C13584"),  // Purple
            SKColor.Parse("833AB4")   // Deep Purple
        ],
        AppGradientDirection.TopLeftToBottomRight,
        [0f, 0.25f, 0.5f, 0.75f, 1f]);

        // Sunset gradient (red -> orange -> yellow)
        public static readonly AppGradientOptions Sunset = new AppGradientOptions(
        [
            SKColor.Parse("FF6B6B"),  // Red
            SKColor.Parse("FF8E53"),  // Orange
            SKColor.Parse("FFD93D")   // Yellow
        ],
        AppGradientDirection.LeftToRight,
        [0f, 0.5f, 1f]);

        // Ocean gradient (blue -> cyan)
        public static readonly AppGradientOptions Ocean = new AppGradientOptions(
        [
            SKColor.Parse("0077BE"),  // Blue
            SKColor.Parse("00A8CC"),  // Light Blue
            SKColor.Parse("5CDB95")   // Cyan
        ],
        AppGradientDirection.TopToBottom,
        [0f, 0.5f, 1f]);

        // Rainbow gradient (all colors)
        public static readonly AppGradientOptions Rainbow = new AppGradientOptions(
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

        // Forest gradient (green -> brown)
        public static readonly AppGradientOptions Forest = new AppGradientOptions(
        [
            SKColor.Parse("#2D6A4F"),  // Dark Green
            SKColor.Parse("#52B788"),  // Light Green
            SKColor.Parse("#95D5B2"),  // Mint
            SKColor.Parse("#B7E4C7")   // Pale Green
        ],
        AppGradientDirection.TopToBottom,
        [0f, 0.33f, 0.67f, 1f]);

        // Galaxy gradient (purple -> pink -> blue)
        public static readonly AppGradientOptions Galaxy = new AppGradientOptions(
        [
            SKColor.Parse("#2D1B69"),  // Deep Purple
            SKColor.Parse("#0F3460"),  // Blue
            SKColor.Parse("#E94560"),  // Pink
            SKColor.Parse("#F47068")   // Light Pink
        ],
        AppGradientDirection.Radial,
        [0f, 0.3f, 0.7f, 1f]);

        // Fire gradient (red -> yellow -> white)
        public static readonly AppGradientOptions Fire = new AppGradientOptions(
        [
            SKColor.Parse("#FF0000"),  // Red
            SKColor.Parse("#FF6600"),  // Orange-Red
            SKColor.Parse("#FFCC00"),  // Yellow
            SKColor.Parse("#FFFFFF")   // White
        ],
        AppGradientDirection.TopToBottom,
        [0f, 0.3f, 0.7f, 1f]);

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
    }
}