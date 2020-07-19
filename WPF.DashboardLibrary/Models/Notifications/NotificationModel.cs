using EventAggregator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DashboardLibrary.Enums;

namespace WPF.DashboardLibrary.Models.Notification
{
    public class NotificationModel
    {
        public NotificationModel(string notificationId, NotificationType notificationType, string notificationTitle, string notificationText, bool canConfirm, IEvent confirmEvent, string confirmInfo, bool canDecline, IEvent declineEvent, string declineInfo, bool canCancel, IEvent cancelEvent, string cancelInfo)
        {
            NotificationId = notificationId;
            NotificationType = notificationType;
            NotificationTitle = notificationTitle;
            NotificationText = notificationText;
            CanConfirm = canConfirm;
            ConfirmEvent = confirmEvent;
            ConfirmInfo = confirmInfo;
            CanDecline = canDecline;
            DeclineEvent = declineEvent;
            DeclineInfo = declineInfo;
            CanCancel = canCancel;
            CancelEvent = cancelEvent;
            CancelInfo = cancelInfo;
        }

        public string NotificationId { get; private set; }

        public NotificationType NotificationType { get; private set; }
        public string NotificationTitle { get; private set; }
        public string NotificationText { get; private set; }

        public bool CanConfirm { get; private set; }
        public IEvent ConfirmEvent { get; private set; }
        public string ConfirmInfo { get; private set; }

        public bool CanDecline { get; private set; }
        public IEvent DeclineEvent { get; private set; }
        public string DeclineInfo { get; private set; }

        public bool CanCancel { get; private set; }
        public IEvent CancelEvent { get; private set; }
        public string CancelInfo { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is NotificationModel notification &&
                   NotificationId == notification.NotificationId;
        }

        public override int GetHashCode()
        {
            return -762866413 + EqualityComparer<string>.Default.GetHashCode(NotificationId);
        }
    }
}
