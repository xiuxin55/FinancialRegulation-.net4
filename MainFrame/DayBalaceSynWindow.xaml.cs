using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Srv = BaseClient.BaseManageSrv;
using System.Xml;
using System.Reflection;
using AvalonDock;
using System.IO;
using FinancialRegulation;
using lgsv=BaseClient.LoginSrv;
using MahApps.Metro.Controls;
using Microsoft.Practices.Prism.Commands;


namespace MainFrame
{
    /// <summary>
    /// DayBalaceSynWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DayBalaceSynWindow : MetroWindow
    {

        public DayBalaceSynWindow()
        {
            this.DataContext = new DayBalaceSynVM();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
