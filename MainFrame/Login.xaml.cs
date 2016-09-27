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

namespace MainFrame
{
    /// <summary>
    /// Test.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    { 
        public LoginWindow()
        {
            InitializeComponent();
            TxtName.Focus();
            this.DataContext = new LoginVM();
            this.CloseAction = new Action(CloseWindow);
            (this.DataContext as LoginVM).CloseAction = this.CloseAction;
        }

        public Action CloseAction { get; set; }


        public void CloseWindow()
        {
            this.DialogResult = true;
            //this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
