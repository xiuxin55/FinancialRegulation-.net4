using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using FundsRegulatoryClient.InterestService;
using FundsRegulatoryClient.JG_AccountManageSrv;

namespace FundsRegulatoryClient
{
    /// <summary>
    /// 利息管理
    /// </summary>
    public class InterestManageClient : BaseClient<InterestService.InterestService>
    {
        private static InterestManageClient _instance;
        /// <summary>
        /// 利息管理
        /// </summary>
        public static InterestManageClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InterestManageClient();
                }
                return _instance;
            }
        }

        /// <summary>
        /// 获取所有季度结息信息
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<InterestService.SeasonInterest> SelectJG_SeasonInterestInfo(SeasonInterest si)
        {
          
           
            ObservableCollection<InterestService.SeasonInterest> oj=null;
            try
            {
                List<InterestService.SeasonInterest> temp = service.Select(si).ToList<InterestService.SeasonInterest>();
                oj = new ObservableCollection<InterestService.SeasonInterest>();
                temp.ForEach(p => oj.Add(p));
            }
            catch(Exception ex)
            {
              //  throw new ArgumentNullException(ex.ToString());

            }

            return oj;
        }

        /// <summary>
        /// 增加一个季度利息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool AddJG_SeasonInterestInfo(InterestService.SeasonInterest ssii)
        {
            return service.AddSeasonInterestInfo(ssii);
        }

        /// <summary>
        /// 修改一个季度利息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool UpdateJG_SeasonInterestInfo(InterestService.SeasonInterest ssii)
        {
            return service.UpdateSeasonInterestInfo(ssii);
        }
        /// <summary>
        /// 删除一个季度利息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool DeleteJG_SeasonInterestInfo(InterestService.SeasonInterest ssii)
        {
            return service.DeleteSeasonInterestInfo(ssii);
        }
        /// <summary>
        /// 获取所一个季度每天余额信息
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<InterestService.DayBalance> SelectJG_DayBalanceInfo(DayBalance db)
        {
            List<InterestService.DayBalance> temp = service.Select(db).ToList<InterestService.DayBalance>();
            ObservableCollection<InterestService.DayBalance > oj = new ObservableCollection<InterestService.DayBalance>();
            temp.ForEach(p => oj.Add(p));
            return oj;
        }
       
        /// <summary>
        /// 增加一条今天余额
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool AddJG_DayBalanceInfo(InterestService.DayBalance ssii)
        {
            return service.AddDayBalanceInfo(ssii);
        }

        /// <summary>
        /// 修改一天余额
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool UpdateJG_DayBalanceInfo(InterestService.DayBalance ssii)
        {
            return service.UpdateDayBalanceInfo(ssii);
        }
        /// <summary>
        /// 删除一个季度利息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool DeleteJG_DayBalanceInfo(InterestService.DayBalance ssii)
        {
            return service.DeleteDayBalanceInfo(ssii);
        }

       
    }
}
