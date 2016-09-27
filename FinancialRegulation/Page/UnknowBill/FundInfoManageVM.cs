using AvalonDock;
using System;
using System.Linq;
using System.Collections.Generic;
using FundsRegulatoryClient.JG_DepositSrv;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using FinancialRegulation.Page.Fund;
using Microsoft.Practices.Prism.ViewModel;

namespace FinancialRegulation.ViewModel.UnknowBillPage
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
        public FundInfoManageVM()
        {
        }
        public FundInfoManageVM(UnknowBill ub)
        {
            this.UnknowModel = ub; 
            FlushExecute(true);
        }
        /// <summary>
        /// 加载命令
        /// </summary>
        public override void LoadCommand()
        {
     
            SearchCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(SearchExecute);
            LinkCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(LinkExecute);

            NewFlushCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(LoadData);
            AddLinkCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(AddLinkExecute);
            DeleteLinkCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(DeleteLinkExecute);
        }

        public override void LoadData()
        {
          
                this.LinkModel2 = new ObservableCollection<UnKnowLinkModel>();
        }

        #endregion 构造加载

        #region 变量属性

        private ObservableCollection<UnKnowLinkModel> linkModeltemp;
        /// <summary>
        /// 未选中的关联项
        /// </summary>
        public ObservableCollection<UnKnowLinkModel> LinkModeltemp
        {
            get { return linkModeltemp; }
            set
            {
                linkModeltemp = value;
                this.RaisePropertyChanged("LinkModeltemp");
            }
        }
        private ObservableCollection<UnKnowLinkModel> linkModel;
        /// <summary>
        /// 未选中的关联项
        /// </summary>
        public ObservableCollection<UnKnowLinkModel> LinkModel
        {
            get { return linkModel; }
            set { linkModel = value;
            this.RaisePropertyChanged("LinkModel");
            }
        }
        private ObservableCollection<UnKnowLinkModel> linkModel2;
        /// <summary>
        /// 选中的关联项
        /// </summary>
        public ObservableCollection<UnKnowLinkModel> LinkModel2
        {
            get { return linkModel2; }
            set
            {
                linkModel2 = value;
                this.RaisePropertyChanged("LinkModel2");
            }
        }
        public UnknowBill UnknowModel { get; set; }
        public string LinkID { get; set; }//不明账款ID
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

        private string account;

        /// <summary>
        /// 查询条件缴款账号
        /// </summary>
        public string Account
        {
            get { return account; }
            set
            {
                account = value;
                RaisePropertyChanged("Account");
            }
        }
        private UnKnowLinkModel _selectLink;
        /// <summary>
        /// 未关联的被选中行
        /// </summary>
        public UnKnowLinkModel SelectLink
        {
            get { return _selectLink; }
            set { _selectLink = value;
                
            }
        }
        private UnKnowLinkModel _selectLink2;
        /// <summary>
        /// 已关联的被选中行
        /// </summary>
        public UnKnowLinkModel SelectLink2
        {
            get { return _selectLink2; }
            set { _selectLink2 = value; }
        }
        #endregion 变量属性

        #region 命令定义

        private Microsoft.Practices.Prism.Commands.DelegateCommand _addUnKnownCommand;
        private Microsoft.Practices.Prism.Commands.DelegateCommand _fundCollectCommand;
        private Microsoft.Practices.Prism.Commands.DelegateCommand _redChongCommand;
        private Microsoft.Practices.Prism.Commands.DelegateCommand _searchCommand;
        private Microsoft.Practices.Prism.Commands.DelegateCommand linkCommand;//关联
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
        public Microsoft.Practices.Prism.Commands.DelegateCommand LinkCommand
        {
            get { return linkCommand; }
            set { linkCommand = value; }
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
        private Microsoft.Practices.Prism.Commands.DelegateCommand addLinkCommand;
        public Microsoft.Practices.Prism.Commands.DelegateCommand AddLinkCommand
        {
            get { return addLinkCommand; }
            set { addLinkCommand = value; }
        }
        private Microsoft.Practices.Prism.Commands.DelegateCommand deleteLinkCommand;
        public Microsoft.Practices.Prism.Commands.DelegateCommand DeleteLinkCommand
        {
            get { return deleteLinkCommand; }
            set { deleteLinkCommand = value; }
        }
        #endregion 命令定义

        #region 命令方法

   
        public Action<DockableContent, ShowModel> ShowSubWindowAction;

        public override void FlushExecute()
        {
            JKPZBH = string.Empty;
            Account = string.Empty;
            FlushExecute(true);
        }
     
        /// <summary>
        /// 刷新方法
        /// </summary>
        public  void FlushExecute(bool IsNull)
        { 
            this.LinkModel = new ObservableCollection<UnKnowLinkModel>();
            LinkModeltemp = new ObservableCollection<UnKnowLinkModel>();
            if (IsNull)
            {
               
                this.LinkModel2 = new ObservableCollection<UnKnowLinkModel>();
            }
            this.Models = new ObservableCollection<DepositFund>();
            //总行可以查看所有
            if (VMHelp.PointCode == Tools.HelpClass.Current.MainWebSite)
            {
                this.Models = client.Selects();
                foreach (DepositFund item in this.Models)
                {
                    UnKnowLinkModel um = new UnKnowLinkModel();
                    um.DF = item;
                    if (UnknowModel.UB_LinkStr!=null && UnknowModel.UB_LinkStr.Contains(item.ID))
                    {
                        um.IsCheck = false;
                        LinkModel2.Add(um);
                        
                    }
                    else
                    {
                        um.IsCheck = false;
                        LinkModel.Add(um);
                        LinkModeltemp.Add(um);
                    }
                   
                }
                return;
            }
            foreach (DepositFund item in client.Selects())
            {
                if (item.BankSiteID==VMHelp.PointCode)
                {
                    this.Models.Add(item);
                    UnKnowLinkModel um = new UnKnowLinkModel();
                    um.DF = item;
                    if (UnknowModel.UB_LinkStr != null && UnknowModel.UB_LinkStr.Contains(item.ID))
                    {
                        um.IsCheck = false;
                        LinkModel2.Add(um);
                    }
                    else
                    {
                        um.IsCheck = false;
                        LinkModel.Add(um);
                        LinkModeltemp.Add(um);
                    }
                }
            }
            
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
            //FlushExecute(false);
            LinkModel.Clear();
            foreach (UnKnowLinkModel item in LinkModeltemp)
            {
                LinkModel.Add(item);
            }
            if (!string.IsNullOrEmpty(JKPZBH))
            {
                var temp = from i in LinkModel
                           where (!string.IsNullOrEmpty(i.DF.DepositNum)
                           ) && (i.DF.DepositNum.Contains(JKPZBH))
                           select i;
                ObservableCollection<UnKnowLinkModel> result = new ObservableCollection<UnKnowLinkModel>();
                temp.ToList<UnKnowLinkModel>().ForEach(p => result.Add(p));
        
                this.LinkModel = result;

            }
            if (!string.IsNullOrEmpty(Account))
            {
                var temp = from i in LinkModel
                           where (!string.IsNullOrEmpty(i.DF.DepositAccount)
                           ) && (i.DF.DepositAccount.Contains(Account))
                           select i;
                ObservableCollection<UnKnowLinkModel> result = new ObservableCollection<UnKnowLinkModel>();
                temp.ToList<UnKnowLinkModel>().ForEach(p => result.Add(p));
          
                this.LinkModel = result;

            }
            
            if (!string.IsNullOrEmpty(JKZH.Content.ToString()))
            {
                if (JKZH.Content.ToString() == "全部")
                {
                    return;
                }
                else
                {
                    var temp = from i in this.LinkModel
                               where (!string.IsNullOrEmpty(i.DF.DepositState)
                               && ((!string.IsNullOrEmpty(JKZH.Content.ToString())
                               && i.DF.DepositState.Contains(JKZH.Content.ToString())
                               )))
                               select i;

                    ObservableCollection<UnKnowLinkModel> result = new ObservableCollection<UnKnowLinkModel>();
                    temp.ToList<UnKnowLinkModel>().ForEach(p => result.Add(p));
             
                    this.LinkModel = result;
                }
            }
                
        }
        /// <summary>
        /// 添加关联
        /// </summary>
        private void AddLinkExecute()
        {
            ObservableCollection<UnKnowLinkModel> temp = new ObservableCollection<UnKnowLinkModel>();
            UnKnowLinkModel umtemp=null ;//= new UnKnowLinkModel();
            foreach (UnKnowLinkModel item in LinkModel)
            {
                if (item.IsCheck)
                {
                    if (umtemp == null)
                    {
                        umtemp = new UnKnowLinkModel();
                        umtemp = item;
                    }
                    else if (umtemp.DF.DepositType != item.DF.DepositType)
                    {
                        VMHelp.ShowMessage("所关联资金性质不一致", false);
                        return;
                    }
                }
            }
            foreach (UnKnowLinkModel item in LinkModel)
            {
                if (item.IsCheck)
                {
                   
                    if (LinkModel2.Count > 0)
                    {
                        if (LinkModel2[0].DF.DepositType != umtemp.DF.DepositType)
                        {
                            VMHelp.ShowMessage("所关联资金性质不一致", false);
                            return;
                        }
                    }
                    LinkModeltemp.Remove(item);
                    item.IsCheck = false;
                    LinkModel2.Add(item);
                }
                else
                {
                    temp.Add(item);
                }
            }
            LinkModel = temp;
        }
        /// <summary>
        /// 移除关联
        /// </summary>
        private void DeleteLinkExecute()
        {
            ObservableCollection<UnKnowLinkModel> temp = new ObservableCollection<UnKnowLinkModel>();
            foreach (UnKnowLinkModel item in LinkModel2)
            {
                if (item.IsCheck)
                {
                    item.IsCheck = false;
                    LinkModel.Add(item);
                    LinkModeltemp.Add(item);
                }
                else
                {
                    temp.Add(item);
                }
            }
            LinkModel2 = temp;
        }
        /// <summary>
        /// 进行关联
        /// </summary>
        
        public void LinkExecute()
        {
            UnknowModel.UB_LinkStr = "";
            decimal money = 0;
            foreach (UnKnowLinkModel item in LinkModel2)
            {
               
                 UnknowModel.UB_LinkStr = UnknowModel.UB_LinkStr + item.DF.ID + ",";
                 money = money + item.DF.DepositAmount.Value;
            }
            if (UnknowModel.UB_LinkStr != "")
            {
                if (money != UnknowModel.UB_Money)
                {
                    VMHelp.ShowMessage(string.Format("不明账款金额：{0}\n缴存总额：{1} \n不明账款和所关联的缴存金额不一致", UnknowModel.UB_Money.Value.ToString(),money.ToString()), false);
                    return;
                }
                UnknowModel.UB_State = "Y";
                if (client.UpdateUnKownJG_Deposit(UnknowModel))
                {
                    VMHelp.ShowMessage("关联成功", true);
                   
                }
                else
                {
                    VMHelp.ShowMessage("关联失败", false);
                }
            }
            else
            {
                UnknowModel.UB_State = "N";
                UnknowModel.UB_LinkStr = "N";
                if (client.UpdateUnKownJG_Deposit(UnknowModel))
                {
                    VMHelp.ShowMessage("取消关联成功", true);
                }
                else
                {
                    VMHelp.ShowMessage("取消关联失败", false);
                }
                
            }
           
        }
        List<string> CollectClomn = new List<string>();
        /// <summary>
        /// 被选中的列
        /// </summary>
        public void SelectColomn(bool ischecked)
        {
            if (ischecked)
            {
                if (SelectLink != null && SelectLink.DF.DepositState == Tools.PublicData.DepositA)
                {
                    if (!CollectClomn.Contains(SelectLink.DF.DepositNum))
                    {
                        CollectClomn.Add(SelectLink.DF.DepositNum);
                    }
                }
            }
            else
            {
                if (SelectLink != null)
                {
                    CollectClomn.Remove(SelectLink.DF.DepositNum);
                }
            }
        }
        /// <summary>
        /// 列表头checkbox
        /// </summary>
        public void HeaderIsChecked(bool Ischecked)
        {
            foreach (UnKnowLinkModel item in LinkModel)
            {
                item.IsCheck = Ischecked;
            }
        }
        public void HeaderIsChecked2(bool Ischecked)
        {
            foreach (UnKnowLinkModel item in LinkModel2)
            {
                item.IsCheck = Ischecked;
            }
        }
        #endregion 命令方法

        
    }
    public class UnKnowLinkModel : NotificationObject
    {
        private DepositFund _dF;

        public DepositFund DF
        {
            get { return _dF; }
            set { _dF = value;
            this.RaisePropertyChanged("DF");
            }
        }
        private bool _isCheck;

        public bool IsCheck
        {
            get { return _isCheck; }
            set { _isCheck = value;
            this.RaisePropertyChanged("IsCheck");
            }
        }
    }
}