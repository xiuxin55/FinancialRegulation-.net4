using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace FinancialRegulation.Tools
{
    public class ZJXZConverter:IValueConverter
    {
        //由Parameter控制转换  表达式 输入值|输出值;输入值|输出值;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (value == null)
                return "";
            switch (value.ToString())
            {
                case "10":
                    return "首付款";
                case "20":
                    return "分期款";
                case "30":
                    return "一次性付款";
                case "40":
                    return "商业贷款";
                case "50":
                    return "公积金贷款";
                case "00":
                    return "支付";
                case "60":
                    return "补息";
                case "70":
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
