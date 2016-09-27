using System;
using System.Collections.Generic;
using MODEL.NewModel;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
namespace Dao
{
    /// <summary>
    /// 存款数据库操作类
    /// </summary>
    public  class JG_DepositDao : BasesDAO<DepositFund>
    {
        /// <summary>
        /// 构建 存款数据库操作类
        /// </summary>
        private JG_DepositDao()
        {
            DefaultKey = "JG_Deposit";
        }

        private static JG_DepositDao _instance;
        /// <summary>
        /// 获取 存款数据库操作类实例
        /// </summary>
        public static JG_DepositDao Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new JG_DepositDao();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 向数据库中添加一个存款的新实例
        /// </summary>
        /// <param name="t">存款新实例</param>
        /// <returns>添加完成状态</returns>
        public override bool Add(DepositFund t)
        {
            return i(t);
        }
        /// <summary>
        /// 修改数据库中的存款数据
        /// </summary>
        /// <param name="t">存款实例</param>
        /// <returns>修改完成状态</returns>
        public override bool Update(DepositFund t)
        {
         
            return u(t);
        }
        /// <summary>
        /// 删除数据库中一条存款
        /// </summary>
        /// <param name="t">存款条件</param>
        /// <returns>删除完成状态</returns>
        public override bool Delete(DepositFund t)
        {
            return d(t);
        }
        /// <summary>
        /// 查看数据库中所有存款数据
        /// </summary>
        /// <returns>存款集合</returns>
        public override IList<DepositFund> Selects()
        {
            return ss();
        }
        /// <summary>
        /// 查看数据库中特定的存款数据
        /// </summary>
        /// <param name="t">存款筛选实例</param>
        /// <returns>存款集合</returns>
        public override IList<DepositFund> Select(DepositFund t)
        {
            return s(t);
        }
        /// <summary>
        /// 根据协议获取账户余额
        /// </summary>
        /// <param name="XYBH">协议编号</param>
        /// <returns>账户余额</returns>
        public  int GetAccountMoney(string XYBH)
        {
            object o = SqlMap.QueryForObject("GetAccountMoney", XYBH);
            return o==null?0:(int)o;
        }

        /// <summary>
        /// 不明账款缴存
        /// </summary>
        /// <param name="jdInfo"></param>
        /// <returns></returns>
        public bool AddUnKownJG_Deposit(UnknowBill jdInfo)
        {
            try
            {
                SqlMap.Insert("AddUnKownJG_Deposit", jdInfo);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 不明账款更新
        /// </summary>
        /// <param name="jdInfo"></param>
        /// <returns></returns>
        public bool UpdateUnKownJG_Deposit(UnknowBill jdInfo)
        {
            try
            {
                SqlMap.Update("UpdateUnKownJG_Deposit", jdInfo);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 不明账款返回集合
        /// </summary>
        /// <param name="jdInfo"></param>
        /// <returns></returns>
        public List<UnknowBill> SelectUnKownJG_Deposit()
        {
            try
            {
                return SqlMap.QueryForList<UnknowBill>("SelectUnKownJG_Deposit", null).ToList<UnknowBill>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteUnKownJG_Deposit(UnknowBill ub)
        {
            try
            {
                int result=SqlMap.Delete("DeleteUnKownJG_Deposit", ub);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 用于非关联表的查询 一大失误!当初没有想到呢
        /// </summary>
        /// <param name="jdInfo"></param>
        /// <returns></returns>
        public IList<DepositFund> Selectn(DepositFund jdInfo)
        {
            return s("SelectJG_Deposits", jdInfo);
        }


        /// <summary>
        /// 返回存款信息
        /// </summary>
        /// <param name="jdInfo"></param>
        /// <returns></returns>
        public static IList<DepositFund> SelectDepositInfoList(DictionaryEntry[] array)
        {
            try
            {
                if (array == null)
                    return null;
                Hashtable obj = new Hashtable();

                foreach (DictionaryEntry entry in array)
                {
                    obj.Add(entry.Key, entry.Value);
                }

                return SqlMap.QueryForList<DepositFund>("SelectDepositInfoList", obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
       
    }
}

