﻿using System;
using Microsoft.Practices.Prism.Commands;
using FinancialRegulation.ClientException;
using Message.NewMessage.Response;
using Message.NewMessage.Request;

using System.Collections.ObjectModel;
using FundsRegulatoryClient;
using FundsRegulatoryClient.JG_PaymentSrv;
using FinancialRegulation.Tools;
namespace FinancialRegulation.ViewModel
{
    /// <summary>
    /// 冲正
    /// </summary>
    public class ReverseTradeVM : BaseEditVM<Request06>
    {
        #region 构造函数
        public ReverseTradeVM() { }
        public ReverseTradeVM(FundPayment df, ObservableCollection<FundPayment> Models) 
        {
            this.ReverseResponse = new Response06();
            this.df = df;
            this.Models = Models;
        }
        #endregion
        /// <summary>
        /// 客户端帮助
        /// </summary>
        public FundsRegulatoryClient.JG_PaymentClient deClient = FundsRegulatoryClient.JG_PaymentClient.Instance;
        public FundsRegulatoryClient.JG_AccountManageClient accountClient = FundsRegulatoryClient.JG_AccountManageClient.Instance;
        public FundsRegulatoryClient.SqlTransClient TranClient = FundsRegulatoryClient.SqlTransClient.Instance;
        public InterestManageClient InterestClient = InterestManageClient.Instance;
        public FundsRegulatoryClient.JG_SpvProtocolClient spvClient = FundsRegulatoryClient.JG_SpvProtocolClient.Instance;

        #region 构造加载

        /// <summary>
        /// 加载命令
        /// </summary>
        public override void LoadCommand()
        {
            
        }

        #endregion 构造加载

        #region 变量属性
        private ObservableCollection<FundPayment> Models;//列表集合
        private Response06 ReverseResponse;
        private FundPayment df;//列表选择的行的SelectedItem对象
        private FundsRegulatoryClient.JG_SpvProtocolSrv.JG_SpvProtocol _spvModel;

        /// <summary>
        /// 协议信息
        /// </summary>
        public FundsRegulatoryClient.JG_SpvProtocolSrv.JG_SpvProtocol SpvModel
        {
            get { return _spvModel; }
            set
            {
                _spvModel = value;
                this.RaisePropertyChanged("SpvModel");
            }
        }

        /// <summary>
        /// 存款性质
        /// </summary>

        private string NatureOfFunding;

        /// <summary>
        /// 报文响应
        /// </summary>
        private Response06 response;

        /// <summary>
        /// 支付信息
        /// </summary>
 

        /// <summary>
        /// 是否查询
        /// </summary>
        private bool IsSearch = false;

        #endregion 变量属性

        #region 命令定义

       
        #endregion 命令定义

        #region 命令方法

        /// <summary>
        /// 添加记录
        /// </summary>
        public override void OKExecute()
        {
            try
            {
                FundsRegulatoryClient.SqlTransSvr.FundPayment fptemp = new FundsRegulatoryClient.SqlTransSvr.FundPayment();
                string strAskMessage = "付款凭证编号：" + df.PaymentID + "\r\n应支付款金额：" + df.PaymentAmount + "\r\n收款人账号：" + df.ReceiverAccount + "\r\n收款人名称：" + df.ReceiverName +
                    "\r\n付款人账号：" + df.PayAccount + "\r\n付款人名称：" + df.PayName;
                if (VMHelp.AskMessage(strAskMessage + "\r\n确认进行冲正?"))
                {
                    fptemp.BusinessCode = CurrentObj.BusinessCode = FinancialRegulation.Tools.PublicData.ReverseFund;
                    fptemp.PaymentID = CurrentObj.PaymentID = df.PaymentID;
                    fptemp.BankSerialNumber = CurrentObj.ReverseSerialNum = df.SerialNumber;//本系统产生的流水号
                    fptemp.ReceiveBank = CurrentObj.ReverseBank = df.PaymentBank;
                    fptemp.BankSiteID = CurrentObj.BankSiteID = df.BankSiteID;
                    fptemp.BankTellerID = CurrentObj.BankTellerID = df.BankTellerID;
                    fptemp.PayID = df.PayID;
                    fptemp.FirmName = df.FirmName;
                    CurrentObj.BankCode = df.BankCode;
                    CurrentObj.ReverseType = Tools.PublicData.ReversePay;//支付冲正
                    response = SendMessage<Response06>(CurrentObj, VMHelp.PointCode, VMHelp.UserCode);
                    if (response.ReturnCode != Tools.PublicData.ResponseSuccess)
                    { VMHelp.ShowMessage(HelpClass.Current.MsgDIC[response.ReturnCode], false); return; }
                    fptemp.PayState = df.PayState = Tools.PublicData.ReverseA;
                    fptemp.ReverseTime = df.ReverseTime = DateTime.Now;
                    fptemp.ReverseInstr = df.ReverseInstr = CurrentObj.ReverseInstr;
                    fptemp.BankSiteID = VMHelp.PointCode;
                    fptemp.BankTellerID = VMHelp.UserCode;
                    fptemp.BusinessCode = df.BusinessCode = FinancialRegulation.Tools.PublicData.ReverseFund;
                    // fptemp.PayID = df.PayID;
                    //if (!deClient.Update(df))
                    //{
                    //    VMHelp.ShowMessage("支付数据更新失败",false);
                    //    return;
                    //}
                    FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo ami = new FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo();
                    ami.AM_JgAccount = df.PayAccount;
                    ObservableCollection<FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo> acc = accountClient.Select(ami);
                    FundsRegulatoryClient.InterestService.DayBalance db = new FundsRegulatoryClient.InterestService.DayBalance();
                    db.DB_ID = acc[0].AM_ID;
                    db.DB_Time = DateTime.Parse(DateTime.Now.ToShortDateString());
                    ObservableCollection<FundsRegulatoryClient.InterestService.DayBalance> dblist = new ObservableCollection<FundsRegulatoryClient.InterestService.DayBalance>();
                    dblist = InterestClient.SelectJG_DayBalanceInfo(db);
                    if (dblist.Count < 1)
                    {
                        VMHelp.ShowMessage("支付失败，数据无今日余额", false);
                        return;
                    }
                    FundsRegulatoryClient.SqlTransSvr.DayBalance temp = new FundsRegulatoryClient.SqlTransSvr.DayBalance();
                    temp.DB_Balance = dblist[0].DB_Balance;
                    temp.DB_InterestRate = dblist[0].DB_InterestRate;
                    temp.DB_Balance = temp.DB_Balance + df.PaymentAmount;
                    temp.ID = dblist[0].ID;
                    temp.DB_ID = acc[0].AM_ID;
                    temp.DB_Time = DateTime.Parse(DateTime.Now.ToShortDateString());
                    if (!TranClient.Update_DbAndPF(temp, fptemp, 2))
                    {
                        VMHelp.ShowMessage("失败原因：\r\n 1、支付表状态更新失败 \r\n 2、当日余额更新失败", false);
                        return;
                    }
                    //if (!InterestClient.UpdateJG_DayBalanceInfo(db))
                    //{
                    //    VMHelp.ShowMessage("今日余额更新失败", false);
                    //    return;
                    //}
                    VMHelp.ShowMessage(true);
                    windowOK();
                }
            }
            catch (Exception e)
            {
                 SendExcetpion(e);
            }
        }
        /// <summary>
        /// 检查到输入信息
        /// </summary>
        /// <returns>成功</returns>
        public override bool Check()
        {
           // CheckHelper.CustomerCheck<decimal>(CurrentObj.Money, "缴款金额不能小于1", (i) => i > 0);
           // CheckHelper.StrLengthCheck(CurrentObj.NatureOfFunding, "缴款类型", 10);
           
            return true;
        }

        #endregion 命令方法
    }
}