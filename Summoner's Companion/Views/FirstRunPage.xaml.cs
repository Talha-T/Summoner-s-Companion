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

        private async void Save_Executed(object sender, ExecutedRoutedEventArgs e)
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
                Variables.FirstRun = false;
                MainWindow.Instance.Transitioner.SelectedIndex = 0;
            }
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (_check)
                NotFoundValidationRule.IsValid = true;
            var bindingExpression = SummonerNameTextBox.GetBindingExpression(TextBox.TextProperty);
            if (bindingExpression != null)
                e.CanExecute = !bindingExpression.HasValidationError;
            else
                throw new NullReferenceException();
        }
    }
}
