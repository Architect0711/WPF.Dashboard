using System;
using System.Globalization;
using System.Windows.Data;
using Unity;
using WPF.DashboardImpl.Converters;
using WPF.DashboardStarter.Configuration;
using WPF.DashboardStarter.Content;
using WPF.DashboardStarter.Dashboard;
using WPF.DashboardStarter.Views.Dashboard;

namespace WPF.DashboardStarter.Converters
{
    public class DashboardContentToBaseUserControlConverter : IndivDashboardContentConverter, IValueConverter
    {
        public DashboardContentToBaseUserControlConverter()
        {
            Controls[DashboardContent.Disconnected] = DashboardViewModelLocator._container.Resolve<DisconnectedView>();
            Controls[DashboardContent.Skinning] = DashboardViewModelLocator._container.Resolve<SkinningView>();
            Controls[DashboardContent.Login] = DashboardViewModelLocator._container.Resolve<LoginView>();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string requestedContent)
            {
                if (Controls.ContainsKey(requestedContent))
                {
                    return Controls[requestedContent];
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
