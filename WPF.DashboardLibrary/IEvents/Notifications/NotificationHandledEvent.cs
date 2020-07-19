using EventAggregator.Interfaces;

namespace WPF.DashboardLibrary.Events.Notifications
{
    /// <summary>
    /// This Event is Published when the User has handled a Notification
    /// </summary>
    public class NotificationHandledEvent : IEvent
    {
        public bool Confirmed { get; private set; }
        public bool Declined { get; private set; }
        public bool Cancelled { get; private set; }

        public NotificationHandledEvent(
            bool confirmed,
            bool declined,
            bool cancelled)
        {
            Confirmed = confirmed;
            Declined = declined;
            Cancelled = cancelled;
        }

        public override string ToString()
        {
            return nameof(NotificationHandledEvent);
        }
    }
}
