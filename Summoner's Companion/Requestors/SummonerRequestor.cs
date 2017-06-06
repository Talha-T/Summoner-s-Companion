using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using RiotSharp;
using RiotSharp.SummonerEndpoint;

namespace Summoner_s_Companion.Requestors
{
    public static class SummonerRequestor
    {

        public static async Task<bool> CheckSummoner(string name, Region region)
        {
            try
            {
                var api = RiotApi.GetInstance(Variables.ApiKey);
                await api.GetSummonerAsync(region, name);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
            
        }

        public static async Task<Summoner> GetSummoner(string name, Region region)
        {
            try
            {
                var api = RiotApi.GetInstance(Variables.ApiKey);
                return await api.GetSummonerAsync(region, name);
            }
            catch (RiotSharpException e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

    }
}
