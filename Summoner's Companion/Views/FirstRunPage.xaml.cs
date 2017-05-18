using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using RiotSharp;
using Summoner_s_Companion.Annotations;
using System.Windows.Input;
using Summoner_s_Companion.Models;
using Summoner_s_Companion.Requestors;

namespace Summoner_s_Companion.Views
{
    /// <summary>
    /// FirstRunPage.xaml etkileşim mantığı
    /// </summary>
    public partial class FirstRunPage : INotifyPropertyChanged
    {
        public FirstRunPage()
        {
            SaveCommand = new RelayCommand(Save_Execute,Save_CanExecute);
            InitializeComponent();
        }

        private string _summName;

        public string SummonerName
        {
            get => _summName;
            set
            {
                _summName = value;
                OnPropertyChanged();
            }
        }

        private Region _region = Region.euw;

        public Region Region
        {
            get => _region;
            set
            {
                _region = value;
                OnPropertyChanged();
            }
        }

        private Language _language;

        public Language Lang
        {
            get => _language;
            set
            {
                _language = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<Language> Languages => Enum.GetValues(typeof(Language)).Cast<Language>();

        public List<Region> Regions
        {
            get
            {
                var c = Enum.GetValues(typeof(Region)).Cast<Region>().ToList();
                c.Remove(Region.global);
                return c;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _check;

        private async void Save_Execute()
        {
            ProgressBar.Visibility = Visibility.Visible;
            SaveButton.Visibility = Visibility.Collapsed;
            var exists = await SummonerRequestor.CheckSummoner(SummonerName, Region);
            ProgressBar.Visibility = Visibility.Collapsed;
            SaveButton.Visibility = Visibility.Visible;
            if (!exists)
            {
                NotFoundValidationRule.IsValid = false;
                _check = true;
                OnPropertyChanged(nameof(SummonerName));
            }
            else
            {
                Variables.SummonerName = SummonerName;
                Variables.Region = Region;
                Variables.Language = Lang;
                MainWindow.Instance.Transitioner.SelectedIndex = 0;
            }
        }

        private bool Save_CanExecute()
        {
            if (_check)
                NotFoundValidationRule.IsValid = true;
            var bindingExpression = SummonerNameTextBox.GetBindingExpression(TextBox.TextProperty);
            if (bindingExpression != null)
                return !bindingExpression.HasValidationError;
            throw new NullReferenceException();
        }

        private void RegionsComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NotFoundValidationRule.IsValid = true;
            SummonerNameTextBox.Text = SummonerNameTextBox.Text;
        }

        public ICommand SaveCommand { get; }
    }
}
