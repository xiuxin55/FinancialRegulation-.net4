using System;
using System.Collections.Generic;
using MODEL;

namespace Dao
{
    /// <summary>
    /// 银行网点数据库操作类
    /// </summary>
    public  class JG_BranchesDao : BasesDAO<JG_BranchesInfo>
    {
        /// <summary>
        /// 构建 银行网点数据库操作类
        /// </summary>
        private JG_BranchesDao()
        {
            DefaultKey = "JG_Branches";
        }

        private static JG_BranchesDao _instance;
        /// <summary>
        /// 获取 银行网点数据库操作类实例
        /// </summary>
        public static JG_BranchesDao Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new JG_BranchesDao();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 向数据库中添加一个银行网点的新实例
        /// </summary>
        /// <param name="t">银行网点新实例</param>
        /// <returns>添加完成状态</returns>
        public override bool Add(JG_BranchesInfo t)
        {
            return i(t);
        }
        /// <summary>
        /// 修改数据库中的银行网点数据
        /// </summary>
        /// <param name="t">银行网点实例</param>
        /// <returns>修改完成状态</returns>
        public override bool Update(JG_BranchesInfo t)
        {
            return u(t);
        }
        /// <summary>
        /// 删除数据库中一条银行网点
        /// </summary>
        /// <param name="t">银行网点条件</param>
        /// <returns>删除完成状态</returns>
        public override bool Delete(JG_BranchesInfo t)
        {
            return d(t.BR_ID);
        }
        /// <summary>
        /// 查看数据库中所有银行网点数据
        /// </summary>
        /// <returns>银行网点集合</returns>
        public override IList<JG_BranchesInfo> Selects()
        {
            return ss();
        }
        /// <summary>
        /// 查看数据库中特定的银行网点数据
        /// </summary>
        /// <param name="t">银行网点筛选实例</param>
        /// <returns>银行网点集合</returns>
        public override IList<JG_BranchesInfo> Select(JG_BranchesInfo t)
        {
            return s(t);
        }
    }
}

