using RiotSharp;
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
            set => Default.FirstRun = value;
        }

        public static string SummonerName
        {
            get => Default.SummonerName;
            set => Default.SummonerName = value;
        }

        public static Region Region
        {
            get => Default.Region;
            set => Default.Region = value;
        }

        public static Language Language
        {
            get => Default.Language;
            set => Default.Language = value;
        }

    }
}
