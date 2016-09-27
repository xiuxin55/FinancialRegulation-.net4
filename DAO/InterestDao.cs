using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.NewModel.BalanceAndInterest;
namespace Dao
{
    /// <summary>
    /// 季度结息
    /// </summary>
   public  class SeasonInterestDao : BasesDAO<SeasonInterest>
    {
        /// <summary>
        /// 构建 协议数据库操作类
        /// </summary>
        private SeasonInterestDao()
        {
            DefaultKey = "SeasonInterestInfo";
        }

        private static SeasonInterestDao _instance;
        /// <summary>
        /// 获取 协议数据库操作类实例
        /// </summary>
        public static SeasonInterestDao Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SeasonInterestDao();
                }
                return _instance;
            }
        }

        public override bool Add(SeasonInterest t)
        {
            return i(t);
        }
        public override bool Update(SeasonInterest t)
        {
            return u(t);
        }

        public override bool Delete(SeasonInterest t)
        {
            return d(t);
        }

        public override IList<SeasonInterest> Select(SeasonInterest t)
        {
            return s(t);
        }

        /// <summary>
        /// 查看数据库中所有利率
        /// </summary>
        /// <returns>利率集合</returns>
        public override IList<SeasonInterest> Selects()
        {
            return ss();
        }
    }
    /// <summary>
    ///每日余额信息
    /// </summary>
   public class DayBalanceDao : BasesDAO<DayBalance>
    {
        /// <summary>
        /// 构建 协议数据库操作类
        /// </summary>
        private DayBalanceDao()
        {
            DefaultKey = "DayBalanceInfo";
        }

        private static DayBalanceDao _instance;
        /// <summary>
        /// 获取 协议数据库操作类实例
        /// </summary>
        public static DayBalanceDao Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DayBalanceDao();
                }
                return _instance;
            }
        }

        public override bool Add(DayBalance t)
        {
            return i(t);
        }
        public override bool Update(DayBalance t)
        {
            return u(t);
        }

        public override bool Delete(DayBalance t)
        {
            return d(t);
        }

        public override IList<DayBalance> Select(DayBalance t)
        {
            return s(t);
        }

        /// <summary>
        /// 查看数据库中所有利率
        /// </summary>
        /// <returns>利率集合</returns>
        public override IList<DayBalance> Selects()
        {
            return ss();
        }
    }
}
