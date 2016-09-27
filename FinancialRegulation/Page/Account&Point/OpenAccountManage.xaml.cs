using MahApps.Metro.Controls;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace FinancialRegulation.Page
{
    /// <summary>
    /// OpenAccountManage.xaml 的交互逻辑
    /// </summary>
    public partial class OpenAccountManage : MetroContentControl
    {
        public OpenAccountManage()
        {
            InitializeComponent();
            ViewModel.OpenAccountManageVM vm = new ViewModel.OpenAccountManageVM(this.dataGrid1);
            this.DataContext = vm;
            
        }
       
  
    }
}