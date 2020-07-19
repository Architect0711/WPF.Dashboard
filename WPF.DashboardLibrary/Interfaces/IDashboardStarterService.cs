using System.Collections.Generic;
using System.Globalization;
using System.Security;
using System.ServiceModel;
using WPF.DashboardLibrary.DTOs.Settings;
using WPF.DashboardLibrary.DTOs.Status;

namespace WPF.DashboardLibrary.Interfaces
{
    /// <summary>
    /// This Interface defines the Starter Functions of the DashboardService and is not to be changed by the Implementor
    /// </summary>
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IDashboardStarterServiceCallback))]
    public interface IDashboardStarterService
    {
        #region Connect/Disconnect
        [OperationContract(IsOneWay = false, IsInitiating = true, IsTerminating = false)]
        bool Connect();

        [OperationContract(IsOneWay = false, IsInitiating = false, IsTerminating = true)]
        bool Disconnect();
        #endregion

        #region Login/Logout
        [OperationContract(IsOneWay = false)]
        bool Login(string userId, SecureString password, CultureInfo cultureInfo);

        [OperationContract(IsOneWay = false)]
        bool Logout(string userId);
        #endregion

        #region Settings
        /// <summary>
        /// Provide the Dashboard with a List of Settings the User can change on the System
        /// </summary>
        /// <param name="UserId">The logged in User, to check if they have Permission to see the Setting</param>
        /// <returns></returns>
        [OperationContract(IsOneWay = false)]
        List<SettingDTO> GetAvailableSettings(string UserId);

        /// <summary>
        /// Let the User change Settings of the System
        /// </summary>
        /// <param name="settingChangeRequest">Setting to change</param>
        /// <param name="UserId">The logged in User, to check if they have Permission to change the Setting</param>
        [OperationContract(IsOneWay = true)]
        void RequestSettingChange(SettingChangeRequestDTO settingChangeRequest, string UserId);
        #endregion

        #region Status
        /// <summary>
        /// Provide the Dashboard with Status Information about the System
        /// </summary>
        /// <param name="UserId">The logged in User, to check if they have Permission to see the Status</param>
        /// <returns>The Status Information the User can see</returns>
        [OperationContract(IsOneWay = false)]
        List<StatusDTO> GetAvailableStatusInfo(string UserId);
        #endregion
    }
}
