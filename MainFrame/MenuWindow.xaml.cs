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
using System.Windows.Shapes;
using AvalonDock;
using BaseClient;
using Srv= BaseClient.BaseManageSrv;
using lgsv=BaseClient.LoginSrv;
using MahApps.Metro.Controls;

namespace MainFrame
{
    /// <summary>
    /// MenuWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MenuWindow : MetroContentControl
    {
        public Action<lgsv.MenuItem> MenuItemDoubleClick { get; set; }

        public MenuWindow()
        {
            InitializeComponent();

        }
        public List<lgsv.MenuItem> menuitem { get; set; }

        private void menuTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void DockableContent_Loaded(object sender, RoutedEventArgs e)
        {

            //List<Srv.MenuItem> lmi = MenuClient.Current.GetMenu();
            this.menuTree.ItemsSource = menuitem;
        }

        private void menuTree_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MenuItemDoubleClick != null)
            {
                MenuItemDoubleClick.Invoke(menuTree.SelectedItem as lgsv.MenuItem);
            }
        }
    }
}
