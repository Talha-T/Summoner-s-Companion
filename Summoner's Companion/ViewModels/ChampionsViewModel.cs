using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiotSharp;
using RiotSharp.StaticDataEndpoint;
using Summoner_s_Companion.Properties;
using Summoner_s_Companion.Requestors;

namespace Summoner_s_Companion.ViewModels
{
    public class ChampionsViewModel : ViewModelBase
    {

        public async Task GetChampions()
        {
            var api = StaticRiotApi.GetInstance(Resources.apiKey);
            var champions = await api.GetChampionsAsync(Variables.Region, ChampionData.all, Variables.Language);
            Champions = champions.Champions.Values.OrderBy(x => x.Name).ToList();
            ChampionsLoaded = true;
        }

        private List<ChampionStatic> _champions;

        public List<ChampionStatic> Champions
        {
            get => _champions;
            set
            {
                _champions = value;
                OnPropertyChanged();
            }
        }

        private bool _championsLoaded;

        public bool ChampionsLoaded
        {
            get => _championsLoaded;
            set { _championsLoaded = value; OnPropertyChanged(); }
        }



    }
}
