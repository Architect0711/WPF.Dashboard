using WPF.Basics.Enums;
using WPF.Basics.MVVM;

namespace WPF.DashboardStarter.Views.Drawer
{
    /// <summary>
    /// Interaction logic for TestView.xaml
    /// </summary>
    public partial class TestView : BaseUserControl
    {
        public TestView() : base(LoadAnimation.SlideAndFadeInFromBottom, UnloadAnimation.SlideAndFadeOutToRight)
        {
            InitializeComponent();
        }
    }
}
