using EventAggregator.Interfaces;
using System.Runtime.Serialization;
using WPF.DashboardLibrary.Enums;

namespace WPF.DashboardLibrary.DTOs.Notification
{
    [DataContract]
    public class NotificationDTO
    {
        [DataMember]
        public string NotificationId { get; private set; }

        [DataMember]
        public NotificationType NotificationType { get; private set; }
        [DataMember]
        public string NotificationTitle { get; private set; }
        [DataMember]
        public string NotificationText { get; private set; }

        [DataMember]
        public bool CanConfirm { get; private set; }
        [DataMember]
        public IEvent ConfirmEvent { get; private set; }
        [DataMember]
        public string ConfirmInfo { get; private set; }

        [DataMember]
        public bool CanDecline { get; private set; }
        [DataMember]
        public IEvent DeclineEvent { get; private set; }
        [DataMember]
        public string DeclineInfo { get; private set; }

        [DataMember]
        public bool CanCancel { get; private set; }
        [DataMember]
        public IEvent CancelEvent { get; private set; }
        [DataMember]
        public string CancelInfo { get; private set; }
    }
}
