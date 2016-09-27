using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundsRegulatoryClient.SysConfigSrv;

namespace FundsRegulatoryClient
{
    /// <summary>
    /// 系统配置
    /// </summary>
    public sealed class SysConfigClient : BaseClient<SysConfigService>
    {
        private static SysConfigClient _instance;
        /// <summary>
        /// 获取 [系统配置] 操作对象实例
        /// </summary>
        public static SysConfigClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SysConfigClient();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 更新 系统配置
        /// </summary>
        /// <param name="m">更新的对象</param>
        /// <returns>完成状态</returns>
        public bool Update(SysConfigInfo m)
        {
            return service.Update(m);
        }
        /// <summary>
        /// 查看所有 系统配置
        /// </summary>
        /// <returns>对象集合</returns>
        public List<SysConfigInfo> Selects()
        {
            return service.Selects().ToList<SysConfigInfo>();
        }

    }
}
