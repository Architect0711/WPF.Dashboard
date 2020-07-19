using System;
using WPF.DashboardLibrary.DTOs.Settings;
using WPF.DashboardLibrary.Models.Settings;

namespace WPF.DashboardLibrary.RequestResponse.Settings
{
    public class SettingChangeRequest
    {
        public string UserId { get; private set; }

        public BaseSetting SettingToChange { get; private set; }

        public SettingChangeRequest(
            string userId,
            BaseSetting settingToChange)
        {
            UserId = userId;
            SettingToChange = settingToChange;
        }

        //public SettingChangeRequest(SettingChangeRequestDTO dto)
        //{
        //    UserId = dto.UserId;
        //    if (dto.SettingToChange is BooleanSettingDTO boolDTO)
        //    {
        //        SettingToChange = new BooleanSetting(boolDTO);
        //    }
        //    else if (dto.SettingToChange is IntegerSettingDTO intDTO)
        //    {
        //        SettingToChange = new IntegerSetting(intDTO);
        //    }
        //}

        public SettingChangeRequestDTO ToDto()
        {
            return new SettingChangeRequestDTO(UserId, SettingToChange.ToDto());
        }
    }
}
