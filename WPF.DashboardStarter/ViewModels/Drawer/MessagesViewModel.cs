using EventAggregator.Interfaces;
using log4net;
using System;
using System.Collections.ObjectModel;
using System.Windows.Data;
using WPF.Basics.MVVM;
using WPF.DashboardLibrary.Enums;
using WPF.DashboardLibrary.IEvents.Messages;
using WPF.DashboardLibrary.Models.Messages;
using WPF.DashboardStarter.WCF;

namespace WPF.DashboardStarter.ViewModels.Drawer
{
    public class MessagesViewModel : BaseViewModel
    {
        #region Fields
        private readonly WCFServiceConnection WCFService;
        #endregion

        #region Properties
        private static object messageLocker = new object();
        private ObservableCollection<MessageModel> messages = new ObservableCollection<MessageModel>();
        private int maxMessages = 20;

        public ObservableCollection<MessageModel> Messages
        {
            get { return messages; }
            set
            {
                OnPropertyChanged(ref messages, value);
            }
        }
        #endregion

        public MessagesViewModel(IEventAggregator eventAggregator, ILog log, WCFServiceConnection wcfService) : base(eventAggregator, log)
        {
            WCFService = wcfService;
            Messages = new ObservableCollection<MessageModel>();
            Messages.Add(new MessageModel("Test1 aaaaaaaaaaaa aaaaaaaaaaaa aaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaa aaaaa", DateTime.Now, MessageType.None));
            Messages.Add(new MessageModel("Test2 aaaaaaaaaaaa aaaaaaaaaaaa aaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaa aaaaa", DateTime.Now, MessageType.Warn));
            Messages.Add(new MessageModel("Test3 aaaaaaaaaaaa aaaaaaaaaaaa aaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaa aaaaa", DateTime.Now, MessageType.Error));
            BindingOperations.EnableCollectionSynchronization(Messages, messageLocker);
        }

        protected override void SubscribeToAllEvents()
        {
            EventAggregator?.Subscribe<MessageEvent>(OnMessageReceived);
        }

        private void OnMessageReceived(MessageEvent e)
        {
            try
            {
                lock (messageLocker)
                {
                    Log.InfoFormat("{0} => {1}", nameof(OnMessageReceived), e.Message.ToString());
                    Messages.Add(e.Message);
                    if (Messages.Count > maxMessages)
                    {
                        Log.InfoFormat("{0} => Removed Message {1}", nameof(OnMessageReceived), Messages[0].ToString());
                        Messages.RemoveAt(0);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
    }
}
