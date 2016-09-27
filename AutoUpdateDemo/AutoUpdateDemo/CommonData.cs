using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoUpdate
{
    class CommonData
    {
        private static CommonData _CommonData;

        public static CommonData Current
        {
            get
            {
                if (_CommonData == null)
                {
                    _CommonData = new CommonData();
                }
                return CommonData._CommonData;
            }
        }

        public string DownLoadAddress 
        {
            get { return "http://11.51.73.9/UpdateFile/"; }
            set { DownLoadAddress = value; }
        }
        public string CurrentDir
        {
            get { return AppDomain.CurrentDomain.BaseDirectory+"//"; }
            set { CurrentDir = value; }
        }

        public string DownLocalAddress
        {
            get { return @"..\..\bin\Debug\"; }
            set { DownLocalAddress = value; }
        }
    }
}
