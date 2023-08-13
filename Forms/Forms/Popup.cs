﻿using Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.Forms
{
    internal class Popup
    {
        public static async Task ShowForm(string title = "")
        {
            MainForm.taskBarIcon.Icon = Language.CurrentLanguage.IconImage; // TODO: Move to upper level
            await LangForm.InitializeAsync();
            using var msg = new LangForm(title);
            msg.StartPosition = FormStartPosition.Manual;
            msg.Location = new Point(Screen.PrimaryScreen != null ? (Screen.PrimaryScreen.Bounds.Width - msg.Width) / 2 : 500, 0);
            msg.Show();
            await Task.Delay(1000);
        }
    }
}