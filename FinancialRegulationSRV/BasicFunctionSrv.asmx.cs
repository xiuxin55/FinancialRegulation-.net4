using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace FinancialRegulationSRV
{
    /// <summary>
    /// BasicFunctionSrv 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BasicFunctionSrv : System.Web.Services.WebService
    {
        [WebMethod]
        public object GetSerialNo()
        {
            return Dao.BasicFunctionDao.GetSerialNo();
        }


        [WebMethod]
        public object GetErrorSerialNo()
        {
            return Dao.BasicFunctionDao.GetErrorSerialNo();
        }

        [WebMethod]
        public DateTime GetServerTime()
        {
            return DateTime.Now;
        }
    }
}
