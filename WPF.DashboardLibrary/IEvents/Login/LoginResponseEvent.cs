using EventAggregator.Interfaces;

namespace WPF.DashboardLibrary.Events.Login
{
    public class LoginResponseEvent : IEvent
    {
        public string Username { get; private set; }
        public bool IsValid { get; private set; }
        public bool IsExpired { get; private set; }
        public bool UsernameTooShort { get; private set; }
        public bool PasswordTooShort { get; private set; }
        public bool PasswordMissingSpecialCharacters { get; private set; }
        public bool PasswordMissingLowercaseCharacters { get; private set; }
        public bool PasswordMissingUppercaseCharacters { get; private set; }
        public bool PasswordMissingNumbers { get; private set; }

        public LoginResponseEvent(bool IsValid,
            bool IsExpired,
            string Username,
            bool UsernameTooShort,
            bool PasswordTooShort,
            bool PasswordMissingSpecialCharacters,
            bool PasswordMissingLowercaseCharacters,
            bool PasswordMissingUppercaseCharacters,
            bool PasswordMissingNumbers)
        {
            this.Username = Username;
            this.IsValid = IsValid;
            this.IsExpired = IsExpired;
        }

        public override string ToString()
        {
            return nameof(LoginResponseEvent);
        }
    }
}
