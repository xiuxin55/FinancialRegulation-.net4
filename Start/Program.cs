using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Reflection;


namespace Start
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
          //  Form frmAutoUpdate = (Form)Assembly.LoadFrom("AutoUpdate.dll").CreateInstance("AutoUpdate.FrmUpdate");
            MainFrame.LoginWindow lw = new MainFrame.LoginWindow();

            if (lw.ShowDialog() == true)
            {
                App app = new App();
                Window w = new MainFrame.MainWindow();
                app.Run(w);
                lw.Close();
            }

            lw = null;


            //if (lw.DialogResult == true)
            //{
            //    App app = new App();
            //    app.Run(new MainFrame.MainWindow() { });
            //    lw.Close();
            //}
            //lw = null;
        }
    }
}
