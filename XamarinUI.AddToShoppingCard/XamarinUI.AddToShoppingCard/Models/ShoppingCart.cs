using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using XamarinUI.AddToShoppingCard.Models.Base;

namespace XamarinUI.AddToShoppingCard.Models
{
    public class ShoppingCart : ModelBase
    {
        private ObservableCollection<Item> _itens;
        public ObservableCollection<Item> Itens
        {
            set { SetProperty(ref _itens, value); }
            get { return _itens; }
        }

        public decimal Total => Itens.Sum(x => x.Price);

        private string _totalPresentation;
        public string TotalPresentation
        {
            set { SetProperty(ref _totalPresentation, value); }
            get { return _totalPresentation; }
        }

        private bool _contentVisible = true;
        public bool ContentVisible
        {
            set { SetProperty(ref _contentVisible, value); }
            get { return _contentVisible; }
        }

        private int _itensCount;
        public int ItensCount
        {
            set { SetProperty(ref _itensCount, value); }
            get { return _itensCount; }
        }
    }
}
