using EventAggregator.Interfaces;
using log4net;
using WPF.Basics.MVVM;

namespace WPF.DashboardImpl.ViewModels.Dashboard
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(IEventAggregator eventAggregator, ILog log) : base(eventAggregator, log)
        {

        }
    }
}
