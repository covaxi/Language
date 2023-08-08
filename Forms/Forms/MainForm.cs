using Language;

namespace Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LangForm.InitializeAsync();
        }

        private async void ShowDefault(object sender, EventArgs e)
        {
            taskBarIcon.Icon = Language.CurrentLanguage.IconImage;
            await Popup.ShowForm();
        }

        private async void ShowUS(object sender, EventArgs e)
        {
            taskBarIcon.Icon = Language.CurrentLanguage.IconImage;
            await Popup.ShowForm("US");
        }

        private async void CreateDefaultConfiguration(object sender, EventArgs e)
        {
            await LangForm.CreateDefaultConfiguration();
            await LangForm.InitializeAsync();
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}