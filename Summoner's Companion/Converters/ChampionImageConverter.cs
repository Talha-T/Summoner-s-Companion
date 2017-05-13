using System;
using System.Globalization;
using System.Windows.Data;

namespace Summoner_s_Companion.Converters
{
    public class ChampionImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "http://ddragon.leagueoflegends.com/cdn/7.9.1/img/champion/" + value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}