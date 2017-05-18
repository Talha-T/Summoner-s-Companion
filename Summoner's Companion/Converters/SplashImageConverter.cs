using System;
using System.Globalization;
using System.Windows.Data;

namespace Summoner_s_Companion.Converters
{
    public class SplashImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var champion = (string) value;
            return $"http://ddragon.leagueoflegends.com/cdn/img/champion/splash/{champion}_0.jpg";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}