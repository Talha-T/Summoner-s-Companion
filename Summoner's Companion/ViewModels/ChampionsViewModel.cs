using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiotSharp;
using RiotSharp.StaticDataEndpoint;
using Summoner_s_Companion.Models;
using Summoner_s_Companion.Properties;
using Summoner_s_Companion.Requestors;

namespace Summoner_s_Companion.ViewModels
{
    public class ChampionsViewModel : ViewModelBase
    {
        public async Task GetChampions()
        {
            var api = StaticRiotApi.GetInstance(Resources.apiKey);
            if (Variables.Champions == null)
            {                
                Champions = (await api.GetChampionsAsync(Variables.Region, ChampionData.all, Variables.Language))
                    .Champions.Values.OrderBy(x => x.Name)
                    .ToList();
                Variables.Champions = new ChampionStaticCollection(Champions);
            }
            else
            {
                var c = Variables.Champions.ToList();
                Champions = c;
            }
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
