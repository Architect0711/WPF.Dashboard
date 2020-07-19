using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using Unity;
using WPF.Basics.MVVM;
using WPF.DashboardImpl.Converters;
using WPF.DashboardStarter.Configuration;
using WPF.DashboardStarter.Content;
using WPF.DashboardStarter.Dashboard;
using WPF.DashboardStarter.Views.Drawer;

namespace WPF.DashboardStarter.Converters
{
    public class DrawerContentToBaseUserControlConverter : IndivDrawerContentConverter, IValueConverter
    {
        public DrawerContentToBaseUserControlConverter()
        {
            Controls[DrawerContent.LaunchPrograms] = DashboardViewModelLocator._container.Resolve<LaunchProgramsView>();
            Controls[DrawerContent.Settings] = DashboardViewModelLocator._container.Resolve<SettingsView>();
            Controls[DrawerContent.Messages] = DashboardViewModelLocator._container.Resolve<MessagesView>();
            Controls[DrawerContent.Status] = DashboardViewModelLocator._container.Resolve<StatusView>();
            Controls[DrawerContent.Menu] = DashboardViewModelLocator._container.Resolve<MenuView>();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string requestedContent)
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
