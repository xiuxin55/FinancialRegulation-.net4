using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows.Input;
using FundsRegulatoryClient.JG_DepositSrv;
using System.Collections.ObjectModel;
using MahApps.Metro.Controls;
namespace FinancialRegulation.Page.Fund
{
    /// <summary>
    /// O1.xaml 的交互逻辑
    /// </summary>
    public partial class ReverseTrade : MetroWindow
    {

        public ReverseTrade(DepositFund df, ObservableCollection<DepositFund> models)
        {
            InitializeComponent();
            ViewModel.Fund.ReverseTradeVM vm = new ViewModel.Fund.ReverseTradeVM(df, models);
            vm.windowClose = CloseWindow;
            vm.windowOK = OpenNewWindow;
            this.DataContext = vm;
        }


        #region TextBox的输入限制
        /// <summary>
        /// 只能输入中文
        /// </summary>Blicae
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxOnlyCHN_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            TextChange[] change = new TextChange[e.Changes.Count];
            e.Changes.CopyTo(change, 0);

            int offset = change[0].Offset;
            if (change[0].AddedLength == 1)
            {
                Regex reg = new Regex("^[\u4e00-\u9fa5]$");
                if (!reg.IsMatch(textBox.Text.Substring(offset, change[0].AddedLength)))
                {
                    textBox.Text = textBox.Text.Remove(offset, change[0].AddedLength);
                    textBox.Select(offset, 0);
                }
            }
        }

        /// <summary>
        /// 只能输入数字
        /// </summary>Blicae
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxNUMPeriod_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;

            //屏蔽非法按键
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key.ToString() == "Tab")
            {
                e.Handled = false;
                  return;

            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)) && e.KeyboardDevice.Modifiers != ModifierKeys.Shift)
            {

                e.Handled = false;
                    return;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 只能输入数字和大写X（身份证）
        /// </summary>Blicae
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSFZ_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;

            //屏蔽非法按键
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || ((e.Key >= Key.D0 && e.Key <= Key.D9) && e.KeyboardDevice.Modifiers != ModifierKeys.Shift) || e.Key == Key.X || e.Key.ToString() == "Tab")
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 只能输入纯数字
        /// </summary>Blicae
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxOnlyNUM_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;

            //屏蔽非法按键
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || ((e.Key >= Key.D0 && e.Key <= Key.D9) && e.KeyboardDevice.Modifiers != ModifierKeys.Shift) || e.Key.ToString() == "Tab")
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion

        

       
    }
}