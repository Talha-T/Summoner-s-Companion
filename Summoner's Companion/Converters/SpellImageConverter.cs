using System;
using System.Globalization;
using System.Windows.Data;

namespace Summoner_s_Companion.Converters
{
    public class SpellImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var loc = (string) value;
            var passive = System.Convert.ToBoolean(parameter);
            return passive ? $"http://ddragon.leagueoflegends.com/cdn/7.9.1/img/passive/{loc}" : $"http://ddragon.leagueoflegends.com/cdn/7.9.1/img/spell/{loc}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}