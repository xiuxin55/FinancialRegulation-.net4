using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace FinancialRegulation.Tools
{
   public  class DateTimeConvert : IValueConverter
    {
       public  object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime dt =(DateTime) value ;
            return dt.ToShortDateString();
        }

        public  object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
