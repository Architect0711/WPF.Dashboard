using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DashboardLibrary.Enums;

namespace WPF.DashboardStarter.EventArgs
{
    public class ContentChangedEventArgs : System.EventArgs
    {
        public UserControlLocation userControlLocation { get; private set; }
        public string userControlName { get; private set; }

        public ContentChangedEventArgs(UserControlLocation userControlLocation, string userControlName)
        {
            this.userControlLocation = userControlLocation;
            this.userControlName = userControlName;
        }
    }
}
