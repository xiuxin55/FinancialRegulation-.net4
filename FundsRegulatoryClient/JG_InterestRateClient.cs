using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundsRegulatoryClient.JG_InterestRateSrv;
using System.Collections.ObjectModel;

namespace FundsRegulatoryClient
{
    public class JG_InterestRateClient:BaseClient<JG_InterestRateSrv.JG_InterestRateSrv>
    {
        private static JG_InterestRateClient _instance;
        /// <summary>
        /// 利率
        /// </summary>
        public static JG_InterestRateClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new JG_InterestRateClient();
                }
                return _instance;
            }
        }

        /// <summary>
        /// 获取所有利率
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<JG_InterestRateInfo> Selects()
        {
            List<JG_InterestRateInfo> temp = service.SelectJG_InterestRateInfo().ToList<JG_InterestRateInfo>();
            ObservableCollection<JG_InterestRateInfo> oj = new ObservableCollection<JG_InterestRateInfo>();
            temp.ForEach(p => oj.Add(p));
            return oj;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="jirInfo"></param>
        /// <returns></returns>
        public bool AddJG_InterestRateInfo(JG_InterestRateInfo jirInfo)
        {
            return service.AddJG_InterestRateInfo(jirInfo);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="jirInfo"></param>
        /// <returns></returns>
        public bool UpdateJG_InterestRateInfo(JG_InterestRateInfo jirInfo)
        {
            return service.UpdateJG_InterestRateInfo(jirInfo);
        }
        /// <summary>
        /// 获取协议利息总额
        /// </summary>
        /// <param name="protocolNo"></param>
        /// <returns></returns>
        public decimal InterestInquire(string protocolNo)
        {
            return service.InterestInquire(protocolNo);
        }
    }
}
