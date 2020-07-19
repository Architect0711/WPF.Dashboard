using EventAggregator.Interfaces;

namespace WPF.DashboardLibrary.Events.Dashboard
{
    public class BackendRestartRequestedEvent : IEvent
    {
        public override string ToString()
        {
            return nameof(BackendRestartRequestedEvent);
        }
    }
}
