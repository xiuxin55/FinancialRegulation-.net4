using MahApps.Metro.Controls;
namespace FinancialRegulation.Page
{
    /// <summary>
    /// FundInfoManage.xaml 的交互逻辑
    /// </summary>
    public partial class TodayCheckBill : MetroContentControl
    {
        //TODO：此处声明与资金归集相同 错误原因在无法通过 节点绑定到后台的Command   2013年10月25日22:44:20  修改 因为明天要用了
        ViewModel.TodayCheckBillVM vm;
        public TodayCheckBill()
        {
            InitializeComponent();
            vm = new ViewModel.TodayCheckBillVM();
            this.DataContext = vm;
          
        }
    }
}