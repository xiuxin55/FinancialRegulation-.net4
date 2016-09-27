using System;
using System.Collections.Generic;
using MODEL;

namespace Dao
{
    /// <summary>
    /// 监管账户数据库操作类
    /// </summary>
    public  class JG_AccountManageDao : BasesDAO<JG_AccountManageInfo>
    {
        /// <summary>
        /// 构建 监管账户数据库操作类
        /// </summary>
        private JG_AccountManageDao()
        {
            DefaultKey = "JG_AccountManage";
        }

        private static JG_AccountManageDao _instance;
        /// <summary>
        /// 获取 监管账户数据库操作类实例
        /// </summary>
        public static JG_AccountManageDao Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new JG_AccountManageDao();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 向数据库中添加一个监管账户的新实例
        /// </summary>
        /// <param name="t">监管账户新实例</param>
        /// <returns>添加完成状态</returns>
        public override bool Add(JG_AccountManageInfo t)
        {
            return i(t);
        }
        /// <summary>
        /// 修改数据库中的监管账户数据
        /// </summary>
        /// <param name="t">监管账户实例</param>
        /// <returns>修改完成状态</returns>
        public override bool Update(JG_AccountManageInfo t)
        {
            return u(t);
        }
        /// <summary>
        /// 删除数据库中一条监管账户
        /// </summary>
        /// <param name="t">监管账户条件</param>
        /// <returns>删除完成状态</returns>
        public override bool Delete(JG_AccountManageInfo t)
        {
            return d(t);
        }
        /// <summary>
        /// 查看数据库中所有监管账户数据
        /// </summary>
        /// <returns>监管账户集合</returns>
        public override IList<JG_AccountManageInfo> Selects()
        {
            return ss();
        }
        /// <summary>
        /// 查看数据库中特定的监管账户数据
        /// </summary>
        /// <param name="t">监管账户筛选实例</param>
        /// <returns>监管账户集合</returns>
        public override IList<JG_AccountManageInfo> Select(JG_AccountManageInfo t)
        {
            return s(t);
        }
        /// <summary>
        /// 获得所有公司
        /// </summary>
        /// <returns>公司集合</returns>
        public IList<JG_AccountManageInfo> GetAllCorp()
        {
            return ss("SelectJG_AllCorpName");
        }
    }
}
