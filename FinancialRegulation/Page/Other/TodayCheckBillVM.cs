using AvalonDock;
using System;
using System.Linq;
using System.Collections.Generic;
using FundsRegulatoryClient.BillOperateSrv;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using FinancialRegulation.Page.Fund;
using System.Windows.Forms;
using Message.NewMessage.Response;
using Message.NewMessage.Request;
using FinancialRegulation.Page.Other;
using System.Text;
using FundsRegulatoryClient.JG_DepositSrv;

namespace FinancialRegulation.ViewModel
{
    /// <summary>
    ///今日对账单信息
    /// </summary>
    [System.Runtime.InteropServices.GuidAttribute("DEEF5BD6-8EB4-41E8-8849-48347844D170")]
    public class TodayCheckBillVM : BaseManageVM<FundsRegulatoryClient.BillOperateSrv.BillFileCheck>
    {
        /// <summary>
        /// 客户端访问对象
        /// </summary>
        public FundsRegulatoryClient.BillOperateClient client = FundsRegulatoryClient.BillOperateClient.Current;
        public FundsRegulatoryClient.JG_AccountManageClient AccountClient = FundsRegulatoryClient.JG_AccountManageClient.Instance;
        FundsRegulatoryClient.JG_DepositClient Depositclient = new FundsRegulatoryClient.JG_DepositClient();
        #region 构造加载

        /// <summary>
        /// 加载命令
        /// </summary>
        public override void LoadCommand()
        {
           
            SearchCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(SearchExecute);
            BillTableCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(BillTableExecute);
            ProduceFileCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(ProduceFileExecute);
            UpLoadFileCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(UpLoadFileExecute);
            SendBillCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(SendBillExecute);
        }

        public override void LoadData()
        {
            FlushExecute();
        }

        #endregion 构造加载

        #region 变量属性
        private ObservableCollection<BillFileCheck> checklist = new ObservableCollection<BillFileCheck>();
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
               
            }
        }

        #endregion 变量属性

        #region 命令定义


        private Microsoft.Practices.Prism.Commands.DelegateCommand billTableCommand;
        private Microsoft.Practices.Prism.Commands.DelegateCommand produceFileCommand;
        private Microsoft.Practices.Prism.Commands.DelegateCommand _searchCommand;
        private Microsoft.Practices.Prism.Commands.DelegateCommand upLoadFileCommand;
        public Microsoft.Practices.Prism.Commands.DelegateCommand SendBillCommand { get; set; }//发起对账命令
        public Microsoft.Practices.Prism.Commands.DelegateCommand UpLoadFileCommand
        {
            get { return upLoadFileCommand; }
            set { upLoadFileCommand = value; }
        }
        /// <summary>
        /// 今日对账单
        /// </summary>
        public Microsoft.Practices.Prism.Commands.DelegateCommand BillTableCommand
        {
            get { return billTableCommand; }
            set { billTableCommand = value; }
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
        /// 生成对账表格
        /// </summary>
        private void BillTableExecute()
        {
            FlushExecute();
        }
        /// <summary>
        /// 生成bat文件
        /// </summary>
        private void ProduceFileExecute()
        {
           
            if (this.Models == null) { VMHelp.ShowMessage("对账信息为空", false); return; }
           
            //if (!VMHelp.AskMessage("是否生成并上传对账文件？"))
            //{
            //    return;
            //}
            try
            {

                List<string> txtInfo = new List<string>();
                foreach (BillFileCheck item in this.Models)
                {
                    BillstrPad bp = new BillstrPad(item);
                    string info = bp.BillPadRight();
                    txtInfo.Add(info);
                }
                if (txtInfo.Count > 0)
                {
                    FileName = VMHelp.BankCode + DateTime.Now.ToString("yyyyMMdd") + ".dat";
                    FilePath = VMHelp.SYSCONFIG.BillFolder;
                    if (client.ProduceBillFile(txtInfo, FilePath, FileName))
                    {
                        VMHelp.ShowMessage("生成成功", true);
                    }
                    else
                    {
                        VMHelp.ShowMessage("生成失败", false);
                        FileName = null;
                        return;
                    }
                    //   UpLoadFileExecute();
                }
            }
            catch (Exception e)
            {
                 SendExcetpion(e);
            }
        }
        private void UpLoadFileExecute()
        {
            try
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
                //op.Filter = "dat(*.dat)|*.dat";
                //if (FilePath != null)
                //{
                //    op.InitialDirectory = FilePath;
                //}
                //if (op.ShowDialog() == DialogResult.OK)
                //{

                if (client.UpLoadFile(FileName, FilePath, ftp.FtpIP, ftp.FtpUser, ftp.FtpPwd))
                {
                    VMHelp.ShowMessage(true);
                }
                else
                {
                    VMHelp.ShowMessage("对账文件上传失败，ftp地址、账号、密码错误", false);
                    //  FileName = null;
                }
                //}
            }
            catch (Exception e)
            {
                 SendExcetpion(e);
            }
        }
        /// <summary>
        /// 刷新方法
        /// </summary>
        public override void FlushExecute()
        {
            BillFileCheck bfc=new BillFileCheck();
            bfc.Time=DateTime.Parse(DateTime.Now.ToShortDateString());
            this.Models = client.SelectsTodayBill(bfc);
            //XYBH = string.Empty;
            //CKZH = string.Empty;
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
          
                //var result = from i in Models
                //             where
                //             (!string.IsNullOrEmpty(JKPZBH))
                //             && (!string.IsNullOrEmpty(i.DepositNum)
                //             )&&(i.DepositNum.Contains(JKPZBH))
                //             select i;
                //List<DepositFund> temp = result.ToList<FundsRegulatoryClient.JG_DepositSrv.DepositFund>();
                //ObservableCollection<DepositFund> oj = new ObservableCollection<DepositFund>();
                //temp.ForEach(p => oj.Add(p));
                //this.Models = oj;
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
            if (!client.UploadState )
            {
                VMHelp.ShowMessage("文件未上传成功", false);
                return;
            }
            Response01 response = new Response01();
            Request01 request = new Request01();
            request.BankCode = VMHelp.BankCode;
            request.FileName = FileName;
            request.BusinessCode = Tools.PublicData.CheckBill;
            ObservableCollection<AccountAndBalance> temp = GetBalance();//获得平台余额
            decimal PlatformBalance=0;
            foreach (AccountAndBalance item in temp)
            {
                PlatformBalance += item.Balance.Value;
            }
            request.PlatformBalance = PlatformBalance.ToString();//平台余额
            BillCheckWindowVm vm = new BillCheckWindowVm();
            BillCheckWindow bkwindow = new BillCheckWindow(vm);
            bkwindow.Tag = "当日对账";
            if (!(bool)bkwindow.ShowDialog())
            {
                return;
            }
            ObservableCollection<UnknowBill> checklist=new ObservableCollection<UnknowBill>();
            foreach (UnknowBill item in Depositclient.SelectUnKownJG_Deposit(null))
            {
                if (item.UB_State == "N")
                {
                    checklist.Add(item);
                }
            }
            decimal money = 0;
            foreach (UnknowBill item in checklist)
            {
                money = money + item.UB_Money.Value;
            }
            request.AccoutCheckInstr = vm.BillInstruction;
            request.AccountBalance = money;//账务余额
            try
            {
                response = SendMessage<Response01>(request, VMHelp.PointCode, VMHelp.UserCode);
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
                ;
                VMHelp.ShowMessage(Tools.HelpClass.Current.MsgDIC[response.ReturnCode], false);
            }
        }
        #endregion 命令方法
        #region 内部方法
        public ObservableCollection<AccountAndBalance> GetBalance()
        {
            ObservableCollection<AccountAndBalance>  AccountList = new ObservableCollection<AccountAndBalance>();
           
            foreach (FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo item in AccountClient.Selects())
            {
                if (item.AM_UseFlag == "正常")
                {
                    AccountAndBalance aab = new AccountAndBalance();
                    aab.AccountInfo = item;
                    AccountList.Add(aab);
                }
            }
            return AccountList;
        }
        /// <summary>
        /// 对账文件字符串拼接
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
       
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
        public BillstrPad(BillFileCheck bfc)
        {
            OrderSequence = new Dictionary<int, string>();
            DataLength = new Dictionary<string, int>();
            DataValue = new Dictionary<string, string>();
            OrderSequence.Add(1, "BussinessCode");
            OrderSequence.Add(2, "CertificateNum");
            OrderSequence.Add(3, "RegulatoryAccount");
            OrderSequence.Add(4, "FirmName");
            OrderSequence.Add(5, "TradeType");
            OrderSequence.Add(6, "TradeFundAmount");
            OrderSequence.Add(7, "TradeObject");
            OrderSequence.Add(8, "TradeMark");
            OrderSequence.Add(9, "ProjectCode");


            DataLength.Add( "BussinessCode",2);
            DataLength.Add( "CertificateNum",10);
            DataLength.Add( "RegulatoryAccount",30);
            DataLength.Add( "FirmName",100);
            DataLength.Add( "TradeType",2);
            DataLength.Add( "TradeFundAmount",18);
            DataLength.Add( "TradeObject",100);
            DataLength.Add( "TradeMark",30);
            DataLength.Add( "ProjectCode",10);

            DataValue.Add("BussinessCode", bfc.BussinessCode);
            DataValue.Add("CertificateNum", bfc.CertificateNum);
            DataValue.Add("RegulatoryAccount", bfc.RegulatoryAccount);
            DataValue.Add("FirmName", bfc.FirmName );
            DataValue.Add("TradeType", bfc.TradeType);
            DataValue.Add("TradeFundAmount", bfc.TradeFundAmount.ToString());
            DataValue.Add("TradeObject", bfc.TradeObject);
            DataValue.Add("TradeMark", bfc.TradeMark);
            DataValue.Add("ProjectCode", bfc.ProjectCode);

        }
        private Encoding encode = Encoding.GetEncoding("GBK");
        public string BillPadRight()
        {
            //string info = item.BussinessCode + "|" + item.CertificateNum.PadRight(10, ' ') + "|" + item.RegulatoryAccount.PadRight(30, ' ') + "|" + item.FirmName.PadRight(100, ' ') + "|" + item.TradeType + "|" + item.TradeFundAmount.ToString().PadRight(18, ' ') + "|" + item.TradeObject.PadRight(100, ' ') + "|" + item.TradeMark.PadRight(30, ' ') + "|" + item.ProjectCode.PadRight(10, ' ');
            string info = "";
          
            for (int i = 1; i < OrderSequence.Count + 1; i++)
            {
                int length = DataLength[OrderSequence[i]];
                string value =DataValue[OrderSequence[i]];
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