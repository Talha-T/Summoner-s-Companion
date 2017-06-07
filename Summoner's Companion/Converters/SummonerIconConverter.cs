using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;
using Summoner_s_Companion.Requestors;

namespace Summoner_s_Companion.Converters
{
    public class SummonerIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.Assert(value != null, "value != null");
            return $"http://ddragon.leagueoflegends.com/cdn/{Variables.Patch}/img/profileicon/{(int)value}.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}