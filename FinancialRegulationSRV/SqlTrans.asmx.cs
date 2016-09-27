using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Dao;
using MODEL;
using MODEL.NewModel;
using MODEL.NewModel.BalanceAndInterest;
namespace FinancialRegulationSRV
{
    /// <summary>
    /// SqlTrans 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class SqlTrans : System.Web.Services.WebService
    {
        JG_DepositDao daoDeposit = JG_DepositDao.Instance;
        JG_PaymentDao daoPay = JG_PaymentDao.Instance;
        RefundTradeDao daort = RefundTradeDao.Instance;
        DayBalanceDao daoday = DayBalanceDao.Instance;
        SeasonInterestDao daoseasion = SeasonInterestDao.Instance;
        JG_AccountManageDao daoacc = JG_AccountManageDao.Instance;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(Description="更新每日余额和存款表和退票的数据库事务")]
       
        public bool Update_DbAndDF(DayBalance db, DepositFund obj,RefundTrade rt)
        {
            BaseDao.SqlMap.BeginTransaction();
            daoDeposit.Update(obj);
            daort.Add(rt);
            daoday.Update(db);
            try
            {
                BaseDao.SqlMap.CommitTransaction();
                return true;
            }
            catch
            {
                BaseDao.SqlMap.RollBackTransaction();
                return false;
            }
        }
        [WebMethod(Description = "更新每日余额和支付表和退票的数据库事务",MessageName="ds")]
        public bool Update_DbAndPF(DayBalance db, FundPayment obj, RefundTrade rt)
        {
            BaseDao.SqlMap.BeginTransaction();
            daoPay.Update(obj);
            daort.Add(rt);
            daoday.Update(db);
            try
            {
                BaseDao.SqlMap.CommitTransaction();
                return true;
            }
            catch
            {
                BaseDao.SqlMap.RollBackTransaction();
                return false;
            }
        }
       [WebMethod(Description = "更新每日余额和存款表的数据库事务",MessageName="deposit")]
        public bool Update_DbAndDF(DayBalance db, DepositFund obj,int i)
        {
            BaseDao.SqlMap.BeginTransaction();
            if (i == 1) { daoDeposit.Add(obj) ; }
            else { daoDeposit.Update(obj); }
            
            daoday.Update(db);
            try
            {
                BaseDao.SqlMap.CommitTransaction();
                return true;
            }
            catch
            {
                BaseDao.SqlMap.RollBackTransaction();
                return false;
            }
        }
        [WebMethod(Description = "更新每日余额和支付表的数据库事务", MessageName = "pay")]
        public bool Update_DbAndPF(DayBalance db, FundPayment obj,int i)//1 代表添加 2 代表更新
        {
            BaseDao.SqlMap.BeginTransaction();
            if (i == 1) { daoPay.Add(obj); }
            else { daoPay.Update(obj); }
            daoday.Update(db);
            try
            {
                BaseDao.SqlMap.CommitTransaction();
                return true;
            }
            catch
            {
                BaseDao.SqlMap.RollBackTransaction();
                return false;
            }
        }
        [WebMethod(Description = "更新每日余额和季度结息表的数据库事务", MessageName = "pay2")]
        public bool Update_DbAndSI(DayBalance[] dblist, SeasonInterest  obj, int i)//1 代表添加 2 代表更新
        {
            BaseDao.SqlMap.BeginTransaction();
            if (i == 1) {  daoseasion.Add(obj); }
            else { daoseasion.Update(obj); }
            foreach (DayBalance item in dblist)
            {
                daoday.Update(item);
            }
            try
            {
                BaseDao.SqlMap.CommitTransaction();
                return true;
            }
            catch
            {
                BaseDao.SqlMap.RollBackTransaction();
                return false;
            }
        }
        [WebMethod(Description = "创建账户时插入季节、每日余额表")]
        public bool CreateAccountSIDB(JG_AccountManageInfo acc,SeasonInterest si,DayBalance db,int i)//1代表插入2 代表更新
        {
            BaseDao.SqlMap.BeginTransaction();

            if (si != null)
            {
                if (i == 1) { daoacc.Add(acc); daoseasion.Add(si); }
                else { daoacc.Update(acc); daoseasion.Update(si); }
            }
            else
            {
                if (i == 1) { daoacc.Add(acc);  }
                else { daoacc.Update(acc);}
            }
            if (db != null)
            {
                daoday.Add(db);
            }
            try
            {
                BaseDao.SqlMap.CommitTransaction();
                return true;
            }
            catch
            {
                BaseDao.SqlMap.RollBackTransaction();
                return false;
            }
        }
    }
}
