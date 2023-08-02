using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using WinFormsApp1;

namespace WinFormsApp1
{
    /// <summary>
    /// TODO: Move to a separate project/package
    /// </summary>
    public class Config
    {
        public const string Name = "lang";

        public Dictionary<string, string> Mappings { get; set; } = new();
        public Dictionary<string, Language> Languages { get; set; } = new();

        public static string ConfigDirectory => ParseDirectory("%DROPBOX%/config");

        public static string FileName => Path.Combine(ConfigDirectory, Name, Path.ChangeExtension(Name, ".ini"));

        public static Config Default = new()
        {
            Mappings  = new Dictionary<string, string>()
            {
                {   "en-US", "US" },
                {   "ru-RU", "RU"},
                {   "he-IL", "HE" },
            },
            Languages = new Dictionary<string, Language> 
            {
                { "EN", new Language { Name = "English", Flag = "%DROPBOX%/config/lang/gb.png" } },
                { "RU", new Language { Name = "Русский", Flag = "%DROPBOX%/config/lang/ru.png" } },
                { "HE", new Language { Name = "עברית", Flag = "%DROPBOX%/config/lang/il.png" } },
                { "US", new Language { Name = "Проклятая НАТА", Flag = "%DROPBOX%/config/lang/us.png" } },
            }
        };

        public static string ParseDirectory(string text)
        {
            return text.Replace("%DROPBOX%", Environment.GetEnvironmentVariable("DROPBOX"))
                .Replace("/", "\\");
        }
    }

    public class Language
    {
        public string Name { get; set; } = "";
        public string Flag { get; set; } = "";
        [JsonIgnore]
        public Image? FlagImage { get; set; }
    }
}
