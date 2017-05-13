using System.Windows.Controls;
using MaterialDesignThemes.Wpf;

namespace Summoner_s_Companion.Models
{
    public class NavigationBarItem
    {

        public UserControl View { get; set; }
        public string Header { get; set; }
        public PackIcon Icon { get; set; }
    }
}
