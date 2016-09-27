﻿using System;
using Microsoft.Practices.Prism.Commands;
using FinancialRegulation.ClientException;
using Message.NewMessage.Response;
using Message.NewMessage.Request;
using System.Collections.ObjectModel;
using FundsRegulatoryClient;
using FundsRegulatoryClient.JG_PaymentSrv;
namespace FinancialRegulation.ViewModel
{
    /// <summary>
    /// 存款补录
    /// </summary>
    public class PayInfoAddToEditVM : BaseEditVM<Request05>
    {
        #region 构造函数
        public PayInfoAddToEditVM() { }
        public PayInfoAddToEditVM(Response04 PayResponse, FundPayment df, ObservableCollection<FundPayment> Models) 
        { 
            this.PayResponse = new Response04();
            this.PayResponse = PayResponse;
            this.df = df;
            this.Models = Models;
        }
        #endregion
        /// <summary>
        /// 客户端帮助
        /// </summary>
        public FundsRegulatoryClient.JG_PaymentClient deClient = FundsRegulatoryClient.JG_PaymentClient.Instance;
        public FundsRegulatoryClient.JG_AccountManageClient accountClient = FundsRegulatoryClient.JG_AccountManageClient.Instance;
        public InterestManageClient InterestClient = InterestManageClient.Instance;
        public FundsRegulatoryClient.JG_SpvProtocolClient spvClient = FundsRegulatoryClient.JG_SpvProtocolClient.Instance;
        FundsRegulatoryClient.SqlTransClient sqlTran = FundsRegulatoryClient.SqlTransClient.Instance;

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
        private Response04 PayResponse;
        private FundPayment df;//列表选择的行的SelectedItem对象
        private FundsRegulatoryClient.JG_SpvProtocolSrv.JG_SpvProtocol _spvModel;

        private string _bankSerialNumber;
        /// <summary>
        /// 银行流水号
        /// </summary>
        public string BankSerialNumber
        {
            get { return _bankSerialNumber; }
            set
            {
                _bankSerialNumber = value;
                this.RaisePropertyChanged("BankSerialNumber");
            }
        }
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
        private Response05 response;

        /// <summary>
        /// 支付信息
        /// </summary>
        private FundPayment model;
        private FundsRegulatoryClient.SqlTransSvr.FundPayment model2;
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
                string strAskMessage = "付款凭证编号：" + PayResponse.PaymentID + "\r\n应支付款金额：" + PayResponse.PaymentAmount + "\r\n收款人账号：" + PayResponse.ReceiverAccount + "\r\n收款人名称：" + PayResponse.ReceiverName +
                    "\r\n付款人账号：" + PayResponse.PayerAccount + "\r\n付款人名称：" + PayResponse.PayerName;
                if (Check() && VMHelp.AskMessage(strAskMessage + "\r\n确认进行存款?"))
                {
                    model = new FundPayment();
                    model2 = new FundsRegulatoryClient.SqlTransSvr.FundPayment();
                    // model. = Guid.NewGuid().ToString();
                    model2.BusinessCode = CurrentObj.BusinessCode = model.BusinessCode = FinancialRegulation.Tools.PublicData.FundPay;//交易代码
                    model2.BankCode = CurrentObj.BankCode = model.BankCode = VMHelp.BankCode;
                    model2.PaymentAmount = CurrentObj.PaymentAmount = model.PaymentAmount = PayResponse.PaymentAmount;//支付金额
                    model2.FirmOperatorName = model.FirmOperatorName = CurrentObj.FirmOperatorName;//企业经办人
                    model2.FirmOperatorID = model.FirmOperatorID = CurrentObj.FirmOperatorID;//经办人证件号
                    model2.PaymentBank = model.PaymentBank = CurrentObj.PaymentBank = VMHelp.BankName;//支付银行
                    model2.BankSiteID = CurrentObj.BankSiteID = model.BankSiteID = VMHelp.PointCode; //网点号
                    model2.BankSerialNumber = model.BankSerialNumber = BankSerialNumber;// 银行流水号
                    model2.SerialNumber = model.SerialNumber = CurrentObj.SerialNumber = VMHelp.ServiceNo;//当前流水号
                    model2.BankTellerID = CurrentObj.BankTellerID = model.BankTellerID = VMHelp.UserCode;//柜员号
                    model2.PaymentInstr = model.PaymentInstr = CurrentObj.PaymentInstr;//付款说明
                    model2.PayState = model.PayState = Tools.PublicData.PayA;
                    model2.PaymentID = model.PaymentID = CurrentObj.PaymentID = PayResponse.PaymentID;//支付凭证编号
                    model2.ReceiverAccount = model.ReceiverAccount = PayResponse.ReceiverAccount;
                    model2.ReceiverName = model.ReceiverName = PayResponse.ReceiverName;
                    model2.ReceiveBank = model.ReceiveBank = PayResponse.ReceiverBankName;
                    model2.PayName = model.PayName = PayResponse.PayerName;
                    model2.PayAccount = model.PayAccount = PayResponse.PayerAccount;
                    model2.PaymentBank = model.PaymentBank = PayResponse.PayBank;
                    model2.ProjectCode = model.ProjectCode = PayResponse.ProjectID;
                    // model2.FirmName = model.FirmName = "";//公司名称
                    //model._DE_cklb = Tools.PublicData.Deposit_Lf;
                    //CurrentObj.BusinessTime = VMHelp.NowTime.ToString();

                    if (df != null)
                    {
                        model2.PayID = model.PayID = df.PayID;
                        model2.PaymentTime = model.PaymentTime = DateTime.Parse(VMHelp.NowTime);//缴款日期
                    }
                    else
                    {
                        model2.PayID = model.PayID = VMHelp.GUID;
                        model2.PaymentTime = model.PaymentTime = model.PaymentConfirmTime = DateTime.Parse(VMHelp.NowTime);//缴款日期
                    }
                    FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo ami = new FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo();
                    ami.AM_JgAccount = model.PayAccount;
                    ObservableCollection<FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo> acc = accountClient.Select(ami);
                    if (acc.Count < 1 || acc[0].AM_UseFlag == "销户")
                    {
                        VMHelp.ShowMessage("付款账户不存在或已销户", false);
                        return;
                    }
                    ////获取企业名称
                    model2.FirmName = model.FirmName = acc[0].AM_CorpName;
                    FundsRegulatoryClient.InterestService.DayBalance db = new FundsRegulatoryClient.InterestService.DayBalance();
                    db.DB_ID = acc[0].AM_ID;
                    db.DB_Time = DateTime.Parse(DateTime.Now.ToShortDateString());
                    ObservableCollection<FundsRegulatoryClient.InterestService.DayBalance> dblist = new ObservableCollection<FundsRegulatoryClient.InterestService.DayBalance>();
                    dblist = InterestClient.SelectJG_DayBalanceInfo(db);
                    if (dblist.Count < 0)
                    {
                        VMHelp.ShowMessage("支付失败，数据无今日余额", false);
                        return;
                    }
                    if (dblist[0].DB_Balance < model.PaymentAmount)
                    {
                        VMHelp.ShowMessage("账户余额不足，无法支付", false);
                        return;
                    }
                    response = SendMessage<Response05>(CurrentObj, VMHelp.PointCode, VMHelp.UserCode);//发送Messageresponse.ReturnCode =="00" 
                    if (response.ReturnCode == Tools.PublicData.ResponseSuccess || response.ReturnCode == Tools.PublicData.PaymentSuccess)
                    {
                        if (response.ReturnCode == Tools.PublicData.PaymentSuccess && !VMHelp.AskMessage("付款凭证已完成付款,是否存数据库？"))
                        {
                            return;
                        }
                        if (df != null)
                        {
                            FundsRegulatoryClient.SqlTransSvr.DayBalance temp = new FundsRegulatoryClient.SqlTransSvr.DayBalance();
                            temp.DB_Balance = dblist[0].DB_Balance;
                            temp.DB_InterestRate = dblist[0].DB_InterestRate;
                            temp.DB_Balance = temp.DB_Balance - model.PaymentAmount;
                            temp.ID = dblist[0].ID;
                            temp.DB_ID = acc[0].AM_ID;
                            temp.DB_Time = DateTime.Parse(DateTime.Now.ToShortDateString());
                            if (sqlTran.Update_DbAndPF(temp, model2, 2))
                            {
                                VMHelp.ShowMessage(true);//"付款凭证已经完成支付",
                                windowOK();
                            }
                            else
                            {
                                VMHelp.ShowMessage("操作失败原因：\r\n 1、支付表更新失败 \r\n 2、余额表更新失败", false);
                                return;
                            }
                        }
                        else
                        {
                            //if (dblist[0].DB_Balance < model.PaymentAmount)
                            //{
                            //    VMHelp.ShowMessage("账户余额不足，无法支付", false);
                            //    return;
                            //}
                            FundsRegulatoryClient.SqlTransSvr.DayBalance temp = new FundsRegulatoryClient.SqlTransSvr.DayBalance();
                            temp.DB_Balance = dblist[0].DB_Balance;
                            temp.DB_InterestRate = dblist[0].DB_InterestRate;
                            temp.DB_Balance = temp.DB_Balance - model.PaymentAmount;
                            temp.ID = dblist[0].ID;
                            temp.DB_ID = acc[0].AM_ID;
                            temp.DB_Time = DateTime.Parse(DateTime.Now.ToShortDateString());
                            if (sqlTran.Update_DbAndPF(temp, model2, 1))
                            {
                                VMHelp.ShowMessage(true);//"付款凭证已经完成支付",
                                windowOK();
                            }
                            else
                            {
                                VMHelp.ShowMessage("操作失败原因：\r\n 1、支付表添加失败 \r\n 2、余额表更新失败", false);
                                return;
                            }
                        }
                    }
                    else //if (response.ReturnCode == Tools.PublicData.PaymentFail)
                    {
                        VMHelp.ShowMessage("付款凭证不存在", false);
                    }
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
            CheckHelper.NotNullCheck(BankSerialNumber, "流水账号");
            CheckHelper.NotNullCheck(CurrentObj.FirmOperatorName, "企业经办人");
            CheckHelper.NotNullCheck(CurrentObj.FirmOperatorID, "经办人证件号");
           // CheckHelper.StrLengthCheck(CurrentObj.NatureOfFunding, "缴款类型", 10);
           
            return true;
        }

        #endregion 命令方法

       
    }
}