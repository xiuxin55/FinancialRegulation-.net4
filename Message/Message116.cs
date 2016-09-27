using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
//using FundsRegulatoryClient.JG_DepositSrv;

namespace Message
{
    /// <summary>
    /// 购房人查询 银行到担保
    /// </summary>
    [XmlRoot("Message116")]
    public class Message116 : BaseMessageRequest
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
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 查询时间
        /// </summary>
        public string Time { get; set; }

        public override BaseMessageResponse GetReponseMessage()
        {
            Message016 responseMsg = new Message016();
            responseMsg.BusinessCode = "016";
            responseMsg.BankCode = BankCode;
            responseMsg.ContractRecordNo = ContractRecordNo;
            responseMsg.Operator = Operator;
            responseMsg.Time = Time;
            return responseMsg;
        }

        public override BaseMessageResponse MeaasgeOperate()
        {
            //Message016 responseMsg = (Message016)GetReponseMessage();
            //object obj = FundsRegulatoryClient.JG_DepositClient.Current.ContractFundsGet(ContractRecordNo);
            //JG_ContractInfo[] jc = FundsRegulatoryClient.JG_DepositClient.Current.ContractInfoGet(ContractRecordNo);
            //decimal d;
            //if (obj == null)
            //{
            //    d = 0;
            //}
            //else
            //{
            //    d = decimal.Parse(obj.ToString());
            //}

            //if (jc.Length == 0)
            //{
            //    responseMsg.ExceptionCode = "03";
            //    responseMsg.ExceptionMessage = "合同备案号错误";
            //    return responseMsg;
            //}
            //if (d >= jc[0].TotalAmount)
            //{
            //    responseMsg.ExceptionCode = "04";
            //    responseMsg.ExceptionMessage = "购房款已缴清";
            //    return responseMsg;
            //}
            //if (jc[0].Bank != BankCode)
            //{
            //    responseMsg.ExceptionCode = "02";
            //    responseMsg.ExceptionMessage = "非监管行，无权查询";
            //    return responseMsg;
            //}
            //responseMsg.ItemName = jc[0].ItemName;
            //responseMsg.Buyers = jc[0].Buyers;
            //responseMsg.IDNO = jc[0].IDNO;
            //responseMsg.Bank = jc[0].Bank;
            //responseMsg.Account = jc[0].Account;
            //responseMsg.TotalAmount = jc[0].TotalAmount;
            //responseMsg.ExceptionCode = "01";
            //responseMsg.SerialNo = FundsRegulatoryClient.BasicFunctionClient.Current.GetSerialNo();
            //responseMsg.BusinessTime = FundsRegulatoryClient.BasicFunctionClient.Current.CurrentTimeServer().ToString(Common.SysConst.BUSINESSDATEFORMATE);
            //return responseMsg;
            throw new NotImplementedException();
        }
    }
}
