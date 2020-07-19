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
using WPF.DashboardStarter.Enums;
using WPF.DashboardStarter.Views.Popup;

namespace WPF.DashboardStarter.Converters
{

    public class PopupContentToBaseUserControlConverter : IndivPopupContentConverter, IValueConverter
    {
        public PopupContentToBaseUserControlConverter()
        {
            Controls[PopupContent.Notification] = DashboardViewModelLocator._container.Resolve<NotificationWindowView>();
            Controls[PopupContent.About] = DashboardViewModelLocator._container.Resolve<AboutWindowView>();
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
