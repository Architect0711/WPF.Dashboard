using EventAggregator.Interfaces;
using System;
using System.Diagnostics;
using System.Windows.Navigation;
using WPF.Basics.Enums;
using WPF.Basics.MVVM;

namespace WPF.DashboardStarter.Views.Popup
{
    /// <summary>
    /// Interaction logic for AboutWindowView.xaml
    /// </summary>
    public partial class AboutWindowView : BaseUserControl
    {
        public AboutWindowView(IEventAggregator eventAggregator) : base(eventAggregator, LoadAnimation.SlideAndFadeInFromBottom, UnloadAnimation.SlideAndFadeOutToTop)
        {
            InitializeComponent();
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
                e.Handled = true;
            }
            catch (Exception)
            {

            }
        }
    }
}
