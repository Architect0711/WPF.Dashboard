using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Timers;
using WPF.DashboardImpl.DTOs.Tests;
using WPF.DashboardImpl.WCF.Interfaces;
using WPF.DashboardLibrary.DTOs.Messages;
using WPF.DashboardLibrary.DTOs.Settings;
using WPF.DashboardLibrary.DTOs.Status;
using WPF.DashboardLibrary.Enums;
using WPF.DashboardLibrary.Interfaces;

namespace WPF.DashboardImpl.WCF.Implementation
{
    public class DashboardService : IDashboardService
    {
        #region Fields
        protected readonly IDashboardServiceCallback Client;

        protected readonly string ClientId = string.Empty;
        #endregion

        #region Properties
        private bool isConnected;
        public bool IsConnected
        {
            get { return isConnected; }
            set
            {
                isConnected = value;
                Console.WriteLine("[" + DateTime.Now.ToString() + "][" + ClientId + "][" + nameof(IsConnected) + " = " + IsConnected + "]");
            }
        } 
        #endregion

        #region Ctor
        public DashboardService()
        {
            // https://stackoverflow.com/questions/3277256/identifying-wcf-client-id
            OperationContext opContext = OperationContext.Current;
            opContext.Channel.Faulted += new EventHandler(Channel_Faulted);
            opContext.Channel.Closed += new EventHandler(Channel_Closed);
            RequestContext requestContext = opContext.RequestContext;
            MessageHeaders headers = requestContext.RequestMessage.Headers;
            int headerIndex = headers.FindHeader("ClientIdentification", "");
            if (headerIndex >= 0)
            {
                ClientId = headers.GetHeader<string>(headerIndex);
            }
            else
            {
                ClientId = "No ClientIdentification found";
            }
            Client = opContext.GetCallbackChannel<IDashboardServiceCallback>();

            IsConnected = true;

            rnd = new Random();

            timer = new Timer();
            timer.Interval = 5000;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Channel_Faulted(object sender, EventArgs e)
        {
            Console.WriteLine("[" + DateTime.Now.ToString() + "][" + ClientId + "] => " + nameof(Channel_Faulted));
            IsConnected = false;
            timer.Stop();
        }

        private void Channel_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("[" + DateTime.Now.ToString() + "][" + ClientId + "] => " + nameof(Channel_Closed));
            IsConnected = false;
            timer.Stop();
        }
        #endregion

        #region IDashboardStarterService
        public virtual List<SettingDTO> GetAvailableSettings(string UserId)
        {
            Console.WriteLine("[" + DateTime.Now.ToString() + "][" + ClientId + "][" + UserId + "] called " + nameof(GetAvailableSettings));
            return AvailableSettings;
        }

        public virtual List<StatusDTO> GetAvailableStatusInfo(string UserId)
        {
            Console.WriteLine("[" + DateTime.Now.ToString() + "][" + ClientId + "][" + UserId + "] called " + nameof(GetAvailableStatusInfo));
            return AvailableStatusInfo;
        }

        public virtual List<TestDTO> GetAvailableTests(string UserId)
        {
            Console.WriteLine("[" + DateTime.Now.ToString() + "][" + ClientId +"][" + UserId + "] called " + nameof(GetAvailableTests));
            return AvailableTests;
        }

        public virtual bool Connect()
        {
            Console.WriteLine("[" + DateTime.Now.ToString() + "][" + ClientId + "] ---- connected ----");
            return true;
        }

        public virtual bool Disconnect()
        {
            Console.WriteLine("[" + DateTime.Now.ToString() + "][" + ClientId + "] ---- disconnected ----");
            return true;
        }

        public virtual bool Login(string userId, SecureString password, CultureInfo cultureInfo)
        {
            Console.WriteLine("[" + DateTime.Now.ToString() + "][" + ClientId + "][" + userId + "] ---- logged in ----");

            // We would use this to get the Password from the SecureString
            // http://www.vcskicks.com/secure-string.php
            IntPtr stringPointer = Marshal.SecureStringToBSTR(password);
            string normalString = Marshal.PtrToStringBSTR(stringPointer);
            Marshal.ZeroFreeBSTR(stringPointer);

            timer.Start();

            return true;
        }

        public virtual bool Logout(string userId)
        {
            timer.Stop();
            Console.WriteLine("[" + DateTime.Now.ToString() + "][" + ClientId + "][" + userId + "] ---- logged out ----");
            return true;
        }

        public virtual void RequestSettingChange(SettingChangeRequestDTO settingChangeRequest, string UserId)
        {
            Console.WriteLine("[" + DateTime.Now.ToString() + "][" + ClientId + "][" + UserId + "] called " + nameof(RequestSettingChange) + ": " + settingChangeRequest.ToString());
            Client.SettingChanged(new SettingChangeResponseDTO(UserId, true, "Demo => always true", settingChangeRequest.SettingToChange));
        }

        public virtual void RequestTest(TestRequestDTO test, string UserId)
        {
            Console.WriteLine("[" + DateTime.Now.ToString() + "][" + ClientId + "][" + UserId + "] called " + nameof(RequestTest) + ": " + test.ToString());
        }
        #endregion

        #region Demo        
        private static List<StatusDTO> AvailableStatusInfo = new List<StatusDTO>
            {
                new StatusDTO(
                    "asdoihasd",
                    0,
                    "Cloud Connection",
                    "Connected (18 ms)",
                    Color.Green),

                new StatusDTO(
                    "guuiiiiiiiddddddd",
                    1,
                    "Database Connection",
                    "SQL Server - 3 Connection Attempts OK",
                    Color.Green),

                new StatusDTO(
                    "ASDIBoooo",
                    2,
                    "Barcode Scanner",
                    "COM Port already in use",
                    Color.Red),

                new StatusDTO(
                    "asppppdiiii",
                    3,
                    "Station 1",
                    "Waiting for User Input",
                    Color.Goldenrod),

                new StatusDTO(
                    "aaaaaaasssssssssssssmmm",
                    4,
                    "Station 2",
                    "Waiting for User Input",
                    Color.Goldenrod),

                new StatusDTO(
                    "irgendwas",
                    5,
                    "Station 3",
                    "Waiting for User Input",
                    Color.Goldenrod)
            };

        private static List<SettingDTO> AvailableSettings = new List<SettingDTO>
                {
                    new BooleanSettingDTO(
                        "DemoSetting0001",
                        0,
                        false,
                        false,
                        true,
                        "Use Cloud Connection",
                        "Turn off to use Local Working Copy",
                        "Disable this, if the Network is unavailable or unreliable",
                        true),

                    new BooleanSettingDTO(
                        "DemoSetting0002",
                        2,
                        false,
                        false,
                        false,
                        "Perform Startup Tests",
                        "Perform Connection Tests on Startup",
                        "Disabling this will decrease Startup time significantly",
                        true),

                    new IntegerSettingDTO(
                        "DemoSetting0003",
                        1,
                        false,
                        false,
                        true,
                        "Order Count",
                        "Request this many Orders at once",
                        "Changing this Setting will Require restarting the Station",
                        2,
                        new List<int> { 1, 2, 3, 4, 5 })
                };

        private static List<TestDTO> AvailableTests = new List<TestDTO>
                {
                    new TestDTO()
                };

        private Timer timer;

        private Random rnd;

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                if (IsConnected)
                {
                    int action = rnd.Next(0, 3);
                    switch (action)
                    {
                        case 0:
                            ChangeARandomStatusItem();
                            break;

                        case 1:
                            //ChangeARandomSetting();
                            break;

                        case 2:
                            SendMessage();
                            break;

                        case 3:
                            SendMessage();
                            break;

                        default:

                            break;
                    }
                }
                else
                {
                    timer.Stop();
                }
            }

        private void SendMessage()
        {
            Console.WriteLine("[" + DateTime.Now.ToString() + "] randomly called " + nameof(SendMessage));
            Client.SendMessage(new MessageDTO("Hello World", MessageType.Warn));
        }

        private void ChangeMultipleRandomStatusItems()
        {
            Console.WriteLine("[" + DateTime.Now.ToString() + "] randomly called " + nameof(ChangeMultipleRandomStatusItems));

            List<StatusDTO> changedStatuses = new List<StatusDTO>();
            List<int> usedIndices = new List<int>();
            int cntChanged = AvailableStatusInfo.Count >= 2 ? 2 : AvailableStatusInfo.Count;

            int i = 0;
            while (i <= cntChanged)
            {
                int rnd = new Random().Next(0, AvailableStatusInfo.Count - 1);
                if (!usedIndices.Contains(rnd))
                {
                    usedIndices.Add(rnd);
                    var status = AvailableStatusInfo.ElementAt(rnd);

                    if (status.BackgroundColor == Color.Red)
                    {
                        status.BackgroundColor = Color.Goldenrod;
                        status.HoverText = "Warning";
                    }
                    else if(status.BackgroundColor == Color.Goldenrod)
                    {
                        status.BackgroundColor = Color.Green;
                        status.HoverText = "Ok";
                    }
                    else if (status.BackgroundColor == Color.Green)
                    {
                        status.BackgroundColor = Color.Red;
                        status.HoverText = "Error";
                    }

                    changedStatuses.Add(status);
                }
                i++;
            }

            if (changedStatuses.Count > 0)
            {
                Client.StatusesChanged(changedStatuses);
            }
        }

        private void ChangeARandomSetting()
        {
            Console.WriteLine("[" + DateTime.Now.ToString() + "] randomly called " + nameof(ChangeARandomSetting));


            int rnd = new Random().Next(0, AvailableSettings.Count - 1);
            var set = AvailableSettings.ElementAt(rnd);

            if (set is BooleanSettingDTO booleanSettingDTO)
            {
                booleanSettingDTO.Value = !booleanSettingDTO.Value;
                Client.SettingChanged(
                    new SettingChangeResponseDTO(
                        "Demo",
                        true,
                        "Setting was randomly changed",
                        booleanSettingDTO));
            }
            else if (set is IntegerSettingDTO integerSettingDTO)
            {
                int rndPos = new Random().Next(0, integerSettingDTO.PossibleValues.Count - 1);
                var rndVal = integerSettingDTO.PossibleValues.ElementAt(rnd);
                bool wasChanged = integerSettingDTO.Value != rndVal;
                integerSettingDTO.Value = rndVal;
                Client.SettingChanged(
                    new SettingChangeResponseDTO(
                        "Demo",
                        wasChanged,
                        "Setting was randomly changed",
                        integerSettingDTO));
            }
        }

        private void ChangeARandomStatusItem()
        {
            Console.WriteLine("[" + DateTime.Now.ToString() + "] randomly called " + nameof(ChangeARandomStatusItem));

            int rnd = new Random().Next(0, AvailableStatusInfo.Count - 1);
            var status = AvailableStatusInfo.ElementAt(rnd);

            if (status.BackgroundColor == Color.Red)
            {
                status.BackgroundColor = Color.Goldenrod;
                status.HoverText = "Warning";
            }
            else if (status.BackgroundColor == Color.Goldenrod)
            {
                status.BackgroundColor = Color.Green;
                status.HoverText = "Ok";
            }
            else if (status.BackgroundColor == Color.Green)
            {
                status.BackgroundColor = Color.Red;
                status.HoverText = "Error";
            }

            Client.StatusChanged(status);
        }
        #endregion
    }
}
