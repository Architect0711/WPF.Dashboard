﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF.DashboardStarter.DashboardService {
    using System;
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.FlagsAttribute()]
    [System.Runtime.Serialization.DataContractAttribute(Name="DateTimeFormatFlags", Namespace="http://schemas.datacontract.org/2004/07/System.Globalization")]
    public enum DateTimeFormatFlags : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        None = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UseGenitiveMonth = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UseLeapYearMonth = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UseSpacesInMonthNames = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UseHebrewRule = 8,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UseSpacesInDayNames = 16,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UseDigitPrefixInTokens = 32,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NotInitialized = -1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DashboardService.IDashboardService", CallbackContract=typeof(WPF.DashboardStarter.DashboardService.IDashboardServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IDashboardService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDashboardStarterService/Connect", ReplyAction="http://tempuri.org/IDashboardStarterService/ConnectResponse")]
        bool Connect();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDashboardStarterService/Connect", ReplyAction="http://tempuri.org/IDashboardStarterService/ConnectResponse")]
        System.Threading.Tasks.Task<bool> ConnectAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/IDashboardStarterService/Disconnect", ReplyAction="http://tempuri.org/IDashboardStarterService/DisconnectResponse")]
        bool Disconnect();
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/IDashboardStarterService/Disconnect", ReplyAction="http://tempuri.org/IDashboardStarterService/DisconnectResponse")]
        System.Threading.Tasks.Task<bool> DisconnectAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDashboardStarterService/Login", ReplyAction="http://tempuri.org/IDashboardStarterService/LoginResponse")]
        bool Login(string userId, System.Security.SecureString password, System.Globalization.CultureInfo cultureInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDashboardStarterService/Login", ReplyAction="http://tempuri.org/IDashboardStarterService/LoginResponse")]
        System.Threading.Tasks.Task<bool> LoginAsync(string userId, System.Security.SecureString password, System.Globalization.CultureInfo cultureInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDashboardStarterService/Logout", ReplyAction="http://tempuri.org/IDashboardStarterService/LogoutResponse")]
        bool Logout(string userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDashboardStarterService/Logout", ReplyAction="http://tempuri.org/IDashboardStarterService/LogoutResponse")]
        System.Threading.Tasks.Task<bool> LogoutAsync(string userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDashboardStarterService/GetAvailableSettings", ReplyAction="http://tempuri.org/IDashboardStarterService/GetAvailableSettingsResponse")]
        WPF.DashboardLibrary.DTOs.Settings.SettingDTO[] GetAvailableSettings(string UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDashboardStarterService/GetAvailableSettings", ReplyAction="http://tempuri.org/IDashboardStarterService/GetAvailableSettingsResponse")]
        System.Threading.Tasks.Task<WPF.DashboardLibrary.DTOs.Settings.SettingDTO[]> GetAvailableSettingsAsync(string UserId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDashboardStarterService/RequestSettingChange")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WPF.DashboardLibrary.DTOs.Settings.IntegerSettingDTO))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WPF.DashboardLibrary.DTOs.Settings.BooleanSettingDTO))]
        void RequestSettingChange(WPF.DashboardLibrary.DTOs.Settings.SettingChangeRequestDTO settingChangeRequest, string UserId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDashboardStarterService/RequestSettingChange")]
        System.Threading.Tasks.Task RequestSettingChangeAsync(WPF.DashboardLibrary.DTOs.Settings.SettingChangeRequestDTO settingChangeRequest, string UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDashboardStarterService/GetAvailableStatusInfo", ReplyAction="http://tempuri.org/IDashboardStarterService/GetAvailableStatusInfoResponse")]
        WPF.DashboardLibrary.DTOs.Status.StatusDTO[] GetAvailableStatusInfo(string UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDashboardStarterService/GetAvailableStatusInfo", ReplyAction="http://tempuri.org/IDashboardStarterService/GetAvailableStatusInfoResponse")]
        System.Threading.Tasks.Task<WPF.DashboardLibrary.DTOs.Status.StatusDTO[]> GetAvailableStatusInfoAsync(string UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDashboardService/GetAvailableTests", ReplyAction="http://tempuri.org/IDashboardService/GetAvailableTestsResponse")]
        WPF.DashboardImpl.DTOs.Tests.TestDTO[] GetAvailableTests(string UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDashboardService/GetAvailableTests", ReplyAction="http://tempuri.org/IDashboardService/GetAvailableTestsResponse")]
        System.Threading.Tasks.Task<WPF.DashboardImpl.DTOs.Tests.TestDTO[]> GetAvailableTestsAsync(string UserId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDashboardService/RequestTest")]
        void RequestTest(WPF.DashboardImpl.DTOs.Tests.TestRequestDTO test, string UserId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDashboardService/RequestTest")]
        System.Threading.Tasks.Task RequestTestAsync(WPF.DashboardImpl.DTOs.Tests.TestRequestDTO test, string UserId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDashboardServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDashboardStarterService/SendMessage")]
        void SendMessage(WPF.DashboardLibrary.DTOs.Messages.MessageDTO message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDashboardStarterService/SettingChanged")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WPF.DashboardLibrary.DTOs.Settings.IntegerSettingDTO))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WPF.DashboardLibrary.DTOs.Settings.BooleanSettingDTO))]
        void SettingChanged(WPF.DashboardLibrary.DTOs.Settings.SettingChangeResponseDTO settingChangeResponse);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDashboardStarterService/StatusChanged")]
        void StatusChanged(WPF.DashboardLibrary.DTOs.Status.StatusDTO status);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDashboardStarterService/StatusesChanged")]
        void StatusesChanged(WPF.DashboardLibrary.DTOs.Status.StatusDTO[] status);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDashboardService/TestResult")]
        void TestResult(WPF.DashboardImpl.DTOs.Tests.TestResultDTO result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDashboardServiceChannel : WPF.DashboardStarter.DashboardService.IDashboardService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DashboardServiceClient : System.ServiceModel.DuplexClientBase<WPF.DashboardStarter.DashboardService.IDashboardService>, WPF.DashboardStarter.DashboardService.IDashboardService {
        
        public DashboardServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public DashboardServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public DashboardServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public DashboardServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public DashboardServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public bool Connect() {
            return base.Channel.Connect();
        }
        
        public System.Threading.Tasks.Task<bool> ConnectAsync() {
            return base.Channel.ConnectAsync();
        }
        
        public bool Disconnect() {
            return base.Channel.Disconnect();
        }
        
        public System.Threading.Tasks.Task<bool> DisconnectAsync() {
            return base.Channel.DisconnectAsync();
        }
        
        public bool Login(string userId, System.Security.SecureString password, System.Globalization.CultureInfo cultureInfo) {
            return base.Channel.Login(userId, password, cultureInfo);
        }
        
        public System.Threading.Tasks.Task<bool> LoginAsync(string userId, System.Security.SecureString password, System.Globalization.CultureInfo cultureInfo) {
            return base.Channel.LoginAsync(userId, password, cultureInfo);
        }
        
        public bool Logout(string userId) {
            return base.Channel.Logout(userId);
        }
        
        public System.Threading.Tasks.Task<bool> LogoutAsync(string userId) {
            return base.Channel.LogoutAsync(userId);
        }
        
        public WPF.DashboardLibrary.DTOs.Settings.SettingDTO[] GetAvailableSettings(string UserId) {
            return base.Channel.GetAvailableSettings(UserId);
        }
        
        public System.Threading.Tasks.Task<WPF.DashboardLibrary.DTOs.Settings.SettingDTO[]> GetAvailableSettingsAsync(string UserId) {
            return base.Channel.GetAvailableSettingsAsync(UserId);
        }
        
        public void RequestSettingChange(WPF.DashboardLibrary.DTOs.Settings.SettingChangeRequestDTO settingChangeRequest, string UserId) {
            base.Channel.RequestSettingChange(settingChangeRequest, UserId);
        }
        
        public System.Threading.Tasks.Task RequestSettingChangeAsync(WPF.DashboardLibrary.DTOs.Settings.SettingChangeRequestDTO settingChangeRequest, string UserId) {
            return base.Channel.RequestSettingChangeAsync(settingChangeRequest, UserId);
        }
        
        public WPF.DashboardLibrary.DTOs.Status.StatusDTO[] GetAvailableStatusInfo(string UserId) {
            return base.Channel.GetAvailableStatusInfo(UserId);
        }
        
        public System.Threading.Tasks.Task<WPF.DashboardLibrary.DTOs.Status.StatusDTO[]> GetAvailableStatusInfoAsync(string UserId) {
            return base.Channel.GetAvailableStatusInfoAsync(UserId);
        }
        
        public WPF.DashboardImpl.DTOs.Tests.TestDTO[] GetAvailableTests(string UserId) {
            return base.Channel.GetAvailableTests(UserId);
        }
        
        public System.Threading.Tasks.Task<WPF.DashboardImpl.DTOs.Tests.TestDTO[]> GetAvailableTestsAsync(string UserId) {
            return base.Channel.GetAvailableTestsAsync(UserId);
        }
        
        public void RequestTest(WPF.DashboardImpl.DTOs.Tests.TestRequestDTO test, string UserId) {
            base.Channel.RequestTest(test, UserId);
        }
        
        public System.Threading.Tasks.Task RequestTestAsync(WPF.DashboardImpl.DTOs.Tests.TestRequestDTO test, string UserId) {
            return base.Channel.RequestTestAsync(test, UserId);
        }
    }
}
