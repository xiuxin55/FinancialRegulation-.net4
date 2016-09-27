using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MODEL.NewModel.BalanceAndInterest;
using MODEL.NewModel;
using MODEL;
using Dao;
using System.Collections;

namespace FinancialRegulationSRV
{
    /// <summary>
    /// InterestService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class InterestService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        private DayBalanceDao daoHelp = DayBalanceDao.Instance;

        [WebMethod(Description = "一天余额精确查询", MessageName = "SelectDay")]
        public List<DayBalance> Select(DayBalance selectDB)
        {
            return daoHelp.Select(selectDB).ToList<DayBalance>();
        }
        [WebMethod(Description = "季度精确查询", MessageName = "SelectSeason")]
        public List<SeasonInterest> Select(SeasonInterest selectDB)
        {
            return SeasonInterestDao.Instance.Select(selectDB).ToList<SeasonInterest>();
        }
       
        [WebMethod(Description = "增加当前账户每个季度结息信息")]
        public bool AddSeasonInterestInfo(SeasonInterest add)
        {
            return SeasonInterestDao.Instance.Add(add);
        }

        [WebMethod(Description = "修改增加当前账户每个季度结息信息")]
        public bool UpdateSeasonInterestInfo(SeasonInterest update)
        {
            return SeasonInterestDao.Instance.Update(update);
        }
        [WebMethod(Description = "删除增加当前账户每个季度结息信息")]
        public bool DeleteSeasonInterestInfo(SeasonInterest del)
        {
            return SeasonInterestDao.Instance.Delete(del);
        }

        [WebMethod(Description = "添加本季度每天余额信息")]
        public bool AddDayBalanceInfo(DayBalance add)
        {
            return daoHelp.Add(add);
        }
        [WebMethod(Description = "修改本季度每天余额信息")]
        public bool UpdateDayBalanceInfo(DayBalance upadte)
        {
            return daoHelp.Update(upadte);
        }

        [WebMethod(Description = "删除本季度每天余额信息")]
        public bool DeleteDayBalanceInfo(DayBalance del)
        {
            return daoHelp.Delete(del);
        }
        
    }
}
