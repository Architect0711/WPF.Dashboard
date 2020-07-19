using EventAggregator.Interfaces;

namespace WPF.DashboardLibrary.Events.Dashboard
{
    public class DashboardRestartRequestedEvent : IEvent
    {
        public override string ToString()
        {
            return nameof(DashboardRestartRequestedEvent);
        }
    }
}
