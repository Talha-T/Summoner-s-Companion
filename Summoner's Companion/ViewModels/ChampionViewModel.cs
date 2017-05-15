﻿using RiotSharp.StaticDataEndpoint;

namespace Summoner_s_Companion.ViewModels
{
    public class ChampionViewModel : ViewModelBase
    {

        private ChampionStatic _champion;

        public ChampionStatic Champion
        {
            get => _champion;
            set
            {
                _champion = value;
                OnPropertyChanged();
            }
        }



    }
}