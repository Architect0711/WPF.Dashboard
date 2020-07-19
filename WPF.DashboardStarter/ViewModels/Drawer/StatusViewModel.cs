using EventAggregator.Interfaces;
using log4net;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using WPF.Basics.MVVM;
using WPF.DashboardLibrary.DTOs.Status;
using WPF.DashboardLibrary.Events.Login;
using WPF.DashboardLibrary.Events.Status;
using WPF.DashboardLibrary.Models.Status;
using WPF.DashboardStarter.Dashboard;
using WPF.DashboardStarter.WCF;

namespace WPF.DashboardStarter.ViewModels.Drawer
{
    public class StatusViewModel : BaseViewModel
    {
        #region Fields
        private readonly WCFServiceConnection WCFService; 
        #endregion

        #region Properties
        private static object statusLocker = new object();

        private ObservableCollection<StatusModel> statuses;
        public ObservableCollection<StatusModel> Statuses
        {
            get { return statuses; }
            private set
            {
                statuses = value;
                OnPropertyChanged<ObservableCollection<StatusModel>>();
            }
        } 
        #endregion

        #region Ctor
        public StatusViewModel(IEventAggregator eventAggregator, ILog log, WCFServiceConnection wcfService) : base(eventAggregator, log)
        {
            WCFService = wcfService;
            Statuses = new ObservableCollection<StatusModel>();
            BindingOperations.EnableCollectionSynchronization(Statuses, statusLocker);
        }

        protected override void SubscribeToAllEvents()
        {
            EventAggregator.Subscribe<StatusChangedEvent>(OnStatusChanged);
            EventAggregator.Subscribe<LoginResponseEvent>(OnLoginProcessedEvent);
        }
        #endregion

        #region IEvents
        private void OnStatusChanged(StatusChangedEvent e)
        {
            if (e != null && e.Statuses != null)
            {
                lock (statusLocker)
                {
                    foreach (var newStatus in e.Statuses)
                    {

                        var oldStatus = Statuses.FirstOrDefault(st => st.Equals(newStatus));
                        if (oldStatus != null)
                        {
                            oldStatus.Update(newStatus);
                        }
                    }
                }
            }
        }

        private void OnLoginProcessedEvent(LoginResponseEvent e)
        {
            Task.Factory.StartNew(GetAvailableStatusInfo);
        }
        #endregion

        #region Functions
        private async Task GetAvailableStatusInfo()
        {
            var availableStatusInfo = await WCFService?.GetAvailableStatusInfo(DashboardViewModel.Username);
            lock (statusLocker)
            {
                foreach (StatusDTO statusInfo in availableStatusInfo)
                {
                    StatusModel current = new StatusModel(statusInfo);
                    StatusModel existing = Statuses.FirstOrDefault(st => st.Equals(current));
                    if (existing != null)
                    {
                        existing.Update(current);
                    }
                    else
                    {
                        Statuses.Add(current);
                    }
                };
            }
        } 
        #endregion
    }
}
