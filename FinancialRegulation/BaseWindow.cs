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
using AvalonDock;
using System.Text.RegularExpressions;

namespace FinancialRegulation
{
    /// <summary>
    /// BaseWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BaseWindow : DockableContent
    {
        public BaseWindow()
        {
            ShowSubWindowAction = new Action<DockableContent, ShowModel>(ShowSubWindow);
        }
        public DockingManager DKM { get; set; }

        private void ShowSubWindow(DockableContent dc,ShowModel showmodel)
        {
            switch (showmodel)
            {
                case ShowModel.show: dc.Show(DKM); break;
                case ShowModel.ShowAsDocument: dc.ShowAsDocument(DKM); break;
                case ShowModel.ShowAsFloatingWindow: dc.ShowAsFloatingWindow(DKM, true); break;
            }
            
        }

        #region TA:2013年10月14日16:10:31 无法打开窗体用于打开窗体
        System.Windows.Window w = new System.Windows.Window();
        public void ShowWindow()
        {
            GetWindow().Show();
        }
        /// <summary>
        /// 关闭返回错误
        /// </summary>
        public void CloseWindow()
        {
            w.Close();
        }
        /// <summary>
        /// 窗体对话框返回true；
        /// </summary>
        public void OpenNewWindow()
        {
            w.DialogResult = true;
        }
        /// <summary>
        /// 关闭返回错误
        /// </summary>
        public bool? ShowDialog()
        {
            GetWindow().ShowDialog();
            return w.DialogResult;
        }
        private System.Windows.Window GetWindow()
        {
            if (w.Content != null) w.Content = null;
            w.Title = this.Tag.ToString();
            w.Icon = this.Icon;
            w.MinWidth = MinWidth;
            w.MinHeight = MinHeight+30;
            w.Width = MinWidth;
            w.Height = MinHeight+30;
            w.Content = this;
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            return w;
        }

        #endregion


         #region TextBox的输入限制
        /// <summary>
        /// 只能输入中文
        /// </summary>Blicae
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextBoxOnlyCHN_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
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
        /// 只能输入数字和小数点，且只能由一个小数点
        /// </summary>Blicae
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextBoxNUMPeriod_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;

            //屏蔽非法按键
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key == Key.Decimal || e.Key.ToString() == "Tab")
            {
                if (txt.Text.Contains(".") && e.Key == Key.Decimal)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9) || e.Key == Key.OemPeriod) && e.KeyboardDevice.Modifiers != ModifierKeys.Shift)
            {
                if (txt.Text.Contains(".") && e.Key == Key.OemPeriod)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
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
        public void TextBoxSFZ_KeyDown(object sender, KeyEventArgs e)
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
        /// 只能输入纯数字（身份证）
        /// </summary>Blicae
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextBoxOnlyNUM_KeyDown(object sender, KeyEventArgs e)
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
        public Action<DockableContent, ShowModel>  ShowSubWindowAction;
        
    }
    public enum ShowModel
    {
        show = 1,
        ShowAsDocument = 2,
        ShowAsFloatingWindow
    }
}
