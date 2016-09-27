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
using System.Windows.Shapes;

namespace FinancialRegulation.Page.Fund
{
    /// <summary>
    /// ProtocolManage.xaml 的交互逻辑
    /// </summary>
    public partial class UnKnownInfoManage : MetroContentControl
    {
        UnKnownInfoManageVM uk = new UnKnownInfoManageVM();
        public UnKnownInfoManage()
        {
            InitializeComponent();
            
            this.DataContext = uk;
        }
        /// <summary>
        /// 关联缴存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkDepositCommand_Click(object sender, RoutedEventArgs e)
        {
            uk.LinkDepositExecute();
        }
    }
}
