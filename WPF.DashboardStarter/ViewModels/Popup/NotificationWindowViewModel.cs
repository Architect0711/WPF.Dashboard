using EventAggregator.Interfaces;
using log4net;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Input;
using WPF.Basics.MVVM;
using WPF.DashboardLibrary.Enums;
using WPF.DashboardLibrary.Events.Notifications;
using WPF.DashboardStarter.Configuration;
using WPF.DashboardStarter.Localization;

namespace WPF.DashboardStarter.ViewModels.Popup
{
    public class NotificationWindowViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Enum to indicate the Type of Notification
        /// </summary>
        private NotificationType _NotificationType = NotificationType.None;
        public NotificationType NotificationType
        {
            get { return _NotificationType; }
            set { OnPropertyChanged(ref _NotificationType, value); }
        }

        /// <summary>
        /// Image based on the <see cref="NotificationType"/>
        /// </summary>
        private string _NotificationImage;
        public string NotificationImage
        {
            get { return _NotificationImage; }
            set { OnPropertyChanged(ref _NotificationImage, value); }
        }

        private Dictionary<NotificationType, string> NotificationImages = new Dictionary<NotificationType, string>();

        /// <summary>
        /// Headline of the Notification
        /// </summary>
        private string _NotificationTitle;
        public string NotificationTitle
        {
            get { return _NotificationTitle; }
            set { OnPropertyChanged(ref _NotificationTitle, value); }
        }

        /// <summary>
        /// Descriptive Text for the User
        /// </summary>
        private string _NotificationText;
        public string NotificationText
        {
            get { return _NotificationText; }
            set { OnPropertyChanged(ref _NotificationText, value); }
        }

        /// <summary>
        /// All Data for confirming the Notification:
        /// - CanConfirm: Can it be confirmed?
        /// - ConfirmCommand: Command to bind to the View
        /// - ConfirmInfo: Info Text - What happens, if the User confirms?
        /// - ConfirmEvent: An IEvent that will be published, if the User confirms
        /// </summary>
        private bool _CanConfirm;
        public bool CanConfirm
        {
            get { return _CanConfirm; }
            set { OnPropertyChanged(ref _CanConfirm, value); }
        }
        private ICommand _Confirm;
        public ICommand ConfirmCommand
        {
            get
            {
                if (_Confirm == null)
                {
                    _Confirm = new RelayCommand(
                        p => (CanConfirm),
                        p => this.Confirm());
                }
                return _Confirm;
            }
        }
        private string _ConfirmInfo;
        public string ConfirmInfo
        {
            get { return _ConfirmInfo; }
            set { OnPropertyChanged(ref _ConfirmInfo, value); }
        }
        private string _ConfirmButton = Strings.Notification_DefaultButtonConfirm;
        public string ConfirmButton
        {
            get { return _ConfirmButton; }
            set { OnPropertyChanged(ref _ConfirmButton, value); }
        }
        private IEvent ConfirmEvent;
        private void Confirm()
        {
            try
            {
                EventAggregator?.Publish(new NotificationHandledEvent(true, false, false));
                if (ConfirmEvent != null)
                {
                    if (ConfirmEvent.GetType() == typeof(NotificationOccurredEvent))
                    {
                        Thread.Sleep(100);
                    }
                    EventAggregator?.Publish(ConfirmEvent);
                }
            }
            catch (System.Exception)
            {

            }
        }

        /// <summary>
        /// All Data for declining the Notification:
        /// - CanDecline: Can it be declined?
        /// - DeclineCommand: Command to bind to the View
        /// - DeclineInfo: Info Text - What happens, if the User declines?
        /// - DeclineEvent: An IEvent that will be published, if the User declines
        /// </summary>
        private bool _CanDecline;
        public bool CanDecline
        {
            get { return _CanDecline; }
            set { OnPropertyChanged(ref _CanDecline, value); }
        }
        private ICommand _Decline;
        public ICommand DeclineCommand
        {
            get
            {
                if (_Decline == null)
                {
                    _Decline = new RelayCommand(
                        p => (CanDecline),
                        p => this.Decline());
                }
                return _Decline;
            }
        }
        private string _DeclineInfo;
        public string DeclineInfo
        {
            get { return _DeclineInfo; }
            set { OnPropertyChanged(ref _DeclineInfo, value); }
        }
        private string _DeclineButton = Strings.Notification_DefaultButtonDecline;
        public string DeclineButton
        {
            get { return _DeclineButton; }
            set { OnPropertyChanged(ref _DeclineButton, value); }
        }
        private IEvent DeclineEvent;
        private void Decline()
        {
            try
            {
                EventAggregator?.Publish(new NotificationHandledEvent(false, true, false));
                if (DeclineEvent != null)
                {
                    if (ConfirmEvent.GetType() == typeof(NotificationOccurredEvent))
                    {
                        Thread.Sleep(100);
                    }
                    EventAggregator?.Publish(DeclineEvent);
                }
            }
            catch (System.Exception)
            {

            }
        }

        /// <summary>
        /// All Data for canceling the Notification:
        /// - CanCancel: Can it be canceled?
        /// - CancelCommand: Command to bind to the View
        /// - CancelInfo: Info Text - What happens, if the User cancels?
        /// - CancelEvent: An IEvent that will be published, if the User cancels
        /// </summary>
        private bool _CanCancel;
        public bool CanCancel
        {
            get { return _CanCancel; }
            set { OnPropertyChanged(ref _CanCancel, value); }
        }
        private ICommand _Cancel;
        public ICommand CancelCommand
        {
            get
            {
                if (_Cancel == null)
                {
                    _Cancel = new RelayCommand(
                        p => (CanCancel),
                        p => this.Cancel());
                }
                return _Cancel;
            }
        }
        private string _CancelInfo;
        public string CancelInfo
        {
            get { return _CancelInfo; }
            set { OnPropertyChanged(ref _CancelInfo, value); }
        }
        private string _CancelButton = Strings.Notification_DefaultButtonCancel;
        public string CancelButton
        {
            get { return _CancelButton; }
            set { OnPropertyChanged(ref _CancelButton, value); }
        }
        private IEvent CancelEvent;
        private void Cancel()
        {
            try
            {
                EventAggregator?.Publish(new NotificationHandledEvent(false, false, true));
                if (CancelEvent != null)
                {
                    if (ConfirmEvent.GetType() == typeof(NotificationOccurredEvent))
                    {
                        Thread.Sleep(100);
                    }
                    EventAggregator?.Publish(CancelEvent);
                }
            }
            catch (System.Exception)
            {

            }
        }

        #endregion

        #region Ctor

        public NotificationWindowViewModel(IEventAggregator eventAggregator, ILog log) : base(eventAggregator, log)
        {
            NotificationImages[NotificationType.None] = string.Empty;
            NotificationImages[NotificationType.Info] = Paths.NotificationWindowInfo;
            NotificationImages[NotificationType.Success] = Paths.NotificationWindowSuccess;
            NotificationImages[NotificationType.Warning] = Paths.NotificationWindowWarn;
            NotificationImages[NotificationType.Error] = Paths.NotificationWindowError;
            NotificationImages[NotificationType.Fatal] = Paths.NotificationWindowFatal;
        }

        #endregion

        #region Init

        protected override void SubscribeToAllEvents()
        {
            EventAggregator.Subscribe<NotificationOccurredEvent>(OnNotificationOccuredEvent);
        }

        #endregion

        #region Events

        private void OnNotificationOccuredEvent(NotificationOccurredEvent e)
        {
            if (e != null && e.Notification != null)
            {
                var notification = e.Notification;

                NotificationTitle = notification.NotificationTitle;
                NotificationType = notification.NotificationType;
                NotificationText = notification.NotificationText;

                CanConfirm = notification.CanConfirm;
                ConfirmInfo = notification.ConfirmInfo;
                ConfirmEvent = notification.ConfirmEvent;

                CanDecline = notification.CanDecline;
                DeclineInfo = notification.DeclineInfo;
                DeclineEvent = notification.DeclineEvent;

                CanCancel = notification.CanCancel;
                CancelInfo = notification.CancelInfo;
                CancelEvent = notification.CancelEvent;

                if (NotificationImages.ContainsKey(NotificationType))
                {
                    NotificationImage = NotificationImages[NotificationType];
                }
            }
        }

        #endregion
    }
}
