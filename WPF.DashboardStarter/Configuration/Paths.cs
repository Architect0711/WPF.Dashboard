using System;
using System.IO;
using WPF.DashboardImpl.Configuration;

namespace WPF.DashboardStarter.Configuration
{
    /// <summary>
    /// All Paths required for the Application
    /// </summary>
    public class Paths : IndivPaths
    {
        private static readonly new string _Color = Skinning.IconPath;

        /// <summary>
        /// All Image Paths related to the Titlebar (Except <see cref="_CompanyLogo"/>)
        /// </summary>
        private static readonly string _ExitIcon = "icons8-close-window-32.png";
        private static readonly string _LogoutIcon = "icons8-exit-32.png";
        private static readonly string _AboutIcon = "icons8-question-mark-48.png";
        private static readonly string _MinimizeIcon = "icons8-minimize-window-32.png";
        private static readonly string _MaximizeIcon = "icons8-maximize-window-32.png";

        public static string ExitIcon
        {
            get { return Path.Combine(_Directory, _Folder, _Icons, _Color, _ExitIcon); }
        }
        public static string LogoutIcon
        {
            get { return Path.Combine(_Directory, _Folder, _Icons, _Color, _LogoutIcon); }
        }
        public static string AboutIcon
        {
            get { return Path.Combine(_Directory, _Folder, _Icons, _Color, _AboutIcon); }
        }
        public static string MinimizeIcon
        {
            get { return Path.Combine(_Directory, _Folder, _Icons, _Color, _MinimizeIcon); }
        }
        public static string MaximizeIcon
        {
            get { return Path.Combine(_Directory, _Folder, _Icons, _Color, _MaximizeIcon); }
        }

        /// <summary>
        /// All Image Paths related to the Sidebar
        /// </summary>
        private static readonly string _ToggleSidebarIcon = "icons8-arrow-32.png";
        private static readonly string _LaunchProgramsIcon = "icons8-external-link-32.png";
        private static readonly string _SettingsIcon = "icons8-settings-32.png";
        private static readonly string _MessageIcon = "icons8-nachricht-32.png";
        private static readonly string _UnreadMessageIcon = "icons8-dringende-nachricht-32.png";
        private static readonly string _BurgerIcon = "icons8-menu-32.png";

        public static string ToggleSidebarIcon
        {
            get { return Path.Combine(_Directory, _Folder, _Icons, _Color, _ToggleSidebarIcon); }
        }

        public static string LaunchProgramsIcon
        {
            get { return Path.Combine(_Directory, _Folder, _Icons, _Color, _LaunchProgramsIcon); }
        }

        public static string SettingsIcon
        {
            get { return Path.Combine(_Directory, _Folder, _Icons, _Color, _SettingsIcon); }
        }

        public static string MessageIcon
        {
            get { return Path.Combine(_Directory, _Folder, _Icons, _Color, _MessageIcon); }
        }

        public static string UnreadMessageIcon
        {
            get { return Path.Combine(_Directory, _Folder, _Icons, _Color, _UnreadMessageIcon); }
        }

        public static string BurgerIcon
        {
            get { return Path.Combine(_Directory, _Folder, _Icons, _Color, _BurgerIcon); }
        }

        /// <summary>
        /// All Image Paths related to the NotificationWindow
        /// </summary>
        private static readonly string _NotificationWindow = "NotificationWindow";

        private static readonly string _Success = "icons8-success-64.png";
        private static readonly string _Info = "icons8-info-64.png";
        private static readonly string _Warn = "icons8-warn-64.png";
        private static readonly string _Error = "icons8-error-64.png";
        private static readonly string _Fatal = "icons8-fatal-64.png";

        public static string NotificationWindowInfo
        {
            get { return Path.Combine(_Directory, _Folder, _NotificationWindow, _Info); }
        }
        public static string NotificationWindowSuccess
        {
            get { return Path.Combine(_Directory, _Folder, _NotificationWindow, _Success); }
        }
        public static string NotificationWindowWarn
        {
            get { return Path.Combine(_Directory, _Folder, _NotificationWindow, _Warn); }
        }
        public static string NotificationWindowError
        {
            get { return Path.Combine(_Directory, _Folder, _NotificationWindow, _Error); }
        }
        public static string NotificationWindowFatal
        {
            get { return Path.Combine(_Directory, _Folder, _NotificationWindow, _Fatal); }
        }

        /// <summary>
        /// All Image Paths related to the Company Logo
        /// </summary>
        private static readonly string _CompanyLogo = "CompanyLogo";
        private static readonly string _CompanyLogo_Small = "company-logo-small.png";
        private static readonly string _CompanyLogo_Large = "company-logo-large.png";

        public static string CompanyLogo_Small
        {
            get { return Path.Combine(_Directory, _Folder, _CompanyLogo, _CompanyLogo_Small); }
        }

        public static string CompanyLogo_Large
        {
            get { return Path.Combine(_Directory, _Folder, _CompanyLogo, _CompanyLogo_Large); }
        }
    }
}
