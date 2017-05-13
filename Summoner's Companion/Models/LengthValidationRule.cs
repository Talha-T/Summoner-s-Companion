using System.Globalization;
using System.Windows.Controls;

namespace Summoner_s_Companion.Models
{
    public class LengthValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = (string) value;
            return new ValidationResult(!string.IsNullOrEmpty(str) && str.Length <= 16, "Summoner name length should be between 1-16");
        }

    }
}
