using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinancialRegulation.Tools;
using FundsRegulatoryClient.JG_DepositSrv;
using System.Collections.ObjectModel;

namespace FinancialRegulation.ViewModel
{
    public class UnKnownInfoAddToEditVM : BaseEditVM<UnknowBill>
    {
        /// <summary>
        /// 客户端帮助
        /// </summary>
        public FundsRegulatoryClient.JG_DepositClient deClient = FundsRegulatoryClient.JG_DepositClient.Instance;
        public FundsRegulatoryClient.JG_SpvProtocolClient spvClient = FundsRegulatoryClient.JG_SpvProtocolClient.Instance;

        #region 构造加载
        /// <summary>
        /// 加载命令
        /// </summary>
        public override void LoadCommand()
        {
            //SpvModel = spvClient.Select(new FundsRegulatoryClient.JG_SpvProtocolSrv.JG_SpvProtocol() { SP_XYBH = Model._DE_xybh })[0];
        }

        /// <summary>
        /// 页面构造函数（传参数）
        /// </summary>
        public UnKnownInfoAddToEditVM()
        {
           // this.Model = model;
           // SpvModel = spvClient.Select(new FundsRegulatoryClient.JG_SpvProtocolSrv.JG_SpvProtocol() { SP_XYBH = Model._DE_xybh })[0];
        }
        #endregion

        #region 变量属性
        //TODO:在此定义命令和属性
        private ObservableCollection<UnknowBill>  _model;
        /// <summary>
        /// 存款信息
        /// </summary>
        public ObservableCollection<UnknowBill> Models
        {
            get { return _model; }
            set
            {
                _model = value;
                this.RaisePropertyChanged("Models");
            }
        }
        private int executeCode;
        /// <summary>
        /// 1代表新增 2代表修改
        /// </summary>
        public int ExecuteCode
        {
            get { return executeCode; }
            set { executeCode = value; }
        }
        /// <summary>
        /// 存款性质
        /// </summary>
        private string NatureOfFunding;

        /// <summary>
        /// 报文响应
        /// </summary>
      
        #endregion

        #region 命令定义
        //TODO:在此定义命令
        #endregion

        #region 命令方法

        public override bool Check()
        {
            
            CheckHelper.CustomerCheck<decimal?>(CurrentObj.UB_Money, "存款金额小于1", (i) => i > 0);
            CheckHelper.NotNullCheck(CurrentObj.UB_FirmName, "开发商名称");
            CheckHelper.NotNullCheck(CurrentObj.UB_ManageAccount, "监管账号");
            CheckHelper.NotNullCheck(CurrentObj.UB_PayerName, "付款人名字");
            CheckHelper.NotNullCheck(CurrentObj.UB_PayerAccount, "付款账号");
            CheckHelper.NotNullCheck(CurrentObj.UB_BankSerialNum, "银行流水号");
            //CheckHelper.NotNullCheck(CurrentObj.UB_Type, "缴款类型");
            CheckHelper.NotNullCheck(CurrentObj.UB_Time, "到账日期");
            return true;
        }

        public override void OKExecute()
        {
            try
            {
                if (ExecuteCode == 1)
                {
                    CurrentObj.UB_ID = VMHelp.GUID;
                    CurrentObj.UB_SerialNum = VMHelp.ServiceNo;
                    CurrentObj.UB_BankCode = VMHelp.BankCode;
                    CurrentObj.UB_BankSiteID = VMHelp.PointCode;
                    CurrentObj.UB_BankTellerID = VMHelp.UserCode;
                    FundsRegulatoryClient.JG_AccountManageClient accountClient = FundsRegulatoryClient.JG_AccountManageClient.Instance;
                    FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo ami = new FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo();
                    ami.AM_JgAccount = CurrentObj.UB_ManageAccount;
                    ObservableCollection<FundsRegulatoryClient.JG_AccountManageSrv.JG_AccountManageInfo> acc = accountClient.Select(ami);
                    if (acc.Count < 1 || acc[0].AM_UseFlag == "销户")
                    {
                        VMHelp.ShowMessage("缴款失败，缴存账户不存在或已销户", false);
                        return;
                    }
                    if (Check() && deClient.AddUnKownJG_Deposit(CurrentObj))
                    {
                        this.Models.Add(CurrentObj);
                        VMHelp.ShowMessage(true);
                        windowClose();
                    }
                }
                else
                {
                    if (Check() && deClient.UpdateUnKownJG_Deposit(CurrentObj))
                    {
                        VMHelp.ShowMessage(true);
                        windowOK();
                    }
                }
                /*  try
                  {
                      switch (Model._DE_ckxz)
                      {
                          case "1":
                              NatureOfFunding = "非贷款";
                              break;
                          case "2":
                              NatureOfFunding = "商业贷款";
                              break;
                          case "3":
                              NatureOfFunding = "公积金贷款";
                              break;
                          default:
                              break;
                      }
                      //string strAskMessage = "合同备案号：" + Model._DE_qybh + "\r\n存款人：" + Model._DE_ckr + "\r\n存款金额：" + Model._DE_ckje + "\r\n资金性质：" + NatureOfFunding + "\r\n账户余额：" + CurrentObj.Balances;
                      string strAskMessage = "合同备案号：" + Model._DE_qybh + "\r\n存款人：" + Model._DE_ckr + "\r\n存款金额：" + Model._DE_ckje + "\r\n资金性质：" + NatureOfFunding ;
                      if (Check() && VMHelp.AskMessage(strAskMessage+"\r\n确定要补录不明存款?"))
                      {
                          if (response == null)
                          {
                              CurrentObj.BusinessCode = "112";
                              CurrentObj.BusinessTime = VMHelp.NowTime;
                              CurrentObj.SerialNo = VMHelp.ServiceNo;
                              CurrentObj.PactNo = Model._DE_xybh;
                              CurrentObj.FormerNo = Model._DE_cklsh;
                              CurrentObj.ContractRecordNo = Model._DE_qybh;
                              CurrentObj.Depositor = Model._DE_ckr;
                              CurrentObj.Money = Model._DE_ckje.Value;
                              CurrentObj.NatureOfFunding = Model._DE_ckxz;
                              CurrentObj.FromBbank = VMHelp.BankCode;
                              CurrentObj.Balances = Model._DE_zhye.Value;
                              CurrentObj.CRCCode = VMHelp.CRCCode;
                          }
                        //  response = SendMessage<Message.Message012>(CurrentObj);
                          if (response != null && response.ExceptionCode == "01")
                          {
                              Model._DE_BankCode = VMHelp.PointCode;
                              bool result = deClient.Update(Model);

                              if (result)
                              {
                                  VMHelp.ShowMessage(true);
                                  windowClose();
                              }
                              else
                              {
                                  VMHelp.ShowMessage(false);
                              }
                          }
                          else
                          {
                              VMHelp.ShowMessage(response.ExceptionMessage, false);
                          }
                      }
                  }
                  catch (Exception ex)
                  {
                      VMHelp.ShowMessage(ex.Message, false);
                  }*/
            }
            catch (Exception e)
            {
                 SendExcetpion(e);
            }
        }
        #endregion
    }
}
