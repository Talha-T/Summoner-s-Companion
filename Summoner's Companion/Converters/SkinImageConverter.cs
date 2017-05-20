using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Summoner_s_Companion.Converters
{
    public class SkinImageConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new BitmapImage(new Uri($"http://ddragon.leagueoflegends.com/cdn/img/champion/splash/{values[0].ToString().Replace(" ","").Replace("'","")}_{values[1]}.jpg"));
        }

        public object[] ConvertBack(object values, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}