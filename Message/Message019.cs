using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using FundsRegulatoryClient.JG_AdjustSrv;
using FundsRegulatoryClient.JG_DepositSrv;
using FundsRegulatoryClient.JG_SpvProtocolSrv;

namespace Message
{
    /// <summary>
    /// 调账请求 担保到银行
    /// </summary>
    [XmlRoot("Message019")]
    public class Message019 : BaseMessageRequest
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
        /// 退款账号  收款账号
        /// </summary>
        public string ReceiveAccount { get; set; }
        /// <summary>
        /// 付款账户
        /// </summary>
        public string PaymentAccount { get; set; }

        public override BaseMessageResponse GetReponseMessage()
        {
            Message119 ms119 = new Message119();
            //ms119.PactNo = PactNo;
            ms119.BusinessCode = "119";
            ms119.BankCode = BankCode;
            ms119.ContractRecordNo = ContractRecordNo;
            ms119.DepositNo = DepositNo;
            ms119.Money = Money;
            ms119.NatureOfFunding = NatureOfFunding;
            ms119.FromBbank = FromBbank;
            ms119.ReceiveAccount = ReceiveAccount;
            ms119.PaymentAccount = PaymentAccount;

            return ms119;
        }

        public override BaseMessageResponse MeaasgeOperate()
        {
            BaseMessageResponse responseMsg = GetReponseMessage();
            responseMsg.SerialNo = FundsRegulatoryClient.BasicFunctionClient.Current.GetSerialNo().ToString();
            responseMsg.BusinessTime = FundsRegulatoryClient.BasicFunctionClient.Current.GetServerTime().ToString(Common.SysConst.BUSINESSDATEFORMATE);

            JG_AdjustInfo jaInfo = new JG_AdjustInfo();

            DepositFund jdInfo = new DepositFund();

            JG_SpvProtocol jgInfo = new JG_SpvProtocol();
            jgInfo.SP_QYZH = ReceiveAccount;
            jaInfo.JA_Xybh = FundsRegulatoryClient.JG_SpvProtocolClient.Instance.Select(jgInfo)[0].SP_XYBH;
            if(jaInfo.JA_FmXybh==""||jaInfo.JA_FmXybh==null)
            {
                responseMsg.ExceptionCode = "02";
                responseMsg.ExceptionMessage = "收款账户错误!";
            }
            jgInfo.SP_QYZH = PaymentAccount;
            jaInfo.JA_FmXybh = FundsRegulatoryClient.JG_SpvProtocolClient.Instance.Select(jgInfo)[0].SP_XYBH;
            if(jaInfo.JA_Xybh==""||jaInfo.JA_Xybh==null)
            {
                responseMsg.ExceptionCode = "03";
                responseMsg.ExceptionMessage = "付款账户错误!";
            }

           // jdInfo._DE_cklsh = DepositNo;

            jaInfo.JA_ID = Guid.NewGuid().ToString();
            //jaInfo.JA_Xybh = PactNo;
            //jaInfo.JA_FmXybh = FundsRegulatoryClient.JG_DepositClient.Instance.Select(jdInfo)[0]._DE_xybh;
   //         jaInfo.JA_FmID = FundsRegulatoryClient.JG_DepositClient.Instance.Select(jdInfo)[0]._DE_ID;
            jaInfo.JA_FmCklsh = DepositNo;

            if (jaInfo.JA_FmID == "" || jaInfo.JA_FmID == null)
            {
                responseMsg.ExceptionCode = "04";
                responseMsg.ExceptionMessage = "存款流水号错误!";
            }
            else
            {
                if (FundsRegulatoryClient.JG_AdjustClient.Current.UpdateJG_AdjustByCklsh(jaInfo))
                {
                    responseMsg.ExceptionCode = "01";
                }
            }

            return responseMsg;
        }
    }
}
