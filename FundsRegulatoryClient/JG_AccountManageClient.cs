using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.ObjectModel;
using FundsRegulatoryClient.JG_AccountManageSrv;
namespace FundsRegulatoryClient
{
	 /// <summary>
     /// 监管账户
     /// </summary>
    public sealed class JG_AccountManageClient:BaseClient<JG_AccountManageService>
    {
        private static JG_AccountManageClient _instance;
        /// <summary>
        /// 获取 [监管账户] 操作对象实例
        /// </summary>
        public static JG_AccountManageClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new JG_AccountManageClient();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 添加对象 监管账户
        /// </summary>
        /// <param name="m"></param>
        /// <returns>完成状态</returns>
        public bool Add(JG_AccountManageInfo m)
        {
            return service.Add(m);
        }
        /// <summary>
        /// 更新对象 监管账户
        /// </summary>
        /// <param name="m">更新的对象</param>
        /// <returns>完成状态</returns>
        public bool Update(JG_AccountManageInfo m)
        {
            return service.Update(m);
        }
        /// <summary>
        /// 删除对象 监管账户
        /// </summary>
        /// <param name="m"></param>
        /// <returns>完成状态</returns>
        public bool Delete(JG_AccountManageInfo m)
        {
            return service.Delete(m);
        }
        /// <summary>
        /// 查看所有对象 监管账户
        /// </summary>
        /// <returns>对象集合</returns>
        public ObservableCollection<JG_AccountManageInfo> Selects()
        {
            List<JG_AccountManageInfo> temp=service.Selects().ToList<JG_AccountManageInfo>();
            ObservableCollection<JG_AccountManageInfo> oj=new ObservableCollection<JG_AccountManageInfo>();
            temp.ForEach(p => oj.Add(p));
            return oj;
        }
        /// <summary>
        /// 查看特定对象 监管账户
        /// </summary>
        /// <param name="m">筛选实例</param>
        /// <returns>对象集合</returns>
        public ObservableCollection<JG_AccountManageInfo> Select(JG_AccountManageInfo ami)
        {
            //JG_AccountManageInfo ami = new JG_AccountManageInfo();
            ////ami = m;
            //ami.AM_ID = m.AM_ID;
            List<JG_AccountManageInfo> temp = service.Select(ami).ToList<JG_AccountManageInfo>();
            ObservableCollection<JG_AccountManageInfo> oj = new ObservableCollection<JG_AccountManageInfo>();
            temp.ForEach(p => oj.Add(p));
            return oj;
        }
        public List<JG_AccountManageInfo> GetAllCorp()
        {
            return service.GetAllCorp().ToList<JG_AccountManageInfo>();
        }
        
    }
}
