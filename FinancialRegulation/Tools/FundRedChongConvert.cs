
namespace FinancialRegulation.Tools
{
    using System;
    using System.Windows.Data;

    /// <summary>
    /// 存款红冲是否启用
    /// </summary>
    public class FundRedChongConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value==null) return true;
            if (value.ToString() == "9")//如果是存款红冲状态的话 按钮为禁用
            {
                return false;
            }
            return true;
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
