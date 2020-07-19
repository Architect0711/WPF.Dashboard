using EventAggregator.Interfaces;

namespace WPF.DashboardLibrary.Events.Dashboard
{
    public class BackendShutdownConfirmedEvent : IEvent
    {
        public override string ToString()
        {
            return nameof(BackendShutdownConfirmedEvent);
        }
    }
}
