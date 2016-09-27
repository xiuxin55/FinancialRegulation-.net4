using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Dao;
using System.Data;

namespace FinancialRegulationSRV
{
    /// <summary>
    /// FunSrv 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class FunSrv : System.Web.Services.WebService
    {
        [WebMethod]
        public DataSet getFunData()
        {
            return FunBiz.getFunData();
        }

        [WebMethod]
        public bool AddFun(DataSet ds)
        {
            return FunBiz.AddFun(ds);
        }

        [WebMethod]
        public bool DeleteFun(string id)
        {
            return FunBiz.DeleteFun(id);
        }

        [WebMethod]
        public DataSet GetDutyFun(string dutyid)
        {
            return FunBiz.GetDutyFun(dutyid);
        }
        [WebMethod]
        public bool SetFun(string dutyid, string[] funids)
        {
            return FunBiz.SetFun(dutyid, funids);
        }
    }
}
