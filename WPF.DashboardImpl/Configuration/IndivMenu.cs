using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DashboardImpl.Content;
using WPF.DashboardLibrary.Enums;
using WPF.DashboardLibrary.Models.MenuItem;

namespace WPF.DashboardImpl.Configuration
{
    public class IndivMenu
    {
        public List<MenuItemModel> MenuItems =
            new List<MenuItemModel>();

        public IndivMenu()
        {
            string iconPath = AppDomain.CurrentDomain.BaseDirectory;

            MenuItems.Add(
                new MenuItemModel(
                    IndivDashboardContent.Main,
                    4,
                    UserControlLocation.Dashboard,
                    "Main",
                    "Main Indiv Content",
                    IndivDashboardContent.Main,
                    ""
                    ));

            MenuItems.Add(
                new MenuItemModel(
                    IndivDrawerContent.Test,
                    5,
                    UserControlLocation.InnerDrawer,
                    "Tests",
                    "Run Tests on the Backend",
                    IndivDrawerContent.Test,
                    ""
                    ));
        }
    }
}
