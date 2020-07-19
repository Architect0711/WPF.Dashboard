using EventAggregator.Interfaces;

namespace WPF.DashboardLibrary.Events.Dashboard
{
    public class DashboardShutdownConfirmedEvent : IEvent
    {
        public override string ToString()
        {
            return nameof(DashboardShutdownConfirmedEvent);
        }
    }
}
