using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Message
{
    /// <summary>
    /// 对账单确认响应担保到银行
    /// </summary>
    public class Message030 : BaseMessageResponse
    {
        ///// <summary>
        ///// 交易编号
        ///// </summary>
        //public string BusinessCode { get; set; }
        ///// <summary>
        ///// 交易时间
        ///// </summary>
        //public string BusinessTime { get; set; }
        ///// <summary>
        ///// 流水号
        ///// </summary>
        //public string SerialNo { get; set; }
        /// <summary>
        /// 元流水号
        /// </summary>
        public string FormerNo { get; set; }
        ///// <summary>
        ///// 协议编号
        ///// </summary>
        ////public string PactNo { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public long FileSize { get; set; }
        ///// <summary>
        ///// 异常代码
        ///// </summary>
        //public string ExceptionCode { get; set; }
        ///// <summary>
        ///// 异常信息
        ///// </summary>
        //public string ExceptionMessage { get; set; }

    
  
        /*
        交易代码	BusinessCode
        交易时间	BusinessTime
        交易流水号	SerialNo
        银行代码	FormerNo
        协议编号	PactNo
        文件名	FileName
        文件大小	FileSize
        异常代码	ExceptionCode
        异常信息	ExceptionMessage
         */



        public override bool MeaasgeOperate()
        {
            throw new NotImplementedException();
        }
    }
}
