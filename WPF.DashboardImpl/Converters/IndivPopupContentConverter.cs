using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Basics.MVVM;

namespace WPF.DashboardImpl.Converters
{
    /// <summary>
    /// Add new Popup Content here
    /// </summary>
    public class IndivPopupContentConverter
    {
        protected Dictionary<string, BaseUserControl> Controls
            = new Dictionary<string, BaseUserControl>();

        public IndivPopupContentConverter()
        {

        }
    }
}
