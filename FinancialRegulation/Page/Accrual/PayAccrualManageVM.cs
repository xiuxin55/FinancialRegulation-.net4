using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundsRegulatoryClient;
using FinancialRegulation.Page;
using Microsoft.Practices.Prism.Commands;
using Message;
using FundsRegulatoryClient.ParmItemSrv;
using FundsRegulatoryClient.InterestService;
using FundsRegulatoryClient.JG_AccountManageSrv;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;
using System.Windows.Controls;
using Message.NewMessage.Response;
using Message.NewMessage.Request;


namespace FinancialRegulation.ViewModel
{
    /// <summary>
    /// 利息支付管理 包含利息支付补录 和利息支付查询确认
    /// </summary>
    public class PayAccrualManageVM : BaseManageVM<FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo>
    {
        DataGrid dg = null;
        public PayAccrualManageVM(DataGrid dg)
        {
            this.dg = dg;
        }
        /// <summary>
        /// 客户端访问对象
        /// </summary>
        public JG_AccountManageClient AccountClient = JG_AccountManageClient.Instance;
        public InterestManageClient InterestClient = InterestManageClient.Instance;
        public SqlTransClient TranClient = SqlTransClient.Instance;
        #region 构造加载

        /// <summary>
        /// 加载命令
        /// </summary>
        public override void LoadCommand()
        {
            InterestCommand = new DelegateCommand(InterestCommandExecute);
            
        }

        public override void LoadData()
        {
            FlushExecute();
        }
        #endregion 构造加载

        #region 变量属性
        //TODO:在此处添加特定变量或属性
        private string fileName;
        /// <summary>
        /// 生成的文件名
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        private string filePath;
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        private Response07 response;//消息返回值
        private bool buttonEnable;

        public bool ButtonEnable
        {
            get { return buttonEnable; }
            set { buttonEnable = value;
            this.RaisePropertyChanged("ButtonEnable");
            }
        }
        private decimal? interestAmount;
        /// <summary>
        /// 结算后本季度利息
        /// </summary>
        public decimal? InterestAmount
        {
            get { return interestAmount; }
            set { interestAmount = value;
            this.RaisePropertyChanged("InterestAmount");
            }
        }
        private string memo;
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo
        {
            get { return memo; }
            set { memo = value;
            this.RaisePropertyChanged("Memo");
            }
        }
        //private string bankSerialNumber;
        ///// <summary>
        ///// 银行流水号
        ///// </summary>
        //public string BankSerialNumber
        //{
        //    get { return bankSerialNumber; }
        //    set { bankSerialNumber = value;
        //    this.RaisePropertyChanged("BankSerialNumber");
        //    }
        //}
        private ObservableCollection<AccountAndBalance> accountList;
        /// <summary>
        /// 所有账户信息
        /// </summary>
        public ObservableCollection<AccountAndBalance> AccountList
        {
            get { return accountList; }
            set { accountList = value;
            this.RaisePropertyChanged("AccountList");
            }
        }
        private AccountAndBalance selectedAccount;
        /// <summary>
        /// 选中一条账户信息
        /// </summary>
        public AccountAndBalance SelectedAccount
        {
            get { return selectedAccount; }
            set
            {
                selectedAccount = value;
                if (value != null)
                {
                    this.RaisePropertyChanged("SelectedAccount");
                    this.SeansonList = null;
                    this.DayBalanceList = null;
                    this.Memo = null;
                    this.ButtonEnable = false;
                    GetSeasonList(value.AccountInfo);
                }
            }
        }
        private ObservableCollection<SeasonInterest> seansonList;
        /// <summary>
        /// 季度信息列表
        /// </summary>
        public ObservableCollection<SeasonInterest> SeansonList
        {
            get { return seansonList; }
            set { seansonList = value;
            this.RaisePropertyChanged("SeansonList");
            }
        }
        private SeasonInterest selectedSeanson;
        /// <summary>
        /// 选中的某一天季度
        /// </summary>
        public SeasonInterest SelectedSeanson
        {
            get { return selectedSeanson; }
            set { selectedSeanson = value;
            if (value != null)
            {
                this.RaisePropertyChanged("SelectedSeanson");
                this.DayBalanceList = null;
                this.Memo = SelectedSeanson.SI_Memo;
                this.InterestAmount = SelectedSeanson.SI_Money;
                if (SelectedSeanson.SI_State == "N")
                { ButtonEnable = true; }
                else
                {
                    ButtonEnable = false;
                }
                GetDaybalanceList(value);
               
            }
            }
        }
        private ObservableCollection<DayBalance> dayBalanceList;
        /// <summary>
        /// 每天账户余额信息列表
        /// </summary>
        public ObservableCollection<DayBalance> DayBalanceList
        {
            get { return dayBalanceList; }
            set { 
                dayBalanceList = value;
                this.RaisePropertyChanged("DayBalanceList");
            }
        }
        #endregion 变量属性

        #region 命令定义

        private Microsoft.Practices.Prism.Commands.DelegateCommand produceFileCommand;
        private Microsoft.Practices.Prism.Commands.DelegateCommand _searchCommand;
        private Microsoft.Practices.Prism.Commands.DelegateCommand upLoadFileCommand;
        public Microsoft.Practices.Prism.Commands.DelegateCommand SendBillCommand { get; set; }//发起对账命令
        private Microsoft.Practices.Prism.Commands.DelegateCommand interestCommand;
        /// <summary>
        /// 上传对账单
        /// </summary>
        public Microsoft.Practices.Prism.Commands.DelegateCommand UpLoadFileCommand
        {
            get { return upLoadFileCommand; }
            set { upLoadFileCommand = value; }
        }
        /// <summary>
        /// 生成对账单文件dat
        /// </summary>
        public Microsoft.Practices.Prism.Commands.DelegateCommand ProduceFileCommand
        {
            get { return produceFileCommand; }
            set { produceFileCommand = value; }
        }
        /// <summary>
        /// 结息命令
        /// </summary>
        public DelegateCommand InterestCommand
        {
            get { return interestCommand; }
            set
            {
                interestCommand = value;
                RaisePropertyChanged("InterestCommand");
            }
        }
        //TODO:在此处添加命令

        #endregion 命令定义

        #region 命令方法
        /// <summary>
        /// 利息结算
        /// </summary>
        public void InterestCommandExecute()
        {
            bool ISinterest = false;
            //if (!Check()) { return; }
            if (!VMHelp.AskMessage("是否进行结息？"))
            {
                return;
            }
            if (DayBalanceList.Count < 1)
            {
                VMHelp.ShowMessage("当前余额表为空，无法结息", false);
                return;
            }
            SeasonInterest si = new SeasonInterest();
            si.SI_AccountNum = SelectedSeanson.SI_AccountNum;
            si.SI_ID = SelectedSeanson.SI_ID;
            
            DateTime? dt=FinancialRegulation.Tools.HelpClass.Current.SYSCONFIG.PayAccuralDate;
            if ( dt== null)
            {
                //if (dt < DateTime.Parse(DateTime.Now.ToShortDateString()))
                //{
                    VMHelp.ShowMessage("请先设置结息日期", false);
                    return;
                //}
            }
            else if (dt > DateTime.Parse(DateTime.Now.ToShortDateString()) || SelectedSeanson.SI_Time != dt.Value)
            {
                VMHelp.AskMessage("结息日期为"+VMHelp.SYSCONFIG.PayAccuralDate.Value.ToShortDateString()+"，不能进行结息");
                return;
            }
            else
            {
                FundsRegulatoryClient.SysConfigClient client = FundsRegulatoryClient.SysConfigClient.Instance;
                VMHelp.SYSCONFIG.PayAccuralDate = VMHelp.SYSCONFIG.PayAccuralDate.Value.AddMonths(3);
                client.Update(VMHelp.SYSCONFIG);
            }
            ObservableCollection<DayBalance> temp = new ObservableCollection<DayBalance>();
            ObservableCollection<FundsRegulatoryClient.SqlTransSvr.DayBalance> Tran_temp = new ObservableCollection<FundsRegulatoryClient.SqlTransSvr.DayBalance>();
            
            decimal? money = 0;
            foreach (DayBalance db in DayBalanceList)
            {
                db.DB_Interest = db.DB_InterestRate * db.DB_Balance / 365;
                money += db.DB_Interest;
                money = decimal.Parse(money.Value.ToString("f2"));
                temp.Add(db);
                FundsRegulatoryClient.SqlTransSvr.DayBalance Tran_db=new FundsRegulatoryClient.SqlTransSvr.DayBalance();
                Tran_db.ID =db.ID;
                Tran_db.DB_Interest =db.DB_Interest;
                Tran_db.DB_InterestRate=db.DB_InterestRate;
               
                Tran_temp.Add(Tran_db);
            }
            money = decimal.Parse(money.Value.ToString("f2"));
            //结息时，将利息加到之后的余额上。
            if (Tran_temp == null || Tran_temp.Count == 0) { return; }
            foreach (var item in  MoreInterestList)
            {
                item.DB_Balance += money;
                Tran_temp.Add(item);
            }

            DayBalanceList.Clear();
            DayBalanceList = temp;
            InterestAmount = money;
            si.SI_Money = money;
            si.SI_Time = SelectedSeanson.SI_Time;
            si.SI_Memo = Memo;
            si.SI_BankSerialNumber = VMHelp.ServiceNo;
            si.SI_BankTellerID = VMHelp.UserCode;
            si.SI_CertificateNum = VMHelp.BankCode + DateTime.Now.ToString("yyyyMMdd");
            si.ID = SelectedSeanson.ID;
            //利息消息
            //Request07 request = new Request07();
            //request.DepositNum = SelectedSeanson.SI_CertificateNum;
            //request.BankCode = VMHelp.BankCode;
            //request.BusinessCode = Tools.PublicData.InterestRecord;
            //request.InterestAmount = money;
            //request.ProjectCode = SelectedAccount.AccountInfo.AM_ProjectCode;
            //request.RecordInstr = Memo;

            ////消息发送
            //response = new Response07();
            //try
            //{
            //    response = SendMessage<Response07>(request, VMHelp.PointCode, VMHelp.UserCode);//发送Messageresponse.ReturnCode =="03" 
            //}
            //catch (Exception ex)
            //{
            //    SendExcetpion(ex);
            //    return;
            //}
            //if (response.ReturnCode != Tools.PublicData.ResponseSuccess)// && response.ReturnCode == Tools.PublicData.)
            //{ VMHelp.ShowMessage(Tools.HelpClass.Current.MsgDIC[response.ReturnCode], false); return; }
            //if (response.ReturnCode == Tools.PublicData.DepositSuccess && !VMHelp.AskMessage("缴款书已完成缴费,是否存数据库？"))
            //{
            //    return;
            //}
            FundsRegulatoryClient.SqlTransSvr.SeasonInterest SI_temp = new FundsRegulatoryClient.SqlTransSvr.SeasonInterest();
            SI_temp.SI_Money = si.SI_Money;
            //SI_temp.SI_Time = si.SI_Time;
            SI_temp.SI_Memo = si.SI_Memo;
            SI_temp.SI_BankSerialNumber=si.SI_BankSerialNumber;//本系统产生的流水号
            SI_temp.SI_BankTellerID = si.SI_BankTellerID;
            SI_temp.SI_CertificateNum = si.SI_CertificateNum;
            SI_temp.ID = SelectedSeanson.ID;
            if (SelectedSeanson.SI_Time < DateTime.Parse(DateTime.Now.ToShortDateString()))
            {
                SI_temp.SI_Time =SelectedSeanson.SI_Time;
                si.SI_Time = SelectedSeanson.SI_Time;
                
            }
            
            if (!TranClient.Update_DbAndSI(Tran_temp.ToList<FundsRegulatoryClient.SqlTransSvr.DayBalance>(), SI_temp, 2))
            {
                VMHelp.ShowMessage("结息失败",false);
                return;
            }
            //foreach (DayBalance db in DayBalanceList)
            //{
            //    InterestClient.UpdateJG_DayBalanceInfo(db);
            //}
            //InterestClient.UpdateJG_SeasonInterestInfo(si);
            //季度结息新插入一条
           
            int index = dg.SelectedIndex;
            if (index > -1)
            {
                
                SeansonList[index] = si;
                dg.SelectedIndex = index;
            }
            //插入一条季度结息
            SeasonInterest Insert = new SeasonInterest();
            Insert.ID = VMHelp.GUID;
            
            Insert.SI_Time = DateTime.Parse(DateTime.Now.ToShortDateString()).AddMonths(3);
            if (SelectedSeanson.SI_Time < DateTime.Parse(DateTime.Now.ToShortDateString()))
            {
                Insert.SI_Time =SelectedSeanson.SI_Time.Value.AddMonths(3);
                FundsRegulatoryClient.SysConfigClient client = FundsRegulatoryClient.SysConfigClient.Instance;
                VMHelp.SYSCONFIG.PayAccuralDate = Insert.SI_Time;
                client.Update(VMHelp.SYSCONFIG);
            }
            Insert.SI_AccountNum = si.SI_AccountNum;
            Insert.SI_ID = si.SI_ID;
            this.SeansonList.Add(Insert);
            InterestClient.AddJG_SeasonInterestInfo(Insert);
            //if (ISinterest)
            //{
            //if (!VMHelp.AskMessage("是否将 " + VMHelp.SYSCONFIG.PayAccuralDate.Value.ToShortDateString() + " 设置为新的结息日期"))
            //{
            //    return;
            //}
           // }
            VMHelp.ShowMessage(true);
            FlushExecute();
           
        }

        #endregion 命令方法

        #region 内部方法

        public override void FlushExecute()
        {
            this.AccountList = new ObservableCollection<AccountAndBalance>();
            this.AccountList.Clear();
            foreach (FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo item in AccountClient.Selects())
            {
                if (item.AM_UseFlag == "正常")
                {
                    AccountAndBalance aab = new AccountAndBalance();
                    aab.AccountInfo = item;
                    this.AccountList.Add(aab);
                }
            }
            SeansonList = null;
            DayBalanceList = null;
            ////银行编号预制 00008 总行
            //if (VMHelp.PointCode == "07") this.Models = client.Selects();
            //else
            //    //每个银行网点只能看到自己的银行
            //    this.Models = client.Select(new FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo()
            //    {
            //        AM_BankCode = VMHelp.PointCode
            //    });
        }
        /// <summary>
        /// 根据选中的账户读取所有季度结息表
        /// </summary>
        /// <param name="ami">选中的账户</param>
        private void GetSeasonList(FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo ami)
        {
            SeasonInterest si = new SeasonInterest();
            si.SI_ID = ami.AM_ID;
            this.SeansonList = InterestClient.SelectJG_SeasonInterestInfo(si);
        }
        /// <summary>
        /// 结息日期之后的所有日期余额，用于结息后，更新余额=余额+利息；
        /// </summary>
        private ObservableCollection<FundsRegulatoryClient.SqlTransSvr.DayBalance> MoreInterestList = new ObservableCollection<FundsRegulatoryClient.SqlTransSvr.DayBalance>();
        /// <summary>
        /// 根据选中的季度结息读取每天余额表
        /// </summary>
        /// <param name="ami">选中的账户</param>
        int i = 0;
        private void GetDaybalanceList(SeasonInterest si)
        {
            DayBalance db = new DayBalance();
            db.DB_ID = si.SI_ID;
            db.DB_Time = si.SI_Time.Value.AddMonths(-3);//季度结息
            ObservableCollection<DayBalance> tempList = new ObservableCollection<DayBalance>();
            MoreInterestList.Clear();
            foreach (DayBalance item in InterestClient.SelectJG_DayBalanceInfo(db))
            {
                if(item.DB_Time < selectedSeanson.SI_Time)
                {
                    tempList.Add(item);
                }
                else
                {
                    
                    FundsRegulatoryClient.SqlTransSvr.DayBalance tranbalance = new FundsRegulatoryClient.SqlTransSvr.DayBalance();
                    tranbalance.DB_Balance = item.DB_Balance;
                    tranbalance.DB_InterestRate = item.DB_InterestRate;
                    tranbalance.DB_ID = item.DB_ID;
                    tranbalance.ID = item.ID;
                    MoreInterestList.Add(tranbalance);
                }
            }
            DayBalanceList = tempList;
        }
        /// <summary>
        /// 获取list
        /// </summary>
        //private void GetList()
        //{
        //    ListLC = new List<ParmItem>(FundsRegulatoryClient.ParmItemClient.Current.SelectTheParmItem(new ParmItem() { PI_SETCODE = "01" }));
        //}
        //public  bool Check()
        //{
        //    if (string.IsNullOrEmpty(BankSerialNumber))
        //    {
        //        System.Windows.Forms.MessageBox.Show("银行流水号不能为空");
        //        return false;
        //    }
        //    // CheckHelper.StrLengthCheck(CurrentObj.NatureOfFunding, "缴款类型", 10);

        //    return true;
        //}
        #endregion 内部方法

       
    }
    /// <summary>
    /// 账户余额
    /// </summary>
    public class AccountAndBalance : NotificationObject
    {
        public InterestManageClient InterestClient = InterestManageClient.Instance;
        FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo accountInfo;
        /// <summary>
        /// 账户信息
        /// </summary>
        public FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo AccountInfo
        {
            get { return accountInfo; }
            set
            {
                accountInfo = value;
                if (value != null)
                {
                    DayBalance db = new DayBalance();
                    db.DB_ID = value.AM_ID;
                    //db.DB_Time = DateTime.Parse(DateTime.Now.ToShortDateString());
                    //db.DB_Time = DateTime.Parse(DateTime.Now.ToShortDateString());
                    ObservableCollection<DayBalance> dblist = new ObservableCollection<DayBalance>();
                    dblist = InterestClient.SelectJG_DayBalanceInfo(db);
                    
                    if (dblist.Count > 0)
                    {
                        this.Balance = InterestClient.SelectJG_DayBalanceInfo(db).OrderByDescending(u => u.DB_Time).FirstOrDefault<DayBalance>().DB_Balance;
                    }
                    else
                    {
                        this.Balance = 0;
                    }
                }
            }
        }
        private decimal? balance;
        /// <summary> 
        /// 当前账户余额
        /// </summary>
        public decimal? Balance
        {
            get { return balance; }
            set { balance = value;
            this.RaisePropertyChanged("Balance");
            }
        }
    }
}