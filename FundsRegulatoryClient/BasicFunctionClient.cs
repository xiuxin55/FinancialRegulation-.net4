using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundsRegulatoryClient
{
    public class BasicFunctionClient
    {
        private static BasicFunctionSrv.BasicFunctionSrv bs;
        private static BasicFunctionClient current = null;
        public static BasicFunctionClient Current
        {
            get 
            {
                if (current == null)
                {
                    current = new BasicFunctionClient();
                }
                return current;
            }
        }
        private BasicFunctionClient()
        {
            bs = new BasicFunctionSrv.BasicFunctionSrv();
            Common.CommonFunction.SetBaseWebReference(bs);
        }

        public string GetSerialNo()
        {
            return bs.GetSerialNo().ToString().PadLeft(8,'0');
        }

        public string GetErrorSerialNo()
        {
            return bs.GetErrorSerialNo().ToString();
        }

        public DateTime GetServerTime()
        {
            return bs.GetServerTime();
        }
    }
}
