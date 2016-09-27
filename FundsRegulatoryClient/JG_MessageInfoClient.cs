using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundsRegulatoryClient.JG_MessageInfoSrv;

namespace FundsRegulatoryClient
{
	 /// <summary>
     /// 报文信息
     /// </summary>
    public sealed class JG_MessageInfoClient : BaseClient<JG_MessageInfoService>
    {
        private static JG_MessageInfoClient _instance;
        /// <summary>
        /// 获取 [报文信息] 操作对象实例
        /// </summary>
        public static JG_MessageInfoClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new JG_MessageInfoClient();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 添加对象 报文信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns>完成状态</returns>
        public bool Add(MessageInfo m)
        {
            return service.Add(m);
        }
        /// <summary>
        /// 更新对象 报文信息
        /// </summary>
        /// <param name="m">更新的对象</param>
        /// <returns>完成状态</returns>
        public bool Update(MessageInfo m)
        {
            return service.Update(m);
        }
        /// <summary>
        /// 删除对象 报文信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns>完成状态</returns>
        public bool Delete(MessageInfo m)
        {
            return service.Delete(m);
        }
        /// <summary>
        /// 查看所有对象 报文信息
        /// </summary>
        /// <returns>对象集合</returns>
        public List<MessageInfo> Selects()
        {
            return service.Selects().ToList<MessageInfo>();
        }
        /// <summary>
        /// 查看特定对象 报文信息
        /// </summary>
        /// <param name="m">筛选实例</param>
        /// <returns>对象集合</returns>
        public List<MessageInfo> Select(MessageInfo m)
        {
            return service.Select(m).ToList<MessageInfo>();
        }
        
    }
}

