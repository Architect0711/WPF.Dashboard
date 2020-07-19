using System.Runtime.Serialization;
using WPF.DashboardLibrary.Models.Settings;

namespace WPF.DashboardLibrary.DTOs.Settings
{
    [DataContract]
    public class BooleanSettingDTO : SettingDTO
    {
        [DataMember]
        public bool Value { get; set; }

        public BooleanSettingDTO(
            string id,
            int order, 
            bool isReadOnly, 
            bool changeRequiresDashboardRestart, 
            bool changeRequiresBackendRestart, 
            string shortText, 
            string longText, 
            string hoverText,
            bool value)
            : base(
                id, 
                order, 
                isReadOnly, 
                changeRequiresDashboardRestart, 
                changeRequiresBackendRestart, 
                shortText, 
                longText, 
                hoverText)
        {
            Value = value;
        }

        public BooleanSettingDTO(BooleanSetting setting)
            : base(
                setting.SettingId,
                setting.Order,
                setting.IsReadOnly,
                setting.ChangeRequiresDashboardRestart,
                setting.ChangeRequiresBackendRestart,
                setting.ShortText,
                setting.LongText,
                setting.HoverText)
        {
            Value = setting.Value;
        }
    }
}
