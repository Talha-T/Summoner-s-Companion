using System;
using System.Globalization;
using System.Windows.Controls;

namespace Summoner_s_Companion.Models
{
    public class NumericValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var result = int.TryParse((string)value, out int number);
            if (result && number >= 10 && number <= 20000)
                return new ValidationResult(true, "");
            return new ValidationResult(false, result ? "Value must be between 10-20000" : "Value must be numeric");

        }
    }
}
