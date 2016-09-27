using System.Windows.Controls;
using FundsRegulatoryClient.JG_DepositSrv;
using MahApps.Metro.Controls;
namespace FinancialRegulation.Page.UnknowBillPage
{
    /// <summary>
    /// FundInfoManage.xaml 的交互逻辑
    /// </summary>
    public partial class FundInfoManage : MetroWindow
    {
        //TODO：此处声明与资金归集相同 错误原因在无法通过 节点绑定到后台的Command   2013年10月25日22:44:20  修改 因为明天要用了
        ViewModel.UnknowBillPage.FundInfoManageVM vm;
       
        public string LinkID { get; set; }//不明账款ID
        public FundInfoManage(UnknowBill ub)
        {
            InitializeComponent();
           
            vm = new ViewModel.UnknowBillPage.FundInfoManageVM( ub);
            this.DataContext = vm;
           
            //vm.ShowSubWindowAction = this.ShowSubWindowAction;
            vm.LinkID = this.LinkID;
        }
        
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            vm.RedChongCommand.Execute();
        }
        /// <summary>
        /// 缴存关联
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Link_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            
            if (vm != null && cb!=null)
            {
                vm.SelectColomn(cb.IsChecked.Value);
            }
        }

      /// <summary>
      /// 列头选中
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private void LinkHeader_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            CheckBox cb=sender as CheckBox;
            //if (cb.IsChecked.Value)
            //{
                if (vm != null)
                {
                    vm.HeaderIsChecked(cb.IsChecked.Value);
                }
                //this.dataGrid1.Items
            //}
        }

        private void LinkHeader_Checked2(object sender, System.Windows.RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            //if (cb.IsChecked.Value)
            //{
            if (vm != null)
            {
                vm.HeaderIsChecked2(cb.IsChecked.Value);
            }
            //this.dataGrid1.Items
            //}
        }
    }
}