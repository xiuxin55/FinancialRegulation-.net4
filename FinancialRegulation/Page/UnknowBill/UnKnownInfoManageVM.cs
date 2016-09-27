using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;
using FundsRegulatoryClient.JG_DepositSrv;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using FinancialRegulation.ViewModel;
using System.Windows.Forms;
using Message.NewMessage.Response;
using Message.NewMessage.Request;
using FinancialRegulation.Page.Other;
using System.Windows.Controls;

namespace FinancialRegulation.Page.Fund
{
    public class UnKnownInfoManageVM : BaseManageVM<UnknowBill>
    {
      
        public override void LoadCommand()
        {
            SearchCommand = new DelegateCommand(Search);
           UnknownCommand=new DelegateCommand(UnknownExecute);
           ProduceFileCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(ProduceFileExecute);
           UpLoadFileCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(UpLoadFileExecute);
           
          // SendBillCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(SendBillExecute);
          // DeleteCommand = new DelegateCommand(DeleteExecute);
           
        }
        public override void LoadData()
        {
            FlushExecute(false);
        }
        /// <summary>
        /// 客户端
        /// </summary>
        FundsRegulatoryClient.JG_DepositClient client = new FundsRegulatoryClient.JG_DepositClient();
        FundsRegulatoryClient.BillOperateClient billclient = FundsRegulatoryClient.BillOperateClient.Current;
        #region 属性
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

        private string currentServerNo = null;
        /// <summary>
        /// 银行流水号
        /// </summary>
        public string CurrentServerNo
        {
            get { return currentServerNo; }
            set
            {
                currentServerNo = value;
                this.RaisePropertyChanged("CurrentServerNo");
            }
        }

        private string currentCorp = null;

        public string CurrentCorp
        {
            get { return currentCorp; }
            set { currentCorp = value;
            this.RaisePropertyChanged("CurrentCorp");
            }
        }
        private string manageAccount = null;
        /// <summary>
        /// 监管账户
        /// </summary>
        public string ManageAccount
        {
            get { return manageAccount; }
            set
            {
                manageAccount = value;
                this.RaisePropertyChanged("ManageAccount");
            }
        }
        private ComboBoxItem glzh;

        /// <summary>
        /// 查询条件
        /// </summary>
        public ComboBoxItem GLZH
        {
            get { return glzh; }
            set
            {
                glzh = value;
                RaisePropertyChanged("GLZH");
            }
        }
        #endregion

        #region 命令
        public DelegateCommand SearchCommand { get; set; }
        private Microsoft.Practices.Prism.Commands.DelegateCommand produceFileCommand;
        public DelegateCommand UnknownCommand { get; set; }
        public DelegateCommand SendBillCommand { get; set; }//发起对账命令
      //  public DelegateCommand DeleteCommand { get; set; }
        /// <summary>
        /// 生成对账单文件dat
        /// </summary>
        public Microsoft.Practices.Prism.Commands.DelegateCommand ProduceFileCommand
        {
            get { return produceFileCommand; }
            set { produceFileCommand = value; }
        }
        private Microsoft.Practices.Prism.Commands.DelegateCommand upLoadFileCommand;
       

        public Microsoft.Practices.Prism.Commands.DelegateCommand UpLoadFileCommand
        {
            get { return upLoadFileCommand; }
            set { upLoadFileCommand = value; }
        }
       
       
        #endregion

        #region 方法
        private void Search()
        {
            //string.IsNullOrEmpty(CurrentServerNo) &&
            List<UnknowBill> ub = new List<UnknowBill>();
            if ( string.IsNullOrEmpty(CurrentCorp) && string.IsNullOrEmpty(ManageAccount))
            {
                ;
            }
            FlushExecute(false);
            //JG_SpvProtocol js = new JG_SpvProtocol() { SP_XYBH = CurrentProtocolNo, SP_CorpName = CurrentCorp, SP_ItemName = CurrentItem, SP_QYZH = CurrentQyzh };
            //ProtocolLst = FundsRegulatoryClient.JG_SpvProtocolClient.Instance.GetProtocolByCondition(js); 
            //var result=from i in this.Models
            //           where()&&!string.IsNullOrEmpty(i.UB_BankSerialNum)&& i.UB_BankSerialNum.Contains(CurrentServerNo))
            //           &&( && (!string.IsNullOrEmpty(i.UB_FirmName) && i.UB_FirmName.Contains(CurrentCorp))
            //           && ( && !string.IsNullOrEmpty(i.UB_ManageAccount) && i.UB_ManageAccount.Contains(ManageAccount))
            //           )select i;
           
             
            // if (!string.IsNullOrEmpty(CurrentServerNo))
            // {
            //     var result = from i in this.Models where (!string.IsNullOrEmpty(i.UB_BankSerialNum) && i.UB_BankSerialNum.Contains(CurrentServerNo)) select i;
            //     ub = result.ToList<UnknowBill>();
            // }
            //else { ub = this.Models.ToList<UnknowBill>(); }
            ub = this.Models.ToList<UnknowBill>();
            if (!string.IsNullOrEmpty(CurrentCorp))
            {
                var result = from i in ub where (!string.IsNullOrEmpty(i.UB_FirmName) && i.UB_FirmName.Contains(CurrentCorp)) select i;
                ub = result.ToList<UnknowBill>();
            }
            if (!string.IsNullOrEmpty(ManageAccount))
            {
                var result = from i in ub where (!string.IsNullOrEmpty(i.UB_ManageAccount) && i.UB_ManageAccount.Contains(ManageAccount)) select i;
                ub = result.ToList<UnknowBill>();
            }
            if (!string.IsNullOrEmpty(GLZH.Content.ToString()))
            {
                if (GLZH.Content.ToString() == "全部")
                {
                    //var result = from i in ub where (!string.IsNullOrEmpty(GLZH.Content.ToString()) && i.UB_State.Contains()) select i;
                    //ub = result.ToList<UnknowBill>();
                    ;
                }
                else if (GLZH.Content.ToString() == "未关联")
                {
                    var result = from i in ub where (!string.IsNullOrEmpty(GLZH.Content.ToString()) && i.UB_State.Contains("N")) select i;
                    ub = result.ToList<UnknowBill>();
                }
                else
                {
                    var result = from i in ub where (!string.IsNullOrEmpty(GLZH.Content.ToString()) && i.UB_State.Contains("Y")) select i;
                    ub = result.ToList<UnknowBill>();
                }
            }

            ObservableCollection<UnknowBill> temp = new ObservableCollection<UnknowBill>();
            ub.ForEach(p => temp.Add(p));
            this.Models = temp;
        }

        private void UnknownExecute()
        {
            //if (CurrentProtocl==null)
            //{
            //    MessageBox.Show("请选择要进行不明账款缴存的协议!");
            //    return;
            //}
            Page.UnKnownInfoAddToEdit ukInfo = new UnKnownInfoAddToEdit(this.Models,null);
            ukInfo.ShowDialog();
        }
        public override void FlushExecute()
        {
            FlushExecute(false);

        }
        public  void FlushExecute(bool IsNull) 
        {
            this.Models.Clear();
            //总行可以查看所有
            if (VMHelp.PointCode == Tools.HelpClass.Current.MainWebSite)
            {
                this.Models = client.SelectUnKownJG_Deposit(null);
                return;
            }
            foreach (UnknowBill item in client.SelectUnKownJG_Deposit(null))
            {
                if (item.UB_BankSiteID == VMHelp.PointCode)
                {
                    this.Models.Add(item);
                }
            }
            if (IsNull)
            {
                //JKPZBH = string.Empty;
                if (GLZH != null)
                {
                    GLZH.Content = "全部";
                }
            }
           //this.Models = client.SelectUnKownJG_Deposit(null);
        }
        public override void DeleteExecute() {
            if (CurModel.UB_ID != null)
            {
                if (VMHelp.AskMessage("是否进行删除"))
                {
                    if (client.DeleteUnKownJG_Deposit(CurModel))
                    {
                        this.Models.Remove(CurModel);
                        VMHelp.ShowMessage(true);

                    }
                }
            }
        }
        public override void ModifyExecute()
        {
            if (CurModel.UB_ID != null)
            {
                Page.UnKnownInfoAddToEdit ukInfo = new UnKnownInfoAddToEdit(this.Models, this.CurModel);

                if (!(bool)ukInfo.ShowDialog())
                {
                    //FlushExecute(false);
                    Search();
                }
            }
        }
        /// <summary>
        /// 生成bat文件
        /// </summary>
        private void ProduceFileExecute()
        {
           
            if (this.Models == null) { VMHelp.ShowMessage("对账信息为空", false); return; }
     
            if (!VMHelp.AskMessage("是否生成对账文件？"))
            {
                return;
            }
            List<string> txtInfo = new List<string>();
            foreach (UnknowBill item in this.Models)
            {
                string info = item.UB_FirmName.PadRight(100, ' ') + "|" + item.UB_ManageAccount.PadRight(30, ' ') + "|" + item.UB_Money.ToString().PadRight(18, ' ') + "|" + item.UB_Time.Value.ToString("yyyy/MM/dd").PadRight(10, ' ') + "|" + item.UB_PayerName.PadRight(100, ' ') + "|" + item.UB_PayerAccount.PadRight(30, ' ');
                txtInfo.Add(info);
            }
            if (txtInfo.Count > 0)
            {
                FileName = VMHelp.BankCode + DateTime.Now.ToString("yyyyMMdd") + ".sdat";
                FilePath = AppDomain.CurrentDomain.BaseDirectory;
                if (billclient.ProduceBillFile(txtInfo, null, FileName))
                {
                    VMHelp.ShowMessage("生成成功", true);
                }
                else
                {
                    VMHelp.ShowMessage("生成失败", false);
                }
            }
        }
        private void UpLoadFileExecute()
        {
            FundsRegulatoryClient.SysConfigSrv.SysConfigInfo ftp = FinancialRegulation.Tools.HelpClass.Current.SYSCONFIG;
            if (ftp.FtpIP == null) { VMHelp.ShowMessage("ftp地址不能为空", false); return; }
            if(ftp.FtpPwd==null ||ftp.FtpUser==null){VMHelp.ShowMessage("ftp账号或密码不能为空",false);return ;}
            if (FileName == null)
            {
                VMHelp.ShowMessage("账单未生成",false);
                return;
            }
            //OpenFileDialog op = new OpenFileDialog();
            //op.Filter = "dat(*.sdat)|*.sdat";
            //if (FilePath != null)
            //{
            //    op.InitialDirectory = FilePath;
            //}
            //if (op.ShowDialog() == DialogResult.OK)
            //{
            //    if (!op.FileName.Contains( FileName))
            //    {
            //        if (VMHelp.AskMessage("上传文件与生产文件不一致，是否仍上传？"))
            //        {
            //            FileName = op.FileName;
            //        }
            //        else { return; }
            //    }

                if (billclient.UpLoadFile(FileName,null, ftp.FtpIP, ftp.FtpUser, ftp.FtpPwd))
                {
                    VMHelp.ShowMessage("对账文件上传成功", true);
                }
                else
                {
                    VMHelp.ShowMessage("对账文件上传失败", false);
                }
            //}
        }
        /// <summary>
        /// 发起对账
        /// </summary>
       /* private void SendBillExecute()
        {
            if (FileName == null)
            {
                VMHelp.ShowMessage("文件未生成", false);
                return;
            }
            if (!billclient.UploadState)
            {
                VMHelp.ShowMessage("文件未上传成功", false);
                return;
            }
            Response09 response = new Response09();
            Request09 request = new Request09();
            request.BankCode = VMHelp.BankCode;
            request.FileName = FileName;
            BillCheckWindow bkwindow = new BillCheckWindow();
            bkwindow.ShowDialog();
            request.Instruction = bkwindow.BillInstruction;
            request.RecordCount = this.Models.Count;
            decimal money = 0;
            foreach (UnknowBill item in client.SelectUnKownJG_Deposit(null))
            {
                money = money + item.UB_Money.Value;
            }
            request.AllAmount = money;
            response = SendMessage<Response09>(request, VMHelp.PointCode, VMHelp.UserCode);
            if (response.ReturnCode == Tools.PublicData.ResponseSuccess)
            {
                VMHelp.ShowMessage("对账成功", true);
            }
            else
            {
                VMHelp.ShowMessage("对账失败", false);
            }
        }*/

        public void LinkDepositExecute()
        {
            UnknowBill ub = CurModel;
            FinancialRegulation.Page.UnknowBillPage.FundInfoManage fd = new FinancialRegulation.Page.UnknowBillPage.FundInfoManage(ub);
            fd.LinkID = CurModel.UB_ID;
            fd.Tag = "不明账款和缴存关联";
            fd.MinWidth = 1000;
            fd.ShowDialog();
            FlushExecute(false);
        }
        
        #endregion
    }
}
