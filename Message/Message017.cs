using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using FundsRegulatoryClient.JG_PaymentSrv;
using FundsRegulatoryClient.JG_SpvProtocolSrv;
using FundsRegulatoryClient.JG_AdjustSrv;
using FundsRegulatoryClient.JG_AccountManageSrv;

namespace Message
{
    /// <summary>
    /// 调账退款请求 担保到银行
    /// </summary>
    [XmlRoot("Message017")]
    public class Message017:BaseMessageRequest
    {
        //public string BusinessCode { get; set; }
        //public string BusinessTime { get; set; }
        //public string SerialNo { get; set; }
        /// <summary>
        /// 银行代码
        /// </summary>
        public string BankCode { get; set; }
        /// <summary>
        /// 合同备案号
        /// </summary>
        public string ContractRecordNo { get; set; }
        /// <summary>
        /// 存款流水号
        /// </summary>
        public string DepositNo { get; set; }
        /// <summary>
        /// 存款金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 资金性质
        /// </summary>
        public string NatureOfFunding { get; set; }
        /// <summary>
        /// 存款银行
        /// </summary>
        public string FromBbank { get; set; }
        /// <summary>
        /// 存款人
        /// </summary>
        public string Depositor { get; set; }
        /// <summary>
        /// 退款账号
        /// </summary>
        public string ReceiveAccount { get; set; }
        /// <summary>
        /// 付款账户
        /// </summary>
        public string PaymentAccount { get; set; }

        public override BaseMessageResponse GetReponseMessage()
        {
            Message117 ms117 = new Message117();
            //ms117.PactNo = PactNo;
            ms117.BusinessCode = "117";
            ms117.BankCode = BankCode;
            ms117.ContractRecordNo = ContractRecordNo;
            ms117.DepositNo = DepositNo;
            ms117.Money = Money;
            ms117.NatureOfFunding = NatureOfFunding;
            ms117.FromBbank = FromBbank;
            ms117.ReceiveAccount = ReceiveAccount;
            ms117.PaymentAccount = PaymentAccount;

            return ms117;
        }

        public override BaseMessageResponse MeaasgeOperate()
        {
            //    BaseMessageResponse responseMsg = GetReponseMessage();
            //    responseMsg.SerialNo = FundsRegulatoryClient.BasicFunctionClient.Current.GetSerialNo().ToString();
            //    responseMsg.BusinessTime = FundsRegulatoryClient.BasicFunctionClient.Current.GetServerTime().ToString(Common.SysConst.BUSINESSDATEFORMATE);

            //    FundsRegulatoryClient.JG_PaymentSrv.JG_PaymentInfo jpInfo = new FundsRegulatoryClient.JG_PaymentSrv.JG_PaymentInfo();
            //    JG_SpvProtocol jsInfo = new JG_SpvProtocol();
            //    JG_AdjustInfo jaInfo = new JG_AdjustInfo();
            //    JG_AccountManageInfo jmi=new JG_AccountManageInfo();

            //    jsInfo.SP_QYZH = ReceiveAccount;

            //    if(FundsRegulatoryClient.JG_SpvProtocolClient.Instance.Select(jsInfo).Count>0)
            //    {
            //        jpInfo.PA_xybh = FundsRegulatoryClient.JG_SpvProtocolClient.Instance.Select(jsInfo)[0].SP_XYBH;
            //    }
            //    else if(jpInfo.PA_xybh==""||jpInfo.PA_xybh==null)
            //    {
            //        responseMsg.ExceptionCode = "02";
            //        responseMsg.ExceptionMessage = "收款账户错误!";
            //        return responseMsg;
            //    }
            //    jsInfo.SP_JGJGZH = PaymentAccount;
            //    if (FundsRegulatoryClient.JG_SpvProtocolClient.Instance.Select(jsInfo) == null)
            //    {
            //        responseMsg.ExceptionCode = "03";
            //        responseMsg.ExceptionMessage = "付款账户错误!";
            //        return responseMsg;
            //    }

            //    jmi.AM_JgAccount=ReceiveAccount;
            //    jpInfo.PA_skfmc = FundsRegulatoryClient.JG_AccountManageClient.Instance.Select(jmi)[0].AM_zhmc;


            //    //jpInfo.PA_xybh = PactNo;
            //    jpInfo.PA_ID = Guid.NewGuid().ToString();
            //    jpInfo.PA_zflb =Common.SysConst.ZFLB_TZ;
            //    jpInfo.PA_zfje = Money;
            //    jpInfo.PA_fkfzh = PaymentAccount;
            //    jpInfo.PA_fkBank = FromBbank;
            //    jpInfo.PA_skfzh = ReceiveAccount;
            //    jpInfo.PA_skBank = BankCode;
            //    jpInfo.PA_zfqqlsh = SerialNo;
            //    jpInfo.PA_zfrq = Convert.ToDateTime(BusinessTime);
            //    jpInfo.PA_lc = "0";


            //    if(FundsRegulatoryClient.JG_PaymentClient.Instance.Add(jpInfo))
            //    {
            //        jaInfo.JA_ID = Guid.NewGuid().ToString();
            //        jaInfo.JA_Tzzflsh = SerialNo;
            //        jaInfo.JA_FmCklsh = DepositNo;
            //        jaInfo.JA_SqTime = FundsRegulatoryClient.BasicFunctionClient.Current.GetServerTime();
            //        jaInfo.JA_LC = "0";

            //        FundsRegulatoryClient.JG_AdjustClient.Current.Add(jaInfo);
            //        responseMsg.ExceptionCode = "01";
            //    }

            //    return responseMsg;
            return null;
        }
    }
}
