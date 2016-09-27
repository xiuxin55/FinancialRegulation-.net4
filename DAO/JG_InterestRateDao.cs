using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;

namespace Dao
{
    public class JG_InterestRateDao : BasesDAO<JG_InterestRateInfo>
    {
        /// <summary>
        /// 构建 协议数据库操作类
        /// </summary>
        private JG_InterestRateDao()
        {
            DefaultKey = "JG_InterestRate";
        }

        private static JG_InterestRateDao _instance;
        /// <summary>
        /// 获取 协议数据库操作类实例
        /// </summary>
        public static JG_InterestRateDao Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new JG_InterestRateDao();
                }
                return _instance;
            }
        }

        public override bool Add(JG_InterestRateInfo t)
        {
            return i(t);
        }

        public override bool Update(JG_InterestRateInfo t)
        {
            return u(t);
        }

        public override bool Delete(JG_InterestRateInfo t)
        {
            return d(t);
        }

        public override IList<JG_InterestRateInfo> Select(JG_InterestRateInfo t)
        {
            return s(t);
        }

        /// <summary>
        /// 查看数据库中所有利率
        /// </summary>
        /// <returns>利率集合</returns>
        public override IList<JG_InterestRateInfo> Selects()
        {
            return ss();
        }
        /// <summary>
        /// 获取协议利息总额
        /// </summary>
        /// <param name="protocolNo"></param>
        /// <returns></returns>
        public static decimal InterestInquire(string protocolNo)
        {
            return decimal.Parse(SqlMap.QueryForObject("SelectInterestSum", protocolNo).ToString());
        }
    }
}
