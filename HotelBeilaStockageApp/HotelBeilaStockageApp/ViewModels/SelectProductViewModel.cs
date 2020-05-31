using HotelBeilaStockageApp.ViewModels.Base;
using HotelBeilaStockageApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using HotelBeilaStockageApp.Models;
using HotelBeilaStockageApp.Interfaces.Services;
using HotelBeilaStockageApp.Container;

namespace HotelBeilaStockageApp.ViewModels
{
    public class SelectProductViewModel : ViewModelBase
    {
        private string chosenArea = "all";
        private readonly IItemDataService _itemDataService;
        private IList<Item> _items;
        private Item _selectedProduct;
        public SelectProductViewModel()
        {
            _itemDataService = (IItemDataService)AppContainer.Instance.Resolve(typeof(IItemDataService));
            MessagingCenter.Subscribe<SelectAreaViewModel, string>(this, "whichArea", (sender, arg) =>
            {
                chosenArea = arg;
                FillListView(chosenArea);
            });
        }

        public string ChosenArea
        {
            get { return chosenArea; }
            set
            {
                chosenArea = value;
                OnPropertyChanged();
            }
        }

        public IList<Item> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public Item SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                if(_selectedProduct != value)
                {
                    _selectedProduct = value;
                    HandleSelectedItem();
                }
                OnPropertyChanged();
            }
        }

        private async void HandleSelectedItem()
        {
            await App.Current.MainPage.Navigation.PushAsync(new DetailPage());
            MessagingCenter.Unsubscribe<SelectAreaViewModel, string>(this, chosenArea);
            MessagingCenter.Send<SelectProductViewModel, Item>(this,"product",SelectedProduct);
        }

        public async void FillListView(string chosenArea)
        {
            if (chosenArea == "bar")
            {
                String area = "Bar";
                Items = await _itemDataService.GetItemByAreaAsync(area);
            }
            else if (chosenArea == "cleaning")
            {
                String area = "Cleaning";
                Items = await _itemDataService.GetItemByAreaAsync(area);
            }
            else if (chosenArea == "breakfast")
            {
                String area = "Breakfast";
                Items = await _itemDataService.GetItemByAreaAsync(area);
            }
            else if (chosenArea == "other")
            {
                String area = "Other";
                Items = await _itemDataService.GetItemByAreaAsync(area);
            }
            else
            {
                Items = await _itemDataService.GetAllItemsAsync();
            }
        }
    }
}