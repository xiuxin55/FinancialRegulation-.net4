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
    public class UnKnownInfoCheckVM : BaseManageVM<UnknowBill>
    {
      
        public override void LoadCommand()
        {
            SearchCommand = new DelegateCommand(Search);
           UnknownCommand=new DelegateCommand(UnknownExecute);
           ProduceFileCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(ProduceFileExecute);
           UpLoadFileCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(UpLoadFileExecute);
           SendBillCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(SendBillExecute);
           //LinkDepositCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(LinkDepositExecute);
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
        private ObservableCollection<UnknowBill> checklist=new ObservableCollection<UnknowBill>();
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
        public DelegateCommand LinkDepositCommand { get; set; }
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
            if (string.IsNullOrEmpty(CurrentCorp) && string.IsNullOrEmpty(ManageAccount))
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
                    var result = from i in ub where(!string.IsNullOrEmpty(GLZH.Content.ToString()) && i.UB_State.Contains("N")) select i;
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
        public void FlushExecute(bool IsNull)
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
                    //FlushExecute(f);
                    Search();
                }
            }
        }
        /// <summary>
        /// 生成bat文件
        /// </summary>
        private void ProduceFileExecute()
        {
            checklist.Clear();
            foreach (UnknowBill item in client.SelectUnKownJG_Deposit(null))
            {
                if (item.UB_State == "N")
                {
                    checklist.Add(item);
                }
            } 
            if (checklist == null) { VMHelp.ShowMessage("对账信息为空", false); return; }

            //if (!VMHelp.AskMessage("是否生成并上传对账文件？"))
            //{
            //    return;
            //}
            List<string> txtInfo = new List<string>();
            foreach (UnknowBill item in checklist)
            {
                BillstrPad bp = new BillstrPad(item);
                string info = bp.BillPadRight();
                txtInfo.Add(info);
            }
            if (txtInfo.Count > 0)
            {
                FileName = VMHelp.BankCode + DateTime.Now.ToString("yyyyMMdd") + ".sdat";
                FilePath = VMHelp.SYSCONFIG.BillFolder;
                if (billclient.ProduceBillFile(txtInfo, FilePath, FileName))
                {
                    VMHelp.ShowMessage("生成成功", true);
                }
                else
                {
                    VMHelp.ShowMessage("生成失败", false);
                    FileName = null;
                    return;
                }
            
            //UpLoadFileExecute();
            }
        }
        private void UpLoadFileExecute()
        {
            FundsRegulatoryClient.SysConfigSrv.SysConfigInfo ftp = FinancialRegulation.Tools.HelpClass.Current.SYSCONFIG;
            if (ftp.FtpIP == null) { VMHelp.ShowMessage("ftp地址不能为空", false); return; }
            if (ftp.FtpPwd == null || ftp.FtpUser == null) { VMHelp.ShowMessage("ftp账号或密码不能为空", false); return; }
            if (FileName == null)
            {
                VMHelp.ShowMessage("账单未生成", false);
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

            if (billclient.UpLoadFile(FileName, FilePath, ftp.FtpIP, ftp.FtpUser, ftp.FtpPwd))
            {
                VMHelp.ShowMessage( true);
            }
            else
            {
                VMHelp.ShowMessage("对账文件上传失败，ftp地址、账号、密码错误", false);
               // FileName = null;
                
            }
            //}
        }
        /// <summary>
        /// 发起对账
        /// </summary>
        private void SendBillExecute()
        {
            if (FileName == null)
            {
                VMHelp.ShowMessage("文件未生成成功", false);
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
            request.BusinessCode = Tools.PublicData.UnknowBill;
            BillCheckWindowVm vm = new BillCheckWindowVm();
            BillCheckWindow bkwindow = new BillCheckWindow(vm);
            bkwindow.Tag = "不明账款对账";
            if (!(bool)bkwindow.ShowDialog())
            {
                return;
            }
            request.Instruction = vm.BillInstruction;
            request.RecordCount = this.checklist.Count;
            decimal money = 0;
            foreach (UnknowBill item in checklist)
            {
                money = money + item.UB_Money.Value;
            }
            request.AllAmount = money;
            try
            {
                response = SendMessage<Response09>(request, VMHelp.PointCode, VMHelp.UserCode);
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
                return;
            }
            if (response.ReturnCode == Tools.PublicData.ResponseSuccess)
            {
                VMHelp.ShowMessage("对账成功", true);
            }
            else
            {
                VMHelp.ShowMessage("对账失败原因:", false);
            }
            
        }
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
    
    public class BillstrPad
    {
        private Dictionary<int, string> _orderSequence;
        /// <summary>
        /// 序列
        /// </summary>
        public Dictionary<int, string> OrderSequence
        {
            get { return _orderSequence; }
            set { _orderSequence = value; }
        }
        private Dictionary<string, int> _dataLength;
        /// <summary>
        /// 数据长度
        /// </summary>
        public Dictionary<string, int> DataLength
        {
            get { return _dataLength; }
            set { _dataLength = value; }
        }
        private Dictionary<string, string> _dataValue;
        /// <summary>
        /// 数据值
        /// </summary>
        public Dictionary<string, string> DataValue
        {
            get { return _dataValue; }
            set { _dataValue = value; }
        }
        public BillstrPad(UnknowBill bfc)
        {
           
            OrderSequence = new Dictionary<int, string>();
            DataLength = new Dictionary<string, int>();
            DataValue = new Dictionary<string, string>();
            OrderSequence.Add(1, "UB_FirmName");
            OrderSequence.Add(2, "UB_ManageAccount");
            OrderSequence.Add(3, "UB_Money");
            OrderSequence.Add(4, "UB_Time");
            OrderSequence.Add(5, "UB_PayerName");
            OrderSequence.Add(6, "UB_PayerAccount");



            DataLength.Add("UB_FirmName",100);
            DataLength.Add("UB_ManageAccount", 30);
            DataLength.Add("UB_Money", 18);
            DataLength.Add("UB_Time", 10);
            DataLength.Add("UB_PayerName", 100);
            DataLength.Add("UB_PayerAccount", 30);

            DataValue.Add("UB_FirmName", bfc.UB_FirmName);
            DataValue.Add("UB_ManageAccount", bfc.UB_ManageAccount);
            DataValue.Add("UB_Money", bfc.UB_Money.ToString());
            DataValue.Add("UB_Time", bfc.UB_Time.Value.ToString("yyyy/MM/dd"));
            DataValue.Add("UB_PayerName", bfc.UB_PayerName);
            DataValue.Add("UB_PayerAccount", bfc.UB_PayerAccount);
        }
        private Encoding encode = Encoding.GetEncoding("GBK");
        public string BillPadRight()
        {
            //string info = item.BussinessCode + "|" + item.CertificateNum.PadRight(10, ' ') + "|" + item.RegulatoryAccount.PadRight(30, ' ') + "|" + item.FirmName.PadRight(100, ' ') + "|" + item.TradeType + "|" + item.TradeFundAmount.ToString().PadRight(18, ' ') + "|" + item.TradeObject.PadRight(100, ' ') + "|" + item.TradeMark.PadRight(30, ' ') + "|" + item.ProjectCode.PadRight(10, ' ');
            string info = "";

            for (int i = 1; i < OrderSequence.Count + 1; i++)
            {
                int length = DataLength[OrderSequence[i]];
                string value = DataValue[OrderSequence[i]];
                byte[] b = new byte[length];
                byte[] temp = encode.GetBytes(value);
                for (int j = 0; j < length; j++)
                {
                    if (j < temp.Length)
                    {
                        b[j] = temp[j];
                    }
                    else
                    {
                        b[j] = 32;
                    }
                }
                info = info + encode.GetString(b) + "|";
            }
            if (info != "")
            {
                info = info.Substring(0, info.Length - 1);
            }
            return info;
        }
    }
}
