using EventAggregator.Interfaces;
using log4net;
using WPF.Basics.MVVM;
using WPF.DashboardStarter.Dashboard;
using WPF.DashboardStarter.Localization;
using WPF.DashboardStarter.WCF;

namespace WPF.DashboardStarter.ViewModels.Dashboard
{
    public class DisconnectedViewModel : BaseViewModel
    {
        private readonly WCFServiceConnection WCFService;

        public string CompanyLogoPath_Large
        {
            get { return Configuration.Paths.CompanyLogo_Large; }
        }

        public string ConnectingText
        {
            get { return Strings.Disconnected_Connecting; }
        }

        public DisconnectedViewModel(IEventAggregator eventAggregator, ILog log, WCFServiceConnection wcfService) : base(eventAggregator, log)
        {
            WCFService = wcfService;
        }

    }
}