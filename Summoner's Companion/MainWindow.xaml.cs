using System;
using System.Linq;
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
                Settings.Default.Save();
            };
            var cmdArgs = Environment.GetCommandLineArgs();
            if (Variables.FirstRun || cmdArgs.Contains("firstrun"))
            {
                Transitioner.SelectedIndex = 1;
            }
        }


    }
}
