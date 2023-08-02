using Language;

namespace WinFormsApp1
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

        private async void button1_Click(object sender, EventArgs e)
        {
            await Popup.ShowForm("IL");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await Popup.ShowForm("US");
        }



        private async void button3_Click(object sender, EventArgs e)
        {
            await LangForm.CreateDefaultConfiguration();
            await LangForm.InitializeAsync();
        }
    }
}