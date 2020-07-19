using EventAggregator.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.ServiceModel;
using System.Threading.Tasks;
using WPF.DashboardImpl.DTOs.Tests;
using WPF.DashboardLibrary.DTOs.Messages;
using WPF.DashboardLibrary.DTOs.Settings;
using WPF.DashboardLibrary.DTOs.Status;
using WPF.DashboardLibrary.Events.Login;
using WPF.DashboardLibrary.Events.Settings;
using WPF.DashboardLibrary.Events.Status;
using WPF.DashboardLibrary.IEvents.Messages;
using WPF.DashboardLibrary.Models.Messages;
using WPF.DashboardLibrary.Models.Settings;
using WPF.DashboardLibrary.Models.Status;
using WPF.DashboardLibrary.RequestResponse.Settings;
using WPF.DashboardStarter.Dashboard;
using WPF.DashboardStarter.DashboardService;

namespace WPF.DashboardStarter.WCF
{
    public class WCFServiceConnection : IDashboardServiceCallback
    {
        #region Fields
        private readonly System.Timers.Timer ReconnectTimer;
        private readonly IEventAggregator EventAggregator;
        private readonly ILog Log;
        private readonly InstanceContext context;
        private DashboardServiceClient client;
        #endregion

        #region Properties
        private bool isConnected = false;
        public bool IsConnected
        {
            get { return isConnected; }
            set
            {
                isConnected = value;
                DashboardViewModel.IsConnected = IsConnected;
                Log.InfoFormat("{0} = {1}", nameof(IsConnected), IsConnected);
                if (IsConnected)
                {
                    ReconnectTimer.Stop();
                }
                else
                {
                    ReconnectTimer.Start();
                }
            }
        }

        protected virtual void IsConnectedChanged()
        { }

        private bool isLoggedIn = false;
        public bool IsLoggedIn
        {
            get { return isLoggedIn; }
            set
            {
                isLoggedIn = value;
                DashboardViewModel.IsLoggedIn = IsLoggedIn;
                Log.InfoFormat("{0} = {1}", nameof(IsLoggedIn), IsLoggedIn);
            }
        }
        
        private bool IsLoggedInAndConnected
        {
            get
            {
                return IsLoggedIn && IsConnected;
            }
        }

        #endregion

        #region Ctor
        public WCFServiceConnection(IEventAggregator eventAggregator, ILog log)
        {
            EventAggregator = eventAggregator;
            Log = log;

            // The Client needs an Instance of the Class that implements the Callback (=Form1)
            context = new InstanceContext(this);
            context.Faulted += Context_Faulted;
            context.Closed += Context_Closed;

            ReconnectTimer = new System.Timers.Timer();
            ReconnectTimer.Interval = 5000;
            ReconnectTimer.Elapsed += ReconnectTimer_Elapsed;
            ReconnectTimer.Start();
        }

        private void Context_Faulted(object sender, System.EventArgs e)
        {
            Log.InfoFormat("----- Context_Faulted -----");
            context.Close();
            IsConnected = false;
        }

        private void Context_Closed(object sender, System.EventArgs e)
        {
            Log.InfoFormat("----- Context_Closed -----");
        }

        private async void ReconnectTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                Log.InfoFormat("----- Starting new Connection Attempt -----");
                await Connect();
            }
            catch (EndpointNotFoundException ex)
            {
                Log.Error(nameof(ex));
            }
            catch (Exception ex)
            {
                Log.Error(nameof(ex));
            }
        }
        #endregion

        #region Connect/Disconnect
        private async Task Connect()
        {
            // Once a Session has been ended, a new Instance of the DashboardServiceClient is required
            client = new DashboardServiceClient(context);

            IsConnected = await client.ConnectAsync();
        }

        public async Task Disconnect()
        {
            IsConnected = await client.DisconnectAsync();
        }
        #endregion

        #region Login/Logout
        public async void Login(string userId, SecureString password, CultureInfo currentCulture)
        {
            if (IsConnected)
            {
                IsLoggedIn = await client.LoginAsync(userId, password, currentCulture);

                EventAggregator?.Publish(
                    new LoginResponseEvent(
                        IsLoggedIn,
                        false,
                        userId,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false));
            }
        }

        public void Logout(string userId)
        {
            if (IsConnected)
            {
                IsLoggedIn = false;
                client.LogoutAsync(userId);
            }
        }
        #endregion

        #region IDashboardServiceCallback
        public void SettingChanged(SettingChangeResponseDTO dto)
        {
            EventAggregator.Publish(new SettingChangeResponseEvent(new SettingChangeResponse(dto)));
        }

        public void StatusChanged(StatusDTO dto)
        {
            EventAggregator?.Publish(
                new StatusChangedEvent(
                    new List<StatusModel>
                    {
                            new StatusModel(dto)
                    }));
        }

        public void StatusesChanged(StatusDTO[] dtos)
        {
            EventAggregator?.Publish(
                new StatusChangedEvent(
                    dtos
                    .ToList()
                    .ConvertAll(st => new StatusModel(st))
                    )
                );
        }

        public void TestResult(TestResultDTO result)
        {

        }

        public void SendMessage(MessageDTO dto)
        {
            EventAggregator?.Publish(new MessageEvent(new MessageModel(dto)));
        }
        #endregion

        #region IDashboardService
        public async Task<SettingDTO[]> GetAvailableSettings(string userId)
        {
            if (IsLoggedInAndConnected)
            {
                return await client.GetAvailableSettingsAsync(userId);
            }
            return new SettingDTO[0];
        }

        public async Task RequestSettingChange(string userId, BaseSetting setting)
        {
            if (IsLoggedInAndConnected)
            {
                await client.RequestSettingChangeAsync(
                    new SettingChangeRequestDTO(userId, setting.ToDto()),
                    userId);
            }
        }

        public async void GetAvailableTests(string userId)
        {
            if (IsLoggedInAndConnected)
            {
                var reply = await client.GetAvailableTestsAsync(userId);
            }
        }

        public async void RequestTest(string userId)
        {
            if (IsLoggedInAndConnected)
            {
                var test = new TestRequestDTO();
                await client.RequestTestAsync(test, userId);

            }
        }

        public async Task<StatusDTO[]> GetAvailableStatusInfo(string userId)
        {
            if (IsLoggedInAndConnected)
            {
                return await client.GetAvailableStatusInfoAsync(userId);
            }
            return new StatusDTO[0];
        }
        #endregion
    }
}
