using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundsRegulatoryClient.JG_SpvProtocolSrv;

namespace FundsRegulatoryClient
{
    /// <summary>
    /// 监管协议
    /// </summary>
    public sealed class JG_SpvProtocolClient : BaseClient<JG_SpvProtocolService>
    {
        private static JG_SpvProtocolClient _instance;
        /// <summary>
        /// 获取 监管协议 操作对象实例
        /// </summary>
        public static JG_SpvProtocolClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new JG_SpvProtocolClient();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 添加对象 监管协议
        /// </summary>
        /// <param name="m"></param>
        /// <returns>完成状态</returns>
        public bool Add(JG_SpvProtocol m)
        {
            return service.Add(m);
        }
        /// <summary>
        /// 更新对象 监管协议
        /// </summary>
        /// <param name="m">更新的对象</param>
        /// <returns>完成状态</returns>
        public bool Update(JG_SpvProtocol m)
        {
            return service.Update(m);
        }
        /// <summary>
        /// 删除对象 监管协议
        /// </summary>
        /// <param name="m"></param>
        /// <returns>完成状态</returns>
        public bool Delete(JG_SpvProtocol m)
        {
            return service.Delete(m);
        }
        /// <summary>
        /// 查看所有对象 监管协议
        /// </summary>
        /// <returns>对象集合</returns>
        public List<JG_SpvProtocol> Selects()
        {
            return service.Selects().ToList<JG_SpvProtocol>();
        }
        /// <summary>
        /// 查看特定对象 监管协议
        /// </summary>
        /// <param name="m">筛选实例</param>
        /// <returns>对象集合</returns>
        public List<JG_SpvProtocol> Select(JG_SpvProtocol m)
        {
            return service.Select(m).ToList<JG_SpvProtocol>();
        }
        public List<JG_SpvProtocol> GetProtocolByCondition(JG_SpvProtocol jG_SpvProtocol)
        {
            return service.GetProtocolByCondition(jG_SpvProtocol, "").ToList();
        }
    }
}

