using System.Collections.Generic;
using System.ServiceModel;
using WPF.DashboardLibrary.DTOs.Messages;
using WPF.DashboardLibrary.DTOs.Settings;
using WPF.DashboardLibrary.DTOs.Status;

namespace WPF.DashboardLibrary.Interfaces
{
    /// <summary>
    /// This Interface defines the Starter Functions of the DashboardServiceCallback and is not to be changed by the Implementor
    /// </summary>
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IDashboardStarterServiceCallback
    {
        #region Messages
        /// <summary>
        /// Send a Message to the Message Log
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void SendMessage(MessageDTO message);
        #endregion

        #region Settings
        /// <summary>
        /// Notify the User that a Setting was changed. Either by them or by someone else.
        /// </summary>
        /// <param name="settingChangeResponse"></param>
        [OperationContract(IsOneWay = true)]
        void SettingChanged(SettingChangeResponseDTO settingChangeResponse);
        #endregion

        #region Status
        /// <summary>
        /// Notify the User that the System Status has changed.
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void StatusChanged(StatusDTO status);

        /// <summary>
        /// Notify the User that the System Status has changed.
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void StatusesChanged(List<StatusDTO> status);
        #endregion
    }
}
