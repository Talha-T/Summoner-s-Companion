using System.Threading.Tasks;
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

    }
}
