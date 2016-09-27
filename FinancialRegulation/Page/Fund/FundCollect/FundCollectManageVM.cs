using System;
using FinancialRegulation.ClientException;
using Microsoft.Practices.Prism.Commands;
using FundsRegulatoryClient;
using FundsRegulatoryClient.BillOperateSrv;
using System.Windows;
using FinancialRegulation.Page.Fund.FundCollect;
using FinancialRegulation.Tools;
using System.Collections.Generic;
//using System.IO;

namespace FinancialRegulation.ViewModel
{
    //public class FundCollectManageVM : BaseManageVM<object>
    //{
      /*  /// <summary>
        /// 客户端访问对象
        /// </summary>
        public FundsRegulatoryClient.JG_AmountCollectClient client = FundsRegulatoryClient.JG_AmountCollectClient.Instance;
        private string _bankNo = HelpClass.Current.BankCode;
        #region 构造加载

        /// <summary>
        /// 加载命令
        /// </summary>
        public override void LoadCommand()
        {
            //资金归集绑定
            CollectCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(CollectExecute);
            OKCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(CollectExecute);
            AllCollectCommond = new Microsoft.Practices.Prism.Commands.DelegateCommand(AllCollectExecute);

            BillCreateCommand = new DelegateCommand<FundCollectManageVM>(BillCreate);
            MoreBillCreateCommand = new DelegateCommand<FundCollectManageVM>(MoreBillCreate);
            GuaranteeBillCreateCommand = new DelegateCommand<FundCollectManageVM>(GuaranteeBillCreate);
            //TODO:此处添加自定义命令与方法绑定的代码
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        public override void LoadData()
        {
            FlushExecute();
        }

        #endregion 构造加载

        #region 变量属性

        /// <summary>
        /// 监管资金余额
        /// </summary>
        private decimal _jgzhye;

        //总的资金监管账户余额 界面显示
        public decimal JGZHYE
        {
            get { return _jgzhye; }
            set
            {
                _jgzhye = value;
                RaisePropertyChanged("JGZHYE");
            }
        }

        private System.Data.DataTable _models;

        /// <summary>
        /// 改掉父类的实体 获取到数据表格
        /// </summary>
        new public System.Data.DataTable Models
        {
            get { return _models; }
            set { _models = value; }
        }

        private System.Data.DataRowView _curModel;

        /// <summary>
        /// 改掉父类 显示当前行
        /// </summary>
        new public System.Data.DataRowView CurModel
        {
            get { return _curModel; }
            set { _curModel = value; }
        }
        private DateTime _curDate;

        public DateTime CurDate
        {
            get { return _curDate; }
            set { _curDate = value; RaisePropertyChanged("CurDate"); }
        }

        #endregion 变量属性

        #region 命令定义

        private Microsoft.Practices.Prism.Commands.DelegateCommand _collectCommand;

        /// <summary>
        /// 单条资金归集命令
        /// </summary>
        public Microsoft.Practices.Prism.Commands.DelegateCommand CollectCommand
        {
            get { return _collectCommand; }
            set
            {
                _collectCommand = value;
                RaisePropertyChanged("CollectCommand");
            }
        }

        private Microsoft.Practices.Prism.Commands.DelegateCommand _okCommand;

        /// <summary>
        /// 单条资金归集命令
        /// </summary>
        public Microsoft.Practices.Prism.Commands.DelegateCommand OKCommand
        {
            get { return _okCommand; }
            set
            {
                _okCommand = value;
                RaisePropertyChanged("CollectCommand");
            }
        }

        private Microsoft.Practices.Prism.Commands.DelegateCommand _allCollectCommond;

        /// <summary>
        /// 归集所有
        /// </summary>
        public Microsoft.Practices.Prism.Commands.DelegateCommand AllCollectCommond
        {
            get { return _allCollectCommond; }
            set
            {
                _allCollectCommond = value;
                RaisePropertyChanged("AllCollectCommond");
            }
        }

        public DelegateCommand<FundCollectManageVM> BillCreateCommand { get; set; }

        public DelegateCommand<FundCollectManageVM> MoreBillCreateCommand { get; set; }

        public DelegateCommand<FundCollectManageVM> GuaranteeBillCreateCommand { get; set; }

        #endregion 命令定义

        #region 命令方法
        private void BillCreate(FundCollectManageVM fcm)
        {
            CurDate = BasicFunctionClient.Current.GetServerTime().Date;
            Search(fcm);
            List<ProtocolCollect> pcLst = IsCollect(CurModel["XYBM"].ToString(), CurDate);
            if (pcLst.Count == 0 || pcLst[0].IsCollect == false)
            {
                MessageBox.Show("该协议未归集，无法生成响应的对账单！");
                return;
            }
            List<BillFile> billFiles = new List<BillFile>();
            BillFile bf = new BillFile();
            bf.BankNo = _bankNo;
            bf.AccountType = BillFileType.GuaranteeAccount;
            bf.PactNo = CurModel["XYBM"].ToString();
            billFiles.Add(bf);

            if (BillCreate(billFiles))
            {
                MessageBox.Show("账单发送成功!");
            }
            else
            {
                MessageBox.Show("账单发送失败!");
            }
        }
        /// <summary>
        /// 生成担保公司账户对账单
        /// </summary>
        /// <param name="fcm"></param>
        private void GuaranteeBillCreate(FundCollectManageVM fcm)
        {
            CurDate = BasicFunctionClient.Current.GetServerTime().Date;
            Search(fcm);
            List<BillFile> billFiles = new List<BillFile>();
            BillFile bf = new BillFile();
            bf.BankNo = _bankNo;
            bf.AccountType = BillFileType.GuaranteeAccount;
            billFiles.Add(bf);

            if (BillCreate(billFiles))
            {
                MessageBox.Show("账单发送成功!");
            }
            else
            {
                MessageBox.Show("账单发送失败!");
            }
        }
        private void MoreBillCreate(FundCollectManageVM fcm)
        {
            CurDate = BasicFunctionClient.Current.GetServerTime().Date;
            Search(fcm);
            List<ProtocolCollect> pcLst = IsCollect(CurDate);
            List<BillFile> billFiles = new List<BillFile>();
            foreach (System.Data.DataRowView drv in Models.DefaultView)
            {
                if (pcLst.Find(p => p.ProtocolNo == drv["XYBM"].ToString()).IsCollect)
                {
                    BillFile bf = new BillFile();
                    bf.AccountType = BillFileType.DeveloperAccount;
                    bf.BankNo = _bankNo;
                    bf.PactNo = drv["XYBM"].ToString();
                    billFiles.Add(bf);
                }
            }
            billFiles.Add(new BillFile() { AccountType = BillFileType.GuaranteeAccount, BankNo = _bankNo });

            if (BillCreate(billFiles))
            {
                MessageBox.Show("账单发送成功!");
            }
            else
            {
                MessageBox.Show("账单发送失败!");
            }
        }

        private bool BillCreate(List<BillFile> billFiles)
        {


            BillFile[] result = BillOperateClient.Current.Bill2Server(CurDate, billFiles);
            if (result == null)
            {
                return false;
            }
            else
            {
                bool msgResult = true;
                foreach (BillFile bf in result)
                {
                    Message.Message130 message = new Message.Message130();
                    message.BusinessCode = "130";
                    message.FileName = bf.FileName;
                    message.FileSize = bf.FileSize;
                    message.PactNo = bf.PactNo;
                    message.SerialNo = BasicFunctionClient.Current.GetSerialNo();
                    message.BusinessTime = BasicFunctionClient.Current.GetServerTime().ToString(Common.SysConst.BUSINESSDATEFORMATE);
                  //  Message.Message030 response = SendMessage<Message.Message030>(message);
                    //if (response.ExceptionCode != "01")
                    //{
                    //    msgResult = false;
                    //    break;
                    //}
                }
                return msgResult;
            }
        }

        private List<ProtocolCollect> IsCollect(string protocolNo, DateTime SDtime)
        {
            Bill bill = new Bill() { ProtocolNo = protocolNo, SDtime = SDtime.Date, EDtime = SDtime.AddDays(1).Date };
            return BillOperateClient.Current.IsCollect(bill);

        }
        private List<ProtocolCollect> IsCollect(DateTime SDtime)
        {
            Bill bill = new Bill() { SDtime = SDtime.Date, EDtime = SDtime.AddDays(1).Date };
            return BillOperateClient.Current.IsCollect(bill);
        }

        private void Search(FundCollectManageVM fcm)
        {

            BillConditionWindow bcw = new BillConditionWindow(fcm);
            bcw.ShowDialog();
        }

        /// <summary>
        /// 添加方法
        /// </summary>
        public override void AddExecute()
        {
        }

        /// <summary>
        /// 刷新方法
        /// </summary>
        public override void FlushExecute()
        {
            Models = client.SelectFund();
            if (Models.Rows.Count > 0)
            {
                JGZHYE = Convert.ToDecimal(Models.Rows[0]["SKZHYE"]);
            }
        }

        decimal money;
        decimal jgmoney;
        /// <summary>
        /// 资金
        /// </summary>
        public void CollectExecute()
        {
            try
            {
                if (!(Check() && GetMoney(out money,out jgmoney))) return;

                if (CollectFund(CurModel, (s) => VMHelp.ShowMessage(s.ExceptionMessage, false)))
                {
                    VMHelp.ShowMessage("归集成功!", true);
                }
                else
                {
                    VMHelp.ShowMessage("归集错误!", false);
                }
                FlushExecute();//刷新
            }
            catch (CheckException ex)
            {
                VMHelp.ShowMessage(ex.Message, false);
            }
            catch (Exception ex)
            {
                SendExcetpion(ex);
            }
        }
        public bool GetMoney(out decimal money, out decimal jgmoney)
        {
            InputMoney im = new InputMoney();
            im.Title = "请输入资金归集的账户余额";
            im.WindowTitle = "确定归集 账号:" + CurModel["FKZH"].ToString();
            bool result = (bool)(im.ShowDialog() ?? false);
            money = result ? im.money : 0;
            jgmoney = result ? im.jgmoney : 0;
            return result;
        }
        private Message.Message007 SendRequest(System.Data.DataRowView drv, string ServiceNo, string NowTime)
        {
            Message.Message107 request = new Message.Message107();
            request.BusinessCode = "107";//交易代码
            request.BusinessTime = NowTime;//交易时间
            request.PactNo = drv["XYBM"].ToString();//2013年11月29日 18:38:26  协议编号缺失
            request.SerialNo = ServiceNo;//流水号
            request.Payer = drv["QYBH"].ToString();//付款人 企业编号
            request.PaymentAccount = drv["FKZH"].ToString();//付款账户
            request.PayeeAccount = drv["SKZH"].ToString();//收款账号
            request.Payee = drv["SKFMC"].ToString();//收款方名称
            request.Money = Convert.ToDecimal(drv["JYJE"] == DBNull.Value ? 0 : drv["JYJE"]);//交易金额
            request.Balances1 = money;// Convert.ToDecimal(drv["FKZHYE"]);//付款方余额 2013年11月30日 10:44:33  改为手动输入
            request.Balances2 = jgmoney;// Convert.ToDecimal(drv["SKZHYE"]);//收款方余额
          //  Message.Message007 result = SendMessage<Message.Message007>(request);
            return null;
        }

        private FundsRegulatoryClient.JG_AmountCollectSrv.JG_AmountCollectInfo CreateModel(System.Data.DataRowView drv, string ServiceNo, string NowTime)
        {
            FundsRegulatoryClient.JG_AmountCollectSrv.JG_AmountCollectInfo model = new FundsRegulatoryClient.JG_AmountCollectSrv.JG_AmountCollectInfo();
            NowTime = VMHelp.NowTime.ToString();
            model.AC_BankCode = VMHelp.PointCode;//银行代码
            model.AC_ckje = Convert.ToDecimal(drv["JYJE"] == DBNull.Value ? 0 : drv["JYJE"]);//存款金额
            model.AC_cklsh = ServiceNo;//存款流水号
            model.AC_cksj = DateTime.Parse(NowTime);//存款时间
            model.AC_fkfye = money;//付款方余额 
            model.AC_fkfzh = drv["FKZH"].ToString();//房款账户
            model.AC_ID = VMHelp.GUID;//GUID
            model.AC_skfye = jgmoney;//收款方余额
            model.AC_skfzh = drv["SKZH"].ToString();//收款账户
            model.AC_xybh = drv["XYBM"].ToString();//交易名称
            model.AC_yhmc = drv["KHWD"].ToString();//开户网点
            return model;
        }
        /// <summary>
        /// 归集一条数据
        /// </summary>
        /// <param name="drv">数据行</param>
        /// <param name="Action">返回消息错误</param>
        /// <returns>是否归集成功</returns>
        private bool CollectFund(System.Data.DataRowView drv, Action<Message.Message007> ResponseError)
        {
            string ServiceNo = VMHelp.ServiceNo;
            string NowTime = VMHelp.NowTime;
            Message.Message007 msg = SendRequest(drv, ServiceNo, NowTime);
            if (msg != null && msg.ExceptionCode != null && msg.ExceptionCode == Tools.PublicData.ResponseSuccess)
            {
                FundsRegulatoryClient.JG_AmountCollectSrv.JG_AmountCollectInfo AmountData = CreateModel(drv, ServiceNo, NowTime);
                if (client.Add(AmountData))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (msg != null && msg.ExceptionCode != null && msg.ExceptionCode != Tools.PublicData.ResponseSuccess)
            {
                ResponseError(msg);
                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 资金归集所有
        /// </summary>
        public void AllCollectExecute()
        {
            try
            {
                //批量执行 返回错误信息
                System.Collections.Generic.List<Message.Message007> errorList = new System.Collections.Generic.List<Message.Message007>();
                System.Collections.Generic.List<System.Data.DataRowView> drvs = new System.Collections.Generic.List<System.Data.DataRowView>();
                if (!VMHelp.AskMessage("确定要归集所有账户" + CurModel["FKZH"].ToString())) return;
                foreach (System.Data.DataRowView item in Models.DefaultView)
                {
                    if (!(item["FKZHYE"] is DBNull || Convert.ToDecimal(item["FKZHYE"]) <= 0)) continue;
                    if (!CollectFund(item, (s) => errorList.Add(s))) drvs.Add(item); //记录错误消息
                }

                FlushExecute();
            }
            catch (CheckException ex)
            {
                VMHelp.ShowMessage(ex.Message, false);
            }
            catch (Exception ex)
            {
                SendExcetpion(ex);
            }
        }

        /// <summary>
        /// 检查信息
        /// </summary>
        /// <param name="errMsg">输出错误信息</param>
        /// <returns>检查是否成功</returns>
        public bool Check()
        {
            //如果付款金额小于 等于 0
            //if (CurModel["FKZHYE"] is DBNull || Convert.ToDecimal(CurModel["FKZHYE"]) <= 0) throw new CheckException("付款账户余额小于1元,不能进行归集");
            return true;
        }

        #endregion 命令方法

        public override void ModifyExecute()
        {
            throw new NotImplementedException();
        }

        public override void DeleteExecute()
        {
            throw new NotImplementedException();
        }

        public override void DestroyAccountExecute()
        {
            throw new NotImplementedException();
        }*/
   // }
}