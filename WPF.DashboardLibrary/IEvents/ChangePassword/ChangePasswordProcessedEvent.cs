using EventAggregator.Interfaces;

namespace WPF.DashboardLibrary.Events.ChangePassword
{
    public class ChangePasswordProcessedEvent : IEvent
    {
        public override string ToString()
        {
            return nameof(ChangePasswordProcessedEvent);
        }
    }
}
