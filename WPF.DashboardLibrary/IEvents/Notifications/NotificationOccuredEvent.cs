using EventAggregator.Interfaces;
using WPF.DashboardLibrary.Enums;
using WPF.DashboardLibrary.Models.Notification;

namespace WPF.DashboardLibrary.Events.Notifications
{
    /// <summary>
    /// Publish this Event, when the User needs to be notified by a Popup that something has occured
    /// </summary>
    public class NotificationOccurredEvent : IEvent
    {
        #region Properties
        public NotificationModel Notification { get; private set; }
        #endregion

        #region Ctor

        /// <summary>
        /// Use this Constructor, if the User can perform Actions in Response to the Event 
        /// they are being notified of
        /// </summary>
        public NotificationOccurredEvent(NotificationModel notification)
        {
            Notification = notification;
        }
        #endregion

        public override string ToString()
        {
            return string.Format("{0} => {1}", 
                nameof(NotificationOccurredEvent), 
                Notification.ToString());
        }
    }
}
