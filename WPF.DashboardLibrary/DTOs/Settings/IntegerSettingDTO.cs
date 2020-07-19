using System.Collections.Generic;
using System.Runtime.Serialization;
using WPF.DashboardLibrary.Models.Settings;

namespace WPF.DashboardLibrary.DTOs.Settings
{
    [DataContract]
    public class IntegerSettingDTO : SettingDTO
    {
        [DataMember]
        public int Value { get; set; }

        [DataMember]
        public List<int> PossibleValues { get; private set; }

        public IntegerSettingDTO(
            string id,
            int order,
            bool isReadOnly,
            bool changeRequiresDashboardRestart,
            bool changeRequiresBackendRestart,
            string shortText,
            string longText,
            string hoverText,
            int value,
            List<int> possibleValues)
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
            PossibleValues = possibleValues;
        }

        public IntegerSettingDTO(IntegerSetting setting)
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
