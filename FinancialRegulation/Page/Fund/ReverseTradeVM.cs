﻿using System;
using Microsoft.Practices.Prism.Commands;
using FinancialRegulation.ClientException;
using Message.NewMessage.Response;
using Message.NewMessage.Request;

using System.Collections.ObjectModel;
using FundsRegulatoryClient;
using FundsRegulatoryClient.JG_DepositSrv;
using FinancialRegulation.Tools;
namespace FinancialRegulation.ViewModel.Fund
{
    /// <summary>
    /// 冲正
    /// </summary>
    public class ReverseTradeVM : BaseEditVM<Request06>
    {
        #region 构造函数
        public ReverseTradeVM() { }
        public ReverseTradeVM(DepositFund df, ObservableCollection<DepositFund> Models) 
        {
            this.ReverseResponse = new Response06();
            this.df = df;
            this.Models = Models;
        }
        #endregion
        /// <summary>
        /// 客户端帮助
        /// </summary>
        public FundsRegulatoryClient.JG_DepositClient deClient = FundsRegulatoryClient.JG_DepositClient.Instance;
        public FundsRegulatoryClient.JG_AccountManageClient accountClient = FundsRegulatoryClient.JG_AccountManageClient.Instance;
        public InterestManageClient InterestClient = InterestManageClient.Instance;
        public FundsRegulatoryClient.JG_SpvProtocolClient spvClient = FundsRegulatoryClient.JG_SpvProtocolClient.Instance;
        public FundsRegulatoryClient.SqlTransClient TranClient = FundsRegulatoryClient.SqlTransClient.Instance;
        #region 构造加载

        /// <summary>
        /// 加载命令
        /// </summary>
        public override void LoadCommand()
        {
            
        }

        #endregion 构造加载

        #region 变量属性
        private ObservableCollection<DepositFund> Models;//列表集合
        private Response06 ReverseResponse;
        private DepositFund df;//列表选择的行的SelectedItem对象
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
                FundsRegulatoryClient.SqlTransSvr.DepositFund dftemp = new FundsRegulatoryClient.SqlTransSvr.DepositFund();
                string strAskMessage = "缴款凭证编号：" + df.DepositNum + "\r\n缴款类型：" + VMHelp.GetMoneyType(df.DepositType) + "\r\n缴款金额：" + df.DepositAmount + "\r\n购房人名称：" + df.PurchaserName + "\r\n购房人证件号：" + df.PurchaserID;
                if (VMHelp.AskMessage(strAskMessage + "\r\n确认进行冲正?"))
                {

                    dftemp.BusinessCode = CurrentObj.BusinessCode = FinancialRegulation.Tools.PublicData.ReverseFund;
                    dftemp.DepositNum = CurrentObj.PaymentID = df.DepositNum;
                    dftemp.DeSerialNumber = CurrentObj.ReverseSerialNum = df.SerialNumber;//本系统产生的流水号
                    dftemp.BankName = CurrentObj.ReverseBank = df.BankName;
                    dftemp.FirmName = df.FirmName;
                    dftemp.BankSiteID = CurrentObj.BankSiteID = df.BankSiteID;
                    dftemp.BankTellerID = CurrentObj.BankTellerID = df.BankTellerID;
                    dftemp.ID = df.ID;
                    dftemp.BankSiteID = VMHelp.PointCode;
                    dftemp.BankTellerID = VMHelp.UserCode;
                    CurrentObj.BankCode = df.BankCode;
                    CurrentObj.ReverseType = Tools.PublicData.ReverseDeposit;//存款冲正
                    response = SendMessage<Response06>(CurrentObj, VMHelp.PointCode, VMHelp.UserCode);//发送Messageresponse.ReturnCode =="03" 
                    //if (response.ReturnCode != Tools.PublicData.ResponseSuccess && response.ReturnCode == Tools.PublicData.ReverseSucces)
                    //{ VMHelp.ShowMessage("原交易不存在无法冲正", false); return; }
                    //if (response.ReturnCode == Tools.PublicData.DepositSuccess && !VMHelp.AskMessage("缴款书已完成缴费,是否存数据库？"))
                    //{
                    //    return;
                    //}
                    //返回码为失败时
                    if (response.ReturnCode != Tools.PublicData.ResponseSuccess )
                    { VMHelp.ShowMessage(HelpClass.Current.MsgDIC[response.ReturnCode], false); return; }

                    dftemp.DepositState = df.DepositState = Tools.PublicData.ReverseA;
                    dftemp.ReverseTime = df.ReverseTime = DateTime.Now;
                    dftemp.ReverseInstr = df.ReverseInstr = CurrentObj.ReverseInstr;
                    dftemp.BusinessCode = df.BusinessCode = FinancialRegulation.Tools.PublicData.ReverseFund;

                    FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo ami = new FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo();
                    ami.AM_JgAccount = df.DepositAccount;
                    ObservableCollection<FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo> acc = accountClient.Select(ami);
                    FundsRegulatoryClient.InterestService.DayBalance db = new FundsRegulatoryClient.InterestService.DayBalance();
                    db.DB_ID = acc[0].AM_ID;
                    db.DB_Time = DateTime.Parse(DateTime.Now.ToShortDateString());
                    ObservableCollection<FundsRegulatoryClient.InterestService.DayBalance> dblist = new ObservableCollection<FundsRegulatoryClient.InterestService.DayBalance>();
                    dblist = InterestClient.SelectJG_DayBalanceInfo(db);
                    if (dblist.Count < 1)
                    {
                        VMHelp.ShowMessage("冲正失败，数据无今日余额", false);
                        return;
                    }
                    FundsRegulatoryClient.SqlTransSvr.DayBalance temp = new FundsRegulatoryClient.SqlTransSvr.DayBalance();
                    temp.DB_Balance = dblist[0].DB_Balance;
                    temp.DB_InterestRate = dblist[0].DB_InterestRate;
                    temp.DB_Balance = temp.DB_Balance - df.DepositAmount;
                    temp.ID = dblist[0].ID;
                    temp.DB_ID = acc[0].AM_ID;
                    temp.DB_Time = DateTime.Parse(DateTime.Now.ToShortDateString());
                    if (!TranClient.Update_DbAndDF(temp, dftemp, 2))
                    {
                        VMHelp.ShowMessage("失败原因：\r\n 1、存款表状态更新失败 \r\n 2、当日余额更新失败", false);
                        return;
                    }
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