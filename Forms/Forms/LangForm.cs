using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using Configuration;

namespace Forms
{
    public partial class LangForm : Form
    {
        public LangForm()
        {
            InitializeComponent();

            var cur = Language.CurrentCulture;
            if (config.Mappings.TryGetValue(cur, out var lang_str))
            {

                if (config.Languages.ContainsKey(lang_str))
                {
                    var lang = config.Languages[lang_str];
                    langLabel.Text = lang.Name;
                    pictureBox1.Image = lang.FlagImage ?? ReadImage(lang.Flag);
                }
                else
                    langLabel.Text = $"No language '{lang_str}' ";
            }
            else
            {
                langLabel.Text = $"No mapping for {cur} :: {Language.CurrentCulture} :: {InputLanguage.CurrentInputLanguage.LayoutName}";
            }
            timeLabel.Text = DateTime.Now.ToString(config.Timestamp);
        }

        public LangForm(string title) : this()
        {
            Debug.WriteLine($"Станцевать переключение {title}");
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

        public static async Task CreateDefaultConfiguration()
        {
            using var sw = File.Create(Config.FileName);
            await JsonSerializer.SerializeAsync(sw, Config.Default);
        }

        private static bool initialized = false;
        private static bool Initialized => Initialized;
        private static Config config = new();
    }
}
