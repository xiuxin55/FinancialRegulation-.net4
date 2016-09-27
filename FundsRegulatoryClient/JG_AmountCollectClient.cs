using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundsRegulatoryClient.JG_AmountCollectSrv;

namespace FundsRegulatoryClient
{
	 /// <summary>
     /// 资金归集
     /// </summary>
    public sealed class JG_AmountCollectClient:BaseClient<JG_AmountCollectService>
    {
        private static JG_AmountCollectClient _instance;
        /// <summary>
        /// 获取 [资金归集] 操作对象实例
        /// </summary>
        public static JG_AmountCollectClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new JG_AmountCollectClient();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 添加对象 资金归集
        /// </summary>
        /// <param name="m"></param>
        /// <returns>完成状态</returns>
        public bool Add(JG_AmountCollectInfo m)
        {
            return service.Add(m);
        }
        /// <summary>
        /// 更新对象 资金归集
        /// </summary>
        /// <param name="m">更新的对象</param>
        /// <returns>完成状态</returns>
        public bool Update(JG_AmountCollectInfo m)
        {
            return service.Update(m);
        }
        /// <summary>
        /// 删除对象 资金归集
        /// </summary>
        /// <param name="m"></param>
        /// <returns>完成状态</returns>
        public bool Delete(JG_AmountCollectInfo m)
        {
            return service.Delete(m);
        }
        /// <summary>
        /// 查看所有对象 资金归集
        /// </summary>
        /// <returns>对象集合</returns>
        public List<JG_AmountCollectInfo> Selects()
        {
            return service.Selects().ToList<JG_AmountCollectInfo>();
        }
        /// <summary>
        /// 查看特定对象 资金归集
        /// </summary>
        /// <param name="m">筛选实例</param>
        /// <returns>对象集合</returns>
        public List<JG_AmountCollectInfo> Select(JG_AmountCollectInfo m)
        {
            return service.Select(m).ToList<JG_AmountCollectInfo>();
        }
        /// <summary>
        /// 获得所有资金归集
        /// </summary>
        /// <returns>资金归集集合</returns>
        public System.Data.DataTable SelectFund()
        {
            return service.GetFundCollects();
        }
    }
}

