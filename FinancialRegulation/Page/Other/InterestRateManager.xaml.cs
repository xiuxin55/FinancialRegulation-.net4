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

namespace FinancialRegulation.Page.Other
{
    /// <summary>
    /// InterestRateManager.xaml 的交互逻辑
    /// </summary>
    public partial class InterestRateManager : MetroContentControl
    {
        public InterestRateManager()
        {
            InitializeComponent();
            InterestRateVM im = new InterestRateVM();
            this.DataContext = im;
        }
    }
}
