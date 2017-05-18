using System.Collections.Generic;
using System.Collections.ObjectModel;
using RiotSharp.StaticDataEndpoint;

namespace Summoner_s_Companion.Models
{
    public class ChampionStaticCollection : Collection<ChampionStatic>
    {
        public ChampionStaticCollection() { }

        public ChampionStaticCollection(List<ChampionStatic> list)
        {
            foreach (var t in list)
            {
                Add(t);
            }
        }
    }
}