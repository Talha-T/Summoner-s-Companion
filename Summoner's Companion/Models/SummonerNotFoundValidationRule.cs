using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Summoner_s_Companion.Annotations;

namespace Summoner_s_Companion.Models
{
    public class SummonerNotFoundValidationRule : ValidationRule, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _isValid = true;

        public bool IsValid
        {
            get => _isValid;
            set
            {
                _isValid = value;
                OnPropertyChanged();
            }
        }


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return new ValidationResult(IsValid, "We cannot find a summoner with given name and region.");
        }
    }
}
