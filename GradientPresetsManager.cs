using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SkiaSharp;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace QRTools
{
    public class GradientPreset
    {
        public string Name { get; set; } = "";
        public string[] Colors { get; set; } = Array.Empty<string>();
        public AppGradientDirection Direction { get; set; }
        public float[]? Positions { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class GradientPresetsManager
    {
        private static readonly string PresetsFilePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "gradient_presets.yml");

        public static List<GradientPreset> LoadPresets()
        {
            try
            {
                // Ensure directory exists
                var directory = Path.GetDirectoryName(PresetsFilePath);
                if (directory != null && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                if (!File.Exists(PresetsFilePath))
                {
                    // Create default presets file
                    CreateDefaultPresetsFile();
                }

                var yaml = File.ReadAllText(PresetsFilePath, Encoding.UTF8);
                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();

                var presets = deserializer.Deserialize<List<GradientPreset>>(yaml) ?? new List<GradientPreset>();

                // Add built-in presets if they don't exist
                EnsureBuiltInPresets(presets);

                return presets;
            }
            catch (Exception)
            {
                // Return default presets on error
                return GetDefaultPresets();
            }
        }

        public static void SavePresets(List<GradientPreset> presets)
        {
            try
            {
                // Ensure directory exists
                var directory = Path.GetDirectoryName(PresetsFilePath);
                if (directory != null && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var serializer = new SerializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();

                var yaml = serializer.Serialize(presets);
                File.WriteAllText(PresetsFilePath, yaml, Encoding.UTF8);
            }
            catch (Exception)
            {
                // Handle error silently for now
                // In a real app, you might want to show a message to the user
            }
        }

        public static AppGradientOptions PresetToGradientOptions(GradientPreset preset)
        {
            var colors = new SKColor[preset.Colors.Length];
            for (int i = 0; i < preset.Colors.Length; i++)
            {
                colors[i] = SKColor.Parse(preset.Colors[i]);
            }

            return new AppGradientOptions(colors, preset.Direction, preset.Positions);
        }

        public static GradientPreset GradientOptionsToPreset(AppGradientOptions options, string name)
        {
            var colors = new string[options.Colors.Length];
            for (int i = 0; i < options.Colors.Length; i++)
            {
                colors[i] = options.Colors[i].ToString();
            }

            return new GradientPreset
            {
                Name = name,
                Colors = colors,
                Direction = options.Direction,
                Positions = options.Positions,
                CreatedAt = DateTime.Now
            };
        }

        private static void CreateDefaultPresetsFile()
        {
            var defaultPresets = GetDefaultPresets();
            SavePresets(defaultPresets);
        }

        private static List<GradientPreset> GetDefaultPresets()
        {
            return new List<GradientPreset>
            {
                new GradientPreset
                {
                    Name = "Instagram",
                    Colors = new[] { "FCAF45", "F77737", "E1306C", "C13584", "833AB4" },
                    Direction = AppGradientDirection.TopLeftToBottomRight,
                    Positions = new float[] { 0f, 0.25f, 0.5f, 0.75f, 1f }
                },
                new GradientPreset
                {
                    Name = "Sunset",
                    Colors = new[] { "FF6B6B", "FF8E53", "FFD93D" },
                    Direction = AppGradientDirection.LeftToRight,
                    Positions = new float[] { 0f, 0.5f, 1f }
                },
                new GradientPreset
                {
                    Name = "Ocean",
                    Colors = new[] { "0077BE", "00A8CC", "5CDB95" },
                    Direction = AppGradientDirection.TopToBottom,
                    Positions = new float[] { 0f, 0.5f, 1f }
                },
                new GradientPreset
                {
                    Name = "Rainbow",
                    Colors = new[] { "#FF0000", "#FFA500", "#FFFF00", "#00FF00", "#0000FF", "#4B0082", "#9400D3" },
                    Direction = AppGradientDirection.LeftToRight,
                    Positions = new float[] { 0f, 0.17f, 0.33f, 0.5f, 0.67f, 0.83f, 1f }
                },
                new GradientPreset
                {
                    Name = "Forest",
                    Colors = new[] { "#2D6A4F", "#52B788", "#95D5B2", "#B7E4C7" },
                    Direction = AppGradientDirection.TopToBottom,
                    Positions = new float[] { 0f, 0.33f, 0.67f, 1f }
                },
                new GradientPreset
                {
                    Name = "Galaxy",
                    Colors = new[] { "#2D1B69", "#0F3460", "#E94560", "#F47068" },
                    Direction = AppGradientDirection.Radial,
                    Positions = new float[] { 0f, 0.3f, 0.7f, 1f }
                },
                new GradientPreset
                {
                    Name = "Fire",
                    Colors = new[] { "#FF0000", "#FF6600", "#FFCC00", "#FFFFFF" },
                    Direction = AppGradientDirection.TopToBottom,
                    Positions = new float[] { 0f, 0.3f, 0.7f, 1f }
                }
            };
        }

        private static void EnsureBuiltInPresets(List<GradientPreset> presets)
        {
            var defaultPresets = GetDefaultPresets();
            foreach (var defaultPreset in defaultPresets)
            {
                if (!presets.Exists(p => p.Name == defaultPreset.Name))
                {
                    presets.Add(defaultPreset);
                }
            }
        }

        public static void AddPreset(GradientPreset preset)
        {
            var presets = LoadPresets();

            // Check if preset with same name exists
            var existingIndex = presets.FindIndex(p => p.Name.Equals(preset.Name, StringComparison.OrdinalIgnoreCase));
            if (existingIndex >= 0)
            {
                presets[existingIndex] = preset; // Replace existing
            }
            else
            {
                presets.Add(preset); // Add new
            }

            SavePresets(presets);
        }

        public static void DeletePreset(string name)
        {
            var presets = LoadPresets();
            presets.RemoveAll(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            SavePresets(presets);
        }

        public static string GetPresetsFilePath()
        {
            return PresetsFilePath;
        }
    }
}