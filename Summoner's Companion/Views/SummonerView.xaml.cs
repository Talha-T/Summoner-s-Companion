using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using Summoner_s_Companion.Models;
using Summoner_s_Companion.Requestors;

namespace Summoner_s_Companion.Views
{
    /// <summary>
    /// SummonerView.xaml etkileşim mantığı
    /// </summary>
    public partial class SummonerView
    {
        public SummonerView()
        {
            InitializeComponent();
            SearchBox.TextChanged += SearchBox_TextChanged;
            ToggleProgress(false);
        }

        

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NotFoundValidationRule.IsValid = true;
            SearchBox.Text = SearchBox.Text;
            BindingOperations.GetBindingExpression(SearchBox, TextBox.TextProperty)?.UpdateTarget();
        }

        private void ToggleProgress(bool progress)
        {
            ProgressBar.Visibility = progress ? Visibility.Visible : Visibility.Collapsed;
            PackIcon.Visibility = !progress ? Visibility.Visible : Visibility.Hidden;
        }

        public RelayCommand SearchCommand => new RelayCommand(Search, x => true);

        private async void Search(object x)
        {
            ToggleProgress(true);
            var summoner = await SummonerRequestor.GetSummoner((string) x, ViewModel.Region);
            if (summoner == null)
            {
                NotFoundValidationRule.IsValid = false;
                SearchBox.Text = SearchBox.Text;
                BindingOperations.GetBindingExpression(SearchBox, TextBox.TextProperty)?.UpdateTarget();
            }
            else
                ViewModel.Summoner = summoner;
            ToggleProgress(false);
        }

        private void Search_OnKeyDown(object sender, KeyEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (e.Key == Key.Enter)
                SearchButton.Command.Execute(textBox.Text);
        }

        private void RegionsComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NotFoundValidationRule.IsValid = true;
            SearchBox.Text = SearchBox.Text;
        }

        
    }
}
