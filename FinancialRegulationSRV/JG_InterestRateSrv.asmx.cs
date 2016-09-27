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
    /// JG_InterestRateSrv 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class JG_InterestRateSrv : System.Web.Services.WebService
    {
        [WebMethod(Description = "返回所有利率")]
        public List<JG_InterestRateInfo> SelectJG_InterestRateInfo()
        {
            return JG_InterestRateDao.Instance.Selects() as List<JG_InterestRateInfo>;
        }


        [WebMethod(Description = "新增")]
        public bool AddJG_InterestRateInfo(JG_InterestRateInfo jirInfo)
        {
            return JG_InterestRateDao.Instance.Add(jirInfo);
        }

        [WebMethod(Description = "修改")]
        public bool UpdateJG_InterestRateInfo(JG_InterestRateInfo jirInfo)
        {
            return JG_InterestRateDao.Instance.Update(jirInfo);
        }
        [WebMethod(Description = "获取协议利息总额")]
        /// <summary>
        /// 获取协议利息总额
        /// </summary>
        /// <param name="protocolNo"></param>
        /// <returns></returns>
        public decimal InterestInquire(string protocolNo)
        {
            return Dao.JG_InterestRateDao.InterestInquire(protocolNo);
        }
    }
}
