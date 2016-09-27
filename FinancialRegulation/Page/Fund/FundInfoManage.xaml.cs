using MahApps.Metro.Controls;
namespace FinancialRegulation.Page
{
    /// <summary>
    /// FundInfoManage.xaml 的交互逻辑
    /// </summary>
    public partial class FundInfoManage : MetroContentControl
    {
        //TODO：此处声明与资金归集相同 错误原因在无法通过 节点绑定到后台的Command   2013年10月25日22:44:20  修改 因为明天要用了
        ViewModel.FundInfoManageVM vm;
        public FundInfoManage()
        {
            InitializeComponent();
            vm = new ViewModel.FundInfoManageVM();
            this.DataContext = vm;
            //vm.ShowSubWindowAction = this.ShowSubWindowAction;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            vm.RedChongCommand.Execute();
        }
    }
}