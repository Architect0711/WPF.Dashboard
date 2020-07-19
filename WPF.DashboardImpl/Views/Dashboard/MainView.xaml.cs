using EventAggregator.Interfaces;
using WPF.Basics.Enums;
using WPF.Basics.MVVM;

namespace WPF.DashboardImpl.Views.Dashboard
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : BaseUserControl
    {
        public MainView(IEventAggregator eventAggregator) : base(eventAggregator, LoadAnimation.SlideAndFadeInFromRight, UnloadAnimation.SlideAndFadeOutToLeft)
        {
            InitializeComponent();
        }
    }
}
