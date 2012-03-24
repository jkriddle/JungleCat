using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace JungleCat.Receiver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form f = new ReceiverView();
            f.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            f.ShowInTaskbar = false;
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new System.Drawing.Point(-2000, -2000);
            f.Size = new System.Drawing.Size(1, 1);
            Application.Run(f);
        }
    }
}
