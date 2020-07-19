using EventAggregator.Interfaces;
using log4net;
using System;
using System.Security;
using System.Windows.Input;
using WPF.Basics.MVVM;
using WPF.DashboardImpl.Configuration;
using WPF.DashboardLibrary.Events.Login;
using WPF.DashboardStarter.Localization;
using WPF.DashboardStarter.WCF;

namespace WPF.DashboardStarter.ViewModels.Dashboard
{
    public class LoginViewModel : BaseViewModel
    {
        #region Fields
        private readonly WCFServiceConnection WCFService;
        #endregion

        #region Properties

        private string title = Strings.LoginView_Title_Login;
        public string Title
        {
            get { return title; }
            set
            {
                OnPropertyChanged(ref title, value);
            }
        }

        private string hint;
        public string Hint
        {
            get { return hint; }
            set
            {
                OnPropertyChanged(ref hint, value);
            }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                OnPropertyChanged(ref username, value);
                CheckInput();
            }
        }

        private SecureString password;
        public SecureString Password
        {
            get { return password; }
            set
            {
                OnPropertyChanged(ref password, value);
                CheckInput();
            }
        }

        private string newPassword;
        public string NewPassword
        {
            get { return newPassword; }
            set
            {
                OnPropertyChanged(ref newPassword, value);
            }
        }

        private string repeatNewPassword;
        public string RepeatNewPassword
        {
            get { return repeatNewPassword; }
            set
            {
                OnPropertyChanged(ref repeatNewPassword, value);
            }
        }

        private bool changePasswordMode;
        public bool ChangePasswordMode
        {
            get { return changePasswordMode; }
            set
            {
                OnPropertyChanged(ref changePasswordMode, value);
            }
        }

        private string changePasswordButtonText = Strings.LoginView_Button_ChangePassword;
        public string ChangePasswordButtonText
        {
            get { return changePasswordButtonText; }
            set
            {
                OnPropertyChanged(ref changePasswordButtonText, value);
            }
        }

        private string loginButtonText = Strings.LoginView_Button_Login;
        public string LoginButtonText
        {
            get { return loginButtonText; }
            set
            {
                OnPropertyChanged(ref loginButtonText, value);
            }
        }
        #endregion

        #region Commands

        private ICommand _RequestLogin;
        public ICommand RequestLoginCommand
        {
            get
            {
                if (_RequestLogin == null)
                {
                    _RequestLogin = new RelayCommand(
                        p => (IsLoginRequestPossible()),
                        p => this.RequestLogin());
                }
                return _RequestLogin;
            }
        }

        private bool IsLoginRequestPossible()
        {
            return Password != null && Password.Length > 0 && Username != null && Username.Length > 0;
        }

        private ICommand _RequestChangePassword;
        public ICommand RequestChangePasswordCommand
        {
            get
            {
                if (_RequestChangePassword == null)
                {
                    _RequestChangePassword = new RelayCommand(
                        p => (IsChangePasswordRequestPossible()),
                        p => this.RequestChangePassword());
                }
                return _RequestChangePassword;
            }
        }

        private bool IsChangePasswordRequestPossible()
        {
            return Password != null && Password.Length > 0 &&
                Username != null && Username.Length > 0 &&
                NewPassword != null && NewPassword.Length > 0 &&
                RepeatNewPassword != null && RepeatNewPassword.Length > 0;
        }

        private ICommand _ChangePasswordMode;
        public ICommand ChangePasswordModeCommand
        {
            get
            {
                if (_ChangePasswordMode == null)
                {
                    _ChangePasswordMode = new RelayCommand(
                        p => (true),
                        p => this.RequestChangePasswordMode());
                }
                return _ChangePasswordMode;
            }
        }

        #endregion

        #region Ctor

        public LoginViewModel(IEventAggregator eventAggregator, ILog log, WCFServiceConnection wcfService) : base(eventAggregator, log)
        {
            WCFService = wcfService;
        }

        #endregion

        protected override void SubscribeToAllEvents()
        {
            EventAggregator.Subscribe<LoginResponseEvent>(OnLoginResponseEvent);
            EventAggregator?.Subscribe<LogoutEvent>(OnLogout);
        }

        private void OnLogout(LogoutEvent e)
        {
            Username = string.Empty;
        }

        private bool CheckInput()
        {
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < PasswordGuidelines.MinimumUsernameLength)
            {
                Hint = string.Format(Strings.LoginView_Text_UsernameLength, PasswordGuidelines.MinimumUsernameLength);
                return false;
            }

            if (Password == null || Password.Length < PasswordGuidelines.MinimumPasswordLength)
            {
                Hint = string.Format(Strings.LoginView_Text_PasswordLength, PasswordGuidelines.MinimumPasswordLength);
                return false;
            }

            Hint = string.Empty;

            return true;
        }
        
        private void RequestLogin()
        {
            WCFService.Login(Username, Password, Configuration.Localization.CurrentCultureInfo);
        }

        private void RequestChangePassword()
        {
            if (NewPassword != RepeatNewPassword)
            {
                Hint = Strings.LoginView_Text_NewPasswordsNoMatch;
            }
        }

        private void RequestChangePasswordMode()
        {
            ChangePasswordMode = !ChangePasswordMode;
            Hint = string.Empty;
            if (ChangePasswordMode)
            {
                ChangePasswordButtonText = Strings.LoginView_Button_EnterPassword;
                LoginButtonText = Strings.LoginView_Button_Change;
                Title = Strings.LoginView_Title_ChangePassword;
            }
            else
            {
                ChangePasswordButtonText = Strings.LoginView_Button_ChangePassword;
                LoginButtonText = Strings.LoginView_Button_Login;
                Title = Strings.LoginView_Title_Login;
            }
        }

        private void OnLoginResponseEvent(LoginResponseEvent e)
        {
            if (e.IsExpired)
            {
                Hint = Strings.LoginView_Text_PasswordExpired;
            }
            else if (!e.IsValid)
            {
                Hint = Strings.LoginView_Text_PasswordRejected;
            }
            else
            {
                Hint = string.Empty;
            }
        }

    }
}
