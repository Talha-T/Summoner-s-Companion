using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using RiotSharp.StaticDataEndpoint;
using Summoner_s_Companion.Models;
using Summoner_s_Companion.Requestors;

namespace Summoner_s_Companion.Views
{
    /// <summary>
    /// ChampionPage.xaml etkileşim mantığı
    /// </summary>
    public partial class ChampionPage
    {
        public ChampionPage(ChampionStatic champion)
        {
            InitializeComponent();
            ChampionViewModel.Champion = champion;
            HideScriptErrors(WebBrowser, true);
            BrowserBackCommand = new RelayCommand(x => WebBrowser.GoBack(), x => WebBrowser.CanGoBack);
            BrowserForwardCommand = new RelayCommand(x => WebBrowser.GoForward(), x => WebBrowser.CanGoForward);          
            WebBrowser.Navigated += WebBrowser_Navigated;
            if (Variables.FirstRun)
                ShowBuggyDialog();
        }

        private async void ShowBuggyDialog()
        {
            await DialogHost.Show(new MessageDialog("Builds and counters might be buggy at the moment; also Riot API data might be wrong so some invalid data might appear at spells page. If you see something weird, please tell it to the author."));
        }

        private void WebBrowser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            CommandManager.InvalidateRequerySuggested();
        }

        public RelayCommand BrowserBackCommand { get; }

        public RelayCommand BrowserForwardCommand { get; }

        private void ChampionImageRectangle_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (e.ClickCount)
            {
                case 1:
                    var toEllipseAnimation =
                        new DoubleAnimation(100, TimeSpan.FromSeconds(1)) {EasingFunction = new QuinticEase()};
                    var toRectangleAnimation =
                        new DoubleAnimation(0, TimeSpan.FromSeconds(1)) {EasingFunction = new QuinticEase()};
                    var animationToPlay = Math.Abs(ChampionImageRectangle.RadiusX - 100) < 1
                        ? toRectangleAnimation
                        : toEllipseAnimation;
                    ChampionImageRectangle.BeginAnimation(Rectangle.RadiusXProperty, animationToPlay);
                    ChampionImageRectangle.BeginAnimation(Rectangle.RadiusYProperty, animationToPlay);
                    break;
                case 2:
                    var img = ChampionViewModel.Champion.Image.Full;
                    var dotpng = img.IndexOf(".png", StringComparison.Ordinal);
                    img = img.Substring(0, dotpng);
                    MainWindow.ShowDialog(new ImageDialog(
                        $"http://ddragon.leagueoflegends.com/cdn/img/champion/splash/{img}_0.jpg",
                        ChampionViewModel.Champion.Name));
                    break;
            }
        }

        private async void LoreButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.RootDialog.IsOpen = false;
            await DialogHost.Show(new MessageDialog(ChampionViewModel.Champion.Lore));
        }

        private async void BlorbButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.RootDialog.IsOpen = false;
            await DialogHost.Show(new MessageDialog(ChampionViewModel.Champion.Blurb));
        }

        public void HideScriptErrors(WebBrowser wb, bool hide)
        {
            var fiComWebBrowser =
                typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fiComWebBrowser == null) return;
            var objComWebBrowser = fiComWebBrowser.GetValue(wb);
            if (objComWebBrowser == null)
            {
                wb.Loaded += (o, s) => HideScriptErrors(wb, hide); //In case we are to early
                return;
            }
            objComWebBrowser.GetType()
                .InvokeMember("Silent", BindingFlags.SetProperty, null, objComWebBrowser, new object[] {hide});
        }

    }
}
