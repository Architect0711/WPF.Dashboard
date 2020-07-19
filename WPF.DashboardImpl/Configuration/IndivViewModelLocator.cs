using Unity;
using WPF.Basics.MVVM;
using WPF.DashboardImpl.ViewModels.Dashboard;
using WPF.DashboardImpl.ViewModels.Drawer;

namespace WPF.DashboardImpl.Configuration
{
    public class IndivViewModelLocator : ViewModelLocator
    {

        public MainViewModel Main
        {
            get { return _container.Resolve<MainViewModel>(); }
        }

        public TestViewModel Test
        {
            get { return _container.Resolve<TestViewModel>(); }
        }
    }
}
