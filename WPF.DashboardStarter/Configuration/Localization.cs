using System.Collections.Generic;
using System.Globalization;

namespace WPF.DashboardStarter.Configuration
{
    public class Localization
    {
        public static List<string> AvailableLanguages =
        new List<string>
        {
            "Windows",
            "de-DE",
            "en-US"
        };
        private static CultureInfo currentCultureInfo;

        public static string CurrentLanguage
        {
            get
            {
                return Properties.Dashboard.Default.Localization;
            }
            set
            {
                Properties.Dashboard.Default.Localization = value;
                Properties.Dashboard.Default.Save();
            }
        }

        public static CultureInfo CurrentCultureInfo
        {
            get => currentCultureInfo;
            set => currentCultureInfo = value;
        }

    }
}
