

namespace FinancialRegulation.Tools
{
    using System;
    using System.Windows.Data;

    /// <summary>
    /// 自定义转换吧....
    /// </summary>
    public class CommonConvert : IValueConverter
    {
        //由Parameter控制转换  表达式 输入值|输出值;输入值|输出值;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string[] ConvertList = parameter.ToString().TrimEnd(';').Split(';'); //获取所有对应组
            foreach (string item in ConvertList)
            {
                string[] ct = item.Split('|');
                if (value.ToString() == ct[0]) return ct[1];
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
