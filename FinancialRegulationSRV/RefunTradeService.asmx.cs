using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Dao;
using MODEL.NewModel;

namespace FinancialRegulationSRV
{
    /// <summary>
    /// RefunTradeService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class RefunTradeService : System.Web.Services.WebService
    {
        RefundTradeDao daoHelp = RefundTradeDao.Instance;

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
       
        [WebMethod(Description = "增加退票")]
        public bool Add(RefundTrade o)
        {
            return daoHelp.Add(o);
        }
        [WebMethod(Description = "查看所有[系统配置]")]
        public List<RefundTrade> Selects()
        {
            return daoHelp.Selects() as List<RefundTrade>;
        }
        [WebMethod(Description = "根据凭证编号查询需要退票信息")]
        public List<RefundTrade> Select(RefundTrade rt)
        {
            return daoHelp.Select(rt) as List<RefundTrade>;
        }
        
    }
}
