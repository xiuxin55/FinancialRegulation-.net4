using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.NewModel;
using System.Linq;
namespace Dao
{
    public class BillOperateDao:BaseDao
    {
        /// <summary>
        /// 今日对账单信息
        /// </summary>
        /// <param name="bills"></param>
        /// <returns></returns>
        public static List<BillFileCheck> SelectsTodayBill(BillFileCheck bfc)
        {
            return SqlMap.QueryForList<BillFileCheck>("SelectsTodayBill", bfc).ToList<BillFileCheck>();
        }
        /// <summary>
        /// 利息对账单信息
        /// </summary>
        /// <param name="bfc"></param>
        /// <returns></returns>
        public static List<InterestBillCheck> SelectsInterestBill(InterestBillCheck bfc)
        {
            return SqlMap.QueryForList<InterestBillCheck>("SelectsInterestBill", bfc).ToList<InterestBillCheck>();
        }
        
    }
}
