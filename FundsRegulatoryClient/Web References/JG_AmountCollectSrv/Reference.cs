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

namespace FundsRegulatoryClient.JG_AmountCollectSrv {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="JG_AmountCollectServiceSoap", Namespace="http://tempuri.org/")]
    public partial class JG_AmountCollectService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback AddOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteOperationCompleted;
        
        private System.Threading.SendOrPostCallback SelectsOperationCompleted;
        
        private System.Threading.SendOrPostCallback SelectOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetFundCollectsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public JG_AmountCollectService() {
            this.Url = global::FundsRegulatoryClient.Properties.Settings.Default.Client_JG_AmountCollectSrv_JG_AmountCollectService;
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
        public event AddCompletedEventHandler AddCompleted;
        
        /// <remarks/>
        public event UpdateCompletedEventHandler UpdateCompleted;
        
        /// <remarks/>
        public event DeleteCompletedEventHandler DeleteCompleted;
        
        /// <remarks/>
        public event SelectsCompletedEventHandler SelectsCompleted;
        
        /// <remarks/>
        public event SelectCompletedEventHandler SelectCompleted;
        
        /// <remarks/>
        public event GetFundCollectsCompletedEventHandler GetFundCollectsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Add(JG_AmountCollectInfo o) {
            object[] results = this.Invoke("Add", new object[] {
                        o});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void AddAsync(JG_AmountCollectInfo o) {
            this.AddAsync(o, null);
        }
        
        /// <remarks/>
        public void AddAsync(JG_AmountCollectInfo o, object userState) {
            if ((this.AddOperationCompleted == null)) {
                this.AddOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddOperationCompleted);
            }
            this.InvokeAsync("Add", new object[] {
                        o}, this.AddOperationCompleted, userState);
        }
        
        private void OnAddOperationCompleted(object arg) {
            if ((this.AddCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddCompleted(this, new AddCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Update", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Update(JG_AmountCollectInfo o) {
            object[] results = this.Invoke("Update", new object[] {
                        o});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateAsync(JG_AmountCollectInfo o) {
            this.UpdateAsync(o, null);
        }
        
        /// <remarks/>
        public void UpdateAsync(JG_AmountCollectInfo o, object userState) {
            if ((this.UpdateOperationCompleted == null)) {
                this.UpdateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateOperationCompleted);
            }
            this.InvokeAsync("Update", new object[] {
                        o}, this.UpdateOperationCompleted, userState);
        }
        
        private void OnUpdateOperationCompleted(object arg) {
            if ((this.UpdateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateCompleted(this, new UpdateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Delete", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Delete(JG_AmountCollectInfo o) {
            object[] results = this.Invoke("Delete", new object[] {
                        o});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void DeleteAsync(JG_AmountCollectInfo o) {
            this.DeleteAsync(o, null);
        }
        
        /// <remarks/>
        public void DeleteAsync(JG_AmountCollectInfo o, object userState) {
            if ((this.DeleteOperationCompleted == null)) {
                this.DeleteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteOperationCompleted);
            }
            this.InvokeAsync("Delete", new object[] {
                        o}, this.DeleteOperationCompleted, userState);
        }
        
        private void OnDeleteOperationCompleted(object arg) {
            if ((this.DeleteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteCompleted(this, new DeleteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Selects", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public JG_AmountCollectInfo[] Selects() {
            object[] results = this.Invoke("Selects", new object[0]);
            return ((JG_AmountCollectInfo[])(results[0]));
        }
        
        /// <remarks/>
        public void SelectsAsync() {
            this.SelectsAsync(null);
        }
        
        /// <remarks/>
        public void SelectsAsync(object userState) {
            if ((this.SelectsOperationCompleted == null)) {
                this.SelectsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSelectsOperationCompleted);
            }
            this.InvokeAsync("Selects", new object[0], this.SelectsOperationCompleted, userState);
        }
        
        private void OnSelectsOperationCompleted(object arg) {
            if ((this.SelectsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SelectsCompleted(this, new SelectsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Select", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public JG_AmountCollectInfo[] Select(JG_AmountCollectInfo o) {
            object[] results = this.Invoke("Select", new object[] {
                        o});
            return ((JG_AmountCollectInfo[])(results[0]));
        }
        
        /// <remarks/>
        public void SelectAsync(JG_AmountCollectInfo o) {
            this.SelectAsync(o, null);
        }
        
        /// <remarks/>
        public void SelectAsync(JG_AmountCollectInfo o, object userState) {
            if ((this.SelectOperationCompleted == null)) {
                this.SelectOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSelectOperationCompleted);
            }
            this.InvokeAsync("Select", new object[] {
                        o}, this.SelectOperationCompleted, userState);
        }
        
        private void OnSelectOperationCompleted(object arg) {
            if ((this.SelectCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SelectCompleted(this, new SelectCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetFundCollects", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GetFundCollects() {
            object[] results = this.Invoke("GetFundCollects", new object[0]);
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void GetFundCollectsAsync() {
            this.GetFundCollectsAsync(null);
        }
        
        /// <remarks/>
        public void GetFundCollectsAsync(object userState) {
            if ((this.GetFundCollectsOperationCompleted == null)) {
                this.GetFundCollectsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetFundCollectsOperationCompleted);
            }
            this.InvokeAsync("GetFundCollects", new object[0], this.GetFundCollectsOperationCompleted, userState);
        }
        
        private void OnGetFundCollectsOperationCompleted(object arg) {
            if ((this.GetFundCollectsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetFundCollectsCompleted(this, new GetFundCollectsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public partial class JG_AmountCollectInfo {
        
        private string aC_IDField;
        
        private string aC_xybhField;
        
        private string aC_cklshField;
        
        private string aC_skfzhField;
        
        private string aC_fkfzhField;
        
        private string aC_yhmcField;
        
        private decimal aC_ckjeField;
        
        private System.DateTime aC_cksjField;
        
        private decimal aC_fkfyeField;
        
        private decimal aC_skfyeField;
        
        private string aC_BankCodeField;
        
        /// <remarks/>
        public string AC_ID {
            get {
                return this.aC_IDField;
            }
            set {
                this.aC_IDField = value;
            }
        }
        
        /// <remarks/>
        public string AC_xybh {
            get {
                return this.aC_xybhField;
            }
            set {
                this.aC_xybhField = value;
            }
        }
        
        /// <remarks/>
        public string AC_cklsh {
            get {
                return this.aC_cklshField;
            }
            set {
                this.aC_cklshField = value;
            }
        }
        
        /// <remarks/>
        public string AC_skfzh {
            get {
                return this.aC_skfzhField;
            }
            set {
                this.aC_skfzhField = value;
            }
        }
        
        /// <remarks/>
        public string AC_fkfzh {
            get {
                return this.aC_fkfzhField;
            }
            set {
                this.aC_fkfzhField = value;
            }
        }
        
        /// <remarks/>
        public string AC_yhmc {
            get {
                return this.aC_yhmcField;
            }
            set {
                this.aC_yhmcField = value;
            }
        }
        
        /// <remarks/>
        public decimal AC_ckje {
            get {
                return this.aC_ckjeField;
            }
            set {
                this.aC_ckjeField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime AC_cksj {
            get {
                return this.aC_cksjField;
            }
            set {
                this.aC_cksjField = value;
            }
        }
        
        /// <remarks/>
        public decimal AC_fkfye {
            get {
                return this.aC_fkfyeField;
            }
            set {
                this.aC_fkfyeField = value;
            }
        }
        
        /// <remarks/>
        public decimal AC_skfye {
            get {
                return this.aC_skfyeField;
            }
            set {
                this.aC_skfyeField = value;
            }
        }
        
        /// <remarks/>
        public string AC_BankCode {
            get {
                return this.aC_BankCodeField;
            }
            set {
                this.aC_BankCodeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void AddCompletedEventHandler(object sender, AddCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AddCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AddCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void UpdateCompletedEventHandler(object sender, UpdateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void DeleteCompletedEventHandler(object sender, DeleteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DeleteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DeleteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void SelectsCompletedEventHandler(object sender, SelectsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SelectsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SelectsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public JG_AmountCollectInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((JG_AmountCollectInfo[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void SelectCompletedEventHandler(object sender, SelectCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SelectCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SelectCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public JG_AmountCollectInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((JG_AmountCollectInfo[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void GetFundCollectsCompletedEventHandler(object sender, GetFundCollectsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetFundCollectsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetFundCollectsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591