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
    /// JG_SpvProtocolService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class JG_SpvProtocolService : System.Web.Services.WebService
    {
        JG_SpvProtocolDao daoHelp = JG_SpvProtocolDao.Instance;

        [WebMethod(Description = "添加监管协议")]
        public bool Add(JG_SpvProtocol o)
        {
            return daoHelp.Add(o);
        }
        [WebMethod(Description = "更新监管协议")]
        public bool Update(JG_SpvProtocol o)
        {
            return daoHelp.Update(o);
        }
        [WebMethod(Description = "删除监管协议")]
        public bool Delete(JG_SpvProtocol o)
        {
            return daoHelp.Delete(o);
        }
        [WebMethod(Description = "查看所有监管协议")]
        public List<JG_SpvProtocol> Selects()
        {
            return daoHelp.Selects() as List<JG_SpvProtocol>;
        }
        [WebMethod(Description = "查看特定监管协议")]
        public List<JG_SpvProtocol> Select(JG_SpvProtocol o)
        {
            return daoHelp.Select(o) as List<JG_SpvProtocol>;
        }


        [WebMethod]
        public List<JG_SpvProtocol> GetProtocolByCondition(JG_SpvProtocol jG_SpvProtocol ,string token)
        {
            return JG_SpvProtocolDao.GetProtocolByCondition(jG_SpvProtocol) as List<JG_SpvProtocol>;
        }
    }
}

