using System;
using System.Globalization;
using System.Windows.Data;

namespace Summoner_s_Companion.Converters
{
    public class AttackSpeedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return .625 / 1 + (double) value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}