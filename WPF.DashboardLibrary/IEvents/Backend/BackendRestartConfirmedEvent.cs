using EventAggregator.Interfaces;

namespace WPF.DashboardLibrary.Events.Backend
{
    public class BackendRestartConfirmedEvent : IEvent
    {
        public override string ToString()
        {
            return nameof(BackendRestartConfirmedEvent);
        }
    }
}
