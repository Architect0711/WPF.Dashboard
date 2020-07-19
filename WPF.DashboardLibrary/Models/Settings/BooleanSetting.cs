using System;
using WPF.DashboardLibrary.DTOs.Settings;

namespace WPF.DashboardLibrary.Models.Settings
{
    /// <summary>
    /// Holds Data to change a Boolean Value
    /// </summary>
    public class BooleanSetting : BaseSetting
    {
        private bool val;
        public bool Value
        {
            get { return val; }
            set
            {
                if (val != value)
                {
                    //Make a copy of the current Object without change the State of this (this is the State the User requests)
                    BooleanSetting setting = new BooleanSetting(this, value);
                    //Invoke the Event "User has requested to change this Setting"
                    ValueChanged?.Invoke(setting, new EventArgs());
                }
            }
        }

        public BooleanSetting(
            string id,
            int order,
            bool Value,
            string shortText,
            string longText,
            string hoverText,
            bool isReadOnly,
            bool changeRequiresDashboardRestart,
            bool changeRequiresBackendRestart,
            bool changeRequiresBackendPermission)
            : base(
                  id,
                  isReadOnly,
                  changeRequiresDashboardRestart,
                  changeRequiresBackendRestart,
                  changeRequiresBackendPermission,
                  order,
                  shortText,
                  longText,
                  hoverText)
        {
            this.val = Value;
        }

        public BooleanSetting(BooleanSetting setting, bool value)
            : base(
                   setting.SettingId,
                   setting.IsReadOnly,
                   setting.ChangeRequiresDashboardRestart,
                   setting.ChangeRequiresBackendRestart,
                   setting.ChangeRequiresBackendPermission,
                   setting.Order,
                   setting.ShortText,
                   setting.LongText,
                   setting.HoverText)
        {
            this.val = value;
        }

        public BooleanSetting(BooleanSettingDTO dto)
            : base(
                  dto.SettingId,
                  dto.IsReadOnly,
                  dto.ChangeRequiresDashboardRestart,
                  dto.ChangeRequiresBackendRestart,
                  true,
                  dto.Order,
                  dto.ShortText,
                  dto.LongText,
                  dto.HoverText)
        {
            this.val = dto.Value;
        }

        public void ChangeValue(bool newValue)
        {
            val = newValue;
            OnPropertyChanged<bool>(nameof(Value));
        }

        public override void Update(BaseSetting baseSetting)
        {
            if (baseSetting is BooleanSetting booleanSetting)
            {
                ChangeValue(booleanSetting.Value);
            }
        }
    }
}
