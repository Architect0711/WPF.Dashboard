using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DashboardLibrary.Enums;

namespace WPF.DashboardLibrary.Models.MenuItem
{
    public class MenuItemModel
    {
        public string MenuItemId { get; private set; }

        public int Order { get; private set; }

        public UserControlLocation UserControlLocation { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public string ConverterKey { get; private set; }

        public string IconPath { get; private set; }

        public MenuItemModel(
            string id,
            int order,
            UserControlLocation userControlLocation,
            string title,
            string description,
            string converterKey,
            string iconPath)
        {
            MenuItemId = id;
            Order = order;
            UserControlLocation = userControlLocation;
            Title = title;
            Description = description;
            ConverterKey = converterKey;
            IconPath = iconPath;
        }

        public override bool Equals(object obj)
        {
            return obj is MenuItemModel model &&
                   MenuItemId == model.MenuItemId;
        }

        public override int GetHashCode()
        {
            return 1517417700 + EqualityComparer<string>.Default.GetHashCode(MenuItemId);
        }
    }
}
