using System;
using System.Globalization;
using System.Windows.Data;

namespace Summoner_s_Companion.Converters
{
    public class NameFlatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = (string) value;
            return str.Replace(" ", "").Replace("'", "").ToLower();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}