using System;
using System.Collections.Generic;
using MODEL;

namespace Dao
{
    /// <summary>
    /// [系统配置]数据库操作类
    /// </summary>
    public class SysConfigDao : BasesDAO<SysConfigInfo>
    {
        /// <summary>
        /// 构建 [系统配置]数据库操作类
        /// </summary>
        private SysConfigDao()
        {
            DefaultKey = "SysConfig";
        }

        private static SysConfigDao _instance;
        /// <summary>
        /// 获取 [系统配置]数据库操作类实例
        /// </summary>
        public static SysConfigDao Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SysConfigDao();
                }
                return _instance;
            }
        }

        /// <summary>
        /// 修改数据库中的[系统配置]数据
        /// </summary>
        /// <param name="t">[系统配置]实例</param>
        /// <returns>修改完成状态</returns>
        public override bool Update(SysConfigInfo t)
        {
            return u(t);
        }
        /// <summary>
        /// 查看数据库中所有[系统配置]数据
        /// </summary>
        /// <returns>[系统配置]集合</returns>
        public override IList<SysConfigInfo> Selects()
        {
            return ss();
        }

        public override bool Add(SysConfigInfo t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(SysConfigInfo t)
        {
            throw new NotImplementedException();
        }

        public override IList<SysConfigInfo> Select(SysConfigInfo t)
        {
            throw new NotImplementedException();
        }
    }
}
