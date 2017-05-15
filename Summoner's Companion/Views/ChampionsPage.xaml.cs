using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RiotSharp.StaticDataEndpoint;
using Summoner_s_Companion.ViewModels;

namespace Summoner_s_Companion.Views
{
    /// <summary>
    /// ChampionsPage.xaml etkileşim mantığı
    /// </summary>
    public partial class ChampionsPage
    {
        public ChampionsPage()
        {
            InitializeComponent();
            var viewModel = (ChampionsViewModel)DataContext;
            Task.Run(() => viewModel.GetChampions());
        }

        private void ListBox_Click(object sender, MouseButtonEventArgs e)
        {
            var item = (FrameworkElement)e.OriginalSource;
            var champ = (ChampionStatic)item.DataContext;
            MainWindow.NavigateTo(new ChampionPage(champ));
        }
    }
}
