using System;
using System.Collections.Generic;
using System.Windows;
using WPF.DashboardStarter.Enums;

namespace WPF.DashboardStarter.Skinning
{
    /// <summary>
    /// Extends ResourceDictionary to select the Source at Startup and enable Skinning
    /// Add a new Skin:
    /// - Create a new Subfolder in the 'Skinning' Folder
    /// - Copy the files from an existing Subfolder to the new Folder
    /// - Change the Values (Colors etc...) as needed
    /// - Add an Enum Value to the <see cref="Skin"/> Enum in the 'Enums' Folder
    /// - Add a Property to this Class to select the new Skin
    /// - Add the new Skin to the SkinResourceDictionary in App.xaml
    /// </summary>
    public class SkinResourceDictionary : ResourceDictionary
    {
        private Dictionary<Skin, Uri> Skins = new Dictionary<Skin, Uri>();

        public SkinResourceDictionary()
        {

        }

        public Uri LightSource
        {
            get { return Skins[Skin.Light]; }
            set
            {
                Skins[Skin.Light] = value;
                UpdateSource();
            }
        }

        public Uri TealSource
        {
            get { return Skins[Skin.Teal]; }
            set
            {
                Skins[Skin.Teal] = value;
                UpdateSource();
            }
        }

        public Uri DarkSource
        {
            get { return Skins[Skin.Dark]; }
            set
            {
                Skins[Skin.Dark] = value;
                UpdateSource();
            }
        }

        private void UpdateSource()
        {
            try
            {
                if (Skins.ContainsKey(Configuration.Skinning.CurrentSkin))
                {
                    Uri val = Skins[Configuration.Skinning.CurrentSkin];
                    if (val != null && base.Source != val)
                        base.Source = val;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
