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

namespace FinancialRegulation.Page.Fund.FundCollect
{
    /// <summary>
    /// InputMoney.xaml 的交互逻辑
    /// </summary>
    public partial class InputMoney : Window
    {
        public InputMoney()
        {
            InitializeComponent();
        }
        public decimal money;//账户余额
        public decimal jgmoney;
        /// <summary>
        /// 窗体标题
        /// </summary>
        public string WindowTitle
        {
            set{
                this.lab_Title.Content = value;
            }
        }
        
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            bool result = decimal.TryParse(moneytxt.Text, out money) && decimal.TryParse(jgmoneytxt.Text, out jgmoney);
            if (result)
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("输入的账户余额有误！");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
