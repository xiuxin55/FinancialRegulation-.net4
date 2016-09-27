using System;
using FinancialRegulation.ClientException;
using FundsRegulatoryClient;
using FundsRegulatoryClient.JG_AccountManageSrv;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FinancialRegulation.ViewModel
{
    /// <summary>
    /// 开户信息补录 添加和发送用此ViewModel
    /// </summary>
    public class OpenAccountEditVM : BaseEditVM<FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo>
    {
        //private FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo accountinfo;//账户信息

        //public FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo Accountinfo
        //{
        //    get { return accountinfo; }
        //    set { accountinfo = value; }
        //}

        public OpenAccountEditVM(JG_AccountManageInfo account, ObservableCollection<JG_AccountManageInfo> Models)
        {
            if (account != null && Models != null)
            {
                CurrentObj.AM_BankCode = account.AM_BankCode;
                CurrentObj.AM_Person = account.AM_Person;
                CurrentObj.AM_zhmc = account.AM_zhmc;
                CurrentObj.AM_CreateDate = account.AM_CreateDate;
                CurrentObj.AM_ItemName = account.AM_ItemName;
                CurrentObj.AM_JgAccount = account.AM_JgAccount;
                CurrentObj.AM_UseFlag = account.AM_UseFlag;
                CurrentObj.AM_zhmc = account.AM_zhmc;
                CurrentObj.AM_ID = account.AM_ID;
                CurrentObj.AM_CorpName = account.AM_CorpName;
                CurrentObj.AM_ProjectCode = account.AM_ProjectCode;
                this.Models = Models;
                this.para = account;
            }
            else
            {
                CurrentObj.AM_UseFlag = "正常";
            }
        }
        /// <summary>
        /// 客户端帮助
        /// </summary>
        public JG_AccountManageClient client = JG_AccountManageClient.Instance;
        public InterestManageClient InterestClient = InterestManageClient.Instance;//利息处理
        public JG_InterestRateClient InterestRateClient = JG_InterestRateClient.Instance;
        public SqlTransClient tranClient = SqlTransClient.Instance;
        #region 构造加载

        /// <summary>
        /// 加载命令
        /// </summary>
        public override void LoadCommand()
        {
        }

        #endregion 构造加载

        #region 变量属性
        ObservableCollection<JG_AccountManageInfo> Models;
        JG_AccountManageInfo para;
        #endregion 变量属性

        #region 命令定义

        #endregion 命令定义

        #region 命令方法

        /// <summary>
        /// 确认按钮
        /// </summary>
        public override void OKExecute()
        {
            if (Models == null && CurrentObj.AM_JgAccount!=null)
            {
                if (Check() && VMHelp.AskMessage("确认要进行开户?"))
                {
                    ObservableCollection<FundsRegulatoryClient.JG_InterestRateSrv.JG_InterestRateInfo> rate= InterestRateClient.Selects();
                    if (rate.Count > 0)
                    {
                        
                        CurrentObj.AM_ID = Guid.NewGuid().ToString();
                        CurrentObj.AM_BankCode = "07";//银行代码
                        CurrentObj.AM_CreateDate = DateTime.Parse(VMHelp.NowTime);
                        //bool result = client.Add(CurrentObj);
                        //对象赋值转换
                        FundsRegulatoryClient.SqlTransSvr.JG_AccountManageInfo tempacc = new FundsRegulatoryClient.SqlTransSvr.JG_AccountManageInfo();
                        tempacc.AM_ID = CurrentObj.AM_ID;
                        tempacc.AM_BankCode = VMHelp.BankCode;//银行代码
                        tempacc.AM_CreateDate = DateTime.Parse(VMHelp.NowTime);
                        tempacc.AM_CorpName = CurrentObj.AM_CorpName;
                        tempacc.AM_ItemName = CurrentObj.AM_ItemName;
                        tempacc.AM_JgAccount = CurrentObj.AM_JgAccount;
                        tempacc.AM_ProjectCode = CurrentObj.AM_ProjectCode;
                        tempacc.AM_UseFlag = CurrentObj.AM_UseFlag;
                        tempacc.AM_zhmc = CurrentObj.AM_zhmc;
                        tempacc.AM_Person = CurrentObj.AM_Person; ;
                        FundsRegulatoryClient.SqlTransSvr.DayBalance db = new FundsRegulatoryClient.SqlTransSvr.DayBalance();
                        //每天余额表添加一条
                        db.DB_ID = CurrentObj.AM_ID;
                        db.DB_AccountNum = CurrentObj.AM_JgAccount;
                        db.DB_Balance = 0;
                        db.DB_InterestRate = rate[0].InterestRate;     //利率；
                        db.DB_Time = DateTime.Parse(DateTime.Now.ToShortDateString());
                        db.ID = Guid.NewGuid().ToString();
                      //  bool result2 = InterestClient.AddJG_DayBalanceInfo(db);
                        //季度结息表增加一条
                        FundsRegulatoryClient.SqlTransSvr.SeasonInterest si = new FundsRegulatoryClient.SqlTransSvr.SeasonInterest();
                        DateTime? dt = FinancialRegulation.Tools.HelpClass.Current.SYSCONFIG.PayAccuralDate;
                        if (dt == null || dt.Value.AddMonths(3) < DateTime.Parse(DateTime.Now.ToShortDateString()))
                        {
                            VMHelp.ShowMessage("请先设置结息日期", false);
                            return;
                        }
                        if (dt.Value < DateTime.Parse(DateTime.Now.ToShortDateString()))
                        {
                            si.SI_Time = dt.Value.AddMonths(3);
                        }
                        else
                        {
                            si.SI_Time = dt.Value;
                        }
                        //si.SI_Time = db.DB_Time.Value.AddMonths(3);
                        si.SI_ID = CurrentObj.AM_ID;
                        si.SI_AccountNum = db.DB_AccountNum;
                        si.ID = Guid.NewGuid().ToString(); 
                       // bool result3 = InterestClient.AddJG_SeasonInterestInfo(si);

                        if (tranClient.CreateAccountSIDB(tempacc,si,db,1))
                        {
                            VMHelp.ShowMessage("开户成功!", true);
                            windowClose();
                        }
                        else
                        {
                            VMHelp.ShowMessage("开户信息保存失败", false);
                        }
                    }
                    else
                    {
                        VMHelp.ShowMessage("请先设置利率", false);
                    }
                }
            }
            else  if (Check() && VMHelp.AskMessage("确认要进行修改?"))
            {
                bool result = client.Update(CurrentObj);
                if (result)
                {
                    int index = this.Models.IndexOf(para);
                    if (index > -1)
                    {
                        this.Models[index] = CurrentObj;
                    }
                    VMHelp.ShowMessage("账户修改成功!", true);
                    windowClose();
                }
                else
                {
                    VMHelp.ShowMessage("账户修改信息保存失败", false);
                }

            }

        }
        public override bool Check()
        {
           // CheckHelper.NotNullCheck(CurrentObj.AM_CorpName, "企业名称");
            CheckHelper.StrLengthCheck(CurrentObj.AM_zhmc, "账户名称", 50);
            CheckHelper.StrLengthCheck(CurrentObj.AM_JgAccount, "账户", 50);
            CheckHelper.NotNullCheck(CurrentObj.AM_Person, "开户人");
            CheckHelper.NotNullCheck(CurrentObj.AM_ItemName, "项目名称");
            CheckHelper.NotNullCheck(CurrentObj.AM_UseFlag, "账户状态");
            return true;
        }

        #endregion 命令方法

        #region 内部方法

        //private Message.Message001 GetResponse()
        //{
        //    Message.Message101 request = new Message.Message101();
        //    request.BusinessTime = VMHelp.NowTime.ToString();//交易时间
        //    request.BusinessCode = "101";//交易代码
        //    request.SerialNo = VMHelp.ServiceNo;//银行流水
        //    request.BankCode = VMHelp.BankCode;//银行代码
        //    request.CorpCode = CurrentObj.AM_CorpCode;//企业代码
        //    request.CorpName = CurrentObj.AM_CorpName;//企业名称
        //    request.AccountName = CurrentObj.AM_zhmc;//账户名称
        //    request.Account = CurrentObj.AM_JgAccount;//账号
        //    //request.PactNo = "2222222222";//协议编号 2013年10月23日14:48:53 开户无协议编号
        //    Message.Message001 response = SendMessage<Message.Message001>(request);
        //    if (response == null) throw new Exception("报文接收失败，无返回报文!");
        //    return response;
        //}

        #endregion 内部方法
    }
}