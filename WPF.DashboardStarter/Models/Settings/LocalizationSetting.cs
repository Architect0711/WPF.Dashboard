using System;
using System.Collections.Generic;
using WPF.DashboardLibrary.Models.Settings;

namespace WPF.DashboardStarter.Models.Settings
{
    public class LocalizationSetting : BaseSetting
    {
        public List<string> PossibleValues { get; private set; }

        private string val;
        public string Value
        {
            get { return val; }
            set
            {
                if (val != value)
                {
                    //Make a copy of the current Object that reflects the State the User wants without changing this one
                    LocalizationSetting setting = new LocalizationSetting(this, value);
                    //Invoke the Event "User has requested to change this Setting"
                    ValueChanged?.Invoke(setting, new System.EventArgs());
                }
            }
        }

        public LocalizationSetting(
            string id,
            int order,
            string value,
            bool isReadOnly,
            string shortText,
            string longText,
            string hoverText) :
            base(
                id,
                isReadOnly,
                true, 
                false,
                false,
                order,
                shortText,
                longText,
                hoverText)
        {
            this.val = value;
            this.PossibleValues = Configuration.Localization.AvailableLanguages;
        }

        public LocalizationSetting(
            LocalizationSetting setting,
            string value) :
            base(
                setting.SettingId,
                setting.IsReadOnly,
                true,
                false,
                false,
                setting.Order,
                setting.ShortText,
                setting.LongText,
                setting.HoverText)
        {
            this.val = value;
            this.PossibleValues = Configuration.Localization.AvailableLanguages;
        }

        public void ChangeValue(string newValue)
        {
            val = newValue;
            OnPropertyChanged<string>(nameof(Value));
        }

        public override void Update(BaseSetting baseSetting)
        {
            if (baseSetting is LocalizationSetting localizationSetting)
            {
                ChangeValue(localizationSetting.Value);
            }
        }
    }
}
