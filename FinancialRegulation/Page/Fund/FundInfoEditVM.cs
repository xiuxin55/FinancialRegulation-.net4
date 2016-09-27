﻿using System;
using Microsoft.Practices.Prism.Commands;
using FinancialRegulation.ClientException;
using Message.NewMessage.Response;
using Message.NewMessage.Request;
using FundsRegulatoryClient.JG_DepositSrv;
using System.Collections.ObjectModel;
using FundsRegulatoryClient;
namespace FinancialRegulation.ViewModel
{
    /// <summary>
    /// 存款补录
    /// </summary>
    public class FundInfoEditVM : BaseEditVM<Request03>
    {
        #region 构造函数
        public FundInfoEditVM() { }
        public FundInfoEditVM(Response02 DepositResponse, DepositFund df, ObservableCollection<DepositFund> Models) 
        {
            this.DepositResponse = DepositResponse;
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
        private Response02 DepositResponse;
        private DepositFund df;//列表选择的行的SelectedItem对象
        private FundsRegulatoryClient.JG_SpvProtocolSrv.JG_SpvProtocol _spvModel;

        private string _bankSerialNumber;
        /// <summary>
        /// 银行流水号
        /// </summary>
        public string BankSerialNumber
        {
            get { return _bankSerialNumber; }
            set { _bankSerialNumber = value;
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
        private Response03 response;

        /// <summary>
        /// 存款信息
        /// </summary>
        private FundsRegulatoryClient.SqlTransSvr.DepositFund model;
        private FundsRegulatoryClient.JG_DepositSrv.DepositFund model2;
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

                string strAskMessage = "缴款凭证编号：" + DepositResponse.DepositID + "\r\n缴款类型：" + VMHelp.GetMoneyType(DepositResponse.DepositType) + "\r\n缴款金额：" + DepositResponse.DepositAmount + "\r\n购房人名称：" + DepositResponse.PurchaserName + "\r\n购房人证件号：" + DepositResponse.PurchaserID;
                if (Check() && VMHelp.AskMessage(strAskMessage + "\r\n确认进行存款?"))
                {

                    model = new FundsRegulatoryClient.SqlTransSvr.DepositFund();
                    model2 = new DepositFund();
                    // model. = Guid.NewGuid().ToString();
                    model2.BusinessCode = CurrentObj.BusinessCode = model.BusinessCode = FinancialRegulation.Tools.PublicData.FundDeposit;//交易代码
                    model2.BankCode = CurrentObj.BankCode = model.BankCode = VMHelp.BankCode;//银行代码
                    model2.DepositNum = CurrentObj.DepositID = model.DepositNum = DepositResponse.DepositID;//缴款凭证编号
                    model2.DepositType = model.DepositType = DepositResponse.DepositType;//缴款类型
                    model2.DepositAmount = CurrentObj.DepositAmount = model.DepositAmount = DepositResponse.DepositAmount;//缴款金额
                    model2.PurchaserName = CurrentObj.PurchaserName = model.PurchaserName = DepositResponse.PurchaserName;//购房人名称
                    model2.PurchaserID = CurrentObj.PurchaserID = model.PurchaserID = DepositResponse.PurchaserID;//购房人证件号

                    model2.BankSiteID = CurrentObj.BankSiteID = model.BankSiteID = VMHelp.PointCode; //网点号
                    model2.DeSerialNumber = model.DeSerialNumber = BankSerialNumber;// VMHelp.ServiceNo;//银行流水号
                    model2.SerialNumber = model.SerialNumber=CurrentObj.SerialNumber = VMHelp.ServiceNo;//当前系统流水号
                    model2.BankTellerID = CurrentObj.BankTellerID = model.BankTellerID = VMHelp.UserCode;//柜员号
                    model2.BankName = model.BankName = VMHelp.BankName;//银行名称
                    model2.FirmName = model.FirmName = DepositResponse.FirmName;
                    model2.DepositAccount = model.DepositAccount = DepositResponse.DepositAccount;
                    model2.ProjectCode = model.ProjectCode = DepositResponse.ProjectCode;
                    model2.DepositInstr = model.DepositInstr = CurrentObj.DepositInstr;//缴款说明
                    model2.DepositState = model.DepositState = Tools.PublicData.DepositA;
                    //model._DE_cklb = Tools.PublicData.Deposit_Lf;
                    //CurrentObj.BusinessTime = VMHelp.NowTime.ToString();
                    CurrentObj.BankName = VMHelp.BankName;//缴款银行名称
                    if (df != null)
                    {
                        model2.ID = model.ID = df.ID;
                        model2.DepositTime = model.DepositTime = DateTime.Parse(VMHelp.NowTime);//缴款日期
                    }
                    else
                    {
                        model2.ID = model.ID = VMHelp.GUID;
                        model2.DepositTime = model.CheckTime = model.DepositTime = DateTime.Parse(VMHelp.NowTime);//缴款日期
                    }
                    FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo ami = new FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo();
                    ami.AM_JgAccount = model.DepositAccount;
                    ObservableCollection<FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo> acc = accountClient.Select(ami);
                    if (acc.Count < 1 || acc[0].AM_UseFlag == "销户")
                    {
                        VMHelp.ShowMessage("缴款失败，缴存账户不存在或已销户", false);
                        return;
                    }
                    FundsRegulatoryClient.InterestService.DayBalance db = new FundsRegulatoryClient.InterestService.DayBalance();
                    db.DB_ID = acc[0].AM_ID;
                    db.DB_Time = DateTime.Parse(DateTime.Now.ToShortDateString());
                    ObservableCollection<FundsRegulatoryClient.InterestService.DayBalance> dblist = new ObservableCollection<FundsRegulatoryClient.InterestService.DayBalance>();
                    dblist = InterestClient.SelectJG_DayBalanceInfo(db);
                    if (dblist.Count < 1)
                    {
                        VMHelp.ShowMessage("缴款失败，余额表无当日余额", false);
                        return;
                    }
                    response = SendMessage<Response03>(CurrentObj, VMHelp.PointCode, VMHelp.UserCode);//发送Messageresponse.ReturnCode =="03" 

                    if (response.ReturnCode == Tools.PublicData.ResponseSuccess || response.ReturnCode == Tools.PublicData.DepositSuccess)
                    {
                        if (response.ReturnCode == Tools.PublicData.DepositSuccess && !VMHelp.AskMessage("缴款书已完成缴费,是否存数据库？"))
                        {
                            return;
                        }
                        if (df != null)
                        {
                                FundsRegulatoryClient.SqlTransSvr.DayBalance temp = new FundsRegulatoryClient.SqlTransSvr.DayBalance();
                                temp.DB_Balance = dblist[0].DB_Balance;
                                temp.DB_InterestRate = dblist[0].DB_InterestRate;
                                temp.DB_Balance = temp.DB_Balance + model.DepositAmount;
                                temp.ID = dblist[0].ID;
                                temp.DB_ID = acc[0].AM_ID;
                                temp.DB_Time = DateTime.Parse(DateTime.Now.ToShortDateString());

                                if (!TranClient.Update_DbAndDF(temp, model, 2))
                                {
                                    VMHelp.ShowMessage("错误原因：\r\n 1、存款信息插入失败  \r\n 2、当日余额更新失败", false);
                                    return;
                                }
                                //this.Models.Remove(df);
                                //this.Models.Add(model2);
                                VMHelp.ShowMessage(true);
                                windowOK();
                                                     
                        }
                        else
                        {
                                FundsRegulatoryClient.SqlTransSvr.DayBalance temp = new FundsRegulatoryClient.SqlTransSvr.DayBalance();
                                temp.DB_Balance = dblist[0].DB_Balance;
                                temp.DB_InterestRate = dblist[0].DB_InterestRate;
                                temp.DB_Balance = temp.DB_Balance + model.DepositAmount;
                                temp.ID = dblist[0].ID;
                                temp.DB_ID = acc[0].AM_ID;
                                temp.DB_Time = DateTime.Parse(DateTime.Now.ToShortDateString());
                                if (!TranClient.Update_DbAndDF(temp, model, 1))
                                {
                                    VMHelp.ShowMessage("错误原因：\r\n 1、存款信息插入失败  \r\n 2、当日余额更新失败", false);
                                    return;
                                }

                                VMHelp.ShowMessage(true);
                                windowOK();
                           
                        }
                    }
                    else //if (response.ReturnCode == Tools.PublicData.DepositFail)
                    {
                        VMHelp.ShowMessage("缴款书不存在", false);
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
           // CheckHelper.StrLengthCheck(CurrentObj.NatureOfFunding, "缴款类型", 10);
           
            return true;
        }

        #endregion 命令方法

       
    }
}