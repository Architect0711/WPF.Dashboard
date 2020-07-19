using System.Runtime.Serialization;

namespace WPF.DashboardLibrary.DTOs.Settings
{
    [DataContract]
    public class SettingChangeResponseDTO
    {
        [DataMember]
        public string UserId { get; private set; }

        [DataMember]
        public bool WasChanged { get; private set; }

        [DataMember]
        public string Info { get; private set; }

        [DataMember]
        public SettingDTO Setting { get; private set; }

        public SettingChangeResponseDTO(
            string userId, 
            bool wasChanged,
            string additionalInfo, 
            SettingDTO settingToChange)
        {
            UserId = userId;
            WasChanged = wasChanged;
            Info = additionalInfo;
            Setting = settingToChange;
        }
    }
}
