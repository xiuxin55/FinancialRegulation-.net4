using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System;
using FundsRegulatoryClient.JG_AccountManageSrv;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MahApps.Metro.Controls;
namespace FinancialRegulation.Page
{
    /// <summary>
    /// O1.xaml 的交互逻辑
    /// </summary>
    public partial class OpenAccountAddToEdit : MetroWindow
    {
        public OpenAccountAddToEdit(JG_AccountManageInfo account, ObservableCollection<JG_AccountManageInfo> Models)
        {
            InitializeComponent();
            if (account != null && Models != null)
            { header.Content = "账户修改"; }
            ViewModel.OpenAccountEditVM vm = new ViewModel.OpenAccountEditVM(account,Models);
            vm.windowClose = this.CloseWindow;
            this.DataContext = vm;
        }
        /// <summary>
        /// 只能输入纯数字
        /// </summary>
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
    
    }
}