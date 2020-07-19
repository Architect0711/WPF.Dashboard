using EventAggregator.Interfaces;

namespace WPF.DashboardLibrary.Events.Dashboard
{
    public class DashboardRestartConfirmedEvent : IEvent
    {
        public override string ToString()
        {
            return nameof(DashboardRestartConfirmedEvent);
        }
    }
}
