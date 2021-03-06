﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using RiotSharp;
using Summoner_s_Companion.Annotations;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
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
            SaveCommand = new RelayCommand(x => Save_Execute(), x => Save_CanExecute());
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
                if (Lang != Variables.Language)
                {
                    Variables.Language = Lang;
                    Variables.Champions = null;
                    await DialogHost.Show(new MessageDialog(
                        "App needs to be restarted. After you close this dialog, app will restart."));
                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
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

        private void ColorButton_OnClick(object sender, RoutedEventArgs e)
        {
            var tag = (string) ((Button) sender).Tag;
            //pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Red.xaml
            Variables.Color = tag;
            App.SwitchColor();
            Colors.SelectedItem = (Button) sender;
        }
    }
}
