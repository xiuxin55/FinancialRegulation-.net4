using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MODEL.NewModel;
using Dao;
using System.Collections;
using System.Collections.ObjectModel;

namespace FinancialRegulationSRV
{
    /// <summary>
    /// JG_DepositService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class JG_DepositService : System.Web.Services.WebService
    {
        JG_DepositDao daoHelp = JG_DepositDao.Instance;

        [WebMethod(Description = "添加存款")]
        public bool Add(DepositFund o)
        {
            return daoHelp.Add(o);
        }
        [WebMethod(Description = "更新存款")]
        public bool Update(DepositFund o)
        {
            return daoHelp.Update(o);
        }
        [WebMethod(Description = "删除存款")]
        public bool Delete(DepositFund o)
        {
            return daoHelp.Delete(o);
        }
        [WebMethod(Description = "查看所有存款")]
        public List<DepositFund> Selects()
        {
            return daoHelp.Selects() as List<DepositFund>;
        }
        [WebMethod(Description = "查看特定存款")]
        public List<DepositFund> Select(DepositFund o)
        {
            return daoHelp.Select(o) as List<DepositFund>;
        }
        [WebMethod(Description = "根据协议获取账户剩余金额")]
        public int GetAccountMoney(string xybh)
        {
            return daoHelp.GetAccountMoney(xybh);
        }
        [WebMethod(Description = "查询特定存款不关联任何表的")]
        public List<DepositFund> Selectn(DepositFund info)
        {
            return daoHelp.Selectn(info) as List<DepositFund>;
        }

        /// <summary>
        /// 返回存款信息
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public List<DepositFund> SelectDepositInfoList(DictionaryEntry[] array)
        {
            return JG_DepositDao.SelectDepositInfoList(array) as List<DepositFund>;
        }

        /// <summary>
        /// 不明账款缴存
        /// </summary>
        /// <param name="jdInfo"></param>
        /// <returns></returns>
        [WebMethod]
        public bool AddUnKownJG_Deposit(UnknowBill jdInfo)
        {
            return daoHelp.AddUnKownJG_Deposit(jdInfo);
        }
        /// <summary>
        /// 不明账款返回
        /// </summary>
        /// <param name="jdInfo"></param>
        /// <returns></returns>
        [WebMethod]
        public bool UpdateUnKownJG_Deposit(UnknowBill jdInfo)
        {
            return daoHelp.UpdateUnKownJG_Deposit(jdInfo);
        }
        /// <summary>
        /// 不明账款更新
        /// </summary>
        /// <param name="jdInfo"></param>
        /// <returns></returns>
        [WebMethod]
        public List<UnknowBill> SelectUnKownJG_Deposit()
        {
            //ObservableCollection<UnknowBill> temp = new ObservableCollection<UnknowBill>();
            //List<UnknowBill> list=daoHelp.SelectUnKownJG_Deposit();
            //list.ForEach(p=>temp.Add(p));
            return daoHelp.SelectUnKownJG_Deposit();
        }
        /// <summary>
        /// 不明账款删除
        /// </summary>
        /// <param name="jdInfo"></param>
        /// <returns></returns>
        [WebMethod]
        public bool DeleteUnKownJG_Deposit(UnknowBill jdInfo)
        {
            //ObservableCollection<UnknowBill> temp = new ObservableCollection<UnknowBill>();
            //List<UnknowBill> list=daoHelp.SelectUnKownJG_Deposit();
            //list.ForEach(p=>temp.Add(p));
            return daoHelp.DeleteUnKownJG_Deposit(jdInfo);
        }
        
    }
}

