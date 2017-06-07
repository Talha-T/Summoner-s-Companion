using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using RiotSharp;
using Summoner_s_Companion.Properties;
using Summoner_s_Companion.Requestors;

namespace Summoner_s_Companion
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow
    {

        public static MainWindow Instance;

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            Closing += delegate
            {
                if (Variables.FirstRun)
                    Variables.FirstRun = false;
                Settings.Default.Save();
            };
            var cmdArgs = Environment.GetCommandLineArgs();
            Settings.Default.Upgrade();
            if (Variables.FirstRun || cmdArgs.Contains("firstrun"))
            {
                
                SummonerView.Loaded += (s, e) =>
                {
                    ShowDialog();
                };
                Transitioner.SelectedIndex = 2;
            }
            if (cmdArgs.Contains("update"))
            {
                Variables.Items = null;
                Variables.Champions = null;
                var versions = StaticRiotApi.GetInstance(Variables.ApiKey).GetVersionsAsync(Variables.Region).GetAwaiter().GetResult();
                Variables.Patch = versions[0];
                // ReSharper disable once AssignNullToNotNullAttribute
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }

            if (!Directory.Exists("Downloads/Splashes"))
                Directory.CreateDirectory("Downloads/Splashes");
            var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            const string appName = "SummonersCompanion.exe";
            if (key != null && key.GetValue(appName) == null)
                key.SetValue(appName, 11001, RegistryValueKind.DWord);

            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            if (key?.GetValue(appName) != null)
                key.SetValue("YourApplicationName.exe", 11001, RegistryValueKind.DWord);
        }

        private async void ShowDialog()
        {
            await DialogHost.Show(new MessageDialog("This page is not fully implemented yet. Check out others."));
        }

        public static void NavigateTo(UserControl control)
        {
            Instance.Transitioner.Items[1] = control;
            NavigateToIndex(1);
        }

        public static void NavigateToIndex(int index)
        {
            Instance.Transitioner.SelectedIndex = index;
        }

        public static async void ShowDialog(object content)
        {
            await DialogHost.Show(content);
        }

        private void SettingsButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateToIndex(2);
        }

        private async void AboutButton_OnClick(object sender, RoutedEventArgs e)
        {
            await DialogHost.Show(new MessageDialog("This app is in progress. Stuff will be added in future."));
        }
    }
}
