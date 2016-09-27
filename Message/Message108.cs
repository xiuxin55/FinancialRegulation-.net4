using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
//using FundsRegulatoryClient;

namespace Message
{
    /// <summary>
    /// 监管账户结息银行到担保
    /// </summary>
    [XmlRoot("Message108")]
    public class Message108:BaseMessageRequest
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
        /// 结息账户
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 结息时间
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// 利息金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal Balances { get; set; }
        /// <summary>
        /// CRC校验码
        /// </summary>
        public string CRCCode { get; set; }

        public override BaseMessageResponse GetReponseMessage()
        {
            Message008 responseMsg = new Message008();
            responseMsg.BusinessCode = "008";
            responseMsg.PactNo = PactNo;
            responseMsg.Account = Account;
            responseMsg.Money = Money;
            responseMsg.Balances = Balances;
            responseMsg.Time = Time;
            responseMsg.CRCCode = CRCCode;
            return responseMsg;
        }

        public override BaseMessageResponse MeaasgeOperate()
        {
            //FundsRegulatoryClient.JG_AmountCollectSrv.JG_AmountCollectInfo jacInfo = null;
            //jacInfo = new FundsRegulatoryClient.JG_AmountCollectSrv.JG_AmountCollectInfo();
            //jacInfo.AC_cklsh = SerialNo;
            //jacInfo.AC_xybh = PactNo;
            //jacInfo.AC_skfzh = Account;
            //jacInfo.AC_ckje = Money;
            //jacInfo.AC_fkzhye = Balances;
            //jacInfo.AC_cksj = Convert.ToDateTime(Time);
            //jacInfo.AC_ckxz = "1";

            //BaseMessageResponse bmr = GetReponseMessage();
            //if (JG_AmountCollectClient.Current.AddAmountCollectInfo(jacInfo))
            //{
            //    bmr.BusinessTime = DateTime.Now.ToString();
            //    bmr.ExceptionCode = "01";
            //}
            //return bmr;
            throw new NotImplementedException();
        }
    }
}
