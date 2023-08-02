using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class LangForm : Form
    {
        public LangForm()
        {
            InitializeComponent();
        }

        public LangForm(string title) : this()
        {
            var cur = System.Windows.Forms.InputLanguage.CurrentInputLanguage.Culture.Name;
            if (config.Mappings.TryGetValue(cur, out var lang_str))
            {

                if (config.Languages.ContainsKey(lang_str))
                {
                    var lang = config.Languages[lang_str];
                    label1.Text = lang.Name;
                    pictureBox1.Image = lang.FlagImage ?? ReadImage(title);
                }
                else
                    label1.Text = $"No language '{lang_str}' ";
            }
            else
            {
                label1.Text = $"No mapping for {cur} :: {InputLanguage.CurrentInputLanguage.LayoutName} :: {InputLanguage.CurrentInputLanguage.LayoutName}";
            }
        }

        static Image ReadImage(string filePath)
        {
            using var fileStream = new FileStream(Config.ParseDirectory(filePath), FileMode.Open,
                FileAccess.Read, FileShare.Read, 4096, true);
            return Image.FromStream(fileStream, true);
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
                lang.Value.FlagImage = ReadImage(lang.Value.Flag);
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
