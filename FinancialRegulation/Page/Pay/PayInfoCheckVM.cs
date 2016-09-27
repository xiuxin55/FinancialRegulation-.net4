﻿using System;
using Microsoft.Practices.Prism.Commands;
using FinancialRegulation.ClientException;
using FinancialRegulation.Page;
using FundsRegulatoryClient.JG_PaymentSrv;
using System.Collections.ObjectModel;
namespace FinancialRegulation.ViewModel
{
    /// <summary>
    /// 存款补录
    /// </summary>
    public class PayInfoCheckVM : BaseEditVM<Message.NewMessage.Response.Response04>, ISearch
    {
        #region 构造函数
        public PayInfoCheckVM(ObservableCollection<FundsRegulatoryClient.JG_PaymentSrv.FundPayment> OBModels)
        {

            this.OBModels = OBModels;
            CurrentObj = new Message.NewMessage.Response.Response04();
        }
        #endregion
        /// <summary>
        /// 客户端帮助
        /// </summary>
        public FundsRegulatoryClient.JG_PaymentClient deClient = FundsRegulatoryClient.JG_PaymentClient.Instance;

        public FundsRegulatoryClient.JG_SpvProtocolClient spvClient = FundsRegulatoryClient.JG_SpvProtocolClient.Instance;
       
        #region 构造加载

        /// <summary>
        /// 加载命令
        /// </summary>
        public override void LoadCommand()
        {
            SearchCommand = new DelegateCommand(SearchExecute);
            DepositCommand = new DelegateCommand(DepositExecute);
           

        }

        #endregion 构造加载

        #region 变量属性
        private ObservableCollection<FundsRegulatoryClient.JG_PaymentSrv.FundPayment> OBModels;//列表集合
        private Message.NewMessage.Request.Request04 _searchInfo;

        /// <summary>
        /// 缴存信息查询检索
        /// </summary>
        public Message.NewMessage.Request.Request04 SearchInfo
        {
            get
            {
                if (_searchInfo == null) _searchInfo = new Message.NewMessage.Request.Request04();
                return _searchInfo;
            }
            set
            {
                _searchInfo = value;
                RaisePropertyChanged("SearchInfo");
                IsSearch = false;
            }
        }

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
        /// 缴款类型
        /// </summary>

        private string NatureOfFunding;

        /// <summary>
        /// 报文响应
        /// </summary>
        private Message.NewMessage.Response.Response04 response;

        /// <summary>
        /// 存款信息
        /// </summary>
        private FundsRegulatoryClient.JG_DepositSrv.DepositFund Models;

        /// <summary>
        /// 是否查询
        /// </summary>
        private bool IsSearch = false;

        #endregion 变量属性

        #region 命令定义
        private DelegateCommand depositCommand;
        /// <summary>
        /// 缴存命令
        /// </summary>
        public DelegateCommand DepositCommand
        {
            get { return depositCommand; }
            set { depositCommand = value; }
        }
        private DelegateCommand _searchCommand;

        /// <summary>
        /// 缴存信息查询命令
        /// </summary>
        public DelegateCommand SearchCommand
        {
            get
            {
                return _searchCommand;
            }
            set
            {
                _searchCommand = value;
                RaisePropertyChanged("SearchCommand");
            }
        }

        #endregion 命令定义

        #region 命令方法

        /// <summary>
        /// 添加未交费记录
        /// </summary>
        public override void OKExecute()
        {
            //IsSearch = true;
            //判断是否查询并且正确
            if (!IsSearch)
            {
                VMHelp.ShowMessage("未进行缴款凭证编号的查询，不可提交", false);
                return;
            }
            
            FundPayment temp = new FundPayment();
            temp.BusinessCode = FinancialRegulation.Tools.PublicData.QueryFundPay;
            temp.PaymentID = SearchInfo.PaymentNum;
           // temp.BusinessCode = CurrentObj.BusinessCode;
            temp.PaymentAmount = CurrentObj.PaymentAmount;
            temp.ReceiverAccount = CurrentObj.ReceiverAccount;
            temp.ReceiverName = CurrentObj.ReceiverName;
            temp.ReceiveBank = CurrentObj.ReceiverBankName;
            temp.PayAccount = CurrentObj.PayerAccount;
            temp.PayName = CurrentObj.PayerName;
            temp.PaymentBank = CurrentObj.PayBank;
            temp.ProjectCode = CurrentObj.ProjectID;
           // temp.DepositTime = DateTime.Parse(VMHelp.NowTime);
            temp.PaymentConfirmTime = DateTime.Parse(VMHelp.NowTime);
            temp.PayState = Tools.PublicData.PayB;
            temp.BankSiteID = VMHelp.PointCode;
            temp.BankTellerID = VMHelp.UserCode;
            temp.PayID = VMHelp.GUID;
            deClient.Add(temp);
            OBModels.Add(temp);
            windowOK(); 
        }
        /// <summary>
        /// 进行缴款
        /// </summary>
        private void DepositExecute()
        {
            //IsSearch = true;
            //判断是否查询并且正确
            if (!IsSearch)
            {
                VMHelp.ShowMessage("未进行缴款凭证编号的查询，不可提交", false);
                return;
            }
            if (response == null && response.ReturnCode != FinancialRegulation.Tools.PublicData.ResponseSuccess)
            {
                VMHelp.ShowMessage("信息查询失败，不可提交", false);
            }
            
            CurrentObj.PaymentID = SearchInfo.PaymentNum;
            PayInfoAddToEdit temp = new PayInfoAddToEdit(CurrentObj, null, OBModels);
            if ((bool)temp.ShowDialog())
            {
                windowOK();
            }
        }
        /// <summary>
        /// 缴存信息查询命令
        /// </summary>
        public void SearchExecute()
        {
            try
            {
                CheckHelper.NotNullCheck(SearchInfo.PaymentNum, "缴款凭证编号");
                SearchInfo.BankCode = VMHelp.BankCode;
                SearchInfo.BusinessCode = FinancialRegulation.Tools.PublicData.QueryFundPay;
                response = SendMessage<Message.NewMessage.Response.Response04>(SearchInfo, VMHelp.PointCode, VMHelp.UserCode);
                if (response != null && response.ReturnCode == FinancialRegulation.Tools.PublicData.ResponseSuccess)
                {
                    
                    CurrentObj = null;
                    CurrentObj=response;
                    // SpvModel = SpvModel;
                    IsSearch = true;//查询成功
                    VMHelp.ShowMessage(true);
                }
                else
                {
                    //VMHelp.ShowMessage("查询失败!", false);
                    VMHelp.ShowMessage(Tools.HelpClass.Current.MsgDIC[response.ReturnCode], false);
                    
                }
                
            }
            catch (CheckException ex)//检查异常
            {
                VMHelp.ShowMessage(ex.Message, false);
            }
            catch (Exception ex)
            {
                SendExcetpion(ex);
            }
        }
        /// <summary>
        /// 检查到输入信息
        /// </summary>
        /// <returns>成功</returns>
        public override bool Check()
        {
           // CheckHelper.CustomerCheck<decimal>(CurrentObj.Money, "存款金额不能小于1", (i) => i > 0);
           // CheckHelper.CustomerCheck<decimal>(CurrentObj.Balances, "账户余额不能小于1", (i) => i > 0);
           // CheckHelper.StrLengthCheck(CurrentObj.NatureOfFunding, "资金性质", 10);
            return true;
        }

        #endregion 命令方法
    }
}