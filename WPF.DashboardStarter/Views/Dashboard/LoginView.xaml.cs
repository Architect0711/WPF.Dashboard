using EventAggregator.Interfaces;
using WPF.Basics.Enums;
using WPF.Basics.MVVM;

namespace WPF.DashboardStarter.Views.Dashboard
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : BaseUserControl
    {
        public LoginView(IEventAggregator eventAggregator) : base(eventAggregator, LoadAnimation.SlideAndFadeInFromRight, UnloadAnimation.SlideAndFadeOutToLeft)
        {
            InitializeComponent();
        }
    }
}
