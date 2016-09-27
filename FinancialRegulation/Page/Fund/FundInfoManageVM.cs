using AvalonDock;
using System;
using System.Linq;
using System.Collections.Generic;
using FundsRegulatoryClient.JG_DepositSrv;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using FinancialRegulation.Page.Fund;

namespace FinancialRegulation.ViewModel
{
    /// <summary>
    ///z资金缴存信息
    /// </summary>
    [System.Runtime.InteropServices.GuidAttribute("DEEF5BD6-8EB4-41E8-8849-48347844D170")]
    public class FundInfoManageVM : BaseManageVM<FundsRegulatoryClient.JG_DepositSrv.DepositFund>
    {
        /// <summary>
        /// 客户端访问对象
        /// </summary>
        public FundsRegulatoryClient.JG_DepositClient client = FundsRegulatoryClient.JG_DepositClient.Instance;

        #region 构造加载

        /// <summary>
        /// 加载命令
        /// </summary>
        public override void LoadCommand()
        {
            AddUnKnownCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(AddUnKnownExecute);
            RedChongCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(RedChongExecute);
            SearchCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(SearchExecute);
            DepositCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(DepositExecute);
            ReverseCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(ReverseExecute);
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
        /// 查询条件缴款凭证编号
        /// </summary>
        public string JKPZBH
        {
            get { return jkpzbh; }
            set
            {
                jkpzbh = value;
                RaisePropertyChanged("JKPZBH");
            }
        }

        private ComboBoxItem jkzh;

        /// <summary>
        /// 查询条件缴款账号
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

        private Microsoft.Practices.Prism.Commands.DelegateCommand _addUnKnownCommand;
        private Microsoft.Practices.Prism.Commands.DelegateCommand _fundCollectCommand;
        private Microsoft.Practices.Prism.Commands.DelegateCommand _redChongCommand;
        private Microsoft.Practices.Prism.Commands.DelegateCommand _searchCommand;
        private Microsoft.Practices.Prism.Commands.DelegateCommand depositCommand;//缴存命令
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
        public Microsoft.Practices.Prism.Commands.DelegateCommand DepositCommand
        {
            get { return depositCommand; }
            set { depositCommand = value; }
        }

        /// <summary>
        /// 录入不明账款
        /// </summary>
        public Microsoft.Practices.Prism.Commands.DelegateCommand AddUnKnownCommand
        {
            get { return _addUnKnownCommand; }
            set { _addUnKnownCommand = value; }
        }

        /// <summary>
        /// 资金归集
        /// </summary>
        public Microsoft.Practices.Prism.Commands.DelegateCommand FundCollectCommand
        {
            get { return _fundCollectCommand; }
            set
            {
                _fundCollectCommand = value;
                RaisePropertyChanged("FundCollectCommand");
            }
        }

        /// <summary>
        /// 存款红冲
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
        /// 选择下表中一行进行资金缴存
        /// </summary>
        private void DepositExecute()
        {
            if (CurModel.BusinessCode == Tools.PublicData.QueryFundDeposit && CurModel.DepositState == Tools.PublicData.DepositB)
            {
                Message.NewMessage.Response.Response02 temp = new Message.NewMessage.Response.Response02();
                //将列表的缴存信息付给 消息返回对象；
                temp.BusinessCode = CurModel.BusinessCode;
                temp.DepositID = CurModel.DepositNum;
                temp.DepositAccount = CurModel.DepositAccount;
                temp.FirmName = CurModel.FirmName;
                temp.DepositType = CurModel.DepositType;
                temp.DepositAmount = CurModel.DepositAmount;
                temp.PurchaserName = CurModel.PurchaserName;
                temp.PurchaserID = CurModel.PurchaserID;
                temp.ProjectCode = CurModel.ProjectCode;
                FinancialRegulation.Page.FundInfoAddToEdit fundadd = new Page.FundInfoAddToEdit(temp,this.CurModel,this.Models);
                fundadd.ShowDialog();
            }
            SearchExecute();
        }
        /// <summary>
        /// 应缴款信息查询
        /// </summary>
        public Action<DockableContent, ShowModel> ShowSubWindowAction;
        public override void AddExecute()
        {
            Page.FundInfoCheck page = new Page.FundInfoCheck(this.Models);
           // ShowSubWindowAction.Invoke(page, ShowModel.ShowAsFloatingWindow);
            if ((bool)page.ShowDialog())
            {
                FlushExecute(true);
            }
            FlushExecute(false);
          //  FlushExecute();
        }

        /// <summary>
        /// 不明账款补录
        /// </summary>
        public void AddUnKnownExecute()
        {
            //if (CurModel._DE_ID == null)
            //{
            //    VMHelp.ShowMessage("请选择需要进行补录的存款项", false);
            //    return;
            //}
            //if (string.IsNullOrEmpty(CurModel._DE_qybh))
            //{
            //    Page.UnKnownInfoAddToEdit page = new Page.UnKnownInfoAddToEdit(CurModel);
            //    //page.vm.Model = CurModel;
            //    page.ShowDialog();
            //    FlushExecute();
            //}
            //else
            //{
            //    VMHelp.ShowMessage("此存款项无需补录", false);
            //    return;
            //}
        }

        /// <summary>
        /// 刷新方法
        /// </summary>
        public  void FlushExecute(bool IsNull)
        {
            this.Models = new ObservableCollection<DepositFund>();
            this.Models = client.Selects();
            //总行可以查看所有
            if (VMHelp.PointCode == Tools.HelpClass.Current.MainWebSite)
            {
                this.Models = client.Selects();
                return;
            }
            foreach (DepositFund item in client.Selects())
            {
                if (item.BankSiteID==VMHelp.PointCode)
                {
                    this.Models.Add(item);
                }
            }
            if (IsNull)
            {
                JKPZBH = string.Empty;
                if (JKZH != null)
                {
                    JKZH.Content = "全部";
                }
            }
        }

        /// <summary>
        /// 存款红冲
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

            if (!string.IsNullOrEmpty(JKPZBH))
            {
                var temp = from i in Models
                           where (!string.IsNullOrEmpty(i.DepositNum)
                           ) && (i.DepositNum.Contains(JKPZBH))
                           select i;
                ObservableCollection<DepositFund> result = new ObservableCollection<DepositFund>();
                temp.ToList<DepositFund>().ForEach(p => result.Add(p));
                this.Models = result;

            }

            if (!string.IsNullOrEmpty(JKZH.Content.ToString()))
            {
                if (JKZH.Content.ToString() == "全部")
                {
                    return;
                }
                else
                {
                    var temp = from i in this.Models
                               where (!string.IsNullOrEmpty(i.DepositState)
                               && ((!string.IsNullOrEmpty(JKZH.Content.ToString())
                               && i.DepositState.Contains(JKZH.Content.ToString())
                               )))
                               select i;

                    ObservableCollection<DepositFund> result = new ObservableCollection<DepositFund>();
                    temp.ToList<DepositFund>().ForEach(p => result.Add(p));
                    this.Models = result;
                }
            }
                
        }
        /// <summary>
        /// 冲正方法
        /// </summary>
        private void ReverseExecute()
        {
            if (CurModel.ID != null)
            {
                if (CurModel.DepositTime != null && CurModel.DepositTime.Value.ToShortDateString() != DateTime.Now.ToShortDateString())
                {
                    VMHelp.ShowMessage("只能冲正今日交易", false);
                    return;
                }
                if (CurModel.DepositState == Tools.PublicData.DepositA)
                {
                    ReverseTrade rt = new ReverseTrade(this.CurModel, this.Models);
                    if ((bool)rt.ShowDialog())
                    {
                        SearchExecute();
                    }
                }
                else 
                {
                    switch (CurModel.DepositState)
                    {
                        case Tools.PublicData.DepositB: VMHelp.ShowMessage("该款项未缴存", false); break;
                        case Tools.PublicData.ReverseA: VMHelp.ShowMessage("该款项已冲正", false); break;
                        case "已退票": VMHelp.ShowMessage("该款项已退票", false); break;
                        default: return;
                    }
                }
                
            }
        }
        public override void DeleteExecute()
        {
            if (CurModel.ID != null)
            {
                
                if (VMHelp.AskMessage("是否进行删除"))
                {
                    if (CurModel.DepositState != Tools.PublicData.DepositB)
                    {
                        VMHelp.ShowMessage("只能删除未缴存信息", false);
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