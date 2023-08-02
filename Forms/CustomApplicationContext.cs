using Forms.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Language
{
    /// <summary>
    /// https://stackoverflow.com/questions/995195/how-can-i-make-a-net-windows-forms-application-that-only-runs-in-the-system-tra
    /// </summary>
    internal class CustomApplicationContext : ApplicationContext
    {
        private NotifyIcon trayIcon;

        public CustomApplicationContext()
        {
            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Icon = null,
                ContextMenuStrip = new ContextMenuStrip(),
                Visible = true
            };


            void Exit(object sender, EventArgs e)
            {
                // Hide tray icon, otherwise it will remain shown until user mouses over it
                trayIcon.Visible = false;

                Application.Exit();
            }
        }
    

        private ContextMenuStrip taskBarMenu;
        private ToolStripMenuItem showTestFormToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}