using EventAggregator.Interfaces;
using log4net;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Data;
using WPF.Basics.MVVM;
using WPF.DashboardLibrary.Models.LaunchPrograms;

namespace WPF.DashboardStarter.ViewModels.Drawer
{
    /// <summary>
    /// Holds Data about all Programs that can be Launched from within the Application
    /// </summary>
    public class LaunchProgramsViewModel : BaseViewModel
    {
        #region Properties
        private static object launchProgramsLocker = new object();
        private ObservableCollection<LaunchProgramModel> launchablePrograms;
        public ObservableCollection<LaunchProgramModel> LaunchablePrograms
        {
            get { return launchablePrograms; }
            private set
            {
                OnPropertyChanged(ref launchablePrograms, value);
            }
        }

        private LaunchProgramModel launchedProgram;
        public LaunchProgramModel LaunchedProgram
        {
            get { return launchedProgram; }
            set
            {
                if (launchedProgram != value)
                {
                    OnPropertyChanged(ref launchedProgram, value);
                    LaunchProgram();
                }
            }
        }
        #endregion

        #region Ctor
        public LaunchProgramsViewModel(IEventAggregator eventAggregator, ILog log) : base(eventAggregator, log)
        {
            LaunchablePrograms = new ObservableCollection<LaunchProgramModel>();

            LoadLaunchableProgramsFromAppConfig();

            BindingOperations.EnableCollectionSynchronization(LaunchablePrograms, launchProgramsLocker);
        }

        private void LoadLaunchableProgramsFromAppConfig()
        {
            string cfgKey = "LaunchPrograms_";
            int cnt = 1;
            while (ConfigurationManager.AppSettings[cfgKey+cnt.ToString()] != null)
            {
                try
                {
                    var configData = ConfigurationManager.AppSettings[cfgKey + cnt.ToString()].Split('|');
                    if (configData.Length == 3)
                    {
                        string path = configData[0];
                        string name = configData[1];
                        string desc = configData[2];
                        if (File.Exists(path) && !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(desc))
                        {
                            LaunchablePrograms.Add(new LaunchProgramModel(cnt, path, name, desc));
                        }
                    }
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
                cnt++;  
            }
        }

        protected override void SubscribeToAllEvents()
        {

        } 
        #endregion

        #region Functions
        private void LaunchProgram()
        {
            try
            {
                if (LaunchedProgram != null)
                {
                    Process.Start(LaunchedProgram.Fullpath);
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        } 
        #endregion
    }
}
