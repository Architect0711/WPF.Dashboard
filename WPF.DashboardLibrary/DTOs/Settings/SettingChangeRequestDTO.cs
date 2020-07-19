using System.Runtime.Serialization;

namespace WPF.DashboardLibrary.DTOs.Settings
{
    [DataContract]
    public class SettingChangeRequestDTO
    {
        [DataMember]
        public string UserId { get; private set; }

        [DataMember]
        public SettingDTO SettingToChange { get; private set; }

        public SettingChangeRequestDTO(string userId, SettingDTO settingToChange)
        {
            UserId = userId;
            SettingToChange = settingToChange;
        }
    }
}
