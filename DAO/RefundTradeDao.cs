using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.NewModel;

namespace Dao
{
    public class RefundTradeDao:BasesDAO<RefundTrade>
    {
         /// <summary>
        /// 
        /// </summary>
        private RefundTradeDao()
        {
            DefaultKey = "RefundTrade";
        }

        private static RefundTradeDao _instance;
        /// <summary>
        ///退票实例化
        /// </summary>
        public static RefundTradeDao Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RefundTradeDao();
                }
                return _instance;
            }
        }

        /// <summary>
        /// 增加退票信息
        /// </summary>
      
        public override bool Add(RefundTrade t)
        {
            return i(t);
        }
        /// <summary>
        /// 退票信息集合
        /// </summary>
        /// <returns>集合</returns>
        public override IList<RefundTrade> Selects()
        {
            return ss();
        }
        /// <summary>
        /// 根据凭证编号查询需要退票信息
        /// </summary>
        /// <returns>集合</returns>
        public override IList<RefundTrade> Select(RefundTrade rt)
        {
            return SqlMap.QueryForList<RefundTrade>("SearchRefunding", rt).ToList<RefundTrade>();
        }
    }
}
