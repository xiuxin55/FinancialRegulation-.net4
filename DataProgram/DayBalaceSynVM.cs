using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Collections.ObjectModel;
using BaseClient.LoginSrv;
using Common;
using System.Windows;
using BaseClient;
using FundsRegulatoryClient;
using FundsRegulatoryClient.JG_AccountManageSrv;
using FundsRegulatoryClient.InterestService;

namespace DataProgram
{
    public class DayBalaceSynVM : NotificationObject
    {
        public DayBalaceSynVM()
        {
            ConfirmCommand = new DelegateCommand(Confirm);
            SearchCommand= new DelegateCommand(SearchCommandExecute);
            SaveDataCommand = new DelegateCommand(SaveDataCommandExecute);
            lg = new Logger();
            initial();
        }

        #region 命令

        public DelegateCommand ConfirmCommand{get; set;}
        public DelegateCommand SearchCommand { get; set; }
        public DelegateCommand UpdatePwdCommand { get; set; }
        public DelegateCommand SaveDataCommand { get; set; }
        
        public Action CloseAction { get; set; }


        #endregion
        public void SetConfig()
        {
            //CommonData.Instance.SysConfig = FinancialRegulation.Tools.HelpClass.Current.SYSCONFIG;
        }

        #region 属性
        public Window CurrentWindow { get; set; }

        Common.Logger lg;
        /// <summary>
        /// 选择企业属性
        /// </summary>
        private JG_AccountManageInfo _SelectedAccount;

        public JG_AccountManageInfo SelectedAccount
        {
            get { return _SelectedAccount; }
            set
            {
                _SelectedAccount = value;
                SearchCommandExecute();
                this.RaisePropertyChanged("SelectedAccount");
            }
        }


        public List<BaseClient.LoginSrv.MenuItem> ListmenuItem { get; set; }





        /// <summary>
        /// 账户列表
        /// </summary>
        private ObservableCollection<JG_AccountManageInfo> _AccountList;

        public ObservableCollection<JG_AccountManageInfo> AccountList
        {
            get { return _AccountList; }
            set
            {
                _AccountList = value;
                this.RaisePropertyChanged("AccountList");
            }
        }

        /// <summary>
        /// 余额列表
        /// </summary>
        private ObservableCollection<DayBalance> _DayBalanceList;

        public ObservableCollection<DayBalance> DayBalanceList
        {
            get { return _DayBalanceList; }
            set
            {
                _DayBalanceList = value;
                this.RaisePropertyChanged("DayBalanceList");
            }
        }

        private string _DisplayStatus;
        /// <summary>
        /// 处理状态
        /// </summary>
        public string DisplayStatus
        {
            get { return _DisplayStatus; }
            set
            {
                _DisplayStatus = value;
                this.RaisePropertyChanged("DisplayStatus");
            }
        }

        private DateTime? _BalanceTime;
        /// <summary>
        /// 余额时间
        /// </summary>
        public DateTime? BalanceTime
        {
            get { return _BalanceTime; }
            set
            {
                _BalanceTime = value;
                this.RaisePropertyChanged("BalanceTime");
            }
        }
        #endregion


        #region 方法

        public void Confirm()
        {
            try
            {
                DisplayStatus = "正在计算并保存。。。";
                if (SelectedAccount==null)
                {
                    MessageBox.Show("先选择账户");
                    return;
                }
                System.Threading.Tasks.Task.Factory.StartNew(() => {
                var interestrateList = JG_InterestRateClient.Instance.Selects();
                var interestrate=interestrateList.Where(e => e.Flag == "0").OrderBy(e => e.SetDate).LastOrDefault();

                string accountid = SelectedAccount.AM_JgAccount;
                List<FundsRegulatoryClient.JG_DepositSrv.DepositFund> fundlist = new List<FundsRegulatoryClient.JG_DepositSrv.DepositFund>();
                fundlist= JG_DepositClient.Instance.Select(new FundsRegulatoryClient.JG_DepositSrv.DepositFund() { DepositAccount= accountid});
                List<FundsRegulatoryClient.JG_PaymentSrv.FundPayment> paylist = new List<FundsRegulatoryClient.JG_PaymentSrv.FundPayment>();
                paylist = JG_PaymentClient.Instance.Select(new FundsRegulatoryClient.JG_PaymentSrv.FundPayment() { PayAccount=accountid }).ToList();

                List<FundsRegulatoryClient.RefunTradeSrv.RefundTrade> refundlist = new List<FundsRegulatoryClient.RefunTradeSrv.RefundTrade>();
                refundlist=RefundTradeClient.Instance.Select(new FundsRegulatoryClient.RefunTradeSrv.RefundTrade() { AccountID = accountid }).ToList();


                var fundmaxtime = fundlist.Max(e => e.DepositTime);
                var fundmintime = fundlist.Min(e => e.DepositTime);

                var paymaxtime = paylist.Max(e => e.PaymentTime);
                var paymintime = paylist.Min(e => e.PaymentTime);
                DateTime? max, min;
                max = DateTime.Parse(DateTime.Now.ToShortDateString());
                if (fundmintime==null || paymintime==null)
                {
                    min = paymintime ?? fundmintime;
                }
                else
                {
                    min = fundmintime < paymintime ? fundmintime : paymintime;
                }
                if (fundlist.Count == 0 && paylist.Count == 0)
                {
                        CurrentWindow.Dispatcher.Invoke(new Action(() =>
                        {
                            MessageBox.Show("该账户支付缴存均为0");
                            DisplayStatus = "";
                        }));
                        return;
                }
                if (min==null)
                {
                        CurrentWindow.Dispatcher.Invoke(new Action(() =>
                        {
                            MessageBox.Show("余额最小日期为空");
                            DisplayStatus = "";
                        }));
                        return;
                }
                
               
                List<DayBalance> resultlist = new List<DayBalance>();
                for (DateTime i = min.Value; i <= max;i=i.AddDays(1))
                {
                    var fundtemplist = fundlist.Where(e=> e.DepositTime!=null && e.DepositTime==i && e.DepositState== "已缴存").ToList();
                    var fundtempRedlist = fundlist.Where(e => e.DepositTime != null && e.DepositTime == i&& e.DepositState == "已冲正");
                    foreach (var item in fundtempRedlist)
                    {
                        var ishas = fundtemplist.FirstOrDefault(e => e.DepositNum == item.DepositNum);
                        if (ishas !=null)
                        {
                            fundtemplist.Remove(ishas);
                        }
                    }

                    var paytemplist = paylist.Where(e => e.PaymentTime!=null &&  e.PaymentTime == i && e.PayState== "已支付").ToList();
                    var paytempRedlist = paylist.Where(e => e.PaymentTime != null && e.PaymentTime == i && e.PayState == "已冲正");
                    foreach (var item in paytempRedlist)
                    {
                        var ishas = paytemplist.FirstOrDefault(e => e.PaymentID == item.PaymentID);
                        if (ishas != null)
                        {
                            paytemplist.Remove(ishas);
                        }
                    }


                    var refundtemplist= refundlist.Where(e => e.RefundTime != null && e.RefundTime == i);
                    foreach (var item in refundtemplist)
                    {
                        var ishas = paytemplist.FirstOrDefault(e => e.PaymentID == item.PaymentID);
                        if (ishas != null)
                        {
                            paytemplist.Remove(ishas);
                        }
                        var ishas2 = fundtemplist.FirstOrDefault(e => e.DepositNum == item.PaymentID);
                        if (ishas2 != null)
                        {
                            fundtemplist.Remove(ishas2);
                        }

                    }
                    //开始计算当日余额
                    DayBalance dayb = new DayBalance();
                    dayb.ID = Guid.NewGuid().ToString();
                    dayb.DB_ID = SelectedAccount.AM_ID;
                    dayb.DB_AccountNum = accountid;
                    dayb.DB_Time = i;
                    var hasbalance = DayBalanceList.FirstOrDefault(e => e.DB_AccountNum == accountid && e.DB_Time!=null&&e.DB_Time == i);
                    if (hasbalance !=null)
                    {
                        dayb.ID = hasbalance.ID;
                        dayb.DB_InterestRate = hasbalance.DB_InterestRate;
                    }
                    else if(interestrate !=null)
                    {
                        dayb.DB_InterestRate = interestrate.InterestRate;
                    }
                    else
                    {
                        dayb.DB_InterestRate = 0;
                    }
                    //获取前一天余额
                    var pre=resultlist.FirstOrDefault(e => e.DB_AccountNum == accountid && e.DB_Time != null && e.DB_Time == i.AddDays(-1));
                    if (fundtemplist==null && paytemplist==null)
                    {
                        if (pre != null)
                        {
                            dayb.DB_Balance = pre.DB_Balance;
                        }
                        else
                        {
                            dayb.DB_Balance = 0;
                        }
                    }
                    else if (fundtemplist == null)
                    {
                        if (pre!=null)
                        {
                            dayb.DB_Balance = pre.DB_Balance - paytemplist.Sum(e => e.PaymentAmount);
                        }
                        else
                        {
                            dayb.DB_Balance = 0 - paytemplist.Sum(e => e.PaymentAmount);
                        }
                    }
                    else if (paytemplist == null)
                    {
                        if (pre != null)
                        {
                            dayb.DB_Balance = pre.DB_Balance + fundtemplist.Sum(e => e.DepositAmount);
                        }
                        else
                        {
                            dayb.DB_Balance = fundtemplist.Sum(e => e.DepositAmount);
                        }
                    }
                    else
                    {
                        if (pre != null)
                        {
                            dayb.DB_Balance = pre.DB_Balance + fundtemplist.Sum(e => e.DepositAmount) - paytemplist.Sum(e => e.PaymentAmount);
                        }
                        else
                        {
                            dayb.DB_Balance = fundtemplist.Sum(e => e.DepositAmount) - paytemplist.Sum(e => e.PaymentAmount);
                        }
                    }
                    resultlist.Add(dayb);
                }
                
                    CurrentWindow.Dispatcher.Invoke(new Action(() =>
                    {
                        DisplayStatus = "";
                        MessageBox.Show("重新计算完成");
                        //DayBalanceList = new ObservableCollection<DayBalance>(resultlist);
                    }));
                });
              
            }
            catch (Exception ex)
            {
                DisplayStatus = "";
                lg.LogWrite(Logger.LogLevel.Debug, "",ex.ToString());
                MessageBox.Show(ex.ToString());
                return;
            }
        }
        private void SaveDataCommandExecute()
        {
            //更新数据库
            
        }

        public void SearchCommandExecute()
        {
            if (SelectedAccount!=null)
            {
                DayBalanceList=InterestManageClient.Instance.SelectJG_DayBalanceInfo(new FundsRegulatoryClient.InterestService.DayBalance() { DB_AccountNum = SelectedAccount.AM_JgAccount,DB_Time= BalanceTime });
                if (BalanceTime!=null)
                {
                    DayBalanceList = new ObservableCollection<DayBalance>(DayBalanceList.Where(e=>e.DB_Time== BalanceTime));
                }
            }
        }
        #endregion
        private void initial()
        {
           
            AccountList =JG_AccountManageClient.Instance.Select(null);
        }
    }
}
