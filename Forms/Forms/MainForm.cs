using Configuration;
using Forms.Forms;
using gma.System.Windows;
using System.Diagnostics;

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
            await Config.InitializeAsync();
            await LangForm.InitializeAsync();

            actHook = new UserActivityHook(); // crate an instance with global hooks
                                              // hang on events

            //actHook.OnMouseActivity += new MouseEventHandler(MouseMoved);
            actHook.KeyDown += ActHook_KeyDown;
            actHook.KeyPress += ActHook_KeyPress;
            actHook.KeyUp += ActHook_KeyUp;

            Application.ApplicationExit += Application_ApplicationExit;

            actHook.Start();

        }

        private void Application_ApplicationExit(object? sender, EventArgs e)
        {
            actHook.Stop();
        }

        private void ActHook_KeyUp(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LMenu && timer1.Enabled)
            {
                timer1.Stop();
            }
        }

        private void ActHook_KeyPress(object? sender, KeyPressEventArgs e)
        {
            Debug.WriteLine("KeyPress");
        }

        private void ActHook_KeyDown(object? sender, KeyEventArgs e)
        {
            Debug.WriteLine($"KeyDown KeyValue:{e.KeyValue} KeyCode:{e.KeyCode} KeyData:{e.KeyData}");
            if (e.KeyCode == Keys.LMenu && !timer1.Enabled)
            {
                timer1.Start();
            }
        }

        private async void ShowDefault(object sender, EventArgs e)
        {
            await Popup.ShowLanguageForm();
        }

        private async void ShowUS(object sender, EventArgs e)
        {
            await Popup.ShowLanguageForm("US");
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

        private UserActivityHook actHook;

        private void showTestFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Focus();
            Show();
            Activate();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            await Popup.ShowLanguageForm();
        }
    }
}