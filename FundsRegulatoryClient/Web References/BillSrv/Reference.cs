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

namespace FundsRegulatoryClient.BillSrv {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BillSrvSoap", Namespace="http://tempuri.org/")]
    public partial class BillSrv : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetDevelopersBillOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetCorpBillOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public BillSrv() {
            this.Url = global::FundsRegulatoryClient.Properties.Settings.Default.Client_BillSrv_BillSrv;
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
        public event GetDevelopersBillCompletedEventHandler GetDevelopersBillCompleted;
        
        /// <remarks/>
        public event GetCorpBillCompletedEventHandler GetCorpBillCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetDevelopersBill", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Bill[] GetDevelopersBill(Bill bill) {
            object[] results = this.Invoke("GetDevelopersBill", new object[] {
                        bill});
            return ((Bill[])(results[0]));
        }
        
        /// <remarks/>
        public void GetDevelopersBillAsync(Bill bill) {
            this.GetDevelopersBillAsync(bill, null);
        }
        
        /// <remarks/>
        public void GetDevelopersBillAsync(Bill bill, object userState) {
            if ((this.GetDevelopersBillOperationCompleted == null)) {
                this.GetDevelopersBillOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDevelopersBillOperationCompleted);
            }
            this.InvokeAsync("GetDevelopersBill", new object[] {
                        bill}, this.GetDevelopersBillOperationCompleted, userState);
        }
        
        private void OnGetDevelopersBillOperationCompleted(object arg) {
            if ((this.GetDevelopersBillCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDevelopersBillCompleted(this, new GetDevelopersBillCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetCorpBill", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Bill[] GetCorpBill(Bill bill) {
            object[] results = this.Invoke("GetCorpBill", new object[] {
                        bill});
            return ((Bill[])(results[0]));
        }
        
        /// <remarks/>
        public void GetCorpBillAsync(Bill bill) {
            this.GetCorpBillAsync(bill, null);
        }
        
        /// <remarks/>
        public void GetCorpBillAsync(Bill bill, object userState) {
            if ((this.GetCorpBillOperationCompleted == null)) {
                this.GetCorpBillOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCorpBillOperationCompleted);
            }
            this.InvokeAsync("GetCorpBill", new object[] {
                        bill}, this.GetCorpBillOperationCompleted, userState);
        }
        
        private void OnGetCorpBillOperationCompleted(object arg) {
            if ((this.GetCorpBillCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCorpBillCompleted(this, new GetCorpBillCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Bill {
        
        private string protocolNoField;
        
        private string contractRecordNoField;
        
        private decimal moneyField;
        
        private string fundsNatureField;
        
        private System.DateTime dtimeField;
        
        private System.DateTime sDtimeField;
        
        private System.DateTime eDtimeField;
        
        /// <remarks/>
        public string ProtocolNo {
            get {
                return this.protocolNoField;
            }
            set {
                this.protocolNoField = value;
            }
        }
        
        /// <remarks/>
        public string ContractRecordNo {
            get {
                return this.contractRecordNoField;
            }
            set {
                this.contractRecordNoField = value;
            }
        }
        
        /// <remarks/>
        public decimal Money {
            get {
                return this.moneyField;
            }
            set {
                this.moneyField = value;
            }
        }
        
        /// <remarks/>
        public string FundsNature {
            get {
                return this.fundsNatureField;
            }
            set {
                this.fundsNatureField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime Dtime {
            get {
                return this.dtimeField;
            }
            set {
                this.dtimeField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime SDtime {
            get {
                return this.sDtimeField;
            }
            set {
                this.sDtimeField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime EDtime {
            get {
                return this.eDtimeField;
            }
            set {
                this.eDtimeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void GetDevelopersBillCompletedEventHandler(object sender, GetDevelopersBillCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDevelopersBillCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDevelopersBillCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Bill[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Bill[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void GetCorpBillCompletedEventHandler(object sender, GetCorpBillCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCorpBillCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCorpBillCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Bill[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Bill[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591