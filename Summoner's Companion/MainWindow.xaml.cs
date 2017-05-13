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
            if (Variables.FirstRun)
            {
                Transitioner.SelectedIndex = 1;
            }
        }


    }
}
