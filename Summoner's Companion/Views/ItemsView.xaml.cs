using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using RiotSharp.StaticDataEndpoint;

namespace Summoner_s_Companion.Views
{
    /// <summary>
    /// ItemsView.xaml etkileşim mantığı
    /// </summary>
    public partial class ItemsView
    {
        public ItemsView()
        {
            InitializeComponent();
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void Search_OnKeyDown(object sender, KeyEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (e.Key == Key.Enter)
                SearchButton.Command.Execute(textBox.Text);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemsListBox.GetBindingExpression(ItemsControl.ItemsSourceProperty).UpdateSource();
        }

        private async void ItemsListBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var element = (FrameworkElement)e.OriginalSource;
            var item = (ItemStatic)element.DataContext;
            await DialogHost.Show(new ItemDialog(item));
        }
    }
}
