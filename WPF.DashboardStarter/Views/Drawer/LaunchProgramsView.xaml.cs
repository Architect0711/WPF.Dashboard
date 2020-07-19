using EventAggregator.Interfaces;
using WPF.Basics.Enums;
using WPF.Basics.MVVM;

namespace WPF.DashboardStarter.Views.Drawer
{
    /// <summary>
    /// Interaction logic for LaunchProgramsView.xaml
    /// </summary>
    public partial class LaunchProgramsView : BaseUserControl
    {
        public LaunchProgramsView(IEventAggregator eventAggregator) : base(eventAggregator, LoadAnimation.SlideAndFadeInFromBottom, UnloadAnimation.SlideAndFadeOutToRight)
        {
            InitializeComponent();
        }
    }
}
