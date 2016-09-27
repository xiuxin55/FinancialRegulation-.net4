using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundsRegulatoryClient;
//using FundsRegulatoryClient.JG_BillSrv;
using System.IO;

namespace Message
{
    /// <summary>
    /// 对账单确认银行到担保
    /// </summary>
    public class Message130 : BaseMessageRequest
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
        //public override BaseMessageResponse GetReponseMessage()
        //{
        //    Message030 responseMsg = new Message030();
        //    responseMsg.BusinessCode = "030";
        //    responseMsg.FormerNo = SerialNo;
        //    responseMsg.PactNo = PactNo;
        //    responseMsg.BusinessCode = FileName;
        //    responseMsg.FileSize = FileSize;
        //    return responseMsg;
        //}
        //public override BaseMessageResponse MeaasgeOperate()
        //{
        //    Message030 responseMsg = GetReponseMessage() as Message030;
        //    JG_BillFiles jb = new JG_BillFiles();
        //    jb.BF_SerialNo = SerialNo;
        //    jb.BF_ProtocolNo = PactNo;
        //    jb.BF_BusTime = BusinessTime;
        //    jb.BF_FileName = FileName;
        //    jb.BF_FileSize = FileSize;
        //    jb.BF_AddTime = BasicFunctionClient.Current.CurrentTimeServer();

        //    if (JG_BillClient.Current.BillFilesAdd(jb))
        //    {
        //        responseMsg.ExceptionCode = "01";
        //        responseMsg.BusinessTime = BasicFunctionClient.Current.CurrentTimeServer();
        //        responseMsg.SerialNo = BasicFunctionClient.Current.GetSerialNo();
        //    }
        //    else
        //    {
        //        File.Delete(@"E:\Bill\"+FileName);
        //        responseMsg.ExceptionCode = "02";
        //        responseMsg.ExceptionMessage = "对账单未保存失败";
        //    }
        //    responseMsg.BusinessTime = BasicFunctionClient.Current.CurrentTimeServer();
        //    responseMsg.SerialNo = BasicFunctionClient.Current.GetSerialNo();
        //    return responseMsg;
        //}

        /*
交易代码	BusinessCode
交易时间	BusinessTime
交易流水号	SerialNo
银行代码	FormerNo
协议编号	PactNo
文件名	FileName
文件大小	FileSize
        */

        public override BaseMessageResponse GetReponseMessage()
        {
            throw new NotImplementedException();
        }

        public override BaseMessageResponse MeaasgeOperate()
        {
            throw new NotImplementedException();
        }
    }
}
