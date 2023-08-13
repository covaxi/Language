using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Forms;

namespace Configuration
{
    /// <summary>
    /// TODO: Move to a separate project/package
    /// </summary>
    public class Config
    {
        public const string Name = "lang";

        public int Timeout { get; set; } = 1000;
        public Dictionary<string, string> Mappings { get; set; } = new();
        public Dictionary<string, LanguageConfig> Languages { get; set; } = new();
        public string Timestamp { get; set; } = "dd MMM HH:MM:ss.ffff";

        public static string ConfigDirectory => ParseDirectory("%DROPBOX%/config");

        public static string FileName => Path.Combine(ConfigDirectory, Name, Path.ChangeExtension(Name, ".ini"));

        public static Config Current { get => config; private set => config = value; }

        public static readonly Config Default = new()
        {
            Mappings = new Dictionary<string, string>()
            {
                {   "en-US", "US" },
                {   "ru-RU", "RU"},
                {   "he-IL", "HE" },
                {   "af-ZA", "NOWAY" }
            },
            Languages = new Dictionary<string, LanguageConfig>
            {
                { "EN", new LanguageConfig { Name = "English", Flag = "%DROPBOX%/config/lang/gb.png", Icon = "%DROPBOX%/config/lang/gb.ico" } },
                { "RU", new LanguageConfig { Name = "Русский", Flag = "%DROPBOX%/config/lang/ru.png" , Icon = "%DROPBOX%/config/lang/ru.ico" } },
                { "HE", new LanguageConfig { Name = "עברית", Flag = "%DROPBOX%/config/lang/il.png" , Icon = "%DROPBOX%/config/lang/il.ico" } },
                { "US", new LanguageConfig { Name = "Проклятая НАТА", Flag = "%DROPBOX%/config/lang/us.png" , Icon = "%DROPBOX%/config/lang/us.ico" } },
                { "NOWAY", new LanguageConfig {Name = "Remove me!!!"} } // My windows 11 (or 10 as well) does a shitty thing - it adds af-ZA to the list from time to time, so I have to remove it using the settings
            },
            Timestamp = "dd MMM HH:mm:ss.fffff"
        };


        public static string ParseDirectory(string text)
        {
            // TODO: Acquire the drop box path from registry (or get all other environment variables maybe)
            return text.Replace("%DROPBOX%", Environment.GetEnvironmentVariable("DROPBOX")).Replace("/", "\\");
        }

        public static async Task InitializeAsync()
        {
            if (initialized)
                return;

            config = Config.Default;
            initialized = false;
            using var sr = new StreamReader(Config.FileName, false);
            config = await JsonSerializer.DeserializeAsync<Config>(sr.BaseStream) ?? new();
            foreach (var lang in config.Languages)
            {
                if (!string.IsNullOrWhiteSpace(lang.Value.Flag))
                    lang.Value.FlagImage = ReadImage(lang.Value.Flag);
                if (!string.IsNullOrWhiteSpace(lang.Value.Icon))
                    lang.Value.IconImage = ReadIcon(lang.Value.Icon);
            }
            initialized = true;
        }

        static Image ReadImage(string filePath)
        {
            using var fileStream = new FileStream(Config.ParseDirectory(filePath), FileMode.Open,
                FileAccess.Read, FileShare.Read, 4096, true);
            return Image.FromStream(fileStream, true);
        }

        static Icon ReadIcon(string fileName)
        {
            using var fileStream = new FileStream(Config.ParseDirectory(fileName), FileMode.Open,
                FileAccess.Read, FileShare.Read, 4096, true);
            return new Icon(fileStream);
        }

        private static bool initialized = false;
        private static Config config = Default;
    }

    public class LanguageConfig
    {
        public string Name { get; set; } = "";
        public string Flag { get; set; } = "";
        [JsonIgnore]
        public Image? FlagImage { get; set; }
        public string Icon { get; set; } = "NO";
        public Icon? IconImage { get; set; }
    }
}
