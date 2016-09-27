using AvalonDock;
using System;
using System.Linq;
using System.Collections.Generic;

using System.Collections.ObjectModel;
using System.Windows.Controls;
using FundsRegulatoryClient;
using FundsRegulatoryClient.JG_PaymentSrv;
using FinancialRegulation.Page;

namespace FinancialRegulation.ViewModel
{
    /// <summary>
    ///资金缴存信息
    /// </summary>

    public class PayManageVM : BaseManageVM<FundsRegulatoryClient.JG_PaymentSrv.FundPayment>
    {
        /// <summary>
        /// 客户端访问对象
        /// </summary>
       // public FundsRegulatoryClient.JG_DepositClient client = FundsRegulatoryClient.JG_DepositClient.Instance;
        public JG_PaymentClient client = JG_PaymentClient.Instance;
        #region 构造加载

        /// <summary>
        /// 加载命令
        /// </summary>
        public override void LoadCommand()
        {
          
            RedChongCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(RedChongExecute);
            SearchCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(SearchExecute);
            PayCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(PayExecute);
            ReverseCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(ReverseExecute);//交易冲正
            NewFlushCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(LoadData);
        }

        public override void LoadData()
        {
            FlushExecute(true);
        }

        #endregion 构造加载

        #region 变量属性

        private string jkpzbh;

        /// <summary>
        /// 查询条件付款凭证编号
        /// </summary>
        public string ZFPZBH
        {
            get { return jkpzbh; }
            set
            {
                jkpzbh = value;
                RaisePropertyChanged("ZFPZBH");
            }
        }

        private ComboBoxItem jkzh;

        /// <summary>
        /// 状态查询
        /// </summary>
        public ComboBoxItem JKZH
        {
            get { return jkzh; }
            set
            {
                jkzh = value;
                RaisePropertyChanged("JKZH");
              
            }
        }

        #endregion 变量属性

        #region 命令定义

       
        private Microsoft.Practices.Prism.Commands.DelegateCommand _fundCollectCommand;
        private Microsoft.Practices.Prism.Commands.DelegateCommand _redChongCommand;
        private Microsoft.Practices.Prism.Commands.DelegateCommand _searchCommand;
        private Microsoft.Practices.Prism.Commands.DelegateCommand payCommand;//缴存命令
        private Microsoft.Practices.Prism.Commands.DelegateCommand reverseCommand;//冲正命令
        private Microsoft.Practices.Prism.Commands.DelegateCommand newFlushCommand;//新的刷新命令

        public Microsoft.Practices.Prism.Commands.DelegateCommand NewFlushCommand
        {
            get { return newFlushCommand; }
            set { newFlushCommand = value; this.RaisePropertyChanged("NewFlushCommand"); }
        }
        /// <summary>
        /// 冲正命令
        /// </summary>
        public Microsoft.Practices.Prism.Commands.DelegateCommand ReverseCommand
        {
            get { return reverseCommand; }
            set { reverseCommand = value; }
        }
        public Microsoft.Practices.Prism.Commands.DelegateCommand PayCommand
        {
            get { return payCommand; }
            set { payCommand = value; }
        }
        /// <summary>
        /// 支付红冲
        /// </summary>
        public Microsoft.Practices.Prism.Commands.DelegateCommand RedChongCommand
        {
            get { return _redChongCommand; }
            set
            {
                _redChongCommand = value;
                RaisePropertyChanged("RedChongCommand");
            }
        }

        /// <summary>
        /// 查询筛选
        /// </summary>
        public Microsoft.Practices.Prism.Commands.DelegateCommand SearchCommand
        {
            get
            {
                return _searchCommand;
            }
            set
            {
                _searchCommand = value;
            }
        }

        #endregion 命令定义

        #region 命令方法
        /// <summary>
        /// 选择下表中一行进行资金缴支付
        /// </summary>
        private void PayExecute()
        {
            try
            {
                if (CurModel.BusinessCode == FinancialRegulation.Tools.PublicData.QueryFundPay && CurModel.PayState == Tools.PublicData.PayB)
                {
                    Message.NewMessage.Response.Response04 temp = new Message.NewMessage.Response.Response04();
                    //将列表的支付信息付给 消息返回对象；
                    temp.BusinessCode = CurModel.BusinessCode;
                    temp.PaymentID = CurModel.PaymentID;
                    temp.PaymentAmount = CurModel.PaymentAmount;
                    temp.ReceiverAccount = CurModel.ReceiverAccount;
                    temp.ReceiverName = CurModel.ReceiverName;
                    temp.ReceiverBankName = CurModel.ReceiveBank;
                    temp.PayerAccount = CurModel.PayAccount;
                    temp.PayerName = CurModel.PayName;
                    temp.PayBank = CurModel.PaymentBank;
                    temp.ProjectID = CurModel.ProjectCode;

                    FinancialRegulation.Page.PayInfoAddToEdit fundadd = new Page.PayInfoAddToEdit(temp, this.CurModel, this.Models);
                    if ((bool)fundadd.ShowDialog())
                    {
                        SearchExecute();
                    }
                }
            }
            catch (Exception e)
            {
                 SendExcetpion(e);
            }
        }
        /// <summary>
        /// 应支付信息信息查询
        /// </summary>
        public Action<DockableContent, ShowModel> ShowSubWindowAction;
        public override void AddExecute()
        {
            Page.PayInfoCheck page = new Page.PayInfoCheck(this.Models);
           // ShowSubWindowAction.Invoke(page, ShowModel.ShowAsFloatingWindow);
            if ((bool)page.ShowDialog())
            {
                FlushExecute(true);
            }
          //  FlushExecute();
        }
        /// <summary>
        /// 刷新方法
        /// </summary>
        public  void FlushExecute(bool IsNull)
        {
            this.Models = new ObservableCollection<FundPayment>();
            //总行可以查看所有
            if (VMHelp.PointCode == Tools.HelpClass.Current.MainWebSite)
            {
                this.Models = client.Selects();
                return;
            }
            foreach (FundPayment item in client.Selects())
            {
                if (item.BankSiteID==VMHelp.PointCode)
                {
                    this.Models.Add(item);
                }
            }
            if (IsNull)
            {
                ZFPZBH = string.Empty;
                if (JKZH != null)
                {
                    JKZH.Content = "全部";
                }
            }
        }

        /// <summary>
        /// 支付红冲
        /// </summary>
        public void RedChongExecute()
        {
            //if (CurModel._DE_cklb == Tools.PublicData.Deposit_Lrc)
            //{
            //    VMHelp.ShowMessage("改存款已经红冲过了!", false);
            //    return;
            //}
            //Page.ReadCongEdit page = new Page.ReadCongEdit(CurModel);
            //page.ShowDialog();
            //FlushExecute();
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        public void SearchExecute()
        {
            //if (string.IsNullOrEmpty(JKPZBH) && string.IsNullOrEmpty(JKZH.Content.ToString()))
            //{
            //    FlushExecute();
            //    return;
            //}
            //FlushExecute();
            FlushExecute(false);
           
            if (!string.IsNullOrEmpty(ZFPZBH))
            {
                var temp = from i in Models
                           where (!string.IsNullOrEmpty(i.PaymentID)
                           ) && (i.PaymentID.Contains(ZFPZBH))
                           select i;
                ObservableCollection<FundPayment> result = new ObservableCollection<FundPayment>();
                temp.ToList<FundPayment>().ForEach(p => result.Add(p));
                this.Models =result ;
               
            }

            if (!string.IsNullOrEmpty(JKZH.Content.ToString()))
            {
                if(JKZH.Content.ToString() == "全部")
                {
                   return ;
                }
                else
                {
                     var temp = from i in this.Models 
                             where (!string.IsNullOrEmpty(i.PayState)
                             && ((!string.IsNullOrEmpty(JKZH.Content.ToString())
                             && i.PayState.Contains(JKZH.Content.ToString())
                             )))
                             select i;

                     ObservableCollection<FundPayment> result = new ObservableCollection<FundPayment>();
                     temp.ToList<FundPayment>().ForEach(p => result.Add(p));
                    this.Models =result ;
                }
            }
        }
        /// <summary>
        /// 冲正方法
        /// </summary>
        private void ReverseExecute()
        {
            if (CurModel.PayID != null)
            {

                if (CurModel.PaymentTime!=null&& CurModel.PaymentTime.Value.ToShortDateString() != DateTime.Now.ToShortDateString())
                {
                    VMHelp.ShowMessage("只能冲正今日交易", false);
                    return;
                }
                if (CurModel.PayState == Tools.PublicData.PayA)
                {
                    ReverseTrade rt = new ReverseTrade(this.CurModel, this.Models);
                    if ((bool)rt.ShowDialog())
                    {
                        SearchExecute();
                    }
                }
                else
                {
                    switch (CurModel.PayState)
                    {
                        case Tools.PublicData.PayB: VMHelp.ShowMessage("该款项未支付", false); break;
                        case "已冲正": VMHelp.ShowMessage("该款项已冲正", false); break;
                        case Tools.PublicData.RefundA: VMHelp.ShowMessage("该款项已退票", false); break;
                        default: return;
                    }
                }
            }
           
        }
        public override void DeleteExecute()
        {
            if (CurModel.PayID != null)
            {
                if (VMHelp.AskMessage("是否进行删除"))
                {
                    if (CurModel.PayState != Tools.PublicData.PayB)
                    {
                        VMHelp.ShowMessage("只能删除未支付信息",false);
                        return;
                    }
                    if (client.Delete(CurModel))
                    {
                        this.Models.Remove(CurModel);
                        VMHelp.ShowMessage(true);
                    }
                }
            }
        }
        #endregion 命令方法

        
    }
}