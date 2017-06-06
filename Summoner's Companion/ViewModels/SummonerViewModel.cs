using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiotSharp;
using RiotSharp.LeagueEndpoint;
using RiotSharp.LeagueEndpoint.Enums;
using RiotSharp.SummonerEndpoint;
using Summoner_s_Companion.Requestors;

namespace Summoner_s_Companion.ViewModels
{
    public class SummonerViewModel : ViewModelBase
    {

        public List<Region> Regions
        {
            get
            {
                var values = Enum.GetValues(typeof(Region)).Cast<Region>().ToList();
                values.Remove(Region.global);
                return values;
            }
        }

        private Region _region = Variables.Region;

        public Region Region
        {
            get => _region;
            set
            {
                _region = value;
                OnPropertyChanged();
            }
        }


        private Summoner _summoner;

        public Summoner Summoner
        {
            get => _summoner;
            set
            {
                _summoner = value;
                OnPropertyChanged();
            }
        }

        private int _division;

        public int SoloQDivision
        {
            get => _division;
            set
            {
                _division = value;
                OnPropertyChanged();
            }
        }

        private Tier _rank;

        public Tier SoloQRank
        {
            get => _rank;
            set
            {
                _rank = value;
                OnPropertyChanged();
            }
        }

        private void GetLeagues()
        {
            //TODO: Implement this system when library is updated. 
        }
    }

}