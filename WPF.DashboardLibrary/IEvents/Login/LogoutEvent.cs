using EventAggregator.Interfaces;

namespace WPF.DashboardLibrary.Events.Login
{
    public class LogoutEvent : IEvent
    {
        public override string ToString()
        {
            return nameof(LogoutEvent);
        }
    }
}
