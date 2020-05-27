using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinUI.AddToShoppingCard.Models;
using XamarinUI.AddToShoppingCard.Models.Base;

namespace XamarinUI.AddToShoppingCard
{
    public class ItemDetailViewModel : ViewModelBase
    {
        public ItemDetailViewModel()
        {

        }

        private Item _currentItem;
        public Item CurrentItem
        {
            set { SetProperty(ref _currentItem, value); }
            get { return _currentItem; }
        }
    }
}
