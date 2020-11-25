using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StudentCS
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

            //登录
            FormLogin login = new FormLogin();
            login.ShowDialog();
            if(login.DialogResult == DialogResult.OK)
                Application.Run(new FormMain());
        }
    }
}
