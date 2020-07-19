using EventAggregator.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPF.Basics.MVVM;

namespace WPF.DashboardStarter.ViewModels.Popup
{
    public class AboutWindowViewModel : BaseViewModel
    {
        private ImageSource appLogo;
        public ImageSource AppLogo
        {
            get { return appLogo; }
            set
            {
                OnPropertyChanged(ref appLogo, value);
            }
        }

        private string appTitle;
        public string AppTitle
        {
            get { return appTitle; }
            set
            {
                OnPropertyChanged(ref appTitle, value);
            }
        }

        private string version;
        public string Version
        {
            get { return version; }
            set
            {
                OnPropertyChanged(ref version, value);
            }
        }

        private string copyrightText;
        public string CopyrightText
        {
            get { return copyrightText; }
            set
            {
                OnPropertyChanged(ref copyrightText, value);
            }
        }

        private string copyrightLink;
        public string CopyrightLink
        {
            get { return copyrightLink; }
            set
            {
                OnPropertyChanged(ref copyrightLink, value);
            }
        }

        private ImageSource creditsForIconsLogo;
        public ImageSource CreditForIconsLogo
        {
            get { return creditsForIconsLogo; }
            set
            {
                OnPropertyChanged(ref creditsForIconsLogo, value);
            }
        }

        private string creditsForIconsText;
        public string CreditsForIconsText
        {
            get { return creditsForIconsText; }
            set
            {
                OnPropertyChanged(ref creditsForIconsText, value);
            }
        }

        private string creditsForIconsLink;
        public string CreditsForIconsLink
        {
            get { return creditsForIconsLink; }
            set
            {
                OnPropertyChanged(ref creditsForIconsLink, value);
            }
        }

        private ImageSource githubLogo;
        public ImageSource GithubLogo
        {
            get { return githubLogo; }
            set
            {
                OnPropertyChanged(ref githubLogo, value);
            }
        }

        private string githubText;
        public string GithubText
        {
            get { return githubText; }
            set
            {
                OnPropertyChanged(ref githubText, value);
            }
        }

        private string githubLink;
        public string GithubLink
        {
            get { return githubLink; }
            set
            {
                OnPropertyChanged(ref githubLink, value);
            }
        }

        private string developerText;
        public string DeveloperText
        {
            get { return developerText; }
            set
            {
                OnPropertyChanged(ref developerText, value);
            }
        }

        private string developerLink;
        public string DeveloperLink
        {
            get { return developerLink; }
            set
            {
                OnPropertyChanged(ref developerLink, value);
            }
        }

        private string _Log4NetText;
        public string Log4NetText
        {
            get { return _Log4NetText; }
            set
            {
                OnPropertyChanged(ref _Log4NetText, value);
            }
        }

        private string _Log4NetLink;
        public string Log4NetLink
        {
            get { return _Log4NetLink; }
            set
            {
                OnPropertyChanged(ref _Log4NetLink, value);
            }
        }

        private string _UnityText;
        public string UnityText
        {
            get { return _UnityText; }
            set
            {
                OnPropertyChanged(ref _UnityText, value);
            }
        }

        private string _UnityLink;
        public string UnityLink
        {
            get { return _UnityLink; }
            set
            {
                OnPropertyChanged(ref _UnityLink, value);
            }
        }


        public AboutWindowViewModel(IEventAggregator eventAggregator, ILog log) : base(eventAggregator, log)
        {
            AppTitle = "WpfDashboardStarter";
            Version = "V 1.0.0.0.0";
            CopyrightText = "This Software is Licensed under the MIT License";
            CopyrightLink = "https://opensource.org/licenses/MIT";
            CreditsForIconsText = "All Icons used are courtesy of";
            CreditsForIconsLink = "https://icons8.com/";
            DeveloperText = "© Robert Bantele 2019";
            DeveloperLink = "Yeah, I should probably get a Website...";
            GithubText = "Follow me on Github for Updates for this Starter Project";
            GithubLink = "https://github.com/Architect0711";
            Log4NetText = "log4net is Licensed under the Apache License 2.0";
            Log4NetLink = "http://www.apache.org/licenses/LICENSE-2.0";
            UnityText = "Unity is Licensed under the Apache License 2.0";
            UnityLink = "http://www.apache.org/licenses/LICENSE-2.0";
        }
    }
}
