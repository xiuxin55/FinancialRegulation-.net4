using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services.Protocols;

namespace FundsRegulatoryClient
{
    /// <summary>
    /// 客户端基类 
    /// 在泛型中添加Web服务的类型 然后使用基类的的 service 对象访问Web服务
    /// </summary>
    /// <typeparam name="T">Web服务类型</typeparam>
    public abstract class BaseClient<T> where T : new()
    {
        /// <summary>
        /// 设置所有Web服务指向同一个地址
        /// </summary>
        /// <param name="objservice">Web服务对象</param>
        private void SetBaseWebReference(object objservice)
        {
            //string baseUrl = "http://localhost:1818/FundsRegulatorySrv";
            //objservice.Url = baseUrl + objservice.Url.Substring(objservice.Url.LastIndexOf('/'));
            Common.Logger lg = new Common.Logger();
            //   lg.LogWrite(Common.Logger.LogLevel.Debug, "", objservice.Url.ToString());
            Common.CommonFunction.SetBaseWebReference(service);
            //    lg.LogWrite(Common.Logger.LogLevel.Debug, "", objservice.Url.ToString());
        }
        /// <summary>
        /// 服务对象
        /// </summary>
        protected T service;
        /// <summary>
        /// 构造方法
        /// </summary>
        protected BaseClient()
        {
            service = new T();
            SetBaseWebReference(service);
        }
    }
}
