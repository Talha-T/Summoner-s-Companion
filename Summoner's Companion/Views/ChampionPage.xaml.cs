using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using RiotSharp.StaticDataEndpoint;

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
            //ImageScrollViewer.ScrollToVerticalOffset(champion.Image.Y + 48);
            //ImageScrollViewer.ScrollToHorizontalOffset(champion.Image.X + 48);
        }

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
    }
}
