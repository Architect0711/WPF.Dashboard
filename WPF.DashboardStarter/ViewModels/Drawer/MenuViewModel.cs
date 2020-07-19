using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using EventAggregator.Interfaces;
using log4net;
using WPF.Basics.MVVM;
using WPF.DashboardLibrary.Interfaces;
using WPF.DashboardLibrary.Models.MenuItem;
using WPF.DashboardLibrary.Enums;
using WPF.DashboardStarter.Dashboard;

namespace WPF.DashboardStarter.ViewModels.Drawer
{
    public class MenuViewModel : BaseViewModel
    {
        private IMenuItemService MenuItemService;

        #region Properties
        private static object menuItemsLocker = new object();
        private ObservableCollection<MenuItemModel> menuItems;
        public ObservableCollection<MenuItemModel> MenuItems
        {
            get { return menuItems; }
            private set
            {
                OnPropertyChanged(ref menuItems, value);
            }
        }

        private MenuItemModel selectedMenuItem;
        public MenuItemModel SelectedMenuItem
        {
            get { return selectedMenuItem; }
            set
            {
                if (selectedMenuItem != value)
                {
                    OnPropertyChanged(ref selectedMenuItem, value);
                    ExecuteMenuItem();
                }
            }
        }

        private void ExecuteMenuItem()
        {
            try
            {
                switch (SelectedMenuItem.UserControlLocation)
                {
                    case UserControlLocation.Unknown:
                        break;
                    case UserControlLocation.Dashboard:
                        DashboardViewModel.DashboardContent = SelectedMenuItem.ConverterKey;
                        break;
                    case UserControlLocation.OuterDrawer:
                        DashboardViewModel.OuterDrawerContent = SelectedMenuItem.ConverterKey;
                        break;
                    case UserControlLocation.InnerDrawer:
                        DashboardViewModel.InnerDrawerContent = SelectedMenuItem.ConverterKey;
                        break;
                    case UserControlLocation.Popup:
                        DashboardViewModel.PopupContent = SelectedMenuItem.ConverterKey;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
        #endregion

        public MenuViewModel(
            IEventAggregator eventAggregator, 
            ILog log,
            IMenuItemService menuItemService) 
            : base(eventAggregator, log)
        {
            MenuItemService = menuItemService;
            MenuItems = new ObservableCollection<MenuItemModel>();
            BindingOperations.EnableCollectionSynchronization(MenuItems, menuItemsLocker);
            InitializeMenuItems();
        }

        private void InitializeMenuItems()
        {
            lock (menuItemsLocker)
            {
                foreach (var item in MenuItemService.GetMenuItems())
                {
                    MenuItems.Add(item);
                }
            }
        }
    }
}
