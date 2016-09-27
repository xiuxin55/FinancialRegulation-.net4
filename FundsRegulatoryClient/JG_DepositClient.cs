using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundsRegulatoryClient.JG_DepositSrv;
using System.Collections.ObjectModel;

namespace FundsRegulatoryClient
{
    /// <summary>
    /// 支付
    /// </summary>
    public sealed class JG_DepositClient : BaseClient<JG_DepositService>
    {
        private static JG_DepositClient _instance;
        /// <summary>
        /// 获取 [存款] 操作对象实例
        /// </summary>
        public static JG_DepositClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new JG_DepositClient();
                }
                return _instance;
            }
        }

        #region 基础物理操作(增删改查)
        /// <summary>
        /// 添加对象 存款
        /// </summary>
        /// <param name="m"></param>
        /// <returns>完成状态</returns>
        public bool Add(DepositFund  m)
        {
            return service.Add(m);
        }
        /// <summary>
        /// 更新对象 存款
        /// </summary>
        /// <param name="m">更新的对象</param>
        /// <returns>完成状态</returns>
        public bool Update(DepositFund m)
        {
            return service.Update(m);
        }
        /// <summary>
        /// 删除对象 存款
        /// </summary>
        /// <param name="m"></param>
        /// <returns>完成状态</returns>
        public bool Delete(DepositFund m)
        {
            return service.Delete(m);
        }
        /// <summary>
        /// 查看所有对象 存款
        /// </summary>
        /// <returns>对象集合</returns>
        public ObservableCollection<DepositFund> Selects()
        {
            
            List<DepositFund> temp =service.Selects().ToList<DepositFund>();
            ObservableCollection<DepositFund> oj = new ObservableCollection<DepositFund>();
            temp.ForEach(p => oj.Add(p));
            return oj;
        }
        /// <summary>
        /// 查看特定对象 存款
        /// </summary>
        /// <param name="m">筛选实例</param>
        /// <returns>对象集合</returns>
        public List<DepositFund> Select(DepositFund m)
        {
            return service.Select(m).ToList<DepositFund>();
        }
        #endregion

        #region 业务逻辑操作
        /// <summary>
        /// 根据协议编号获取所有存款
        /// </summary>
        /// <param name="XYBH">协议编号</param>
        /// <returns>剩余金额</returns>
        public int GetAccountMoney(string XYBH)
        {
            return service.GetAccountMoney(XYBH);
        }
        /// <summary>
        /// 不明账款缴存
        /// </summary>
        /// <param name="jdInfo"></param>
        /// <returns></returns>
        public bool AddUnKownJG_Deposit(UnknowBill jdInfo)
        {
            return service.AddUnKownJG_Deposit(jdInfo);
        }
        /// <summary>
        /// 不明账款返回集合
        /// </summary>
        /// <param name="jdInfo"></param>
        /// <returns></returns>
        public ObservableCollection<UnknowBill> SelectUnKownJG_Deposit(UnknowBill jdInfo)
        {
            ObservableCollection<UnknowBill> temp = new ObservableCollection<UnknowBill>();
            List<UnknowBill> list = service.SelectUnKownJG_Deposit().ToList<UnknowBill>();
            list.ForEach(p=>temp.Add(p));
            return temp;
        }
        /// <summary>
        /// 不明账款更新
        /// </summary>
        /// <param name="jdInfo"></param>
        /// <returns></returns>
        public bool UpdateUnKownJG_Deposit(UnknowBill jdInfo)
        {
            return service.UpdateUnKownJG_Deposit(jdInfo);
        }
        public bool DeleteUnKownJG_Deposit(UnknowBill jdInfo)
        {
            return service.DeleteUnKownJG_Deposit(jdInfo);
        }
        /// <summary>
        /// 返回存款信息
        /// </summary>
        /// <returns></returns>
        public List<DepositFund> SelectDepositInfoList(JG_DepositSrv.DictionaryEntry[] array)
        {
            return new List<DepositFund>(service.SelectDepositInfoList(array));
        }
        /// <summary>
        /// 查询结息
        /// </summary>
        /// <param name="m">筛选实例</param>
        /// <returns>对象集合</returns>
        public List<DepositFund> SelectPayAccrual()
        {
            //资金性质 9 结息 存款类别1 存款
            DepositFund info = new DepositFund()
            {
               // _DE_ckxz = "9",
                //_DE_cklb = "1"
            };

            return service.Selectn(info).ToList<DepositFund>();
        }
        /// <summary>
        /// 结息
        /// </summary>
        /// <returns></returns>
        public bool PayAccrual(DepositFund accrual)
        {
            if (accrual == null) throw new NullReferenceException("结息对象为空");
           // accrual._DE_cklb = "1";//存款类别  1 类别 
//accrual._DE_ckxz = "9";//存款性质 9 结息
            return Add(accrual); //添加
        }
        #endregion
        
    }
}

