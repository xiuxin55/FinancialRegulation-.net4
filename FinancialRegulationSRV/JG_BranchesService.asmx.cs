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
    /// JG_BranchesService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class JG_BranchesService : System.Web.Services.WebService
    {
        JG_BranchesDao daoHelp =  JG_BranchesDao.Instance;

        [WebMethod(Description="添加银行网点")]
        public bool Add(JG_BranchesInfo o)
        {
            return daoHelp.Add(o);
        }
        [WebMethod(Description="更新银行网点")]
        public bool Update(JG_BranchesInfo o)
        {
            return daoHelp.Update(o);
        }
        [WebMethod(Description="删除银行网点")]
        public bool Delete(JG_BranchesInfo o)
        {
            return daoHelp.Delete(o);
        }
        [WebMethod(Description="查看所有银行网点")]
        public List<JG_BranchesInfo> Selects()
        {
            return daoHelp.Selects() as List<JG_BranchesInfo>;
        }
        [WebMethod(Description="查看特定银行网点")]
        public List<JG_BranchesInfo> Select(JG_BranchesInfo o)
        {
            return daoHelp.Select(o) as List<JG_BranchesInfo>;
        }
    }
}

