using System;
using System.Windows;
using Summoner_s_Companion.Properties;
using Summoner_s_Companion.Requestors;

namespace Summoner_s_Companion
{
    /// <summary>
    /// App.xaml etkileşim mantığı
    /// </summary>
    public partial class App
    {

        public new static ResourceDictionary Resources;

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += (s, ex) =>
            {
                MessageBox.Show("An exception occurred: " + ((Exception)ex.ExceptionObject).Message + " Stacktrace: " + ((Exception)ex.ExceptionObject).StackTrace);
            };
            Resources = base.Resources;
            Settings.Default.SettingsLoaded += delegate
            {
                SwitchColor();
            };
        }

        public static void SwitchColor()
        {
            var primarySource = new Uri($"pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.{Variables.Color ?? "Red"}.xaml");
            Resources.MergedDictionaries[2] = new ResourceDictionary { Source = primarySource };
        }
    }
}
