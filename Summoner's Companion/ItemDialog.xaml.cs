using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using RiotSharp.StaticDataEndpoint;
using Summoner_s_Companion.Annotations;
using Summoner_s_Companion.Requestors;

namespace Summoner_s_Companion
{
    /// <summary>
    /// ItemDialog.xaml etkileşim mantığı
    /// </summary>
    public partial class ItemDialog : INotifyPropertyChanged
    {
        private ItemStatic _ıtem;

        public ItemDialog()
        {
            InitializeComponent();
        }

        private readonly Stopwatch _watch = new Stopwatch();

        public ItemDialog(ItemStatic item) : this()
        {
            Item = item;
        }

        public ItemStatic Item
        {
            get => _ıtem;
            set
            {
                _ıtem = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(BuildsInto));
                OnPropertyChanged(nameof(BuildsFrom));
            }
        }

        public List<ItemStatic> BuildsInto
        {
            get
            {
                return Item?.Into?.ConvertAll(x => Variables.Items.Find(y => y.Id == x)).ToList();
            }
        }

        public List<ItemStatic> BuildsFrom
        {
            get
            {
                return Item?.From?.ConvertAll(x => Variables.Items.Find(y => y.Id == int.Parse(x))).ToList();
            }
        }

        public Stopwatch Watch => _watch;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void Listbox_Click(object sender, MouseButtonEventArgs e)
        {
            var element = (FrameworkElement)e.OriginalSource;
            var item = (ItemStatic)element.DataContext;
            MainWindow.Instance.RootDialog.IsOpen = false;
            await DialogHost.Show(new ItemDialog(item));
        }
    }
}
