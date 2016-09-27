using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace FinancialRegulation.Tools
{
    public class ZQLBConverter : IValueConverter
    {
        //由Parameter控制转换  表达式 输入值|输出值;输入值|输出值;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (value == null)
                return "";
            switch (value.ToString())
            {
                case "01":
                    return "缴款";
                case "02":
                    return "支付";
                case "03":
                    return "冲正";
                case "04":
                    return "补息";
                case "05":
                    return "退票";
                default:
                    return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
