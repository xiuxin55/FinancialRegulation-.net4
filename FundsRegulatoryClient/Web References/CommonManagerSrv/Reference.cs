﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.42000 版自动生成。
// 
#pragma warning disable 1591

namespace FundsRegulatoryClient.CommonManagerSrv {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="CommonManagerSrvSoap", Namespace="http://tempuri.org/")]
    public partial class CommonManagerSrv : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetItemsBySetCodeOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetSerialNoOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetListNumberOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetBusiCodeOperationCompleted;
        
        private System.Threading.SendOrPostCallback ViewBusiCodeOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetSysParaValueOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public CommonManagerSrv() {
            this.Url = global::FundsRegulatoryClient.Properties.Settings.Default.HSIS_Client_CommonManagerSrv_CommonManagerSrv;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetItemsBySetCodeCompletedEventHandler GetItemsBySetCodeCompleted;
        
        /// <remarks/>
        public event GetSerialNoCompletedEventHandler GetSerialNoCompleted;
        
        /// <remarks/>
        public event GetListNumberCompletedEventHandler GetListNumberCompleted;
        
        /// <remarks/>
        public event GetBusiCodeCompletedEventHandler GetBusiCodeCompleted;
        
        /// <remarks/>
        public event ViewBusiCodeCompletedEventHandler ViewBusiCodeCompleted;
        
        /// <remarks/>
        public event GetSysParaValueCompletedEventHandler GetSysParaValueCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetItemsBySetCode", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetItemsBySetCode(string[] SetCode) {
            object[] results = this.Invoke("GetItemsBySetCode", new object[] {
                        SetCode});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetItemsBySetCodeAsync(string[] SetCode) {
            this.GetItemsBySetCodeAsync(SetCode, null);
        }
        
        /// <remarks/>
        public void GetItemsBySetCodeAsync(string[] SetCode, object userState) {
            if ((this.GetItemsBySetCodeOperationCompleted == null)) {
                this.GetItemsBySetCodeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetItemsBySetCodeOperationCompleted);
            }
            this.InvokeAsync("GetItemsBySetCode", new object[] {
                        SetCode}, this.GetItemsBySetCodeOperationCompleted, userState);
        }
        
        private void OnGetItemsBySetCodeOperationCompleted(object arg) {
            if ((this.GetItemsBySetCodeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetItemsBySetCodeCompleted(this, new GetItemsBySetCodeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetSerialNo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetSerialNo() {
            object[] results = this.Invoke("GetSerialNo", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetSerialNoAsync() {
            this.GetSerialNoAsync(null);
        }
        
        /// <remarks/>
        public void GetSerialNoAsync(object userState) {
            if ((this.GetSerialNoOperationCompleted == null)) {
                this.GetSerialNoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSerialNoOperationCompleted);
            }
            this.InvokeAsync("GetSerialNo", new object[0], this.GetSerialNoOperationCompleted, userState);
        }
        
        private void OnGetSerialNoOperationCompleted(object arg) {
            if ((this.GetSerialNoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSerialNoCompleted(this, new GetSerialNoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetListNumber", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetListNumber() {
            object[] results = this.Invoke("GetListNumber", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetListNumberAsync() {
            this.GetListNumberAsync(null);
        }
        
        /// <remarks/>
        public void GetListNumberAsync(object userState) {
            if ((this.GetListNumberOperationCompleted == null)) {
                this.GetListNumberOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetListNumberOperationCompleted);
            }
            this.InvokeAsync("GetListNumber", new object[0], this.GetListNumberOperationCompleted, userState);
        }
        
        private void OnGetListNumberOperationCompleted(object arg) {
            if ((this.GetListNumberCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetListNumberCompleted(this, new GetListNumberCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetBusiCode", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetBusiCode() {
            object[] results = this.Invoke("GetBusiCode", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetBusiCodeAsync() {
            this.GetBusiCodeAsync(null);
        }
        
        /// <remarks/>
        public void GetBusiCodeAsync(object userState) {
            if ((this.GetBusiCodeOperationCompleted == null)) {
                this.GetBusiCodeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBusiCodeOperationCompleted);
            }
            this.InvokeAsync("GetBusiCode", new object[0], this.GetBusiCodeOperationCompleted, userState);
        }
        
        private void OnGetBusiCodeOperationCompleted(object arg) {
            if ((this.GetBusiCodeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetBusiCodeCompleted(this, new GetBusiCodeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ViewBusiCode", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ViewBusiCode() {
            object[] results = this.Invoke("ViewBusiCode", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ViewBusiCodeAsync() {
            this.ViewBusiCodeAsync(null);
        }
        
        /// <remarks/>
        public void ViewBusiCodeAsync(object userState) {
            if ((this.ViewBusiCodeOperationCompleted == null)) {
                this.ViewBusiCodeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnViewBusiCodeOperationCompleted);
            }
            this.InvokeAsync("ViewBusiCode", new object[0], this.ViewBusiCodeOperationCompleted, userState);
        }
        
        private void OnViewBusiCodeOperationCompleted(object arg) {
            if ((this.ViewBusiCodeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ViewBusiCodeCompleted(this, new ViewBusiCodeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetSysParaValue", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetSysParaValue(string ParmCode) {
            object[] results = this.Invoke("GetSysParaValue", new object[] {
                        ParmCode});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetSysParaValueAsync(string ParmCode) {
            this.GetSysParaValueAsync(ParmCode, null);
        }
        
        /// <remarks/>
        public void GetSysParaValueAsync(string ParmCode, object userState) {
            if ((this.GetSysParaValueOperationCompleted == null)) {
                this.GetSysParaValueOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSysParaValueOperationCompleted);
            }
            this.InvokeAsync("GetSysParaValue", new object[] {
                        ParmCode}, this.GetSysParaValueOperationCompleted, userState);
        }
        
        private void OnGetSysParaValueOperationCompleted(object arg) {
            if ((this.GetSysParaValueCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSysParaValueCompleted(this, new GetSysParaValueCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void GetItemsBySetCodeCompletedEventHandler(object sender, GetItemsBySetCodeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetItemsBySetCodeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetItemsBySetCodeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void GetSerialNoCompletedEventHandler(object sender, GetSerialNoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetSerialNoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetSerialNoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void GetListNumberCompletedEventHandler(object sender, GetListNumberCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetListNumberCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetListNumberCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void GetBusiCodeCompletedEventHandler(object sender, GetBusiCodeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetBusiCodeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetBusiCodeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void ViewBusiCodeCompletedEventHandler(object sender, ViewBusiCodeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ViewBusiCodeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ViewBusiCodeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void GetSysParaValueCompletedEventHandler(object sender, GetSysParaValueCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetSysParaValueCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetSysParaValueCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591