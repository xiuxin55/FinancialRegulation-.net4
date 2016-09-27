using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace FinancialRegulation.Tools
{
    public class LinkSateConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            string v ="";
            if (value != null)
            {
                v = value.ToString();
            }
            if (v == "Y")
            {
                return "已关联";
            }
            return "未关联";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
