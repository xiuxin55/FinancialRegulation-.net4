﻿using System;
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
using FinancialRegulation.ViewModel;

namespace FinancialRegulation.Page.Fund.FundCollect
{
    /// <summary>
    /// BillConditionWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BillConditionWindow : Window
    {
        public BillConditionWindow()
        {
            InitializeComponent();
        }
        //public BillConditionWindow(FundCollectManageVM fcm)
        //    : this()
        //{
        //    gbMain.DataContext = fcm;
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
