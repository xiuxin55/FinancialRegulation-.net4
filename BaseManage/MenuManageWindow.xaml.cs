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
using MahApps.Metro.Controls;

namespace BaseManage
{
    /// <summary>
    /// MenuManageWindow.xaml 的交互逻辑 DockableContent
    /// </summary>
    public partial class MenuManageWindow : MetroContentControl
    {
        public MenuManageWindow()
        {
            InitializeComponent();
            this.DataContext = new MenuManageVM();
        }
    }
}
