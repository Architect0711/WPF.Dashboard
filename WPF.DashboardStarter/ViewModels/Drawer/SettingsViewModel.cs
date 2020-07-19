using EventAggregator.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using WPF.Basics.MVVM;
using WPF.DashboardLibrary.DTOs.Settings;
using WPF.DashboardLibrary.Enums;
using WPF.DashboardLibrary.Events.Dashboard;
using WPF.DashboardLibrary.Events.Login;
using WPF.DashboardLibrary.Events.Notifications;
using WPF.DashboardLibrary.Events.Settings;
using WPF.DashboardLibrary.Models.Notification;
using WPF.DashboardLibrary.Models.Settings;
using WPF.DashboardStarter.Dashboard;
using WPF.DashboardStarter.Localization;
using WPF.DashboardStarter.Models.Settings;
using WPF.DashboardStarter.WCF;

namespace WPF.DashboardStarter.ViewModels.Drawer
{
    /// <summary>
    /// This ViewModel provides Data and Functionality to Change Settings in a Backend Application
    /// The "ValueChanged" Event gets fired when the User REQUESTS to change a Setting and a Request is sent to the Backend
    /// After validating the Request, the OnSettingChangeResponse Event can be used to Update the ViewModel to the 
    /// actual Value from the Backend. This way, the View ALWAYS represents the actual State in the Application
    /// </summary>
    public class SettingsViewModel : BaseViewModel
    {
        #region Fields
        private readonly WCFServiceConnection WCFService; 
        #endregion

        #region Properties
        private static object settingsLocker = new object();
        private ObservableCollection<BaseSetting> settings = new ObservableCollection<BaseSetting>();
        public ObservableCollection<BaseSetting> Settings
        {
            get { return settings; }
            set
            {
                OnPropertyChanged(ref settings, value);
            }
        }
        #endregion

        #region Ctor
        public SettingsViewModel(IEventAggregator eventAggregator, ILog log, WCFServiceConnection wcfService) : base(eventAggregator, log)
        {
            WCFService = wcfService;
            Settings = new ObservableCollection<BaseSetting>();
            BindingOperations.EnableCollectionSynchronization(Settings, settingsLocker);

            var HardcodedSettings = new List<BaseSetting>
                {
                    new SkinSetting(
                        "SkinSettingId",
                        9999,
                        Configuration.Skinning.CurrentSkin,
                        false,
                        Strings.Setting_SkinsShort,
                        Strings.Setting_SkinsLong,
                        Strings.Setting_SkinsHover),

                    new LocalizationSetting(
                        "LocalizationSettingId",
                        9998,
                        Configuration.Localization.CurrentLanguage,
                        false,
                        Strings.Setting_LocalizationShort,
                        Strings.Setting_LocalizationLong,
                        Strings.Setting_LocalizationHover),

                    new BooleanSetting(
                        "ShowSidebarSettingId",
                        9997,
                        Properties.Dashboard.Default.ShowSidebar,
                        Strings.Setting_ShowSidebarShort,
                        Strings.Setting_ShowSidebarLong,
                        Strings.Setting_ShowSidebarHover,
                        false,
                        true,
                        false,
                        false)
                };

            foreach (var setting in HardcodedSettings)
            {
                Settings.Add(setting);
                if (!setting.IsReadOnly)
                {
                    setting.ValueChanged += ValueChanged;
                }
            }
        }

        protected override void SubscribeToAllEvents()
        {
            EventAggregator.Subscribe<LoginResponseEvent>(OnLoginProcessedEvent);
            EventAggregator.Subscribe<SettingChangeResponseEvent>(OnSettingChangeResponse);
        }
        #endregion

        #region IEvents
        /// <summary>
        /// This Event should be called when the Processing of a SettingChangeRequestedEvent is finished with the Result
        /// </summary>
        /// <param name="e"></param>
        private void OnSettingChangeResponse(SettingChangeResponseEvent e)
        {
            if (e != null && e.Response != null & e.Response.Setting is BaseSetting)
            {
                UpdateSetting(e.Response.Setting, e.Response.WasChanged);
            }
        }

        private void OnLoginProcessedEvent(LoginResponseEvent e)
        {
            Task.Factory.StartNew(GetAvailableSettings);
        }
        #endregion

        #region Events
        /// <summary>
        /// All the Settings that are not Read-Only will raise this Event when the User Requests changing them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                BaseSetting setting = sender as BaseSetting;
                if (setting != null)
                {
                    if (!setting.ChangeRequiresBackendPermission)
                    {
                        UpdateSetting(setting, true);
                        if (setting.LongText == Strings.Setting_ShowSidebarLong && setting is BooleanSetting boolSet)
                        {
                            Properties.Dashboard.Default.ShowSidebar = boolSet.Value;
                            Properties.Dashboard.Default.Save();
                        }
                    }
                    else
                    {
                        WCFService.RequestSettingChange(DashboardViewModel.Username, setting);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region Functions
        private void UpdateSetting(BaseSetting setting, bool wasChanged)
        {
            #region BooleanSettings
            BooleanSetting newValue = setting as BooleanSetting;
            if (newValue != null)
            {
                var oldValue = Settings.FirstOrDefault(set => set.Equals(newValue));
                if (oldValue != null)
                {
                    BooleanSetting oldBoolValue = oldValue as BooleanSetting;
                    if (oldBoolValue != null)
                    {
                        if (wasChanged)
                        {
                            oldBoolValue.ChangeValue(newValue.Value);
                        }
                        else
                        {
                            oldBoolValue.ChangeValue(oldBoolValue.Value);
                        }
                        PublishSettingChangeNotification(setting, wasChanged);
                        return;
                    }
                }
            }
            #endregion

            #region IntegerSettings
            IntegerSetting newIntValue = setting as IntegerSetting;
            if (newIntValue != null)
            {
                var oldValue = Settings.FirstOrDefault(set => set.Equals(newIntValue));
                if (oldValue != null)
                {
                    IntegerSetting oldIntValue = oldValue as IntegerSetting;
                    if (oldIntValue != null)
                    {
                        if (wasChanged)
                        {
                            oldIntValue.ChangeValue(newIntValue.Value);
                        }
                        else
                        {
                            oldIntValue.ChangeValue(oldIntValue.Value);
                        }
                        PublishSettingChangeNotification(setting, wasChanged);
                        return;
                    }
                }
            }
            #endregion

            #region SkinSettings
            SkinSetting newSkinValue = setting as SkinSetting;
            if (newSkinValue != null)
            {
                var oldValue = Settings.FirstOrDefault(set => set.Equals(newSkinValue));
                if (oldValue != null)
                {
                    SkinSetting oldSkinValue = oldValue as SkinSetting;
                    if (oldSkinValue != null)
                    {
                        if (wasChanged)
                        {
                            oldSkinValue.ChangeValue(newSkinValue.Value);
                            Configuration.Skinning.CurrentSkin = newSkinValue.Value;
                        }
                        else
                        {
                            oldSkinValue.ChangeValue(oldSkinValue.Value);
                        }
                        PublishSettingChangeNotification(setting, wasChanged);
                        return;
                    }
                }
            }
            #endregion

            #region LocalizationSettings
            if (setting is LocalizationSetting newLocalizationValue)
            {
                var oldValue = Settings.FirstOrDefault(set => set.Equals(newLocalizationValue));
                if (oldValue != null)
                {
                    if (oldValue is LocalizationSetting oldLocalizationValue)
                    {
                        if (wasChanged)
                        {
                            oldLocalizationValue.ChangeValue(newLocalizationValue.Value);
                            Configuration.Localization.CurrentLanguage = newLocalizationValue.Value;
                        }
                        else
                        {
                            oldLocalizationValue.ChangeValue(oldLocalizationValue.Value);
                        }
                        PublishSettingChangeNotification(setting, wasChanged);
                        return;
                    }
                }
            }
            #endregion
        }

        private void PublishSettingChangeNotification(BaseSetting setting, bool wasChanged)
        {
            NotificationModel notificationToSend = null;
            if (wasChanged)
            {
                if (setting.ChangeRequiresBackendRestart)
                {
                    EventAggregator.Publish(
                        new NotificationOccurredEvent(
                            new NotificationModel(
                            "SettingChangeResponse",
                            NotificationType.Warning,
                            string.Format(Strings.Setting_ChangeSuccessful, setting.ShortText),
                            Strings.Setting_ChangeRequiresBackendRestart,
                            true, new BackendRestartRequestedEvent(), Strings.Setting_ChangeRequiresRestartAccept,
                            false, null, null,
                            true, null, Strings.Notification_DefaultCancel)));
                }
                else if (setting.ChangeRequiresDashboardRestart)
                {
                    EventAggregator.Publish(
                        new NotificationOccurredEvent(
                            new NotificationModel(
                            "SettingChangeResponse",
                            NotificationType.Warning,
                            string.Format(Strings.Setting_ChangeSuccessful, setting.ShortText),
                            Strings.Setting_ChangeRequiresDashboardRestart,
                            true, new DashboardRestartRequestedEvent(), Strings.Setting_ChangeRequiresRestartAccept,
                            false, null, null,
                            true, null, Strings.Notification_DefaultCancel)));
                }
                else
                {

                    EventAggregator.Publish(
                        new NotificationOccurredEvent(
                            new NotificationModel(
                            "SettingChangeResponse",
                            NotificationType.Success,
                            string.Format(Strings.Setting_ChangeSuccessful, setting.ShortText),
                            string.Empty,
                            true, null, Strings.Setting_ChangeDoesNotRequireRestartAccept ,
                            false, null, null,
                            false, null, null)));
                }
            }
            else
            {
                notificationToSend = new NotificationModel(
                "SettingChangeResponse",
                NotificationType.Error,
                string.Format(Strings.Setting_ChangeSuccessful, setting.ShortText),
                Strings.Setting_ChangeRequiresBackendRestart,
                true, new BackendRestartRequestedEvent(), Strings.Setting_ChangeRequiresRestartAccept,
                true, null, Strings.Setting_ChangeRequiresRestartDecline,
                true, null, Strings.Notification_DefaultCancel);
            }
        }

        private async Task GetAvailableSettings()
        {
            var availableSettings = await WCFService?.GetAvailableSettings(DashboardViewModel.Username);
            lock (settingsLocker)
            {
                foreach (var dto in availableSettings)
                {
                    var setting = GetSettingFromDTO(dto);
                    if (setting != null)
                    {
                        BaseSetting existingSetting =
                            Settings
                            .FirstOrDefault(s => s.Equals(setting));

                        if (existingSetting != null)
                        {
                            existingSetting.Update(setting);
                        }
                        else
                        {
                            Settings.Add(setting);
                            if (!setting.IsReadOnly)
                            {
                                setting.ValueChanged += this.ValueChanged;
                            };
                        }
                    }
                }
            }
        }

        private BaseSetting GetSettingFromDTO(SettingDTO dto)
        {
            BaseSetting baseSetting = null;
            try
            {
                if (dto is BooleanSettingDTO boolDto)
                {
                    return new BooleanSetting(boolDto);
                }

                if (dto is IntegerSettingDTO intDto)
                {
                    return new IntegerSetting(intDto);
                }
            }
            catch (Exception e)
            {
                Log.Error(nameof(GetSettingFromDTO), e);
            }
            return baseSetting;
        } 
        #endregion
    }
}
