using EventAggregator.Interfaces;

namespace WPF.DashboardLibrary.Events.Dashboard
{
    public class BackendShutdownRequestedEvent : IEvent
    {
        public override string ToString()
        {
            return nameof(BackendShutdownRequestedEvent);
        }
    }
}
