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
                { "NOWAY", new LanguageConfig {Name = "Удали меня"} } // Windows 11 (or 10 as well) has a shitty thing - it adds this language from time to time
            },
            Timestamp = "dd MMM HH:mm:ss.fffff"
        };

        public static Config Now { get; set; } = Default;

        public static string ParseDirectory(string text)
        {
            // TODO: Acquire the drop box path from registry
            return text.Replace("%DROPBOX%", Environment.GetEnvironmentVariable("DROPBOX")).Replace("/", "\\");
        }
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
