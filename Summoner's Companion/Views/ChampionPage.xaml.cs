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
            ViewModel.Champion = champion;
        }
    }
}
