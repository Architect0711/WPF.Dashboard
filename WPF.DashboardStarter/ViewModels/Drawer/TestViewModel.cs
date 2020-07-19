using EventAggregator.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Basics.MVVM;

namespace WPF.DashboardStarter.ViewModels.Drawer
{
    public class TestViewModel : BaseViewModel
    {
        public TestViewModel(IEventAggregator eventAggregator, ILog log) : base(eventAggregator, log)
        {

        }
    }
}
