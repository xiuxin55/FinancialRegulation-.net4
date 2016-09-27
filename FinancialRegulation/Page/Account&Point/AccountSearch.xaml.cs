using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System;
using FundsRegulatoryClient.JG_AccountManageSrv;
using System.Collections.Generic;
using Microsoft.Practices.Prism.Commands;
using System.Collections.ObjectModel;
using MahApps.Metro.Controls;
namespace FinancialRegulation.Page
{
    /// <summary>
    /// O1.xaml 的交互逻辑
    /// </summary>
    public partial class AccountSearch : MetroWindow
    {
        public AccountSearch(Action<ObservableCollection<JG_AccountManageInfo>> likesearchCommand)
        {
            InitializeComponent();

            ViewModel.AccountSearchVM vm = new ViewModel.AccountSearchVM(likesearchCommand);
            vm.windowClose = this.CloseWindow;
            this.DataContext = vm;
        }

        private void TextBoxOnlyNUM_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    
    }
}