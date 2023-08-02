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
            await ShowForm("IL");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await ShowForm("US");
        }

        private static async Task ShowForm(string title)
        {
            using var msg = new LangForm(title);
            msg.StartPosition = FormStartPosition.Manual;
            msg.Location = new Point(Screen.PrimaryScreen != null ? (Screen.PrimaryScreen.Bounds.Width - msg.Width) / 2 : 500, 0);
            msg.Show();
            await Task.Delay(1000);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await LangForm.CreateDefaultConfiguration();
            await LangForm.InitializeAsync();
        }
    }
}