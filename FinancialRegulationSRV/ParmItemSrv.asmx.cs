using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Dao;
using MODEL;

namespace FinancialRegulationSRV
{
    /// <summary>
    /// ParmItemSrv 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class ParmItemSrv : System.Web.Services.WebService
    {

        /// <summary>
        /// 获取by条件
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [WebMethod]
        public List<ParmItem> SelectTheParmItem(ParmItem p)
        {
            return ParmItemDao.SelectTheParmItem(p) as List<ParmItem>;
        }
    }
}
