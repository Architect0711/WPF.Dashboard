using EventAggregator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.Basics.Enums;
using WPF.Basics.MVVM;

namespace WPF.DashboardStarter.Views.Dashboard
{
    /// <summary>
    /// Interaction logic for SkinningView.xaml
    /// </summary>
    public partial class SkinningView : BaseUserControl
    {
        public SkinningView(IEventAggregator eventAggregator) : base(eventAggregator, LoadAnimation.SlideAndFadeInFromRight, UnloadAnimation.SlideAndFadeOutToLeft)
        {
            InitializeComponent();
        }
    }
}
