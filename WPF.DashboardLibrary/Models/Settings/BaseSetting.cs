using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPF.Basics.MVVM;
using WPF.DashboardLibrary.DTOs.Settings;

namespace WPF.DashboardLibrary.Models.Settings
{
    public abstract class BaseSetting : ObservableObject
    {
        public EventHandler ValueChanged;
        public string SettingId { get; set; }
        public int Order { get; private set; }
        public bool IsReadOnly { get; private set; }
        public bool ChangeRequiresDashboardRestart { get; private set; }
        public bool ChangeRequiresBackendRestart { get; private set; }
        public bool ChangeRequiresBackendPermission { get; private set; }

        public string ShortText { get; private set; }
        public string LongText { get; private set; }
        public string HoverText { get; private set; }

        public BaseSetting(
            string settingId,
            bool isReadOnly,
            bool changeRequiresDashboardRestart,
            bool changeRequiresBackendRestart,
            bool changeRequiresBackendPermission,
            int order,
            string shortText,
            string longText,
            string hoverText)
        {
            ChangeRequiresDashboardRestart = changeRequiresDashboardRestart;
            ChangeRequiresBackendRestart = changeRequiresBackendRestart;
            ChangeRequiresBackendPermission = changeRequiresBackendPermission;
            ShortText = shortText;
            LongText = longText;
            HoverText = hoverText;
            IsReadOnly = isReadOnly;
            Order = order;
            SettingId = settingId;
        }

        public SettingDTO ToDto()
        {
            if (this.GetType() == typeof(BooleanSetting))
            {
                return new BooleanSettingDTO((BooleanSetting)this);
            }
            else if (this.GetType() == typeof(IntegerSetting))
            {
                return new IntegerSettingDTO((IntegerSetting)this);
            }
            return null;
        }

        public abstract void Update(BaseSetting baseSetting);

        public override bool Equals(object obj)
        {
            return obj is BaseSetting setting &&
                   SettingId == setting.SettingId;
        }

        public override int GetHashCode()
        {
            return -1011996714 + EqualityComparer<string>.Default.GetHashCode(SettingId);
        }
    }
}
