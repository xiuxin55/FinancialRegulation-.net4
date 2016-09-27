using MahApps.Metro.Controls;
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


namespace FinancialRegulation.Page
{
    /// <summary>
    /// O1.xaml 的交互逻辑
    /// </summary>
    public partial class PointEdit : MetroWindow
    {
        public PointEdit()
        {
            InitializeComponent();
            FinancialRegulation.ViewModel.PointManageEditVM vm = new ViewModel.PointManageEditVM();
            vm.windowClose = CloseWindow;
            this.DataContext = vm;
        }
        public PointEdit(FinancialRegulation.ViewModel.PointManageEditVM vm)
        {
            InitializeComponent();
            if (vm == null) throw new NullReferenceException("Vm is Null");
            vm.windowClose = CloseWindow;
            this.DataContext = vm;
        }
       
    }
}

