namespace Forms
{
    partial class MainForm : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            bShow = new Button();
            bSwitch = new Button();
            bCreate = new Button();
            mainMenu = new ContextMenuStrip(components);
            showTestFormToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            taskBarIcon = new NotifyIcon(components);
            lblInfo = new Label();
            mainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // bShow
            // 
            bShow.Location = new Point(171, 106);
            bShow.Name = "bShow";
            bShow.Size = new Size(75, 23);
            bShow.TabIndex = 0;
            bShow.Text = "Show";
            bShow.UseVisualStyleBackColor = true;
            bShow.Click += ShowDefault;
            // 
            // bSwitch
            // 
            bSwitch.Location = new Point(252, 106);
            bSwitch.Name = "bSwitch";
            bSwitch.Size = new Size(75, 23);
            bSwitch.TabIndex = 1;
            bSwitch.Text = "US";
            bSwitch.UseVisualStyleBackColor = true;
            bSwitch.Click += ShowUS;
            // 
            // bCreate
            // 
            bCreate.Location = new Point(12, 106);
            bCreate.Name = "bCreate";
            bCreate.Size = new Size(153, 23);
            bCreate.TabIndex = 2;
            bCreate.Text = "Create (overwrite!) config";
            bCreate.UseVisualStyleBackColor = true;
            bCreate.Click += CreateDefaultConfiguration;
            // 
            // mainMenu
            // 
            mainMenu.Items.AddRange(new ToolStripItem[] { showTestFormToolStripMenuItem, exitToolStripMenuItem });
            mainMenu.Name = "contextMenuStrip1";
            mainMenu.Size = new Size(170, 48);
            // 
            // showTestFormToolStripMenuItem
            // 
            showTestFormToolStripMenuItem.Name = "showTestFormToolStripMenuItem";
            showTestFormToolStripMenuItem.Size = new Size(169, 22);
            showTestFormToolStripMenuItem.Text = "Show information";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(169, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += Exit;
            // 
            // taskBarIcon
            // 
            taskBarIcon.ContextMenuStrip = mainMenu;
            taskBarIcon.Icon = (Icon)resources.GetObject("taskBarIcon.Icon");
            taskBarIcon.Text = "notifyIcon1";
            taskBarIcon.Visible = true;
            // 
            // lblInfo
            // 
            lblInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(-426, 55);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(812, 15);
            lblInfo.TabIndex = 3;
            lblInfo.Text = "Trying to create an appropriate language indicator with an ability to show current language without lqanding a mousepointer into autohided taskbar part";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 141);
            Controls.Add(lblInfo);
            Controls.Add(bCreate);
            Controls.Add(bSwitch);
            Controls.Add(bShow);
            Name = "MainForm";
            ShowInTaskbar = false;
            Text = "Form1";
            Load += Form1_Load;
            mainMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bShow;
        private Button bSwitch;
        private Button bCreate;
        private ContextMenuStrip mainMenu;
        private ToolStripMenuItem showTestFormToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private NotifyIcon taskBarIcon;
        private Label lblInfo;
    }
}