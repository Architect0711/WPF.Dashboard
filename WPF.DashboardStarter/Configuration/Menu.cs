using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DashboardImpl.Configuration;
using WPF.DashboardLibrary.Interfaces;
using WPF.DashboardLibrary.Enums;
using WPF.DashboardLibrary.Models.MenuItem;
using WPF.DashboardStarter.Localization;
using WPF.DashboardStarter.Content;

namespace WPF.DashboardStarter.Configuration
{
    /// <summary>
    /// Provides the Content for the Drawer Menu
    /// Add MenuItemModels to <see cref="IndivMenu.MenuItems"/> to show them to the User
    /// </summary>
    public class Menu : IndivMenu, IMenuItemService
    {
        public Menu()
        {

        }

        public List<MenuItemModel> GetMenuItems()
        {
            return MenuItems;
        }
    }
}
