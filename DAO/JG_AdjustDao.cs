using System;
using System.Collections.Generic;
using Model;
using System.Data;

namespace Dao
{
    /// <summary>
    /// 调账数据库操作类
    /// </summary>
    public class JG_AdjustDao : BasesDAO<JG_AdjustInfo>
    {
        /// <summary>
        /// 构建 调账数据库操作类
        /// </summary>
        private JG_AdjustDao()
        {
            DefaultKey = "JG_Adjust";
        }

        private static JG_AdjustDao _instance;
        /// <summary>
        /// 获取 调账数据库操作类实例
        /// </summary>
        public static JG_AdjustDao Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new JG_AdjustDao();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 向数据库中添加一个调账的新实例
        /// </summary>
        /// <param name="t">调账新实例</param>
        /// <returns>添加完成状态</returns>
        public override bool Add(JG_AdjustInfo t)
        {
            return i(t);
        }
        /// <summary>
        /// 修改数据库中的调账数据
        /// </summary>
        /// <param name="t">调账实例</param>
        /// <returns>修改完成状态</returns>
        public override bool Update(JG_AdjustInfo t)
        {
            return u(t);
        }


        /// <summary>
        /// 根据原存款流水号修改数据库中的调账数据
        /// </summary>
        /// <param name="t">调账实例</param>
        /// <returns>修改完成状态</returns>
        public bool UpdateJG_AdjustByCklsh(JG_AdjustInfo t)
        {
            SqlMap.Update("UpdateJG_AdjustByCklsh", t);
            return true;
        }

        /// <summary>
        /// 删除数据库中一条调账
        /// </summary>
        /// <param name="t">调账条件</param>
        /// <returns>删除完成状态</returns>
        public override bool Delete(JG_AdjustInfo t)
        {
            return d(t);
        }
        /// <summary>
        /// 查看数据库中所有调账数据
        /// </summary>
        /// <returns>调账集合</returns>
        public override IList<JG_AdjustInfo> Selects()
        {
            return ss();
        }
        /// <summary>
        /// 查看数据库中特定的调账数据
        /// </summary>
        /// <param name="t">调账筛选实例</param>
        /// <returns>调账集合</returns>
        public override IList<JG_AdjustInfo> Select(JG_AdjustInfo t)
        {
            return s(t);
        }
        /// <summary>
        /// 获取所有调账数据
        /// </summary>
        /// <param name="lc">流程</param>
        /// <returns>数据表</returns>
        public DataTable GetJG_Adjust(int lc)
        {
            return GetTable("GetJG_Adjust",lc);
        }


    }
}
