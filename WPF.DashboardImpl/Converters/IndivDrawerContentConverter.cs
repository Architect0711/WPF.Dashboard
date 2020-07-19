using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using WPF.Basics.MVVM;
using WPF.DashboardImpl.Configuration;
using WPF.DashboardImpl.Content;
using WPF.DashboardImpl.Views.Drawer;

namespace WPF.DashboardImpl.Converters
{
    /// <summary>
    /// Add new Drawer Content here
    /// </summary>
    public class IndivDrawerContentConverter
    {
        protected Dictionary<string, BaseUserControl> Controls
            = new Dictionary<string, BaseUserControl>();

        public IndivDrawerContentConverter()
        {
            Controls[IndivDrawerContent.Test] = IndivViewModelLocator._container.Resolve<TestView>();
        }
    }
}
