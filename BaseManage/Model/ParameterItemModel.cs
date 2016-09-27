using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;

namespace BaseManage
{
    public class ParameterItemModel : NotificationObject
    {
        private string dataName;

        public string DataName
        {
            get { return dataName; }
            set
            {
                dataName = value;
                this.RaisePropertyChanged("DataName");
            }
        }

        private string dataType;

        public string DataType
        {
            get { return dataType; }
            set
            {
                dataType = value;
                this.RaisePropertyChanged("DataType");
            }
        }

        private string dataValue;

        public string DataValue
        {
            get { return dataValue; }
            set
            {
                dataValue = value;
                this.RaisePropertyChanged("DataValue");
            }
        }
    }
}
