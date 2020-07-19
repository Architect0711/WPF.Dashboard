using EventAggregator.Implementations.Nonstatic.Async;
using EventAggregator.Interfaces;
using Unity;
using Unity.log4net;
using WPF.DashboardImpl.Configuration;
using WPF.DashboardLibrary.Interfaces;
using WPF.DashboardStarter.Dashboard;
using WPF.DashboardStarter.ViewModels.Dashboard;
using WPF.DashboardStarter.ViewModels.Drawer;
using WPF.DashboardStarter.ViewModels.Popup;
using WPF.DashboardStarter.Views.Dashboard;
using WPF.DashboardStarter.Views.Drawer;
using WPF.DashboardStarter.Views.Popup;
using WPF.DashboardStarter.WCF;

namespace WPF.DashboardStarter.Configuration
{
    public class IoC : IndivIoC
    {
        public static void RegisterTypes(UnityContainer _container)
        {
            _container.AddNewExtension<Log4NetExtension>();

            _container.RegisterType<IEventAggregator, NonstaticAsyncEventAggregator>();

            _container.RegisterSingleton<WCFServiceConnection>()
                .Resolve<WCFServiceConnection>();

            _container.RegisterType<IMenuItemService, Menu>();

            RegisterImplTypes(_container);

            // We need to resolve the ViewModels right away so they can get the IEvents from IEventAggregator
            _container.RegisterSingleton<MenuView>();
            _container.RegisterSingleton<MenuViewModel>()
                .Resolve<MenuViewModel>();

            _container.RegisterSingleton<DisconnectedView>();
            _container.RegisterSingleton<DisconnectedViewModel>()
                .Resolve<DisconnectedViewModel>();

            _container.RegisterSingleton<LoginView>();
            _container.RegisterSingleton<LoginViewModel>()
                .Resolve<LoginViewModel>();

            _container.RegisterSingleton<SettingsView>();
            _container.RegisterSingleton<SettingsViewModel>()
                .Resolve<SettingsViewModel>();

            _container.RegisterSingleton<StatusView>();
            _container.RegisterSingleton<StatusViewModel>()
                .Resolve<StatusViewModel>();

            _container.RegisterSingleton<MessagesView>();
            _container.RegisterSingleton<MessagesViewModel>()
                .Resolve<MessagesViewModel>();

            _container.RegisterSingleton<LaunchProgramsView>();
            _container.RegisterSingleton<LaunchProgramsViewModel>()
                .Resolve<LaunchProgramsViewModel>();

            _container.RegisterSingleton<AboutWindowView>();
            _container.RegisterSingleton<AboutWindowViewModel>()
                .Resolve<AboutWindowViewModel>();

            _container.RegisterSingleton<NotificationWindowView>();
            _container.RegisterSingleton<NotificationWindowViewModel>()
                .Resolve<NotificationWindowViewModel>();

            _container.RegisterSingleton<SkinningView>();
            _container.RegisterSingleton<DashboardViewModel>()
                .Resolve<DashboardViewModel>();
        }

    }
}

