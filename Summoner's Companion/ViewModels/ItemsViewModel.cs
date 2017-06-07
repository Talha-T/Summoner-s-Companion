using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using RiotSharp;
using RiotSharp.StaticDataEndpoint;
using Summoner_s_Companion.Models;
using Summoner_s_Companion.Properties;
using Summoner_s_Companion.Requestors;

namespace Summoner_s_Companion.ViewModels
{
    public class ItemsViewModel : ViewModelBase
    {
        public List<ItemStatic> Items
        {
            get => _items;
            private set { _items = value; OnPropertyChanged();}
        }

        public ItemsViewModel()
        {
            LoadItems();
            SearchCommand = new RelayCommand(x => Items = Variables.Items.Where(y => y.Name != null && y.Name.ToLower().Contains(x.ToString().ToLower())).ToList());
        }

        public RelayCommand SearchCommand { get; } 

        private async void LoadItems()
        {
            try
            {
                if (Variables.Items == null)
                {
                    var api = StaticRiotApi.GetInstance(Resources.apiKey);
                    Items = Variables.Items =
                        (await api.GetItemsAsync(Variables.Region, ItemData.all, Variables.Language))
                        .Items.Values
                        .ToList();
                }
                else
                    Items = Variables.Items;
                SortBySortMode();
                ItemsLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool _itemsLoaded;
        private List<ItemStatic> _items;
        private string _sortMode = "Name";

        public bool ItemsLoaded
        {
            get => _itemsLoaded;
            set { _itemsLoaded = value; OnPropertyChanged(); }
        }

        public string SortMode
        {
            get => _sortMode;
            set
            {
                _sortMode = value;
                OnPropertyChanged();
                SortBySortMode();
            }
        }

        private string _filter = "All";

        public string Filter
        {
            get => _filter;
            set
            {
                _filter = value;
                OnPropertyChanged();
                FilterItems();
            }
        }


        private void SortBySortMode()
        {
            Items.RemoveAll(x => x?.Name == null || x.Gold == null);
            Items = Items.OrderBy(x => SortMode == "Name"
                    ? x.Name
                    : x.Gold.TotalPrice.ToString()).Distinct()
                .ToList();
            //OnPropertyChanged(nameof(Items));
        }

        private void FilterItems()
        {
            Items = Variables.Items.Where(x => Filter == "Summoner's Rift" ? x.Maps["11"] : Filter == "Twisted Treeline" ? x.Maps["10"] : Filter == "Howling Abyss" ? x.Maps["12"] : true).ToList();
            SortBySortMode();
        }
        
    }
}