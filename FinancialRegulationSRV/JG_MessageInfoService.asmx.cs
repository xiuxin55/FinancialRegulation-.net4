using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MODEL.NewModel;
using Dao;

namespace FinancialRegulationSRV
{
    /// <summary>
    /// JG_MessageInfoService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class JG_MessageInfoService : System.Web.Services.WebService
    {
        JG_MessageInfoDao daoHelp =  JG_MessageInfoDao.Instance;

        [WebMethod(Description="添加报文信息")]
        public bool Add(MessageInfo o)
        {
            return daoHelp.Add(o);
        }
        [WebMethod(Description="更新报文信息")]
        public bool Update(MessageInfo o)
        {
            return daoHelp.Update(o);
        }
        [WebMethod(Description="删除报文信息")]
        public bool Delete(MessageInfo o)
        {
            return daoHelp.Delete(o);
        }
        [WebMethod(Description="查看所有报文信息")]
        public List<MessageInfo> Selects()
        {
            return daoHelp.Selects() as List<MessageInfo>;
        }
        [WebMethod(Description="查看特定报文信息")]
        public List<MessageInfo> Select(MessageInfo o)
        {
            return daoHelp.Select(o) as List<MessageInfo>;
        }
    }
}

