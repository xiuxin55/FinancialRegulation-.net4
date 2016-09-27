using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Common;

namespace TestProject
{
    class Program
    {
        [STAThread]
        static void Main(string [] args)
        {
            Form frmAutoUpdate = (Form)Assembly.LoadFrom("AutoUpdate.dll").CreateInstance("AutoUpdate.FrmUpdate");

            MainFrame.LoginWindow lw = new MainFrame.LoginWindow();
            lw.ShowDialog();
            if (lw.DialogResult == true)
            {
                App app = new App();
                app.Run(new MainFrame.MainWindow() {});
                lw.Close();
            }
            lw = null;
        }
    }
}
