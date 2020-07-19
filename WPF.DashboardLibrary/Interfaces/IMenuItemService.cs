using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DashboardLibrary.Models.MenuItem;

namespace WPF.DashboardLibrary.Interfaces
{
    public interface IMenuItemService
    {
        List<MenuItemModel> GetMenuItems();
    }
}
