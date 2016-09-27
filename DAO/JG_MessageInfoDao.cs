using System;
using System.Collections.Generic;
using MODEL.NewModel;

namespace Dao
{
    /// <summary>
    /// 报文信息数据库操作类
    /// </summary>
    public  class JG_MessageInfoDao : BasesDAO<MessageInfo>
    {
        /// <summary>
        /// 构建 报文信息数据库操作类
        /// </summary>
        private JG_MessageInfoDao()
        {
            DefaultKey = "MessageInfo";
        }

        private static JG_MessageInfoDao _instance;
        /// <summary>
        /// 获取 报文信息数据库操作类实例
        /// </summary>
        public static JG_MessageInfoDao Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new JG_MessageInfoDao();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 向数据库中添加一个报文信息的新实例
        /// </summary>
        /// <param name="t">报文信息新实例</param>
        /// <returns>添加完成状态</returns>
        public override bool Add(MessageInfo t)
        {
            return i(t);
        }
        /// <summary>
        /// 修改数据库中的报文信息数据
        /// </summary>
        /// <param name="t">报文信息实例</param>
        /// <returns>修改完成状态</returns>
        public override bool Update(MessageInfo t)
        {
            return u(t);
        }
        /// <summary>
        /// 删除数据库中一条报文信息
        /// </summary>
        /// <param name="t">报文信息条件</param>
        /// <returns>删除完成状态</returns>
        public override bool Delete(MessageInfo t)
        {
            return d(t);
        }
        /// <summary>
        /// 查看数据库中所有报文信息数据
        /// </summary>
        /// <returns>报文信息集合</returns>
        public override IList<MessageInfo> Selects()
        {
            return ss();
        }
        /// <summary>
        /// 查看数据库中特定的报文信息数据
        /// </summary>
        /// <param name="t">报文信息筛选实例</param>
        /// <returns>报文信息集合</returns>
        public override IList<MessageInfo> Select(MessageInfo t)
        {
            return s(t);
        }
    }
}

