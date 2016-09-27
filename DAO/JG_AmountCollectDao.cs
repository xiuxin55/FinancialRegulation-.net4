using System;
using System.Collections.Generic;
using System.Data;
using MODEL;

namespace Dao
{
    /// <summary>
    /// 资金归集数据库操作类
    /// </summary>
    public  class JG_AmountCollectDao : BasesDAO<JG_AmountCollectInfo>
    {
        /// <summary>
        /// 构建 资金归集数据库操作类
        /// </summary>
        private JG_AmountCollectDao()
        {
            DefaultKey = "JG_AmountCollect";
        }

        private static JG_AmountCollectDao _instance;
        /// <summary>
        /// 获取 资金归集数据库操作类实例
        /// </summary>
        public static JG_AmountCollectDao Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new JG_AmountCollectDao();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 向数据库中添加一个资金归集的新实例
        /// </summary>
        /// <param name="t">资金归集新实例</param>
        /// <returns>添加完成状态</returns>
        public override bool Add(JG_AmountCollectInfo t)
        {
            return i(t);
        }
        /// <summary>
        /// 修改数据库中的资金归集数据
        /// </summary>
        /// <param name="t">资金归集实例</param>
        /// <returns>修改完成状态</returns>
        public override bool Update(JG_AmountCollectInfo t)
        {
            return u(t);
        }
        /// <summary>
        /// 删除数据库中一条资金归集
        /// </summary>
        /// <param name="t">资金归集条件</param>
        /// <returns>删除完成状态</returns>
        public override bool Delete(JG_AmountCollectInfo t)
        {
            return d(t);
        }
        /// <summary>
        /// 查看数据库中所有资金归集数据
        /// </summary>
        /// <returns>资金归集集合</returns>
        public override IList<JG_AmountCollectInfo> Selects()
        {
            return ss();
        }
        /// <summary>
        /// 查看数据库中特定的资金归集数据
        /// </summary>
        /// <param name="t">资金归集筛选实例</param>
        /// <returns>资金归集集合</returns>
        public override IList<JG_AmountCollectInfo> Select(JG_AmountCollectInfo t)
        {
            return s(t);
        }
        /// <summary>
        /// 获取资金归集 升级
        /// </summary>
        /// <returns>数据表</returns>
        public DataTable GetFundCollects()
        {
            return GetTable("SelectFundInfos", null);
        }
    }
}

