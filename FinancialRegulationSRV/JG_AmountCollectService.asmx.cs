using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MODEL;
using Dao;

namespace FinancialRegulationSRV
{
    /// <summary>
    /// JG_AmountCollectService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class JG_AmountCollectService : System.Web.Services.WebService
    {
        JG_AmountCollectDao daoHelp =  JG_AmountCollectDao.Instance;

        [WebMethod(Description="添加资金归集")]
        public bool Add(JG_AmountCollectInfo o)
        {
            return daoHelp.Add(o);
        }
        [WebMethod(Description="更新资金归集")]
        public bool Update(JG_AmountCollectInfo o)
        {
            return daoHelp.Update(o);
        }
        [WebMethod(Description="删除资金归集")]
        public bool Delete(JG_AmountCollectInfo o)
        {
            return daoHelp.Delete(o);
        }
        [WebMethod(Description="查看所有资金归集")]
        public List<JG_AmountCollectInfo> Selects()
        {
            return daoHelp.Selects() as List<JG_AmountCollectInfo>;
        }
        [WebMethod(Description="查看特定资金归集")]
        public List<JG_AmountCollectInfo> Select(JG_AmountCollectInfo o)
        {
            return daoHelp.Select(o) as List<JG_AmountCollectInfo>;
        }
        [WebMethod(Description = "获取资金归集")]
        public System.Data.DataTable GetFundCollects()
        {
            return daoHelp.GetFundCollects();
        }
    }
}

