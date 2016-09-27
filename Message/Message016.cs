using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Message
{
    /// <summary>
    /// 购房人查询响应 担保到银行
    /// </summary>
    [XmlRoot("Message016")]
    public class Message016:BaseMessageResponse
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
        /// <summary>
        /// 项目坐落
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 购房人
        /// </summary>
        public string Buyers { get; set; }
        /// <summary>
        /// 购房人证件号码
        /// </summary>
        public string IDNO { get; set; }
        /// <summary>
        /// 监管银行
        /// </summary>
        public string Bank { get; set; }
        /// <summary>
        /// 监管账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 房款总额
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 贷款金额
        /// </summary>
        public decimal LoanAmount { get; set; }
        //public string ExceptionCode { get; set; }
        //public string ExceptionMessage { get; set; }

        public override bool MeaasgeOperate()
        {
            throw new NotImplementedException();
        }
    }
}
