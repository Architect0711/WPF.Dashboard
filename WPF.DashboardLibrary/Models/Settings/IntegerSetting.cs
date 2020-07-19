using System;
using System.Collections.Generic;
using WPF.DashboardLibrary.DTOs.Settings;

namespace WPF.DashboardLibrary.Models.Settings
{
    /// <summary>
    /// Holds Data to change a Integer Value
    /// </summary>
    public class IntegerSetting : BaseSetting
    {
        private int val;
        public int Value
        {
            get { return val; }
            set
            {
                if (val != value)
                {
                    //Make a copy of the current Object without change the State of this (this is the State the User requests)
                    IntegerSetting setting = new IntegerSetting(this, value);
                    //Invoke the Event "User has requested to change this Setting"
                    ValueChanged?.Invoke(setting, new EventArgs());
                    OnPropertyChanged<int>(nameof(Value));
                }
            }
        }

        public List<int> PossibleValues { get; private set; }

        public IntegerSetting(
            string id,
            int order,
            int Value,
            List<int> possibleValues,
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
            this.PossibleValues = possibleValues;
        }

        public IntegerSetting(IntegerSetting setting, int value)
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
            this.PossibleValues = setting.PossibleValues;
        }

        public IntegerSetting(IntegerSettingDTO dto)
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
            this.PossibleValues = dto.PossibleValues;
        }

        public void ChangeValue(int newValue)
        {
            val = newValue;
            OnPropertyChanged<int>("Value");
        }

        public override void Update(BaseSetting baseSetting)
        {
            if (baseSetting is IntegerSetting integerSetting)
            {
                ChangeValue(integerSetting.Value);
            }
        }
    }
}
