using EventAggregator.Interfaces;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using WPF.Basics.MVVM;
using WPF.DashboardLibrary.Events.Dashboard;
using WPF.DashboardLibrary.Events.Login;
using WPF.DashboardStarter.Content;
using WPF.DashboardStarter.Configuration;
using WPF.DashboardStarter.Localization;
using WPF.DashboardStarter.EventArgs;

namespace WPF.DashboardStarter.Dashboard
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window, INotifyPropertyChanged
    {
        protected IEventAggregator EventAggregator;

        #region Dependency Properties

        public int SidebarButtonLength
        {
            get { return (int)GetValue(SidebarButtonLengthProperty); }
            set { SetValue(SidebarButtonLengthProperty, value); }
        }

        public static readonly DependencyProperty SidebarButtonLengthProperty =
            DependencyProperty.Register(nameof(SidebarButtonLength), typeof(int), typeof(Dashboard), new PropertyMetadata(50));

        public Thickness DashboardContentMargin
        {
            get { return (Thickness)GetValue(DashboardContentMarginProperty); }
            set { SetValue(DashboardContentMarginProperty, value); }
        }

        public static readonly DependencyProperty DashboardContentMarginProperty =
            DependencyProperty.Register(nameof(DashboardContentMargin), typeof(Thickness), typeof(Dashboard), new PropertyMetadata(default(Thickness)));

        #endregion

        #region Properties

        /// <summary>
        /// Determine which View is currently visible in the inner Drawer
        /// </summary>
        private string innerDrawerContent;
        public string InnerDrawerContent
        {
            get { return innerDrawerContent; }
            set
            {
                if (innerDrawerContent != value)
                {
                    innerDrawerContent = value;
                    InnerDrawerExpanded = true;
                }
                else
                {
                    InnerDrawerExpanded = !InnerDrawerExpanded;
                }
            }
        }

        /// <summary>
        /// OuterDrawer expanded or retracted
        /// </summary>
        private bool outerDrawerExpanded = false;
        public bool OuterDrawerExpanded
        {
            get { return outerDrawerExpanded; }
            set
            {
                if (outerDrawerExpanded != value)
                {
                    outerDrawerExpanded = value;
                    OnOuterDrawerExpandedChanged();
                    OnPropertyChanged();
                }
            }
        }
        
        /// <summary>
        /// Width of a Button
        /// </summary>
        private int sidebarsRetractedWidth = 50;
        public int SidebarsRetractedWidth
        {
            get { return sidebarsRetractedWidth; }
            set { sidebarsRetractedWidth = value; }
        }

        /// <summary>
        /// InnerDrawer expanded or retracted
        /// </summary>
        private bool innerDrawerExpanded = false;
        public bool InnerDrawerExpanded
        {
            get { return innerDrawerExpanded; }
            set
            {
                if (innerDrawerExpanded != value)
                {
                    innerDrawerExpanded = value;
                    OnInnerDrawerExpandedChanged();
                }
            }
        }

        /// <summary>
        /// Both Drawers are hidden
        /// </summary>
        private bool bothDrawersCompletelyHidden = true;
        public bool BothDrawersCompletelyHidden
        {
            get { return bothDrawersCompletelyHidden; }
            set
            {
                if (bothDrawersCompletelyHidden != value)
                {
                    bothDrawersCompletelyHidden = value;

                    if (bothDrawersCompletelyHidden)
                    {
                        if (OuterDrawerExpanded)
                        {
                            OuterDrawerExpanded = false;
                        }

                        Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ThreadStart(() =>
                        {
                            HideSidebars(500, 1000);
                            ChangeDashboardContentMargin(DashboardContentMargin_BothDrawersCompletelyHidden);
                        }));
                    }
                    else
                    {
                        if (InnerDrawerExpanded)
                        {
                            InnerDrawerExpanded = false;
                        }

                        Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ThreadStart(() =>
                        {
                            ShowSidebars(500, 500);
                            ChangeDashboardContentMargin(DashboardContentMargin_OuterDrawerRetracted);
                        }));
                    }
                }
            }
        }

        /// <summary>
        /// https://stackoverflow.com/questions/10181245/how-can-i-animate-the-margin-of-a-stackpanel-with-a-storyboard
        /// </summary>
        /// <param name="newMargin"></param>
        private void ChangeDashboardContentMargin(Thickness newMargin)
        {
            var sb = new Storyboard();
            var ta = new ThicknessAnimation();
            ta.BeginTime = new TimeSpan(0);
            ta.SetValue(Storyboard.TargetNameProperty, "DashboardHost");
            Storyboard.SetTargetProperty(ta, new PropertyPath(MarginProperty));

            ta.From = DashboardContentMargin;
            ta.To = newMargin;
            ta.Duration = new Duration(TimeSpan.FromMilliseconds(500));

            sb.Children.Add(ta);
            sb.Begin(this);
            DashboardContentMargin = newMargin;
        }

        private string _ExpandSidebarButtonText;
        public string ExpandSidebarButtonText
        {
            get { return _ExpandSidebarButtonText; }
            set
            {
                _ExpandSidebarButtonText = value;
                OnPropertyChanged();
            }
        }

        public string ArrowIconPath
        {
            get { return Paths.ToggleSidebarIcon; }
        }

        public string SettingsIconPath
        {
            get { return Paths.SettingsIcon; }
        }

        public string BurgerIconPath
        {
            get { return Paths.BurgerIcon; }
        }

        public string LaunchIconPath
        {
            get { return Paths.LaunchProgramsIcon; }
        }

        private string messageIconPath = Paths.MessageIcon;
        public string MessageIconPath
        {
            get { return messageIconPath; }
            set
            {
                messageIconPath = value;
                OnPropertyChanged();
            }
        }

        private bool isLoggedIn = false;
        public bool IsLoggedIn
        {
            get { return isLoggedIn; }
            set
            {
                if (isLoggedIn != value)
                {
                    isLoggedIn = value;
                    OnPropertyChanged();
                    BothDrawersCompletelyHidden = !IsLoggedIn;
                    if (IsLoggedIn)
                    {
                        OuterDrawerExpanded = Properties.Dashboard.Default.ShowSidebar;
                    }
                }
            }
        }

        #endregion

        #region Variables

        private readonly int SidebarsHiddenWidth = 0;
        private readonly int SidebarExpandedWidth = 250;
        private readonly int InnerDrawerExpandedWidth = 500;

        private readonly Thickness DashboardContentMargin_BothDrawersCompletelyHidden;
        private readonly Thickness DashboardContentMargin_OuterDrawerRetracted;
        private readonly Thickness DashboardContentMargin_OuterDrawerExpanded;
        #endregion

        #region Commands

        private ICommand _ToggleSidebar;
        public ICommand ToggleSidebarCommand
        {
            get
            {
                if (_ToggleSidebar == null)
                {
                    _ToggleSidebar = new RelayCommand(
                        p => (IsLoggedIn),
                        p => OuterDrawerExpanded = !OuterDrawerExpanded);
                }
                return _ToggleSidebar;
            }
        }

        #endregion

        #region Ctor

        public Dashboard()
        {
            InitializeComponent();
            if (DataContext is BaseViewModel viewModel)
            {
                EventAggregator = viewModel.GetEventAggregator;
                if (viewModel is DashboardViewModel dashboardViewModel)
                {
                    DashboardViewModel.ContentChanged += DashboardViewModel_ContentChanged;
                }
            }
            InitializeEvents();
            DashboardContentMargin_BothDrawersCompletelyHidden = new Thickness(0, 0, 0, 0);
            DashboardContentMargin_OuterDrawerRetracted = new Thickness(0, 0, SidebarButtonLength, 0);
            DashboardContentMargin_OuterDrawerExpanded = new Thickness(0, 0, SidebarExpandedWidth, 0);
        }

        private void DashboardViewModel_ContentChanged(object sender, System.EventArgs ea)
        {
            try
            {
                if (ea is ContentChangedEventArgs ccea)
                {
                    switch (ccea.userControlLocation)
                    {
                        case DashboardLibrary.Enums.UserControlLocation.Unknown:
                            break;
                        case DashboardLibrary.Enums.UserControlLocation.Dashboard:
                            break;
                        case DashboardLibrary.Enums.UserControlLocation.OuterDrawer:
                            break;
                        case DashboardLibrary.Enums.UserControlLocation.InnerDrawer:
                            InnerDrawerContent = ccea.userControlName;
                            break;
                        case DashboardLibrary.Enums.UserControlLocation.Popup:
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region Init

        private void InitializeEvents()
        {
            EventAggregator?.Subscribe<LoginResponseEvent>(OnLoginResponse);
            EventAggregator?.Subscribe<LogoutEvent>(OnLogout);
            Titlebar.MouseDown += Titlebar_MouseDown;
            Titlebar.MinimizeButton.Click += MinimizeButton_Click;
            Titlebar.MaximizeButton.Click += MaximizeButton_Click;
            Titlebar.CloseButton.Click += CloseButton_Click;
        }

        #endregion

        #region IEvents

        private void OnLogout(LogoutEvent e)
        {
            IsLoggedIn = false;
        }

        private void OnLoginResponse(LoginResponseEvent e)
        {
            if (e.IsValid)
            {
                IsLoggedIn = true;
            }
        }

        #endregion

        #region OuterDrawer Animations

        private void OnOuterDrawerExpandedChanged()
        {
            if (InnerDrawerExpanded && !outerDrawerExpanded)
            {
                InnerDrawerExpanded = false;

                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ThreadStart(() =>
                {
                    RetractInnerDrawer(500);
                }));

                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ThreadStart(() =>
                {
                    RetractOuterDrawer(500);
                    RotateArrow(180, 0);
                    ExpandSidebarButtonText = Strings.HoverText_ExpandSidebar;
                }));
            }

            if (outerDrawerExpanded)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ThreadStart(() =>
                {
                    ExpandSidebar(500);
                    RotateArrow(0, 180);
                    ExpandSidebarButtonText = Strings.HoverText_RetractSidebar;
                    ChangeDashboardContentMargin(DashboardContentMargin_OuterDrawerExpanded);
                }));
            }
            else
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ThreadStart(() =>
                {
                    RetractOuterDrawer(500);
                    RotateArrow(180, 0);
                    ExpandSidebarButtonText = Strings.HoverText_ExpandSidebar;
                    ChangeDashboardContentMargin(DashboardContentMargin_OuterDrawerRetracted);
                }));
            }
        }

        private void OnInnerDrawerExpandedChanged()
        {
            if (InnerDrawerExpanded)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ThreadStart(() =>
                {
                    ExpandInnerDrawer(500);
                }));
            }
            else
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ThreadStart(() =>
                {
                    RetractInnerDrawer(1000);
                }));
            }
        }

        private void RotateArrow(int from, int to)
        {
            var da = new DoubleAnimation(from, to, new Duration(TimeSpan.FromMilliseconds(500)));
            var rt = new RotateTransform();
            Arrow.RenderTransform = rt;
            Arrow.RenderTransformOrigin = new Point(0.5, 0.5);
            rt.BeginAnimation(RotateTransform.AngleProperty, da);
        }

        private void RotateSettingsIcon(int from, int to)
        {
            var da = new DoubleAnimation(from, to, new Duration(TimeSpan.FromMilliseconds(500)));
            var rt = new RotateTransform();
            SettingsIcon.RenderTransform = rt;
            SettingsIcon.RenderTransformOrigin = new Point(0.5, 0.5);
            rt.BeginAnimation(RotateTransform.AngleProperty, da);
        }

        private void HideSidebars(int durationInnerSidebarMs, int durationOuterSidebarMs)
        {
            ChangeGridWidth(InnerDrawer,
                (int)InnerDrawer.Width,
                SidebarsHiddenWidth,
                TimeSpan.FromMilliseconds(durationInnerSidebarMs));
            ChangeGridWidth(OuterDrawer,
                (int)OuterDrawer.Width,
                SidebarsHiddenWidth,
                TimeSpan.FromMilliseconds(durationOuterSidebarMs));
        }

        private void ShowSidebars(int durationInnerSidebarMs, int durationOuterSidebarMs)
        {
            ChangeGridWidth(InnerDrawer,
                (int)InnerDrawer.Width,
                SidebarsRetractedWidth,
                TimeSpan.FromMilliseconds(durationInnerSidebarMs));
            ChangeGridWidth(OuterDrawer,
                (int)OuterDrawer.Width,
                SidebarsRetractedWidth,
                TimeSpan.FromMilliseconds(durationOuterSidebarMs));
        }

        private void ExpandSidebar(int durationInMs)
        {
            ChangeGridWidth(OuterDrawer,
                SidebarsRetractedWidth,
                SidebarExpandedWidth,
                TimeSpan.FromMilliseconds(durationInMs));
        }

        private void RetractOuterDrawer(int durationInMs)
        {
            ChangeGridWidth(OuterDrawer,
                (int)OuterDrawer.Width,
                SidebarsRetractedWidth,
                TimeSpan.FromMilliseconds(durationInMs));
        }

        private void ExpandInnerDrawer(int durationInMs)
        {
            ChangeGridWidth(InnerDrawer,
                SidebarExpandedWidth,
                InnerDrawerExpandedWidth,
                TimeSpan.FromMilliseconds(durationInMs));
        }

        private void RetractInnerDrawer(int durationInMs)
        {
            ChangeGridWidth(InnerDrawer,
                (int)InnerDrawer.Width,
                SidebarsRetractedWidth,
                TimeSpan.FromMilliseconds(durationInMs));
        }

        private void ChangeGridWidth(Grid grid, int oldWidth, int newWidth, TimeSpan duration)
        {
            DoubleAnimationUsingKeyFrames animation = new DoubleAnimationUsingKeyFrames();
            LinearDoubleKeyFrame start = new LinearDoubleKeyFrame(oldWidth);
            animation.KeyFrames.Add(start);
            LinearDoubleKeyFrame end = new LinearDoubleKeyFrame(newWidth, duration);
            animation.KeyFrames.Add(end);
            grid.BeginAnimation(Grid.WidthProperty, animation);
        }

        private void Titlebar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                }
                this.DragMove();
            }
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            EventAggregator?.Publish(new DashboardShutdownRequestedEvent());
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
