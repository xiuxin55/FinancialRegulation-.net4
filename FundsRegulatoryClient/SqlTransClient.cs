using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundsRegulatoryClient.SqlTransSvr;

namespace FundsRegulatoryClient
{
   public  class SqlTransClient : BaseClient<SqlTransSvr.SqlTrans>
    {
        private static SqlTransClient _instance;
        /// <summary>
        /// 获取操作对象实例
        /// </summary>
        public static SqlTransClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SqlTransClient();
                }
                return _instance;
            }
        }
       /// <summary>
        ///添加退票 更新每日余额和存款表的数据库事务
       /// </summary>
       /// <param name="db"></param>
       /// <param name="i"></param>
       /// <param name="obj"></param>
       /// <returns></returns>
        public bool Update_DbAndDF(FundsRegulatoryClient.SqlTransSvr.DayBalance db, RefundTrade rt, DepositFund obj)
        {

           return  service.Update_DbAndDF(db,obj,rt);
        }
       /// <summary>
        ///添加退票 更新每日余额和支付表的数据库事务
       /// </summary>
       /// <param name="db"></param>
       /// <param name="i"></param>
       /// <param name="obj"></param>
       /// <returns></returns>
        public bool Update_DbAndPF(FundsRegulatoryClient.SqlTransSvr.DayBalance db, FundPayment obj,RefundTrade rt)
        {

            return service.Update_DbAndPF(db, obj,rt);
        }
        /// <summary>
        ///更新每日余额和存款表的数据库事务
        /// </summary>
        /// <param name="db"></param>
        /// <param name="i"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update_DbAndDF(FundsRegulatoryClient.SqlTransSvr.DayBalance db, DepositFund obj,int i )
        {

            return service.Update_DbAndDF(db, obj,i);
        }
        /// <summary>
        /// 更新每日余额和支付表的数据库事务
        /// </summary>
        /// <param name="db"></param>
        /// <param name="i"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update_DbAndPF(FundsRegulatoryClient.SqlTransSvr.DayBalance db, FundPayment obj,int i)
        {

            return service.Update_DbAndPF(db, obj,i);
        }
        /// <summary>
        /// 更新每日余额和季度结息的数据库事务
        /// </summary>
        /// <param name="db"></param>
        /// <param name="i"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update_DbAndSI(List<FundsRegulatoryClient.SqlTransSvr.DayBalance> dblist, SeasonInterest obj, int i)//1 代表添加 2 代表更新
        {
            return service.Update_DbAndSI(dblist.ToArray < FundsRegulatoryClient.SqlTransSvr.DayBalance>(), obj, i);
        }
       /// <summary>
       /// 创建账户时插入季节、每日余额表
       /// </summary>
       /// <returns></returns>
        public bool CreateAccountSIDB(FundsRegulatoryClient.SqlTransSvr.JG_AccountManageInfo acc, SeasonInterest si, DayBalance db,int i)
        {
            return service.CreateAccountSIDB(acc,si,db,i);
        }
    }
}
