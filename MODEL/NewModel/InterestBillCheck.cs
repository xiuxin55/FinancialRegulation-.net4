using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.NewModel
{
    public class InterestBillCheck
    {
       
        private string regulatoryAccount;
        /// <summary>
        /// 监管账号
        /// </summary>
        public string RegulatoryAccount
        {
            get { return regulatoryAccount; }
            set { regulatoryAccount = value; }
        }
        private decimal? tradeFundAmount;
        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal? TradeFundAmount
        {
            get { return tradeFundAmount; }
            set
            {
                tradeFundAmount = value;

            }
        }
        private DateTime? time;
        /// <summary>
        /// 到账日期
        /// </summary>
        public DateTime? Time
        {
            get { return time; }
            set { time = value; }
        }
        private string projectCode;
        /// <summary>
        /// 项目标识码
        /// </summary>
        public string ProjectCode
        {
            get { return projectCode; }
            set { projectCode = value; }
        }
        private string tradeObject;
        /// <summary>
        /// 交易对象
        /// </summary>
        public string TradeObject
        {
            get { return tradeObject; }
            set { tradeObject = value; }
        }
        private string tradeMark;
        /// <summary>
        /// 交易标识
        /// </summary>
        public string TradeMark
        {
            get { return tradeMark; }
            set { tradeMark = value; }
        }
        private string bankSerialNumber;
        /// <summary>
        /// 流水号
        /// </summary>
        public string BankSerialNumber
        {
            get { return bankSerialNumber; }
            set { bankSerialNumber = value; }
        }
        private string instruction;
        /// <summary>
        /// 补录说明
        /// </summary>
        public string Instruction
        {
            get { return instruction; }
            set { instruction = value; }
        }
    }
}
