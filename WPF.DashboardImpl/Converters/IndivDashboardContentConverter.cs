using System.Collections.Generic;
using Unity;
using WPF.Basics.MVVM;
using WPF.DashboardImpl.Configuration;
using WPF.DashboardImpl.Content;
using WPF.DashboardImpl.Views.Dashboard;

namespace WPF.DashboardImpl.Converters
{
    /// <summary>
    /// Add new Dashboard Content here
    /// </summary>
    public class IndivDashboardContentConverter
    {
        protected Dictionary<string, BaseUserControl> Controls
            = new Dictionary<string, BaseUserControl>();

        public IndivDashboardContentConverter()
        {
            Controls[IndivDashboardContent.Main] = IndivViewModelLocator._container.Resolve<MainView>();
        }

    }
}
