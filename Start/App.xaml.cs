using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;

namespace Start
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    //public partial class App : Application
    //{
    //}
    public partial class App : Application
    {
  
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            System.Windows.Forms.Form frmAutoUpdate = (System.Windows.Forms.Form)Assembly.LoadFrom("AutoUpdate.dll").CreateInstance("AutoUpdate.FrmUpdate");
            MainFrame.LoginWindow lw = new MainFrame.LoginWindow();

            if (lw.ShowDialog() == true)
            {
                Window w = new MainFrame.MainWindow();
 
                lw.Close();
                w.Show();
            }

            lw = null;
        }
    }
}
