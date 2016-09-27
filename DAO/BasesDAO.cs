﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;

namespace Dao
{
    /// <summary>
    /// 父DAO
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public abstract class BasesDAO<T> where T : new()
    {
        /// <summary>
        /// 默认Key
        /// </summary>
        protected string DefaultKey;
        /// <summary>
        /// SqlMap帮助对象
        /// </summary>
        protected static ISqlMapper SqlMap = BaseDao.SqlMap;

        #region 抽象方法
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="t">添加的对象</param>
        /// <returns>是否成功</returns>
        public virtual bool Add(T t) { throw new NotFiniteNumberException(); }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="t">修改的对象</param>
        /// <returns>是否成功</returns>
        public virtual bool Update(T t) { throw new NotFiniteNumberException(); }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="t">删除的筛选对象</param>
        /// <returns>是否成功</returns>
        public virtual bool Delete(T t) { throw new NotFiniteNumberException(); }
        /// <summary>
        /// 查看全部
        /// </summary>
        /// <returns>所有数据集合</returns>
        public virtual IList<T> Selects() { throw new NotFiniteNumberException(); }
        /// <summary>
        /// 查看筛选数据
        /// </summary>
        /// <param name="t">筛选对象</param>
        /// <returns>特定数据集合</returns>
        public virtual IList<T> Select(T t) { throw new NotFiniteNumberException(); }
        #endregion

        #region 帮助方法

        #region 私有方法
        /// <summary>
        /// 获取默认的一套IBatis Map的 各项操作Key
        /// </summary>
        /// <param name="state">标记值</param>
        /// <returns>默认操作标记</returns>
        private string GetKeyExp(KeyFlag state)
        {
            if (DefaultKey == null) throw new Exception("Error : DefaultKey is Null !");
            return state.ToString() + DefaultKey;
        } 
        #endregion

        #region 普通辅助
        protected virtual bool i(string Key, object t)
        {
            
            string sql = ShowSQL(Key, t);
            SqlMap.Insert(Key, t);
            return true;
        }
        protected virtual bool u(string Key, object t)
        {
            
            int result = (int)SqlMap.Update(Key, t);
            return result > 0;
        }
        protected virtual bool d(string Key, object t)
        {
            
            int result = (int)SqlMap.Delete(Key, t);
            return result > 0;
        }
        protected virtual IList<T> s(string Key, object t)
        {
            return SqlMap.QueryForList<T>(Key, t);
        }
        protected virtual IList<T> ss(string Key)
        {
            return SqlMap.QueryForList<T>(Key, null);
        } 
        #endregion

        #region 规范辅助
        protected bool i(T t)
        {
            return i(GetKeyExp(KeyFlag.Add), t);
        }
        protected bool u(T t)
        {
            return u(GetKeyExp(KeyFlag.Update), t);
        }
        protected bool d(object t)
        {
            return d(GetKeyExp(KeyFlag.Delete), t);
        }
        protected IList<T> s(T t)
        {
            return s(GetKeyExp(KeyFlag.Select), t);
        }
        protected IList<T> ss()
        {
            return ss(GetKeyExp(KeyFlag.Select));
        } 
        #endregion

        /// <summary>
        /// 获得输入SQL
        /// </summary>
        /// <param name="Key">标志</param>
        /// <param name="o">对象</param>
        /// <returns>SQL拼接后的语句</returns>
        public string ShowSQL(string Key,object o)
        {
            return MyBatis.QueryForSql(Key, o);
        }
        /// <summary>
        /// 获得DataTable
        /// </summary>
        /// <param name="key">标志</param>
        /// <param name="o">对象</param>
        /// <returns>数据表</returns>
        public System.Data.DataTable GetTable(string key,Object o)
        {
            return MyBatis.QueryForDataTable(key, o);
        }

        #endregion
        
    }
}
