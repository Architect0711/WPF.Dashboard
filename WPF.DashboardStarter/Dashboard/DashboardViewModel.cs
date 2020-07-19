using EventAggregator.Interfaces;
using log4net;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using WPF.Basics.MVVM;
using WPF.DashboardLibrary.Enums;
using WPF.DashboardLibrary.Events.Dashboard;
using WPF.DashboardLibrary.Events.Login;
using WPF.DashboardLibrary.Events.Notifications;
using WPF.DashboardLibrary.Models.Notification;
using WPF.DashboardStarter.Content;
using WPF.DashboardStarter.EventArgs;
using WPF.DashboardStarter.Localization;
using WPF.DashboardStarter.WCF;

namespace WPF.DashboardStarter.Dashboard
{
    /// <summary>
    /// Composite ViewModel that controls the Layout of the Application
    /// </summary>
    public class DashboardViewModel : BaseViewModel
    {

        #region StaticPropertyChanged
        private static event EventHandler<PropertyChangedEventArgs> staticPropertyChanged = delegate { };
        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged
        {
            add { staticPropertyChanged += value; }
            remove { staticPropertyChanged -= value; }
        }
        protected static void OnStaticPropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = staticPropertyChanged;
            if (handler != null)
            {
                staticPropertyChanged(null, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Fields
        private readonly WCFServiceConnection WCFService;
        #endregion

        #region Properties
        #region nonstatic content

        ///// <summary>
        ///// Determine which View is currently visible in the main Viewport
        ///// </summary>
        //private DashboardContent dashboardContent;
        //public DashboardContent DashboardContent
        //{
        //    get { return dashboardContent; }
        //    set
        //    {
        //        OnPropertyChanged(ref dashboardContent, value);
        //        Log.InfoFormat("{0} = {1}", 
        //            nameof(DashboardContent), 
        //            Enum.GetName(typeof(DashboardContent), DashboardContent));
        //    }
        //}

        ///// <summary>
        ///// Determine which View is currently visible in the outer Drawer
        ///// </summary>
        //private DrawerContent outerDrawerContent;
        //public DrawerContent OuterDrawerContent
        //{
        //    get { return outerDrawerContent; }
        //    set
        //    {
        //        OnPropertyChanged(ref outerDrawerContent, value);
        //        Log.InfoFormat("{0} = {1}", 
        //            nameof(OuterDrawerContent), 
        //            Enum.GetName(typeof(DrawerContent), OuterDrawerContent));
        //    }
        //}

        ///// <summary>
        ///// Determine which View is currently visible in the inner Drawer
        ///// </summary>
        //private DrawerContent innerDrawerContent;
        //public DrawerContent InnerDrawerContent
        //{
        //    get { return innerDrawerContent; }
        //    set
        //    {
        //        OnPropertyChanged(ref innerDrawerContent, value);
        //        Log.InfoFormat("{0} = {1}", 
        //            nameof(InnerDrawerContent), 
        //            Enum.GetName(typeof(DrawerContent), InnerDrawerContent));
        //    }
        //}

        ///// <summary>
        ///// Determine which Popup is currently visible 
        ///// </summary>
        //private PopupContent popupContent;
        //public PopupContent PopupContent
        //{
        //    get { return popupContent; }
        //    set
        //    {
        //        OnPropertyChanged(ref popupContent, value);
        //        Log.InfoFormat("{0} = {1}", 
        //            nameof(PopupContent), 
        //            Enum.GetName(typeof(PopupContent), PopupContent));
        //    }
        //} 
        #endregion

        public static event EventHandler ContentChanged;

        /// <summary>
        /// Determine which View is currently visible in the main Viewport
        /// </summary>
        private static string dashboardContent;
        public static string DashboardContent
        {
            get { return dashboardContent; }
            set
            {
                if (dashboardContent != value)
                {
                    dashboardContent = value;
                    OnStaticPropertyChanged();
                }
                ContentChanged?.Invoke(null, new ContentChangedEventArgs(UserControlLocation.Dashboard, dashboardContent));
            }
        }

        /// <summary>
        /// Determine which View is currently visible in the outer Drawer
        /// </summary>
        private static string outerDrawerContent;
        public static string OuterDrawerContent
        {
            get { return outerDrawerContent; }
            set
            {
                if (outerDrawerContent != value)
                {
                    outerDrawerContent = value;
                    OnStaticPropertyChanged();
                }
                ContentChanged?.Invoke(null, new ContentChangedEventArgs(UserControlLocation.OuterDrawer, outerDrawerContent));
            }
        }

        /// <summary>
        /// Determine which View is currently visible in the inner Drawer
        /// </summary>
        private static string innerDrawerContent;
        public static string InnerDrawerContent
        {
            get { return innerDrawerContent; }
            set
            {
                if (innerDrawerContent != value)
                {
                    innerDrawerContent = value;
                    OnStaticPropertyChanged();
                }
                ContentChanged?.Invoke(null, new ContentChangedEventArgs(UserControlLocation.InnerDrawer, innerDrawerContent));
            }
        }

        /// <summary>
        /// Determine which Popup is currently visible 
        /// </summary>
        private static string popupContent;
        public static string PopupContent
        {
            get { return popupContent; }
            set
            {
                if (popupContent != value)
                {
                    popupContent = value;
                    OnStaticPropertyChanged();
                }
                ContentChanged?.Invoke(null, new ContentChangedEventArgs(UserControlLocation.Popup, popupContent));
            }
        }

        /// <summary>
        /// Set this to true to show the Spinner when running a long
        /// </summary>
        private static bool isBusy = false;
        public static bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    OnStaticPropertyChanged();
                }
            }
        }

        private static bool isLoggedIn = false;
        public static bool IsLoggedIn
        {
            get { return isLoggedIn; }
            set
            {
                if (isLoggedIn != value)
                {
                    isLoggedIn = value;
                    OnStaticPropertyChanged();
                    if (IsLoggedIn)
                    {
                        OuterDrawerContent = DrawerContent.Status;
                    }
                    else
                    {
                        DashboardContent = Content.DashboardContent.Login;
                    }
                }
            }
        }

        private static bool isConnected = false;
        public static bool IsConnected
        {
            get { return isConnected; }
            set
            {
                if (isConnected != value)
                {
                    isConnected = value;
                    OnStaticPropertyChanged();
                    if (!isConnected)
                    {
                        DashboardContent = Content.DashboardContent.Disconnected;
                    }
                    else
                    {
                        DashboardContent = Content.DashboardContent.Login;
                    }
                }
            }
        }

        private string appTitleText = Strings.App_Title;
        public string AppTitleText
        {
            get { return appTitleText; }
            set
            {
                OnPropertyChanged(ref appTitleText, value);
                Log.DebugFormat("{0} = {1}", nameof(AppTitleText), AppTitleText);
            }
        }

        private static string username;
        public static string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnStaticPropertyChanged();
            }
        }

        private string loggedInUserText;
        public string LoggedInUserText
        {
            get { return loggedInUserText; }
            set
            {
                OnPropertyChanged(ref loggedInUserText, value);
                Log.InfoFormat("{0} = {1}", nameof(LoggedInUserText), LoggedInUserText);
            }
        }

        private string companyLogoPath_Small = Configuration.Paths.CompanyLogo_Small;
        public string CompanyLogoPath_Small
        {
            get { return companyLogoPath_Small; }
            set
            {
                OnPropertyChanged(ref companyLogoPath_Small, value);
                Log.InfoFormat("{0} = {1}", nameof(CompanyLogoPath_Small), CompanyLogoPath_Small);
            }
        }

        private string companyLogoPath_Large = Configuration.Paths.CompanyLogo_Large;
        public string CompanyLogoPath_Large
        {
            get { return companyLogoPath_Large; }
            set
            {
                OnPropertyChanged(ref companyLogoPath_Large, value);
                Log.InfoFormat("{0} = {1}", nameof(CompanyLogoPath_Large), CompanyLogoPath_Large);
            }
        }

        #endregion

        #region Commands

        private ICommand _RequestAbout;
        public ICommand RequestAboutCommand
        {
            get
            {
                if (_RequestAbout == null)
                {
                    _RequestAbout = new RelayCommand(
                        p => (true),
                        p => this.RequestAbout());
                }
                return _RequestAbout;
            }
        }

        private void RequestAbout()
        {
            Log.DebugFormat("RequestAbout()");
            if (PopupContent != Content.PopupContent.About)
            {
                PopupContent = Content.PopupContent.About;
            }
            else
            {
                PopupContent = Content.PopupContent.None;
            }
        }

        private ICommand _RequestLogout;
        public ICommand RequestLogoutCommand
        {
            get
            {
                if (_RequestLogout == null)
                {
                    _RequestLogout = new RelayCommand(
                        p => (IsLoggedIn),
                        p => this.RequestLogout());
                }
                return _RequestLogout;
            }
        }

        private void RequestLogout()
        {
            WCFService.Logout("");
            IsLoggedIn = false;
            EventAggregator?.Publish(new LogoutEvent());
        }

        private ICommand _RequestLaunchProgram;
        public ICommand RequestLaunchProgramCommand
        {
            get
            {
                if (_RequestLaunchProgram == null)
                {
                    _RequestLaunchProgram = new RelayCommand(
                        p => (IsLoggedIn),
                        p => this.RequestLaunchProgram());
                }
                return _RequestLaunchProgram;
            }
        }

        private void RequestLaunchProgram()
        {
            Log.DebugFormat("RequestLaunchProgram()");
            InnerDrawerContent = DrawerContent.LaunchPrograms;
        }

        private ICommand _RequestSettings;
        public ICommand RequestSettingsCommand
        {
            get
            {
                if (_RequestSettings == null)
                {
                    _RequestSettings = new RelayCommand(
                        p => (IsLoggedIn),
                        p => this.RequestSettings());
                }
                return _RequestSettings;
            }
        }

        private void RequestSettings()
        {
            Log.DebugFormat("RequestSettings()");
            InnerDrawerContent = DrawerContent.Settings;
        }

        private ICommand _RequestMessages;
        public ICommand RequestMessagesCommand
        {
            get
            {
                if (_RequestMessages == null)
                {
                    _RequestMessages = new RelayCommand(
                        p => (IsLoggedIn),
                        p => this.RequestMessages());
                }
                return _RequestMessages;
            }
        }

        private void RequestMessages()
        {
            InnerDrawerContent = DrawerContent.Messages;
        }

        private ICommand _RequestMenu;
        public ICommand RequestMenuCommand
        {
            get
            {
                if (_RequestMenu == null)
                {
                    _RequestMenu = new RelayCommand(
                        p => (IsLoggedIn),
                        p => this.RequestMenu());
                }
                return _RequestMenu;
            }
        }

        private void RequestMenu()
        {
            Log.DebugFormat("RequestMenu()");
            InnerDrawerContent = DrawerContent.Menu;
        }

        #endregion

        #region Ctor
        public DashboardViewModel(IEventAggregator eventAggregator, ILog log, WCFServiceConnection wcfService) : base(eventAggregator, log)
        {
            WCFService = wcfService;
            DashboardContent = Content.DashboardContent.Disconnected;
        }

        protected override void SubscribeToAllEvents()
        {
            EventAggregator.Subscribe<LoginResponseEvent>(OnLoginResponseEvent);
            EventAggregator.Subscribe<DashboardRestartRequestedEvent>(OnRestartRequested);
            EventAggregator.Subscribe<DashboardShutdownRequestedEvent>(OnShutdownRequested);
            EventAggregator.Subscribe<NotificationOccurredEvent>(OnNotificationOccurredEvent);
            EventAggregator.Subscribe<NotificationHandledEvent>(OnNotificationHandledEvent);
            EventAggregator.Subscribe<DashboardRestartConfirmedEvent>(OnRestartConfirmed);
            EventAggregator.Subscribe<DashboardShutdownConfirmedEvent>(OnShutdownConfirmed);
        }
        #endregion

        #region IEvents

        private void OnLoginResponseEvent(LoginResponseEvent e)
        {
            try
            {
                if (e.IsValid)
                {
                    IsLoggedIn = true;
                    Username = e.Username;
                    DashboardContent = Content.DashboardContent.Main;
                    LoggedInUserText = string.Format("{0}: {1}", Strings.Titlebar_LoggedInUser, e.Username);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(nameof(OnLoginResponseEvent), ex);
            }
        }

        private void OnShutdownRequested(DashboardShutdownRequestedEvent e)
        {
            Log.InfoFormat("OnShutdownRequested() => {0}", e.ToString());
            IsBusy = true;
            EventAggregator.Publish(new DashboardShutdownConfirmedEvent());
        }

        private void OnShutdownConfirmed(DashboardShutdownConfirmedEvent e)
        {
            Log.InfoFormat("OnShutdownConfirmed() => {0}", e.ToString());
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ThreadStart(() =>
            {
                Application.Current.Shutdown();
            }));
        }

        private void OnRestartRequested(DashboardRestartRequestedEvent e)
        {
            Log.InfoFormat("OnRestartRequested() => {0}", e.ToString());
            IsBusy = true;
            EventAggregator.Publish(new DashboardRestartConfirmedEvent());
        }

        private void OnRestartConfirmed(DashboardRestartConfirmedEvent e)
        {
            Log.InfoFormat("OnRestartConfirmed() => {0}", e.ToString());
            //https://stackoverflow.com/questions/4773632/how-do-i-restart-a-wpf-application
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ThreadStart(() =>
            {
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }));
        }
        
        private void OnNotificationOccurredEvent(NotificationOccurredEvent e)
        {
            if (e != null)
            {
                Log.InfoFormat("OnNotificationOccurredEvent() => {0}", e.ToString());
                PopupContent = Content.PopupContent.Notification;
            }
        }

        private void OnNotificationHandledEvent(NotificationHandledEvent e)
        {
            if (e != null && PopupContent == Content.PopupContent.Notification)
            {
                Log.InfoFormat("OnNotificationHandledEvent() => {0}", e.ToString());
                PopupContent = Content.PopupContent.None;
            }
        }
        #endregion

        #region DEMO (DELETE THIS WHEN IMPLEMENTING A REAL APP)

        private void Run_ShowANotificationToTheUserDemo()
        {
            var fatalEvent = new NotificationOccurredEvent(
                new NotificationModel(
                "FatalDemo",
                NotificationType.Fatal,
                Strings.Notification_Fatal,
                string.Format(Strings.Notification_FatalDemoLongText, Strings.Notification_DefaultButtonConfirm),
                true, null, "",
                true, null, "",
                true, null, "")
                );

            var errorEvent = new NotificationOccurredEvent(
                new NotificationModel(
                "ErrorDemo",
                NotificationType.Error,
                Strings.Notification_Error,
                string.Format(Strings.Notification_ErrorDemoLongText, Strings.Notification_DefaultButtonConfirm),
                true, fatalEvent, "",
                true, null, "",
                true, null, "")
                );

            var warnEvent = new NotificationOccurredEvent(
                new NotificationModel(
                "WarnDemo",
                NotificationType.Warning,
                Strings.Notification_Warn,
                string.Format(Strings.Notification_WarnDemoLongText, Strings.Notification_DefaultButtonConfirm),
                true, errorEvent, "",
                true, null, "",
                true, null, "")
                );

            var successEvent = new NotificationOccurredEvent(
                new NotificationModel(
                "SuccessDemo",
                NotificationType.Success,
                Strings.Notification_Success,
                string.Format(Strings.Notification_SuccessDemoLongText, Strings.Notification_DefaultButtonConfirm),
                true, warnEvent, "",
                true, null, "",
                true, null, "")
                );

            var infoEvent = new NotificationOccurredEvent(
                new NotificationModel(
                "InfoDemo",
                NotificationType.Info,
                Strings.Notification_Info,
                string.Format(Strings.Notification_InfoDemoLongText, Strings.Notification_DefaultButtonConfirm),
                true, successEvent, "",
                true, null, "",
                true, null, "")
                );

            var Event = new NotificationOccurredEvent(
                new NotificationModel(
                "NoneDemo",
                NotificationType.None,
                Strings.Notification_Welcome,
                string.Format(Strings.Notification_WelcomeDemoLongText, Strings.Notification_DefaultButtonConfirm),
                true, infoEvent, "",
                true, null, "",
                true, null, "")
                );

            EventAggregator?.Publish<NotificationOccurredEvent>(Event);
        }

        #endregion
    }
}
