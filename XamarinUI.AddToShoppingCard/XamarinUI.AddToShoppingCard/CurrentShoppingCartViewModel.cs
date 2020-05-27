using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XamarinUI.AddToShoppingCard.Models;
using XamarinUI.AddToShoppingCard.Models.Base;

namespace XamarinUI.AddToShoppingCard
{
    public class CurrentShoppingCartViewModel : ViewModelBase
    {
        public CurrentShoppingCartViewModel()
        {
            ResetProps();
        }

        public void ResetProps()
        {
            CurrentCart = new ShoppingCart();
            CheckOutButtonVisible = false;
        }

        public void AddItemInCurrentCart(Item item)
        {
            CurrentCart.ContentVisible = true;

            if (CurrentCart.Itens != null && CurrentCart.Itens.Contains(item))
            {
                CurrentCart.Itens.FirstOrDefault(x => x == item).Quantity++;
                CurrentCart.Itens.FirstOrDefault(x => x == item).PriceByQuantityPresentation = (CurrentCart.Itens.FirstOrDefault(x => x == item).Quantity * item.Price).ToString("C");

                ReloadTotal();
                
                return;
            }

            item.Quantity++;
            item.PriceByQuantityPresentation = item.Price.ToString("C");

            if (CurrentCart?.Itens == null || CurrentCart.Itens.Count.Equals(0))
                CurrentCart.Itens = new ObservableCollection<Item>
                {
                    item
                };

            else
                CurrentCart.Itens.Add(item);

            ReloadTotal();
        }

        public void ReloadTotal()
        {
            if (CurrentCart.Itens == null)
                return;

            CurrentCart.TotalPresentation = CurrentCart.Itens.Sum(x => x.PriceByQuantity).ToString("C");
        }

        public Command<Item> AddQuantityCommand => new Command<Item>((item) =>
        {
            item.Quantity++;
            item.PriceByQuantityPresentation = (item.Quantity * item.Price).ToString("C");

            ReloadTotal();
        });

        public Command<Item> RmQuantityCommand => new Command<Item>((item) =>
        {
            item.Quantity--;
            item.PriceByQuantityPresentation = (item.Quantity * item.Price).ToString("C");

            ReloadTotal();
        });

        public Command ResumeCartCommand => new Command(() =>
        {
            CurrentCart.ContentVisible = CurrentCart.ContentVisible ? false : true;
        });

        public Command<Item> RemoveItemCommand => new Command<Item>((itemToRemove) =>
        {
            CurrentCart.Itens.Remove(itemToRemove);

            ReloadTotal();
        });

        private ShoppingCart _currentCart;
        public ShoppingCart CurrentCart
        {
            set { SetProperty(ref _currentCart, value); }
            get { return _currentCart; }
        }

        private bool _checkOutButtonVisible;
        public bool CheckOutButtonVisible
        {
            set { SetProperty(ref _checkOutButtonVisible, value); }
            get { return _checkOutButtonVisible; }
        }
    }
}
