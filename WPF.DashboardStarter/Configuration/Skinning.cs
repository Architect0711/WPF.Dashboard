using System;
using System.Collections.Generic;
using System.Linq;
using WPF.DashboardStarter.Enums;
using WPF.DashboardStarter.Properties;

namespace WPF.DashboardStarter.Configuration
{
    /// <summary>
    /// Configures and Controls the Application's <see cref="Skin"/> and <see cref="Enums.IconColor"/>
    /// </summary>
    public static class Skinning
    {
        /// <summary>
        /// Configure the <see cref="Enums.IconColor"/> to be used with each <see cref="Skin"/>
        /// </summary>
        private static Dictionary<Skin, IconColor> SkinIconRef = new Dictionary<Skin, IconColor>
        {
            [Skin.Dark] = IconColor.White,
            [Skin.Light] = IconColor.White,
            [Skin.Teal] = IconColor.White
        };

        /// <summary>
        /// Configure the Path where the Icons for each Color are stored
        /// </summary>
        private static Dictionary<IconColor, string> IconPathRef = new Dictionary<IconColor, string>
        {
            [IconColor.Black] = Paths._Black,
            [IconColor.White] = Paths._White
        };

        /// <summary>
        /// Gets all available Skins
        /// </summary>
        public static List<Skin> AvailableSkins
        {
            get
            {
                var skins = (Skin[])Enum.GetValues(typeof(Skin));
                return skins.ToList();
            }
        }

        /// <summary>
        /// Get or Set the Current Skin
        /// Changing requires restarting the Application
        /// </summary>
        public static Skin CurrentSkin
        {
            get
            {
                return Properties.Dashboard.Default.CurrentSkin;
            }
            set
            {
                Properties.Dashboard.Default.CurrentSkin = value;
                Properties.Dashboard.Default.Save();
                UpdateIconColor();
            }
        }

        /// <summary>
        /// Changing the <see cref="CurrentSkin"/> may require to change the <see cref="IconColor"/>
        /// </summary>
        private static void UpdateIconColor()
        {
            if (SkinIconRef.ContainsKey(CurrentSkin))
            {
                IconColor = SkinIconRef[CurrentSkin];
            }
            else
            {
                IconColor = IconColor.White;
            }
        }
        
        /// <summary>
        /// Gets or Sets the current Icon Color
        /// </summary>
        public static IconColor IconColor
        {
            get
            {
                return Properties.Dashboard.Default.IconColor;
            }
            set
            {
                Properties.Dashboard.Default.IconColor = value;
                Properties.Dashboard.Default.Save();
                UpdateIconPath();
            }
        }

        /// <summary>
        /// Changing the <see cref="IconColor"/> requires to change the <see cref="IconPath"/>
        /// </summary>
        private static void UpdateIconPath()
        {
            if (IconPathRef.ContainsKey(IconColor))
            {
                IconPath = IconPathRef[IconColor];
            }
            else
            {
                IconPath = Paths._White;
            }
        }

        /// <summary>
        /// Folder Name for the Apllication Icons
        /// </summary>
        public static string IconPath
        {
            get
            {
                return Properties.Dashboard.Default.IconPath;
            }
            set
            {
                Properties.Dashboard.Default.IconPath = value;
                Properties.Dashboard.Default.Save();
            }
        }
    }
}
