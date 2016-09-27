using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MODEL.NewModel;
using Dao;
using System.Collections;

namespace FinancialRegulationSRV
{
    /// <summary>
    /// JG_PaymentService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class JG_PaymentService : System.Web.Services.WebService
    {
        JG_PaymentDao daoHelp = JG_PaymentDao.Instance;

        [WebMethod(Description = "添加支付")]
        public bool Add(FundPayment o)
        {
            return daoHelp.Add(o);
        }
        [WebMethod(Description = "更新支付")]
        public bool Update(FundPayment o)
        {
            return daoHelp.Update(o);
        }
        [WebMethod(Description = "删除支付")]
        public bool Delete(FundPayment o)
        {
            return daoHelp.Delete(o);
        }
        [WebMethod(Description = "查看所有支付")]
        public List<FundPayment> Selects()
        {
            return daoHelp.Selects() as List<FundPayment>;
        }
        [WebMethod(Description = "查看特定支付")]
        public List<FundPayment> Select(FundPayment o)
        {
            return daoHelp.Select(o) as List<FundPayment>;
        }

        [WebMethod(Description = "更新支付")]
        public bool UpPayMentInfoById(FundPayment o)
        {
            return daoHelp.UpPayMentInfoById(o);
        }


        [WebMethod(Description = "更新支付(利息支付)")]
        public bool UpPayMentInfoInterestById(FundPayment o)
        {
            return daoHelp.UpPayMentInfoInterestById(o);
        }


       

        /// <summary>
        /// 根据协议编号查询余额
        /// </summary>
        [WebMethod]
        public decimal selectYEByXybh(string xybh)
        {
            return daoHelp.selectYEByXybh(xybh);
        }


        [WebMethod(Description = "查看特定支付(利息支付列表)")]
        public List<FundPayment> SelectJG_PaymentInterest(FundPayment o)
        {
            return daoHelp.SelectJG_PaymentInterest(o) as List<FundPayment>;
        }


        /// <summary>
        /// 根据区间条件查询
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [WebMethod]
        public List<FundPayment> SelectThePaymentInfoByInterval(DictionaryEntry[] array)
        {
            if (array == null) return null;
            Hashtable ht = new Hashtable();
            foreach (DictionaryEntry entry in array)
            {
                ht.Add(entry.Key, entry.Value);
            }
            return JG_PaymentDao.SelectThePaymentInfoByInterval(ht) as List<FundPayment>;
        }
       
    }
}

