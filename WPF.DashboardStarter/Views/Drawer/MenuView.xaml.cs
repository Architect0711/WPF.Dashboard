using EventAggregator.Interfaces;
using WPF.Basics.Enums;
using WPF.Basics.MVVM;

namespace WPF.DashboardStarter.Views.Drawer
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : BaseUserControl
    {
        public MenuView(IEventAggregator eventAggregator) : base(eventAggregator, LoadAnimation.SlideAndFadeInFromBottom, UnloadAnimation.SlideAndFadeOutToRight)
        {
            InitializeComponent();
        }
    }
}
