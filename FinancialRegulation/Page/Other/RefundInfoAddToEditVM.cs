using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinancialRegulation.Tools;
using FundsRegulatoryClient.RefunTradeSrv;
using System.Collections.ObjectModel;
using FundsRegulatoryClient.SqlTransSvr;
using Message.NewMessage.Response;
using Message.NewMessage.Request;

namespace FinancialRegulation.ViewModel
{
    public class RefundInfoAddToEditVM : BaseEditVM<FundsRegulatoryClient.RefunTradeSrv.RefundTrade>
    {
        /// <summary>
        /// 客户端帮助
        /// </summary>
        public FundsRegulatoryClient.RefundTradeClient Client = FundsRegulatoryClient.RefundTradeClient.Instance;
        FundsRegulatoryClient.JG_DepositClient dclient = FundsRegulatoryClient.JG_DepositClient.Instance;
        FundsRegulatoryClient.JG_PaymentClient pclient = FundsRegulatoryClient.JG_PaymentClient.Instance;
        FundsRegulatoryClient.SqlTransClient sqlTran = FundsRegulatoryClient.SqlTransClient.Instance;
        #region 构造加载
        /// <summary>
        /// 加载命令
        /// </summary>
        public override void LoadCommand()
        {
            SearchCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(SearchExecute);
        }

        /// <summary>
        /// 页面构造函数（传参数）
        /// </summary>
        public RefundInfoAddToEditVM()
        {
            
        }
        #endregion

        #region 变量属性
       
        //TODO:在此定义命令和属性
        private Response08 response;
        private string _refundType;
        /// <summary>
        /// 退票类型
        /// </summary>
        public string RefundType
        {
            get { return _refundType; }
            set { _refundType = value;
            this.RaisePropertyChanged("RefundType");
            }
        }
        private string _id;

        public string ID
        {
            get { return _id; }
            set { _id = value;
            this.RaisePropertyChanged("ID");
            CurrentObj = null;
            CurrentObj.PaymentID = value;
            IsSearch = null;
            RefundType = null;
            }
        }
        private bool? IsSearch;//凭证编号是否存在；
        private ObservableCollection<FundsRegulatoryClient.RefunTradeSrv.RefundTrade>  _model;
        /// <summary>
        /// 存款信息
        /// </summary>
        public ObservableCollection<FundsRegulatoryClient.RefunTradeSrv.RefundTrade> Models
        {
            get { return _model; }
            set
            {
                _model = value;
                this.RaisePropertyChanged("Models");
            }
        }
        private int executeCode;
        /// <summary>
        /// 1代表新增 2代表修改
        /// </summary>
        public int ExecuteCode
        {
            get { return executeCode; }
            set { executeCode = value; }
        }
        /// <summary>
        /// 存款性质
        /// </summary>
        private string NatureOfFunding;

        /// <summary>
        /// 报文响应
        /// </summary>
      
        #endregion

        #region 命令定义
        //TODO:在此定义命令
        private Microsoft.Practices.Prism.Commands.DelegateCommand searchCommand;

        public Microsoft.Practices.Prism.Commands.DelegateCommand SearchCommand
        {
            get { return searchCommand; }
            set { searchCommand = value; }
        }
        #endregion

        #region 命令方法

        public override bool Check()
        {
            
            CheckHelper.CustomerCheck<decimal?>(CurrentObj.RefundAmount, "存款金额小于1", (i) => i > 0);
            CheckHelper.NotNullCheck(CurrentObj.BankSerialNum, "银行流水号");
            CheckHelper.NotNullCheck(CurrentObj.AccountName, "退票账号");
            CheckHelper.NotNullCheck(CurrentObj.PaymentID, "凭证编号");
            
            return true;
        }

        public override void OKExecute()
        {
            try
            {
                if (IsSearch == null)
                {
                    VMHelp.ShowMessage("未查询", false);
                    return;
                }
                if (!(bool)IsSearch || !Check())
                {

                    return;
                }



                Request08 refundRequest = new Request08();
                refundRequest.BusinessCode = Tools.PublicData.Refund;
                refundRequest.BankCode = VMHelp.BankCode;
                refundRequest.PaymentID = CurrentObj.PaymentID;
                refundRequest.RefundAmount = CurrentObj.RefundAmount;
                refundRequest.RefundInstr = CurrentObj.RefundInstr;
                response = SendMessage<Response08>(refundRequest, VMHelp.PointCode, VMHelp.UserCode);
                if (response.ReturnCode != Tools.PublicData.ResponseSuccess)
                { VMHelp.ShowMessage(Tools.HelpClass.Current.MsgDIC[response.ReturnCode], false); return; }
                //if (response.ReturnCode == Tools.PublicData.DepositSuccess && !VMHelp.AskMessage("付款凭证已经完成支付,是否存数据库？"))
                //{
                //    return;
                //}
                if (!DayBalanceAndRefundAndState())
                {
                    VMHelp.ShowMessage("操作失败,原因：" + "\r\n 1、数据库中无今日余额  \r\n 2、今日余额更新失败 \r\n 3、存款或支付表状态更新失败", false);
                    return;
                }
                this.Models.Add(CurrentObj);
                VMHelp.ShowMessage(true);
                windowClose();
            }
            catch (Exception e)
            {
                 SendExcetpion(e);
            }
        }
        /// <summary>
        /// 根据凭证编号查询要退票的信息
        /// </summary>
        public void SearchExecute()
        {
            if (CurrentObj.PaymentID != null)
            {
                foreach (FundsRegulatoryClient.RefunTradeSrv.RefundTrade item in this.Models)
                {
                    if (item.PaymentID == CurrentObj.PaymentID)
                    {
                        VMHelp.ShowMessage("该凭证编号已退票", false);
                        return;
                    }
                }
                ObservableCollection<FundsRegulatoryClient.RefunTradeSrv.RefundTrade> temp = Client.Select(CurrentObj);
                if (temp.Count > 0)
                {
                    if (temp[0].Bankwebsite != VMHelp.PointCode && VMHelp.PointCode != Tools.HelpClass.Current.MainWebSite)
                    {
                        VMHelp.ShowMessage("不能退票非本网点交易", false);
                        return;
                    }
                    if (temp[0].RefundTime.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
                    {
                        if (!VMHelp.AskMessage("当日交易建议冲正，是否进行退票？"))
                        {
                            return;
                        }
                    }
                    switch(temp[0].BussinessCode)
                    {
                        case Tools.PublicData.QueryFundDeposit:VMHelp.ShowMessage("该款项未缴存",false);return;
                        case Tools.PublicData.QueryFundPay:VMHelp.ShowMessage("该款项未支付",false);return;
                        case Tools.PublicData.ReverseFund:VMHelp.ShowMessage("该款项已冲正",false);return;
                        default :break ;
                    }
                    temp[0].PaymentID = CurrentObj.PaymentID;
                    temp[0].RefundInstr = CurrentObj.RefundInstr;
                    temp[0].BankSerialNum = CurrentObj.BankSerialNum;
                    RefundType = temp[0].BussinessCode;
                    CurrentObj = temp[0];
                    IsSearch = true;
                }
                else 
                {
                    VMHelp.ShowMessage("该凭证编号不存在", false);
                    IsSearch = false;
                }
            }
            
        }
        #endregion
        /// <summary>
        /// 更新当日余额,存款表状态，支付表状态,添加退票信息
        /// </summary>
        /// <returns></returns>
        private bool DayBalanceAndRefundAndState()
        {
            FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo ami = new FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo();
            FundsRegulatoryClient.JG_AccountManageClient accountClient = FundsRegulatoryClient.JG_AccountManageClient.Instance;
            FundsRegulatoryClient.InterestManageClient InterestClient = FundsRegulatoryClient.InterestManageClient.Instance;
          //   FundsRegulatoryClient.RefundTradeClient refundClient=fun
            ami.AM_JgAccount =CurrentObj.AccountName;
            ObservableCollection<FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo> acc = accountClient.Select(ami);
            if (acc.Count < 1)
            {
                VMHelp.ShowMessage("账户不存在", false);
                return false;
            }
            FundsRegulatoryClient.InterestService.DayBalance db = new FundsRegulatoryClient.InterestService.DayBalance();
             FundsRegulatoryClient.SqlTransSvr.DayBalance sqldb = new FundsRegulatoryClient.SqlTransSvr.DayBalance();
            sqldb.DB_ID=db.DB_ID = acc[0].AM_ID;
            //  db.DB_AccountNum = model.DepositAccount;
            sqldb.DB_Time=db.DB_Time = DateTime.Parse(DateTime.Now.ToShortDateString());
            ObservableCollection<FundsRegulatoryClient.InterestService.DayBalance> dblist = new ObservableCollection<FundsRegulatoryClient.InterestService.DayBalance>();
            dblist = InterestClient.SelectJG_DayBalanceInfo(db);
            if (dblist.Count > 0)
            {
                FundsRegulatoryClient.SqlTransSvr.RefundTrade temp = new FundsRegulatoryClient.SqlTransSvr.RefundTrade();
               // CurrentObj.ID = temp.ID = VMHelp.GUID;
                temp.BussinessCode = FinancialRegulation.Tools.PublicData.Refund;
                temp.SerialNum = VMHelp.ServiceNo;
                temp.BankCode = VMHelp.BankCode;
                CurrentObj.Bankwebsite = temp.Bankwebsite = VMHelp.PointCode;
                CurrentObj.AccountTeller= temp.AccountTeller = VMHelp.UserCode;
                CurrentObj.RefundTime= temp.RefundTime = DateTime.Now;
                temp.AccountName = CurrentObj.AccountName;
                temp.BankSerialNum = CurrentObj.BankSerialNum;
                temp.PaymentID = CurrentObj.PaymentID;
                temp.RefundInstr = CurrentObj.RefundInstr;
                temp.RefundAmount = CurrentObj.RefundAmount;
                temp.RT_Type = RefundType;

                if (CurrentObj.BussinessCode == FinancialRegulation.Tools.PublicData.FundDeposit)
                {
                    sqldb.DB_Balance=db.DB_Balance = dblist[0].DB_Balance;
                    sqldb.DB_InterestRate=db.DB_InterestRate = dblist[0].DB_InterestRate;
                    sqldb.DB_Balance=db.DB_Balance = db.DB_Balance - CurrentObj.RefundAmount;
                    sqldb.ID =db.ID = dblist[0].ID;
                    
                    temp.AccountID = acc[0].AM_ID;
                    DepositFund dftemp=(DepositFund) UpdatePayOrDeposit(1);
                    temp.ID =VMHelp.GUID ;
                    if (sqlTran.Update_DbAndDF(sqldb, temp, dftemp))
                    {
                        
                        return true;
                    }
                    else
                    {
                      
                        return false;
                    }

                }
                else
                {

                    sqldb.DB_Balance = db.DB_Balance = dblist[0].DB_Balance;
                    sqldb.DB_InterestRate = db.DB_InterestRate = dblist[0].DB_InterestRate;
                    sqldb.DB_Balance = db.DB_Balance = db.DB_Balance + CurrentObj.RefundAmount;
                    sqldb.ID = db.ID = dblist[0].ID;
                    temp.AccountID = acc[0].AM_ID;
                    FundPayment fptemp=(FundPayment)UpdatePayOrDeposit(2);
                    temp.ID =VMHelp.GUID;
                    if (sqlTran.Update_DbAndPF(sqldb, fptemp, temp))
                    {
                        
                        return true;
                    }
                    else
                    {

                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新支付表或缴存表
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private object UpdatePayOrDeposit(int i)
        {
           
            switch (i)
            {
                case 1:
                    FundsRegulatoryClient.SqlTransSvr.DepositFund df = new FundsRegulatoryClient.SqlTransSvr.DepositFund();
                    df.ID = CurrentObj.ID;
                    df.BusinessCode = Tools.PublicData.Refund;
                    df.DepositState = Tools.PublicData.RefundA;
                    return df;
                    //if (dclient.Update(df))
                    //{
                       
                    //    return true;
                    //}
                    //else { return false; }
                case 2:
                    FundsRegulatoryClient.SqlTransSvr.FundPayment fp = new FundsRegulatoryClient.SqlTransSvr.FundPayment();
                    fp.PayID = CurrentObj.ID;
                    fp.PayState = Tools.PublicData.RefundA;
                    fp.BusinessCode = Tools.PublicData.Refund;
                    return fp;
                    //if (pclient.Update(fp))
                    //{
                    //    return true;
                    //}
                    //else { return false; }
                default: return null;// return false; 
            }
            
            
        }
    }
}
