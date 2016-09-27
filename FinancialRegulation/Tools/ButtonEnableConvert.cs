using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
namespace FinancialRegulation.Tools
{
    public class ButtonEnableConvert:IValueConverter
    {
       public  object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal? enable = (decimal?)value;
            if (enable == 0 || enable == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       public object  ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
