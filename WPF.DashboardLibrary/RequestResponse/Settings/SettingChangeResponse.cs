using WPF.DashboardLibrary.DTOs.Settings;
using WPF.DashboardLibrary.Models.Settings;

namespace WPF.DashboardLibrary.RequestResponse.Settings
{
    public class SettingChangeResponse
    {
        public string UserId { get; private set; }

        public bool WasChanged { get; private set; }

        public string AdditionalInfo { get; private set; }

        public BaseSetting Setting { get; private set; }

        public SettingChangeResponse(
            string userId,
            bool wasChanged,
            string additionalInfo,
            BaseSetting setting)
        {
            UserId = userId;
            WasChanged = wasChanged;
            AdditionalInfo = additionalInfo;
            Setting = setting;
        }

        public SettingChangeResponse(SettingChangeResponseDTO dto)
        {
            UserId = dto.UserId;
            WasChanged = dto.WasChanged;
            AdditionalInfo = dto.Info;
            if (dto.Setting is BooleanSettingDTO boolDTO)
            {
                Setting = new BooleanSetting(boolDTO);
            }
            else if (dto.Setting is IntegerSettingDTO intDTO)
            {
                Setting = new IntegerSetting(intDTO);
            }
        }
    }
}
