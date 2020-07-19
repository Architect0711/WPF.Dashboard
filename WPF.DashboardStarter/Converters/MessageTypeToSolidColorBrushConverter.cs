using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using WPF.DashboardLibrary.Enums;

namespace WPF.DashboardStarter.Converters
{
    public class MessageTypeToSolidColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is MessageType messageType)
            {
                switch (messageType)
                {
                    case MessageType.Warn:
                        return Application.Current.FindResource("SecondaryWarning");
                    case MessageType.Error:
                        return Application.Current.FindResource("SecondaryError");
                    default:
                        return Application.Current.FindResource("PrimaryBackground");
                }
            }

            return Application.Current.FindResource("PrimaryBackground");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
