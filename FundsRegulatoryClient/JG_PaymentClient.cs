using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundsRegulatoryClient.JG_PaymentSrv;
using System.Collections.ObjectModel;

namespace FundsRegulatoryClient
{
	 /// <summary>
     /// 支付
     /// </summary>
    public sealed class JG_PaymentClient:BaseClient<JG_PaymentService>
    {
        private static JG_PaymentClient _instance;
        /// <summary>
        /// 获取 [支付] 操作对象实例
        /// </summary>
        public static JG_PaymentClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new JG_PaymentClient();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 添加对象 支付
        /// </summary>
        /// <param name="m"></param>
        /// <returns>完成状态</returns>
        public bool Add(FundPayment m)
        {
            return service.Add(m);
        }
        /// <summary>
        /// 更新对象 支付
        /// </summary>
        /// <param name="m">更新的对象</param>
        /// <returns>完成状态</returns>
        public bool Update(FundPayment m)
        {
            return service.Update(m);
        }

        /// <summary>
        /// 更新对象 支付
        /// </summary>
        /// <param name="m">更新的对象</param>
        /// <returns>完成状态</returns>
        public bool UpPayMentInfoById(FundPayment m)
        {
            return service.UpPayMentInfoById(m);
        }


        /// <summary>
        /// 更新对象 支付(利息支付)
        /// </summary>
        /// <param name="m">更新的对象</param>
        /// <returns>完成状态</returns>
        public bool UpPayMentInfoInterestById(FundPayment m)
        {
            return service.UpPayMentInfoInterestById(m);
        }


        /// <summary>
        /// 删除对象 支付
        /// </summary>
        /// <param name="m"></param>
        /// <returns>完成状态</returns>
        public bool Delete(FundPayment m)
        {
            return service.Delete(m);
        }
        /// <summary>
        /// 查看所有对象 支付
        /// </summary>
        /// <returns>对象集合</returns>
        public ObservableCollection<FundPayment> Selects()
        {
            List<FundPayment> temp = service.Selects().ToList<FundPayment>();
            ObservableCollection<FundPayment> oj = new ObservableCollection<FundPayment>();
            temp.ForEach(p => oj.Add(p));
            return oj;
        }
        /// <summary>
        /// 查看特定对象 支付
        /// </summary>
        /// <param name="m">筛选实例</param>
        /// <returns>对象集合</returns>
        public ObservableCollection<FundPayment> Select(FundPayment m)
        {
            List<FundPayment> temp = service.Select(m).ToList<FundPayment>();
            ObservableCollection<FundPayment> oj = new ObservableCollection<FundPayment>();
            temp.ForEach(p => oj.Add(p));
            return oj;
             
        }


        /// <summary>
        /// 查看特定对象 支付
        /// </summary>
        /// <param name="m">筛选实例</param>
        /// <returns>对象集合</returns>
        public decimal selectYEByXybh(string xybh)
        {
            return service.selectYEByXybh(xybh);
        }


        /// <summary>
        /// 查看特定对象 利息支付
        /// </summary>
        /// <param name="m">筛选实例</param>
        /// <returns>对象集合</returns>
        public List<FundPayment> SelectJG_PaymentInterest(FundPayment m)
        {

            return service.SelectJG_PaymentInterest(m).ToList<FundPayment>();
        }


        /// <summary>
        /// 根据区间条件查询
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<FundPayment> SelectThePaymentInfoByInterval(JG_PaymentSrv.DictionaryEntry[] array)
        {
            List<FundPayment> temp = new List<FundPayment>(service.SelectThePaymentInfoByInterval(array));
            ObservableCollection<FundPayment> oj = new ObservableCollection<FundPayment>();
            temp.ForEach(p => oj.Add(p));
            return oj;
             
        }

       
       
    }
}

