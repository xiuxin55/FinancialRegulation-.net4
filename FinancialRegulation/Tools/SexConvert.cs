using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
namespace FinancialRegulation.Tools
{
    public class SexConvert : IValueConverter
    {
       public  object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
           if(value == null) { return 0; }
            string str = value.ToString();
            if (str=="男")
            {
                return 0;
            }
            return 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) { return null; }
            int index = (int)value;
            if (index == 0)
            {
                return "男";
            }
            return "女";
        }
    }
}
