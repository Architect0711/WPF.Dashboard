using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Markup;
using WPF.DashboardStarter.Configuration;
using WPF.DashboardStarter.Dashboard;

namespace WPF.DashboardStarter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Removing the StartupUri and Starting in App.xaml.cs
        /// provides more Control over the Startup Process of the Application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Decide which CultureInfo to use
            SetApplicationCultureInfo();
            // Make sure log4net has read the Configuration before registering it with the IoC Container
            ConfigureLog4Net();
            // Initialize the IoC container
            ConfigureUnity();
            // Start the App
            StartDashboard();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void SetApplicationCultureInfo()
        {
            try
            {
                if (Configuration.Localization.CurrentLanguage != "Windows")
                {
                    CultureInfo SelectedCultureInfo = new CultureInfo(Configuration.Localization.CurrentLanguage);
                    Configuration.Localization.CurrentCultureInfo = SelectedCultureInfo;
                    CultureInfo.DefaultThreadCurrentCulture = SelectedCultureInfo;
                    CultureInfo.DefaultThreadCurrentUICulture = SelectedCultureInfo;
                    FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(Configuration.Localization.CurrentLanguage)));

                    // We need to set the CultureInfo for the Strings Library manually
                    Localization.Strings.Culture = SelectedCultureInfo;
                }
                else
                {
                    // Ensure the current culture passed into bindings is the OS culture. 
                    // By default, WPF uses en-US as the culture, regardless of the system settings.
                    FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

                    Configuration.Localization.CurrentCultureInfo = new CultureInfo(CultureInfo.CurrentCulture.IetfLanguageTag);
                    Localization.Strings.Culture = Configuration.Localization.CurrentCultureInfo;
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Normally the log4net Config goes into the AssemblyInfo, but it didn't 
        /// work properly, so we tell log4net where to find the Config File manually
        /// </summary>
        private static void ConfigureLog4Net()
        {
            string log4netConfig = "log4net.config";
            FileInfo log4netInfo = new FileInfo(log4netConfig);
            log4net.Config.XmlConfigurator.ConfigureAndWatch(log4netInfo);
        }

        /// <summary>
        /// Configure the IoC Container in the <see cref="DashboardViewModelLocator"/>
        /// </summary>
        private static void ConfigureUnity()
        {
            IoC.RegisterTypes(DashboardViewModelLocator._container);
        }

        /// <summary>
        /// With CultureInfo, logging and DI set up, we can Start the Dashboard
        /// </summary>
        private static void StartDashboard()
        {
            // Create the Dashboard
            Dashboard.Dashboard wnd = new Dashboard.Dashboard();
            // Show the Dashboard
            wnd.Show();
        }

    }
}
