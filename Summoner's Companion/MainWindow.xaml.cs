using System;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
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
            };
            var cmdArgs = Environment.GetCommandLineArgs();
            Settings.Default.Upgrade();
            if (Variables.FirstRun || cmdArgs.Contains("firstrun"))
            {
                Transitioner.SelectedIndex = 2;
            }
            if (!Directory.Exists("Downloads/Splashes"))
                Directory.CreateDirectory("Downloads/Splashes");
        }

        public static void NavigateTo(UserControl control)
        {
            Instance.Transitioner.Items[1] = control;
            Instance.Transitioner.SelectedIndex = 1;
        }

        public static void NavigateToIndex(int index)
        {
            Instance.Transitioner.SelectedIndex = index;
        }

        public static async void ShowDialog(object content)
        {
            await DialogHost.Show(content);
        }
    }
}
