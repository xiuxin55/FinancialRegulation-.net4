using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using FinancialRegulation.ViewModel;
using BaseClient.SysConfigSrv;

namespace FinancialRegulation.Tools
{
    public class JGYHConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "";

            SysConfigInfo sysInfo = (SysConfigInfo)Common.CommonData.GetInstance().SysConfig;

            return sysInfo.BankName.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return null;
            throw new NotImplementedException();
        }
    }
}
