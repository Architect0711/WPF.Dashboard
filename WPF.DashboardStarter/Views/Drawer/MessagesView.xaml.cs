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
using WPF.Basics.MVVM;
using WPF.Basics.Enums;
using EventAggregator.Interfaces;

namespace WPF.DashboardStarter.Views.Drawer
{
    /// <summary>
    /// Interaction logic for MessagesView.xaml
    /// </summary>
    public partial class MessagesView : BaseUserControl
    {
        public MessagesView(IEventAggregator eventAggregator) : base(eventAggregator, LoadAnimation.SlideAndFadeInFromBottom, UnloadAnimation.SlideAndFadeOutToRight)
        {
            InitializeComponent();
        }
    }
}
