using System;
using System.Collections.Generic;
using System.Text;
using FundsRegulatoryClient.RegulatorySrv;
using System.Data;

namespace FundsRegulatoryClient
{
    public class RegulatoryClient
    {
        private static RegulatoryClient _CurrentInstance = null;
        private RegulatorySrv.RegulatorySrv resrv;

        private RegulatoryClient()
        {
            resrv = new FundsRegulatoryClient.RegulatorySrv.RegulatorySrv();
            Common.CommonFunction.SetBaseWebReference(resrv);
        }


        public static RegulatoryClient Current
        {
            get
            {
                if (_CurrentInstance == null)
                {
                    _CurrentInstance = new RegulatoryClient();
                }
                return _CurrentInstance; 
            }
        }

        /// <summary>
        /// 支付请求 010
        /// </summary>
        /// <returns></returns>
        public bool PaymentRequest(JG_PaymentInfo JG_PaymentInfo)
        {
            return resrv.PaymentRequest(JG_PaymentInfo);
        }
        /// <summary>
        /// 协议确认保存
        /// </summary>
        /// <param name="jG_SpvProtocol"></param>
        /// <returns></returns>
        public bool ProtocolSave(JG_SpvProtocol jG_SpvProtocol)
        {
            return resrv.ProtocolSave(jG_SpvProtocol);
        }

        /// <summary>
        /// 插入报文信息
        /// </summary>
        /// <param name="mi"></param>
        /// <returns></returns>
        public bool AddJG_MessageInfo(JG_MessageInfo mi)
        {
            return resrv.AddJG_MessageInfo(mi);
        }

        /// <summary>
        /// 账户变更
        /// </summary>
        /// <param name="mi"></param>
        /// <returns></returns>
        public bool ChangeProtocol(JG_SpvProtocol JG_SpvProtocol)
        {
            return resrv.ChangeProtocol(JG_SpvProtocol);
        }


        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="mi"></param>
        /// <returns></returns>
        public DataSet DoSqlRetrun(string sqlStr,string UserCode,string UserPwd)
        {
            return resrv.DoSqlRetrun(sqlStr, UserCode, UserPwd);
        }
    }
}
