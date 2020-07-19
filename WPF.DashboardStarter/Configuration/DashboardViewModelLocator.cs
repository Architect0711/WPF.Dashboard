using Unity;
using WPF.DashboardImpl.Configuration;
using WPF.DashboardImpl.ViewModels.Dashboard;
using WPF.DashboardStarter.Dashboard;
using WPF.DashboardStarter.ViewModels.Dashboard;
using WPF.DashboardStarter.ViewModels.Drawer;
using WPF.DashboardStarter.ViewModels.Popup;

namespace WPF.DashboardStarter.Configuration
{
    public class DashboardViewModelLocator : IndivViewModelLocator
    {
        public DashboardViewModelLocator()
        {

        }

        public DashboardViewModel Dashboard
        {
            get { return _container.Resolve<DashboardViewModel>(); }
        }

        public DisconnectedViewModel Disconnected
        {
            get { return _container.Resolve<DisconnectedViewModel>(); }
        }

        public MenuViewModel Menu
        {
            get { return _container.Resolve<MenuViewModel>(); }
        }

        public LoginViewModel Login
        {
            get { return _container.Resolve<LoginViewModel>(); }
        }

        public SettingsViewModel Settings
        {
            get { return _container.Resolve<SettingsViewModel>(); }
        }

        public StatusViewModel Status
        {
            get { return _container.Resolve<StatusViewModel>(); }
        }

        public MessagesViewModel Messages
        {
            get { return _container.Resolve<MessagesViewModel>(); }
        }

        public LaunchProgramsViewModel Launch
        {
            get { return _container.Resolve<LaunchProgramsViewModel>(); }
        }

        public AboutWindowViewModel About
        {
            get { return _container.Resolve<AboutWindowViewModel>(); }
        }

        public NotificationWindowViewModel Notification
        {
            get { return _container.Resolve<NotificationWindowViewModel>(); }
        }
    }
}
