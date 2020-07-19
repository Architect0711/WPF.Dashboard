using EventAggregator.Interfaces;

namespace WPF.DashboardLibrary.Events.Dashboard
{
    public class DashboardShutdownRequestedEvent : IEvent
    {
        public override string ToString()
        {
            return nameof(DashboardShutdownRequestedEvent);
        }
    }
}
