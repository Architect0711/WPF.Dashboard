using Unity;
using WPF.DashboardImpl.ViewModels.Dashboard;
using WPF.DashboardImpl.ViewModels.Drawer;
using WPF.DashboardImpl.Views.Dashboard;
using WPF.DashboardImpl.Views.Drawer;

namespace WPF.DashboardImpl.Configuration
{
    public class IndivIoC
    {
        public static void RegisterImplTypes(UnityContainer _container)
        {
            _container.RegisterSingleton<MainView>();
            _container.RegisterSingleton<MainViewModel>()
                .Resolve<MainViewModel>();

            _container.RegisterSingleton<TestView>();
            _container.RegisterSingleton<TestViewModel>()
                .Resolve<TestViewModel>();
        }
    }
}
