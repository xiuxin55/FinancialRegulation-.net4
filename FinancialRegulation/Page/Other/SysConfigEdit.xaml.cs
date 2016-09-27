using MahApps.Metro.Controls;
namespace FinancialRegulation.Page
{
    /// <summary>
    /// O1.xaml 的交互逻辑
    /// </summary>
    public partial class SysConfigEdit : MetroContentControl
    {
        public SysConfigEdit()
        {
            InitializeComponent();
            ViewModel.SysConfigEditVM vm = new ViewModel.SysConfigEditVM();
            this.DataContext = vm;
        }

    }
}