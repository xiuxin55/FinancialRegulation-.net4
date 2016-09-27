using System;
using System.Collections.Generic;
using MODEL;

namespace Dao
{
    /// <summary>
    /// 协议数据库操作类
    /// </summary>
    public  class JG_SpvProtocolDao : BasesDAO<JG_SpvProtocol>
    {
        /// <summary>
        /// 构建 协议数据库操作类
        /// </summary>
        private JG_SpvProtocolDao()
        {
            DefaultKey = "JG_SpvProtocol";
        }

        private static JG_SpvProtocolDao _instance;
        /// <summary>
        /// 获取 协议数据库操作类实例
        /// </summary>
        public static JG_SpvProtocolDao Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new JG_SpvProtocolDao();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 向数据库中添加一个协议的新实例
        /// </summary>
        /// <param name="t">协议新实例</param>
        /// <returns>添加完成状态</returns>
        public override bool Add(JG_SpvProtocol t)
        {
            return i(t);
        }
        /// <summary>
        /// 修改数据库中的协议数据
        /// </summary>
        /// <param name="t">协议实例</param>
        /// <returns>修改完成状态</returns>
        public override bool Update(JG_SpvProtocol t)
        {
            return u(t);
        }
        /// <summary>
        /// 删除数据库中一条协议
        /// </summary>
        /// <param name="t">协议条件</param>
        /// <returns>删除完成状态</returns>
        public override bool Delete(JG_SpvProtocol t)
        {
            return d(t);
        }
        /// <summary>
        /// 查看数据库中所有协议数据
        /// </summary>
        /// <returns>协议集合</returns>
        public override IList<JG_SpvProtocol> Selects()
        {
            return ss();
        }
        /// <summary>
        /// 查看数据库中特定的协议数据
        /// </summary>
        /// <param name="t">协议筛选实例</param>
        /// <returns>协议集合</returns>
        public override IList<JG_SpvProtocol> Select(JG_SpvProtocol t)
        {
            return s(t);
        }

        /// <summary>
        /// 根据条件获取协议信息
        /// </summary>
        /// <param name="jG_SpvProtocol"></param>
        /// <returns></returns>
        public static IList<JG_SpvProtocol> GetProtocolByCondition(JG_SpvProtocol jG_SpvProtocol)
        {
            return SqlMap.QueryForList<JG_SpvProtocol>("SelectProtocolByCondition", jG_SpvProtocol);
        }
    }
}

