using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dao
{
    /// <summary>
    /// 标记值(用于定义XML Map的前缀)
    /// </summary>
    public enum KeyFlag
    {
        /// <summary>
        /// 添加
        /// </summary>
        Add,
        /// <summary>
        /// 修改
        /// </summary>
        Update,
        /// <summary>
        /// 删除
        /// </summary>
        Delete,
        /// <summary>
        /// 查询
        /// </summary>
        Select
    }
}
