using EventAggregator.Interfaces;

namespace WPF.DashboardLibrary.Events.ChangePassword
{
    public class ChangePasswordRequestedEvent : IEvent
    {
        public override string ToString()
        {
            return nameof(ChangePasswordRequestedEvent);
        }
    }
}
