using System.ComponentModel;

namespace QRTools
{
    public enum QRQuality
    {
        [Description("Thấp")]
        Low = 0,

        [Description("Trung bình")]
        Medium = 1,

        [Description("Cao")]
        High = 2,

        [Description("Rất cao")]
        VeryHigh = 3
    }

    public enum QRErrorCorrection
    {
        [Description("Thấp (L~7%)")]
        Low = 0,

        [Description("Trung bình (M~15%)")]
        Medium = 1,

        [Description("Cao (Q~25%)")]
        Quartile = 2,

        [Description("Rất cao (H~30%)")]
        High = 3
    }

    public static class QRQualityExtensions
    {
        public static int GetResolutionMultiplier(this QRQuality quality)
        {
            return quality switch
            {
                QRQuality.Low => 1,
                QRQuality.Medium => 2,
                QRQuality.High => 4,
                QRQuality.VeryHigh => 8,
                _ => 2
            };
        }

        public static int GetECCLevel(this QRErrorCorrection errorCorrection)
        {
            return errorCorrection switch
            {
                QRErrorCorrection.Low => 0, // L
                QRErrorCorrection.Medium => 1, // M
                QRErrorCorrection.Quartile => 2, // Q
                QRErrorCorrection.High => 3, // H
                _ => 1 // M
            };
        }
    }
}