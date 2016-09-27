using System;
using System.Collections.Generic;
using MODEL.NewModel;
using System.Collections;

namespace Dao
{
    /// <summary>
    /// 支付数据库操作类
    /// </summary>
    public class JG_PaymentDao : BasesDAO<FundPayment>
    {
        /// <summary>
        /// 构建 支付数据库操作类
        /// </summary>
        private JG_PaymentDao()
        {
            DefaultKey = "JG_Payment";
        }

        private static JG_PaymentDao _instance;
        /// <summary>
        /// 获取 支付数据库操作类实例
        /// </summary>
        public static JG_PaymentDao Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new JG_PaymentDao();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 向数据库中添加一个支付的新实例
        /// </summary>
        /// <param name="t">支付新实例</param>
        /// <returns>添加完成状态</returns>
        public override bool Add(FundPayment t)
        {
            return i(t);
        }
        /// <summary>
        /// 修改数据库中的支付数据
        /// </summary>
        /// <param name="t">支付实例</param>
        /// <returns>修改完成状态</returns>
        public override bool Update(FundPayment t)
        {
            return u(t);
        }


        /// <summary>
        /// 修改数据库中的支付数据
        /// </summary>
        /// <param name="t">支付实例</param>
        /// <returns>修改完成状态</returns>
        public bool UpPayMentInfoById(FundPayment t)
        {
            try
            {
                SqlMap.Update("UpPayMentInfoById", t);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 修改数据库中的支付数据(利息支付确认)
        /// </summary>
        /// <param name="t">支付实例</param>
        /// <returns>修改完成状态</returns>
        public bool UpPayMentInfoInterestById(FundPayment t)
        {
            try
            {
                SqlMap.Update("UpPayMentInfoInterestById", t);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 删除数据库中一条支付
        /// </summary>
        /// <param name="t">支付条件</param>
        /// <returns>删除完成状态</returns>
        public override bool Delete(FundPayment t)
        {
            return d(t);
        }
        /// <summary>
        /// 查看数据库中所有支付数据
        /// </summary>
        /// <returns>支付集合</returns>
        public override IList<FundPayment> Selects()
        {
            return ss();
        }
        /// <summary>
        /// 查看数据库中特定的支付数据
        /// </summary>
        /// <param name="t">支付筛选实例</param>
        /// <returns>支付集合</returns>
        public override IList<FundPayment> Select(FundPayment t)
        {
            return s(t);
        }


        /// <summary>
        /// 根据协议编号查询余额
        /// </summary>
        public decimal selectYEByXybh(string xybh)
        {
            try
            {
                return SqlMap.QueryForObject<decimal>("selectYEByXybh", xybh);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 查看数据库中特定的支付数据(利息支付)
        /// </summary>
        /// <param name="t">支付筛选实例</param>
        /// <returns>支付集合</returns>
        public IList<FundPayment> SelectJG_PaymentInterest(FundPayment t)
        {
            try
            {
                return SqlMap.QueryForList<FundPayment>("SelectJG_PaymentInterest", t);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据区间条件查询
        /// </summary>
        /// <returns></returns>
        public static IList<FundPayment> SelectThePaymentInfoByInterval(Hashtable ht)
        {
            return SqlMap.QueryForList<FundPayment>("SelectThePaymentInfoByInterval", ht);
        }

        /// <summary>
        /// 调账 更新支付请求的信息
        /// </summary>
        /// <param name="t">更新的支付信息</param>
        /// <returns></returns>
        public bool AdjustAccountJG_Payment(FundPayment t)
        {
            return u("AdjustAccountJG_Payment", t);
        }
    }
}

