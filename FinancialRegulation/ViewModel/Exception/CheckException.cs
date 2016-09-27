using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//此名称空间未 基础异常类
namespace FinancialRegulation.ClientException
{
    /// <summary>
    /// 输入检查异常类
    /// </summary>
    [Serializable]
    public class CheckException : Exception
    {
        public CheckException() { }
        public CheckException(string message) : base(message) { }
        public CheckException(string message, Exception inner) : base(message, inner) { }
        protected CheckException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
