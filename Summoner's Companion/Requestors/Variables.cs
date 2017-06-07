using System.Collections.Generic;
using Newtonsoft.Json;
using RiotSharp;
using RiotSharp.StaticDataEndpoint;
using Summoner_s_Companion.Models;
using Summoner_s_Companion.Properties;
using static Summoner_s_Companion.Properties.Settings;

namespace Summoner_s_Companion.Requestors
{
    public static class Variables
    {

        public static string ApiKey => Resources.apiKey;

        public static bool FirstRun
        {
            get => Default.FirstRun;
            set
            {
                Default.FirstRun = value;
                Save();
            }
        }

        public static string SummonerName
        {
            get => Default.SummonerName;
            set
            {
                Default.SummonerName = value;
                Save();
            }
        }

        public static Region Region
        {
            get => Default.Region;
            set
            {
                Default.Region = value;
                Save();
            }
        }

        public static Language Language
        {
            get => Default.Language;
            set
            {
                Default.Language = value;
                Save();
            }
        }

        public static ChampionStaticCollection Champions
        {
            get => JsonConvert.DeserializeObject<ChampionStaticCollection>(Default.Champions);
            set
            {
                Default.Champions = JsonConvert.SerializeObject(value);
                Save();
            }
        }

        private static List<ItemStatic> _items;

        public static List<ItemStatic> Items
        {
            get => _items ?? JsonConvert.DeserializeObject<List<ItemStatic>>(Default.Items);
            set
            {
                Default.Items = JsonConvert.SerializeObject(value);
                _items = value;
                Save();
            }
        }

        public static string Color
        {
            get => Default.Color;
            set
            {
                Default.Color = value;
                Save();
            }
        }

        public static string Patch
        {
            get => Default.Patch;
            set { Default.Patch = value;
                Save();
            }
        }

        private static void Save()
        {
            Default.Save();
        }

    }
}
