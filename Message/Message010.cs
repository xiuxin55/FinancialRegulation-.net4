using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using FundsRegulatoryClient;

namespace Message
{
    /// <summary>
    /// 支付请求担保到银行
    /// </summary>
    [XmlRoot("Message010")]
    public class Message010:BaseMessageRequest
    {
        ///// <summary>
        ///// 交易代码
        ///// </summary>
        //public string BusinessCode { get; set; }
        ///// <summary>
        ///// 交易时间
        ///// </summary>
        //public string BusinessTime { get; set; }
        ///// <summary>
        ///// 交易流水号
        ///// </summary>
        //public string SerialNo { get; set; }
        /// <summary>
        /// 协议编号
        /// </summary>
        //public string PactNo { get; set; }

        /// <summary>
        /// 付款账户
        /// </summary>
        public string PayAccount { get; set; }
        /// <summary>
        /// 支取人
        /// </summary>
        public string Payee { get; set; }
        /// <summary>
        /// 支取账户
        /// </summary>
        public string PayeeAccount { get; set; }
        /// <summary>
        /// 支取金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        public string PayType { get; set; }
        /// <summary>
        /// CRC校验码
        /// </summary>
        public string CRCCode { get; set; }


        public override BaseMessageResponse GetReponseMessage()
        {
            //throw new NotImplementedException();
            Message110 responseMsg = new Message110();
            responseMsg.PactNo = PactNo;
            responseMsg.Payee = Payee;
            responseMsg.PayeeAccount = PayeeAccount;
            responseMsg.PayAccount = PayAccount;
            responseMsg.Money = Money;
            responseMsg.PayType = PayType;
            responseMsg.CRCCode = CRCCode;
            responseMsg.BusinessCode = "110";

            responseMsg.PayAccount = PayAccount;
            return responseMsg;
        }

        public override BaseMessageResponse MeaasgeOperate()
        {
            //throw new NotImplementedException();
            FundsRegulatoryClient.RegulatorySrv.JG_PaymentInfo pa = new FundsRegulatoryClient.RegulatorySrv.JG_PaymentInfo();
            pa.PA_ID = Guid.NewGuid().ToString();
            pa.PA_xybh = PactNo;
            pa.PA_skfmc = Payee;
            pa.PA_skfzh = PayeeAccount;
            pa.PA_zfje = Money;
            pa.PA_fkfzh = PayAccount;
            pa.PA_zflb = PayType;
            pa.PA_zfqqlsh = SerialNo;
            pa.PA_zfrq = Convert.ToDateTime(BusinessTime);
            pa.PA_lc = "0";

            BaseMessageResponse responseMsg = GetReponseMessage();
            //GetReponseMessage();
            // 校验信息
            // 如果失败 
            // responseMsg.ExceptionCode ="";
            // responseMsg.ExceptionMessage="...";
            responseMsg.BusinessTime = DateTime.Now.ToString(Common.SysConst.BUSINESSDATEFORMATE);
            responseMsg.SerialNo = FundsRegulatoryClient.BasicFunctionClient.Current.GetSerialNo().ToString();
            if (FundsRegulatoryClient.RegulatoryClient.Current.PaymentRequest(pa))
            {
                //responseMsg.BusinessTime = DateTime.Now.ToString(Common.SysConst.BUSINESSDATEFORMATE);
                responseMsg.ExceptionCode = "01";
                //responseMsg.SerialNo = FundsRegulatoryClient.BasicFunctionClient.Current.GetSerialNo();
            }
            return responseMsg;
        }
    }
}
