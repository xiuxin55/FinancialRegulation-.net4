using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FundsRegulatoryClient
{
    public class FunClient
    {
        private static FunSrv.FunSrv funsrv;

        private static FunClient _CurrentInstance = null;

        public static FunClient Current
        {
            get
            {
                if (_CurrentInstance == null)
                {
                    _CurrentInstance = new FunClient();
                }
                return _CurrentInstance;
            }            
        }
        private FunClient()
        {
            funsrv = new FunSrv.FunSrv() ;
            Common.CommonFunction.SetBaseWebReference(funsrv);
        }

        public DataSet getFunData()
        {
            return funsrv.getFunData();
        }

        public bool AddFun(DataSet ds)
        {
            return funsrv.AddFun(ds);
        }

        public bool DeleteFun(string id)
        {
            return funsrv.DeleteFun(id);
        }

        public DataSet GetDutyFun(string dutyid)
        {
            return funsrv.GetDutyFun(dutyid);
        }

        public bool SetFun(string dutyid, string[] funids)
        {
            return funsrv.SetFun(dutyid, funids);
        }
    }
}
