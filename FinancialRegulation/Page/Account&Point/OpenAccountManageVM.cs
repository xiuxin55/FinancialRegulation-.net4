using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundsRegulatoryClient;
using FinancialRegulation.Page;
using Microsoft.Practices.Prism.Commands;
using FundsRegulatoryClient.JG_AccountManageSrv;
using System.Collections.ObjectModel;
using System.Windows.Controls;


namespace FinancialRegulation.ViewModel
{
    /// <summary>
    /// 开户管理
    /// </summary>
    public class OpenAccountManageVM : BaseManageVM<FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo>
    {
        public OpenAccountManageVM(DataGrid dg)
        {
            this.dg = dg;
        }
        /// <summary>
        /// 客户端访问对象
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
            SearchCommand = new DelegateCommand(SearchExecute);
            DeleteCommand = new DelegateCommand(DeleteExecute);
            SearchCommand = new DelegateCommand(SearchExecute);
            ModifyCommand = new DelegateCommand(ModifyExecute);
            likesearchCommand = new Action<ObservableCollection<JG_AccountManageInfo>>(SearchResultExecute);
            //TODO:此处添加自定义命令与方法绑定的代码
        }
        public override void LoadData()
        {
            FlushExecute();//数据初始化加载
            
        }
        #endregion

        #region 变量属性

        //TODO:在此处添加特定变量或属性
        DataGrid dg;//前台表格
        #endregion

        #region 命令定义
        DelegateCommand searchCommand;

        public DelegateCommand SearchCommand
        {
            get { return searchCommand; }
            set { searchCommand = value; }
        }

        Action<ObservableCollection<JG_AccountManageInfo>> likesearchCommand;

        public Action<ObservableCollection<JG_AccountManageInfo>> LikeSearchCommand
        {
            get { return likesearchCommand; }
            set { likesearchCommand = value; }
        }
        #endregion

        #region 命令方法

        /// <summary>
        /// 添加网点方法
        /// </summary>
        public override void AddExecute()
        {
            OpenAccountAddToEdit o = new OpenAccountAddToEdit(null, null);
            
            o.ShowDialog();
            
            
            FlushExecute();
        }
        /// <summary>
        /// 刷新方法（数据初始化加载）
        /// </summary>
        public override void FlushExecute()
        {
            this.Models = client.Selects();
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
        /// 修改
        /// </summary>
        /// <param name="obj"></param>
        public override void ModifyExecute()
        {
            //if (CurModel.AM_ID!=null)
            //{
            //    //FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo jj = (FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo)obj;
            //    ObservableCollection<JG_AccountManageInfo> temp = new ObservableCollection<JG_AccountManageInfo>();
            //    int index = this.Models.IndexOf(CurModel);
            //    OpenAccountAddToEdit page = new OpenAccountAddToEdit(CurModel, Models);
            //    page.ShowDialog();
            //    this.dg.SelectedIndex = index;
            //  //  this.Models[index] = CurModel;
            //    //foreach (JG_AccountManageInfo item in this.Models)
            //    //{
            //    //    temp.Add(item);
            //    //}
            //    //this.Models.Clear();
            //    //this.Models = temp;
            //  //  FlushExecute();
            //}
            if (CurModel.AM_ID != null)
            {
                // FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo jj = (FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo)obj;
                int index = Models.IndexOf(CurModel);//检索列表中是否存在该项
                if (index > -1)
                {
                    if (CurModel.AM_UseFlag == "正常")
                    { VMHelp.ShowMessage("账户已经启用", false);return ;}
                    CurModel.AM_UseFlag = "正常";
                    
                    ObservableCollection<FundsRegulatoryClient.JG_InterestRateSrv.JG_InterestRateInfo> rate = InterestRateClient.Selects();
                    int i = 0;
                    for(;i<rate.Count;i++ )
                    {
                        if (rate[i].Flag == "1")
                        {
                            break;
                        }
                    }
                    if (rate.Count < 1 || i==rate.Count) { VMHelp.ShowMessage("未启用最新利率或设置利率",false); return; }
                    FundsRegulatoryClient.InterestService.DayBalance db = new FundsRegulatoryClient.InterestService.DayBalance();
                    db.DB_ID = CurModel.AM_ID;
                  //  db.DB_Time = DateTime.Parse(DateTime.Now.ToShortDateString());
                    ObservableCollection<FundsRegulatoryClient.InterestService.DayBalance> dblist = InterestClient.SelectJG_DayBalanceInfo(db);
                    FundsRegulatoryClient.SqlTransSvr.JG_AccountManageInfo tempacc = new FundsRegulatoryClient.SqlTransSvr.JG_AccountManageInfo();

                    tempacc.AM_ID = CurModel.AM_ID;
                    tempacc.AM_BankCode = VMHelp.BankCode;//银行代码
                    tempacc.AM_CreateDate = DateTime.Parse(VMHelp.NowTime);
                    tempacc.AM_CorpName = CurModel.AM_CorpName;
                    tempacc.AM_ItemName = CurModel.AM_ItemName;
                    tempacc.AM_JgAccount = CurModel.AM_JgAccount;
                    tempacc.AM_ProjectCode = CurModel.AM_ProjectCode;
                    tempacc.AM_UseFlag = CurModel.AM_UseFlag;
                    tempacc.AM_zhmc = CurModel.AM_zhmc;
                    tempacc.AM_Person = CurModel.AM_Person;

                  
                    FundsRegulatoryClient.SqlTransSvr.DayBalance tempdb = new FundsRegulatoryClient.SqlTransSvr.DayBalance();
                    //每天余额表添加一条
                    tempdb.DB_ID = CurModel.AM_ID;
                    tempdb.DB_AccountNum = CurModel.AM_JgAccount;
                    tempdb.DB_InterestRate = rate[0].InterestRate;     //利率；
                    tempdb.DB_Time = DateTime.Parse(DateTime.Now.ToShortDateString());
                    if (dblist.Count > 0)
                    {
                        tempdb.DB_Balance = dblist[dblist.Count - 1].DB_Balance;
                    }
                    else
                    {
                        tempdb.DB_Balance = null;
                    }
                    tempdb.ID = Guid.NewGuid().ToString();
                    //季度结息表更新
                    FundsRegulatoryClient.SqlTransSvr.SeasonInterest si = new FundsRegulatoryClient.SqlTransSvr.SeasonInterest();
                    FundsRegulatoryClient.InterestService.SeasonInterest tempsi = new FundsRegulatoryClient.InterestService.SeasonInterest();

                    tempsi.SI_ID =si.SI_ID = tempdb.DB_ID;
                    ObservableCollection<FundsRegulatoryClient.InterestService.SeasonInterest> silist = InterestClient.SelectJG_SeasonInterestInfo(tempsi);
                    si.SI_Time = tempdb.DB_Time.Value.AddMonths(3);
                    si.SI_AccountNum = tempdb.DB_AccountNum;
                  
                    if (dblist[dblist.Count - 1].DB_Time==DateTime.Parse(DateTime.Now.ToShortDateString()))
                        {
                            if (tranClient.CreateAccountSIDB(tempacc, null, null, 2))
                            {
                                VMHelp.ShowMessage("启用成功!", true);
                                
                            }
                            else
                            {
                                VMHelp.ShowMessage("启用失败", false);
                            }
                        }
                        else if(silist[silist.Count-1].SI_Time<=DateTime.Parse(DateTime.Now.ToShortDateString()))
                        {
                            si.ID =silist[silist.Count-1].ID;
                            if (tranClient.CreateAccountSIDB(tempacc, si, tempdb,2))
                            {
                                VMHelp.ShowMessage("启用成功!", true);
                                // windowClose();
                            }
                            else
                            {
                                VMHelp.ShowMessage("启用失败", false);
                            }
                        }
                    FlushExecute();
                }
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="obj"></param>
        public override void DeleteExecute()
        {
            if (CurModel.AM_ID != null)
            {
                // FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo jj = (FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo)obj;

                client.Delete(CurModel);
                FlushExecute();
            }
        }
        /// <summary>
        /// 销户命令
        /// </summary>
        public override void DestroyAccountExecute()
        {
            if (CurModel.AM_ID != null)
            {
                // FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo jj = (FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo)obj;
                int index = Models.IndexOf(CurModel);//检索列表中是否存在该项
                if (index > -1)
                {
                    if (CurModel.AM_UseFlag != "销户")
                    {
                        FundsRegulatoryClient.InterestService.DayBalance db = new FundsRegulatoryClient.InterestService.DayBalance();
                        db.DB_ID = CurModel.AM_ID;
                      //  db.DB_Time = DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString());
                        ObservableCollection<FundsRegulatoryClient.InterestService.DayBalance> dblist= InterestClient.SelectJG_DayBalanceInfo(db);
                        if (dblist.Count == 1&&CurModel.AM_CreateDate.Value.ToShortDateString()==DateTime.Now.ToShortDateString())
                        {
                            CurModel.AM_UseFlag = "销户";
                            client.Update(CurModel);
                            //Models[index] = CurModel;  //AccountSearch.xaml
                            FlushExecute();
                            VMHelp.ShowMessage("销户成功", true);
                            return;
                        }
                        if (dblist.Count == 1 || dblist[dblist.Count - 2].DB_Interest == null)
                        {
                            VMHelp.ShowMessage("请先结息", false);
                            return;
                        }
                        CurModel.AM_UseFlag = "销户";
                        client.Update(CurModel);
                        //Models[index] = CurModel;  //AccountSearch.xaml
                        FlushExecute();
                        VMHelp.ShowMessage("销户成功",true);
                    }
                    else
                    {
                        VMHelp.ShowMessage("已经销户",false);
                    }
                }
            }
        }
        /// <summary>
        /// 查询结果并更新列表
        /// </summary>
        /// <param name="am"></param>
        private void SearchResultExecute(ObservableCollection<JG_AccountManageInfo> am)
        {
            this.Models =am;
        }
        /// <summary>
        /// 查找命令
        /// </summary>
        private void SearchExecute()
        {
            AccountSearch AccSearch = new AccountSearch(likesearchCommand);
            AccSearch.ShowDialog();
        }
        #endregion 
    }
}
