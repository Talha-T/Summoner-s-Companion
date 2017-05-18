using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;
using Summoner_s_Companion.Annotations;

namespace Summoner_s_Companion
{
    /// <summary>
    /// ImageDialog.xaml etkileşim mantığı
    /// </summary>
    public partial class ImageDialog : INotifyPropertyChanged
    {
        public ImageDialog(string source, string champName)
        {
            InitializeComponent();
            Source = new BitmapImage(new Uri(source));
            ChampionName = champName;
            OnPropertyChanged(nameof(Source));
            if (!File.Exists($"Downloads\\Splashes\\{ChampionName}.jpg")) return;
            _downloaded = true;
            DownloadButton.Content = "OPEN FOLDER";
            Image.Source = new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(),
                $"Downloads\\Splashes\\{ChampionName}.jpg")));
        }

        public BitmapImage Source { get; }
        private string ChampionName { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _downloaded;

        private async void DownloadButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var dir = "Downloads\\Splashes\\";
            var loc = $"{dir}{ChampionName}.jpg";
            if (!_downloaded)
            {
                DownloadButton.Content = Resources["ProgressBar"];
                using (WebClient wc = new WebClient())
                {
                    await wc.DownloadFileTaskAsync(Source.UriSource,
                        loc);
                    _downloaded = true;
                    DownloadButton.Content = "OPEN FOLDER";
                }
            }
            else
            {
                Process.Start(dir);
            }

        }

        
    }
}
