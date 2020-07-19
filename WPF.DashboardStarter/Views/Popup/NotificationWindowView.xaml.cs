using EventAggregator.Interfaces;
using WPF.Basics.Enums;
using WPF.Basics.MVVM;

namespace WPF.DashboardStarter.Views.Popup
{
    /// <summary>
    /// Interaction logic for NotificationWindowView.xaml
    /// </summary>
    public partial class NotificationWindowView : BaseUserControl
    {
        public NotificationWindowView(IEventAggregator eventAggregator) : base(eventAggregator, LoadAnimation.SlideAndFadeInFromBottom, UnloadAnimation.SlideAndFadeOutToTop)
        {
            InitializeComponent();
        }
    }
}
