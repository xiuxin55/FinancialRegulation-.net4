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

namespace FundsRegulatoryClient.JG_AdjustSrv {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="JG_AdjustServiceSoap", Namespace="http://tempuri.org/")]
    public partial class JG_AdjustService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback AddOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateJG_AdjustByCklshOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteOperationCompleted;
        
        private System.Threading.SendOrPostCallback SelectsOperationCompleted;
        
        private System.Threading.SendOrPostCallback SelectOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetJG_AdjustOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public JG_AdjustService() {
            this.Url = global::FundsRegulatoryClient.Properties.Settings.Default.FinancialRegulationClient_JG_AdjustSrv_JG_AdjustService;
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
        public event UpdateJG_AdjustByCklshCompletedEventHandler UpdateJG_AdjustByCklshCompleted;
        
        /// <remarks/>
        public event DeleteCompletedEventHandler DeleteCompleted;
        
        /// <remarks/>
        public event SelectsCompletedEventHandler SelectsCompleted;
        
        /// <remarks/>
        public event SelectCompletedEventHandler SelectCompleted;
        
        /// <remarks/>
        public event GetJG_AdjustCompletedEventHandler GetJG_AdjustCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Add(JG_AdjustInfo o) {
            object[] results = this.Invoke("Add", new object[] {
                        o});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void AddAsync(JG_AdjustInfo o) {
            this.AddAsync(o, null);
        }
        
        /// <remarks/>
        public void AddAsync(JG_AdjustInfo o, object userState) {
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
        public bool Update(JG_AdjustInfo o) {
            object[] results = this.Invoke("Update", new object[] {
                        o});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateAsync(JG_AdjustInfo o) {
            this.UpdateAsync(o, null);
        }
        
        /// <remarks/>
        public void UpdateAsync(JG_AdjustInfo o, object userState) {
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
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UpdateJG_AdjustByCklsh", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool UpdateJG_AdjustByCklsh(JG_AdjustInfo o) {
            object[] results = this.Invoke("UpdateJG_AdjustByCklsh", new object[] {
                        o});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateJG_AdjustByCklshAsync(JG_AdjustInfo o) {
            this.UpdateJG_AdjustByCklshAsync(o, null);
        }
        
        /// <remarks/>
        public void UpdateJG_AdjustByCklshAsync(JG_AdjustInfo o, object userState) {
            if ((this.UpdateJG_AdjustByCklshOperationCompleted == null)) {
                this.UpdateJG_AdjustByCklshOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateJG_AdjustByCklshOperationCompleted);
            }
            this.InvokeAsync("UpdateJG_AdjustByCklsh", new object[] {
                        o}, this.UpdateJG_AdjustByCklshOperationCompleted, userState);
        }
        
        private void OnUpdateJG_AdjustByCklshOperationCompleted(object arg) {
            if ((this.UpdateJG_AdjustByCklshCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateJG_AdjustByCklshCompleted(this, new UpdateJG_AdjustByCklshCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Delete", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Delete(JG_AdjustInfo o) {
            object[] results = this.Invoke("Delete", new object[] {
                        o});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void DeleteAsync(JG_AdjustInfo o) {
            this.DeleteAsync(o, null);
        }
        
        /// <remarks/>
        public void DeleteAsync(JG_AdjustInfo o, object userState) {
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
        public JG_AdjustInfo[] Selects() {
            object[] results = this.Invoke("Selects", new object[0]);
            return ((JG_AdjustInfo[])(results[0]));
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
        public JG_AdjustInfo[] Select(JG_AdjustInfo o) {
            object[] results = this.Invoke("Select", new object[] {
                        o});
            return ((JG_AdjustInfo[])(results[0]));
        }
        
        /// <remarks/>
        public void SelectAsync(JG_AdjustInfo o) {
            this.SelectAsync(o, null);
        }
        
        /// <remarks/>
        public void SelectAsync(JG_AdjustInfo o, object userState) {
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
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetJG_Adjust", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GetJG_Adjust(int ProcessState) {
            object[] results = this.Invoke("GetJG_Adjust", new object[] {
                        ProcessState});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void GetJG_AdjustAsync(int ProcessState) {
            this.GetJG_AdjustAsync(ProcessState, null);
        }
        
        /// <remarks/>
        public void GetJG_AdjustAsync(int ProcessState, object userState) {
            if ((this.GetJG_AdjustOperationCompleted == null)) {
                this.GetJG_AdjustOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetJG_AdjustOperationCompleted);
            }
            this.InvokeAsync("GetJG_Adjust", new object[] {
                        ProcessState}, this.GetJG_AdjustOperationCompleted, userState);
        }
        
        private void OnGetJG_AdjustOperationCompleted(object arg) {
            if ((this.GetJG_AdjustCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetJG_AdjustCompleted(this, new GetJG_AdjustCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public partial class JG_AdjustInfo {
        
        private string jA_IDField;
        
        private string jA_FmIDField;
        
        private string jA_XybhField;
        
        private string jA_FmXybhField;
        
        private System.Nullable<System.DateTime> jA_SqTimeField;
        
        private System.Nullable<System.DateTime> jA_QrTimeField;
        
        private string jA_QrrField;
        
        private string jA_LCField;
        
        private string jA_TzzflshField;
        
        private string jA_FmCklshField;
        
        /// <remarks/>
        public string JA_ID {
            get {
                return this.jA_IDField;
            }
            set {
                this.jA_IDField = value;
            }
        }
        
        /// <remarks/>
        public string JA_FmID {
            get {
                return this.jA_FmIDField;
            }
            set {
                this.jA_FmIDField = value;
            }
        }
        
        /// <remarks/>
        public string JA_Xybh {
            get {
                return this.jA_XybhField;
            }
            set {
                this.jA_XybhField = value;
            }
        }
        
        /// <remarks/>
        public string JA_FmXybh {
            get {
                return this.jA_FmXybhField;
            }
            set {
                this.jA_FmXybhField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> JA_SqTime {
            get {
                return this.jA_SqTimeField;
            }
            set {
                this.jA_SqTimeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> JA_QrTime {
            get {
                return this.jA_QrTimeField;
            }
            set {
                this.jA_QrTimeField = value;
            }
        }
        
        /// <remarks/>
        public string JA_Qrr {
            get {
                return this.jA_QrrField;
            }
            set {
                this.jA_QrrField = value;
            }
        }
        
        /// <remarks/>
        public string JA_LC {
            get {
                return this.jA_LCField;
            }
            set {
                this.jA_LCField = value;
            }
        }
        
        /// <remarks/>
        public string JA_Tzzflsh {
            get {
                return this.jA_TzzflshField;
            }
            set {
                this.jA_TzzflshField = value;
            }
        }
        
        /// <remarks/>
        public string JA_FmCklsh {
            get {
                return this.jA_FmCklshField;
            }
            set {
                this.jA_FmCklshField = value;
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
    public delegate void UpdateJG_AdjustByCklshCompletedEventHandler(object sender, UpdateJG_AdjustByCklshCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateJG_AdjustByCklshCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateJG_AdjustByCklshCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
        public JG_AdjustInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((JG_AdjustInfo[])(this.results[0]));
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
        public JG_AdjustInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((JG_AdjustInfo[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void GetJG_AdjustCompletedEventHandler(object sender, GetJG_AdjustCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetJG_AdjustCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetJG_AdjustCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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