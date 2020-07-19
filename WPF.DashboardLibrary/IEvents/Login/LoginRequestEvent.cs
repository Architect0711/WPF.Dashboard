using EventAggregator.Interfaces;
using System.Security;

namespace WPF.DashboardLibrary.Events.Login
{
    public class LoginRequestEvent : IEvent
    {
        public string Username { get; private set; }
        public SecureString Password { get; private set; }

        public LoginRequestEvent(string Username, SecureString Password)
        {
            this.Username = Username;
            this.Password = Password;
            Password.MakeReadOnly();
        }

        public override string ToString()
        {
            return string.Format("{0} by User {1}",nameof(LoginRequestEvent), Username);
        }
    }
}
