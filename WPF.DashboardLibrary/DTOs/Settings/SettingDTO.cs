using System.Runtime.Serialization;

namespace WPF.DashboardLibrary.DTOs.Settings
{
    /// <summary>
    /// To pass derived Types as Base Type through WCF, decorate the Base Type with the KnownTypeAttribute 
    /// for every derived Class. That way, the Serializer knows that a 'DeviredType' is of Type 'BaseType'.
    /// https://stackoverflow.com/questions/8555089/datacontract-and-inheritance
    /// </summary>
    [DataContract]
    [KnownType(typeof(IntegerSettingDTO))]
    [KnownType(typeof(BooleanSettingDTO))]
    public abstract class SettingDTO
    {
        [DataMember]
        public string SettingId { get; private set; }

        [DataMember]
        public int Order { get; private set; }

        [DataMember]
        public bool IsReadOnly { get; private set; }

        [DataMember]
        public bool ChangeRequiresDashboardRestart { get; private set; }

        [DataMember]
        public bool ChangeRequiresBackendRestart { get; private set; }

        [DataMember]
        public string ShortText { get; private set; }

        [DataMember]
        public string LongText { get; private set; }

        [DataMember]
        public string HoverText { get; private set; }

        public SettingDTO(string id, int order, bool isReadOnly, bool changeRequiresDashboardRestart, bool changeRequiresBackendRestart, string shortText, string longText, string hoverText)
        {
            SettingId = id;
            Order = order;
            IsReadOnly = isReadOnly;
            ChangeRequiresDashboardRestart = changeRequiresDashboardRestart;
            ChangeRequiresBackendRestart = changeRequiresBackendRestart;
            ShortText = shortText;
            LongText = longText;
            HoverText = hoverText;
        }
    }
}
