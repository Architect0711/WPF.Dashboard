using System;
using System.Collections.Generic;
using WPF.DashboardLibrary.Models.Settings;
using WPF.DashboardStarter.Enums;

namespace WPF.DashboardStarter.Models.Settings
{
    public class SkinSetting : BaseSetting
    {
        public List<Skin> PossibleValues { get; private set; }

        private Skin val;
        public Skin Value
        {
            get { return val; }
            set
            {
                if (val != value)
                {
                    //Make a copy of the current Object that reflects the State the User wants without changing this one
                    SkinSetting setting = new SkinSetting(this, value);
                    //Invoke the Event "User has requested to change this Setting"
                    ValueChanged?.Invoke(setting, new System.EventArgs());
                }
            }
        }

        public SkinSetting(
            string id,
            int order,
            Skin value,
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
            this.PossibleValues = Configuration.Skinning.AvailableSkins;
        }

        public SkinSetting(
            SkinSetting setting,
            Skin value) :
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
            this.PossibleValues = Configuration.Skinning.AvailableSkins;
        }

        public void ChangeValue(Skin newValue)
        {
            val = newValue;
            OnPropertyChanged<Skin>(nameof(Value));
        }

        public override void Update(BaseSetting baseSetting)
        {
            if (baseSetting is SkinSetting skinSetting)
            {
                ChangeValue(skinSetting.Value);
            }
        }
    }
}
