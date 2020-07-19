using EventAggregator.Interfaces;
using WPF.Basics.Enums;
using WPF.Basics.MVVM;

namespace WPF.DashboardStarter.Views.Drawer
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : BaseUserControl
    {
        public SettingsView(IEventAggregator eventAggregator) : base(eventAggregator, LoadAnimation.SlideAndFadeInFromBottom, UnloadAnimation.SlideAndFadeOutToRight)
        {
            InitializeComponent();
        }
    }
}
