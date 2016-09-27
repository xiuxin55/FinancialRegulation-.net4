using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundsRegulatoryClient.RefunTradeSrv;
using System.Collections.ObjectModel;

namespace FundsRegulatoryClient
{
    public class RefundTradeClient : BaseClient<RefunTradeSrv.RefunTradeService>
    {
        private static RefundTradeClient _instance;
        /// <summary>
        ///  操作对象实例
        /// </summary>
        public static RefundTradeClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RefundTradeClient();
                }
                return _instance;
            }
        }
        /// <summary>
        ///增加退票信息
        /// </summary>
      
        public bool Add(RefundTrade m)
        {
            return service.Add(m);
        }
        /// <summary>
        /// 查看所有 系统配置
        /// </summary>
        /// <returns>对象集合</returns>
        public ObservableCollection<RefundTrade> Selects()
        {
            ObservableCollection<RefundTrade> temp = new ObservableCollection<RefundTrade>();
            service.Selects().ToList<RefundTrade>().ForEach(p => temp.Add(p));
            return temp;
        }
        public ObservableCollection<RefundTrade> Select(RefundTrade rt)
        {
            ObservableCollection<RefundTrade> temp = new ObservableCollection<RefundTrade>();
            List<RefundTrade> list = service.Select(rt).ToList<RefundTrade>();
            list.ForEach(p => temp.Add(p));
            return temp;
        }
        
    }
}
