#region Using Statements

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

#endregion Using Statements

namespace DialogGenerator.Views.TitleBarHolder
{
    /// <summary>
    /// Interaction logic for TitleBar.xaml
    /// </summary>
    public partial class TitleBar : UserControl
    {
        #region Dependency Properties

        public Window ParentWindow
        {
            get { return (Window)GetValue(ParentWindowProperty); }
            set { SetValue(ParentWindowProperty, value); }
        }

        public static readonly DependencyProperty ParentWindowProperty =
        DependencyProperty.Register("ParentWindow", typeof(Window), typeof(TitleBar), new PropertyMetadata(default));

        public bool ShowOnlyCloseButton
        {
            get { return (bool)GetValue(ShowOnlyCloseButtonProperty); }
            set { SetValue(ShowOnlyCloseButtonProperty, value); }
        }

        public static readonly DependencyProperty ShowOnlyCloseButtonProperty =
        DependencyProperty.Register("ShowOnlyCloseButton", typeof(bool), typeof(TitleBar), new PropertyMetadata(false, ShowOnlyCloseChanged));

        public Brush TitleBarBackground
        {
            get { return (Brush)GetValue(TitleBarBackgroundProperty); }
            set { SetValue(TitleBarBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TitleBarBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleBarBackgroundProperty =
            DependencyProperty.Register("TitleBarBackground", typeof(Brush), typeof(TitleBar), new PropertyMetadata(Brushes.AliceBlue));

        private static void ShowOnlyCloseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var titlebar = d as TitleBar;
            if (e.NewValue is bool value && value && titlebar != null)
            {
                titlebar.MinimizeButton.Visibility = Visibility.Collapsed;
                titlebar.ResizeButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                titlebar.MinimizeButton.Visibility = Visibility.Visible;
                titlebar.ResizeButton.Visibility = Visibility.Visible;
            }
        }

        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Caption.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaptionProperty =
        DependencyProperty.Register("Caption", typeof(string), typeof(TitleBar), new PropertyMetadata(string.Empty));

        #endregion Dependency Properties

        #region Constructor

        public TitleBar()
        {
            InitializeComponent();
            this.Loaded += TitleBar_Loaded;
        }

        #endregion Constructor

        #region UI Events

        private void TitleBar_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.ParentWindow != null)
            {
                Window.GetWindow(this).StateChanged += TitleBar_StateChanged;
            }
        }

        private void TitleBar_StateChanged(object? sender, System.EventArgs e)
        {
            if (sender is Window window)
            {
                if (window.WindowState == WindowState.Maximized)
                {
                    this.MaximizedState.Visibility = Visibility.Collapsed;
                    this.NormalState.Visibility = Visibility.Visible;
                }
                if (window.WindowState == WindowState.Normal)
                {
                    this.MaximizedState.Visibility = Visibility.Visible;
                    this.NormalState.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.ParentWindow?.DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.ParentWindow?.Close();
        }

        private void ResizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.ParentWindow.WindowState = (this.ParentWindow?.WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.ParentWindow.WindowState = WindowState.Minimized;
        }

        private void TitleBar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.ParentWindow.WindowState = (this.ParentWindow?.WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
        }

        #endregion UI Events
    }
}