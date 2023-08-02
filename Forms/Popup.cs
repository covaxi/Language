using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace Language
{
    internal class Popup
    {
        public static async Task ShowForm(string title)
        {
            using var msg = new LangForm(title);
            msg.StartPosition = FormStartPosition.Manual;
            msg.Location = new Point(Screen.PrimaryScreen != null ? (Screen.PrimaryScreen.Bounds.Width - msg.Width) / 2 : 500, 0);
            msg.Show();
            await Task.Delay(1000);
        }
    }
}
