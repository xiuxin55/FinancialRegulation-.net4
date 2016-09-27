using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundsRegulatoryClient.JG_BranchesSrv;
using System.Collections.ObjectModel;

namespace FundsRegulatoryClient
{
	 /// <summary>
     /// 银行网点
     /// </summary>
    public sealed class JG_BranchesClient:BaseClient<JG_BranchesService>
    {
        private static JG_BranchesClient _instance;
        /// <summary>
        /// 获取 [银行网点] 操作对象实例
        /// </summary>
        public static JG_BranchesClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new JG_BranchesClient();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 添加对象 银行网点
        /// </summary>
        /// <param name="m"></param>
        /// <returns>完成状态</returns>
        public bool Add(JG_BranchesInfo m)
        {
            return service.Add(m);
        }
        /// <summary>
        /// 更新对象 银行网点
        /// </summary>
        /// <param name="m">更新的对象</param>
        /// <returns>完成状态</returns>
        public bool Update(JG_BranchesInfo m)
        {
            return service.Update(m);
        }
        /// <summary>
        /// 删除对象 银行网点
        /// </summary>
        /// <param name="m"></param>
        /// <returns>完成状态</returns>
        public bool Delete(JG_BranchesInfo m)
        {
            return service.Delete(m);
        }
        /// <summary>
        /// 查看所有对象 银行网点
        /// </summary>
        /// <returns>对象集合</returns>
        public ObservableCollection<JG_BranchesInfo> Selects()
        {
            List<JG_BranchesInfo> temp = service.Selects().ToList<JG_BranchesInfo>();
            ObservableCollection<JG_BranchesInfo> oj = new ObservableCollection<JG_BranchesInfo>();
            temp.ForEach(p => oj.Add(p));
            return oj;
        }
        /// <summary>
        /// 查看特定对象 银行网点
        /// </summary>
        /// <param name="m">筛选实例</param>
        /// <returns>对象集合</returns>
        public List<JG_BranchesInfo> Select(JG_BranchesInfo m)
        {
            return service.Select(m).ToList<JG_BranchesInfo>();
        }
        
    }
}

