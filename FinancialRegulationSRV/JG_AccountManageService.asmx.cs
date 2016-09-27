using System.Collections.Generic;
using System.Web.Services;
using Dao;
using MODEL;

namespace FinancialRegulationSRV
{
    /// <summary>
    /// JG_AccountManageService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class JG_AccountManageService : System.Web.Services.WebService
    {
        private JG_AccountManageDao daoHelp = JG_AccountManageDao.Instance;

        [WebMethod(Description = "添加监管账户")]
        public bool Add(JG_AccountManageInfo o)
        {
            return daoHelp.Add(o);
        }

        [WebMethod(Description = "更新监管账户")]
        public bool Update(JG_AccountManageInfo o)
        {
            return daoHelp.Update(o);
        }

        [WebMethod(Description = "删除监管账户")]
        public bool Delete(JG_AccountManageInfo o)
        {
            return daoHelp.Delete(o);
        }

        [WebMethod(Description = "查看所有监管账户")]
        public List<JG_AccountManageInfo> Selects()
        {
            return daoHelp.Selects() as List<JG_AccountManageInfo>;
        }

        [WebMethod(Description = "查看特定监管账户")]
        public List<JG_AccountManageInfo> Select(JG_AccountManageInfo o)
        {
            return daoHelp.Select(o) as List<JG_AccountManageInfo>;
        }

        [WebMethod(Description = "获得所有公司")]
        public List<JG_AccountManageInfo> GetAllCorp()
        {
            return daoHelp.GetAllCorp() as List<JG_AccountManageInfo>;
        }
    }
}