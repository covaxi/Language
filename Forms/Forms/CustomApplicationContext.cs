using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Forms
{
    /// <summary>
    /// https://stackoverflow.com/questions/995195/how-can-i-make-a-net-windows-forms-application-that-only-runs-in-the-system-tra
    /// </summary>
    internal class CustomApplicationContext : ApplicationContext
    {
        private NotifyIcon trayIcon;
        private ContextMenuStrip mainMenu;

        public CustomApplicationContext()
        {
            components = new System.ComponentModel.Container();
            mainMenu = new ContextMenuStrip(components);
            mainMenu.SuspendLayout();
            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Icon = null,
                ContextMenuStrip = new ContextMenuStrip(),
                Visible = true
            };

            Application.ApplicationExit += Application_ApplicationExit;


            void Exit(object sender, EventArgs e)
            {
                // Hide tray icon, otherwise it will remain shown until user mouses over it
                trayIcon.Visible = false;

                Application.Exit();
            }
        }

        private void Application_ApplicationExit(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private ToolStripMenuItem showTestFormToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
    }
}