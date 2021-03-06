﻿using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Summoner_s_Companion.Converters
{
    public class ArrayToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var array = ((IEnumerable) value).OfType<object>();
            var seperator = parameter == null ? ", " : (string)parameter;
            if (!array.Any()) return "";
            return array.Aggregate((x, y) => x + seperator + y);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}