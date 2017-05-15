using System;
using System.Linq;
using System.Windows.Controls;
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
                Transitioner.SelectedIndex = 2;
            }
        }

        public static void NavigateTo(UserControl control)
        {
            Instance.Transitioner.Items[1] = control;
            Instance.Transitioner.SelectedIndex = 1;
        }


    }
}
