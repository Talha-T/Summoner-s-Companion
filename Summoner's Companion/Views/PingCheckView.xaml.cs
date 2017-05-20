using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Windows;
using MaterialDesignThemes.Wpf;
using RiotSharp;
using Summoner_s_Companion.Annotations;

namespace Summoner_s_Companion.Views
{
    /// <summary>
    /// PingCheckView.xaml etkileşim mantığı
    /// </summary>
    public partial class PingCheckView : INotifyPropertyChanged
    {
        public PingCheckView()
        {
            InitializeComponent();
        }

        public List<Region> Regions
        {
            get
            {
                var c = Enum.GetValues(typeof(Region)).Cast<Region>().ToList();
                c.Remove(Region.global);
                return c;
            }
        }

        private bool _pingChecking;

        public bool PingChecking
        {
            get => _pingChecking;
            set
            {
                _pingChecking = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void CheckButton_OnClick(object sender, RoutedEventArgs e)
        {
            Ping p = new Ping();
            var region = RegionsComboBox.SelectedItem as Region?;
            if (region == null)
                return;
            PingChecking = true;
            var url = region + ".leagueoflegends.com";
            IPAddress address = null;
            try
            {
                address = Dns.GetHostAddresses(url)[0];
            }
            catch
            {
                PingChecking = false;
                await DialogHost.Show(new MessageDialog("Riot servers are down or not connected to the Internet?"));
                return;
            }
            var timeout = 15000;
            var pings = new PingReply[200];
            for (int i = 0; i < 200; i++)
            {
                pings[i] = await p.SendPingAsync(address, timeout);
            }
            var roundTimes = pings.Select(x => x.RoundtripTime);
            var enumerable = roundTimes as long[] ?? roundTimes.ToArray();
            var maxPing = enumerable.Max();
            var minPing = enumerable.Min();
            var averagePing = enumerable.Average();
            var packetLoss = pings.Count(x => x.Status != IPStatus.Success);
            var packetLossPercentage = packetLoss / pings.Length * 100;
            PingChecking = false;
            var finalString =
                $"We checked your ping for {pings.Length} times. Your minimum ping is {minPing}, maximum ping is {maxPing}, average ping is {averagePing}. Your packet loss is {packetLoss}/{pings.Length}; which is equal %{packetLossPercentage}. Good luck in your game.";
            await DialogHost.Show(new MessageDialog(finalString));
        }
    }
}
