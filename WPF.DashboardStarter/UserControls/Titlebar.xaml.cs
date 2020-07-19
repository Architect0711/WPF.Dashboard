using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WPF.DashboardStarter.Configuration;
using WPF.DashboardStarter.Localization;

namespace WPF.DashboardStarter.UserControls
{
    /// <summary>
    /// Interaction logic for Titlebar.xaml
    /// </summary>
    public partial class Titlebar : UserControl
    {
        #region Fields

        public EventHandler Minimize;
        public EventHandler Maximize; 

        #endregion

        #region Properties

        public string ExitIconPath
        {
            get { return Paths.ExitIcon; }
        }

        public string AboutIconPath
        {
            get { return Paths.AboutIcon; }
        }

        public string LogoutIconPath
        {
            get { return Paths.LogoutIcon; }
        }

        public string MinimizeIconPath
        {
            get { return Paths.MinimizeIcon; }
        }

        public string MaximizeIconPath
        {
            get { return Paths.MaximizeIcon; }
        }

        public string MaximizeIconTooltip
        {
            get { return true ? Strings.HoverText_Resize : Strings.HoverText_Maximize; }
        }

        #endregion

        #region Ctor

        public Titlebar()
        {
            InitializeComponent();
        } 

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged<T>(ref T property, T value, string propertyName)
        {
            property = value;
            var handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
