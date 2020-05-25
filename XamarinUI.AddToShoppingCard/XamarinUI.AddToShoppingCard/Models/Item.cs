using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using XamarinUI.AddToShoppingCard.Models.Base;

namespace XamarinUI.AddToShoppingCard.Models
{
    public class Item : ModelBase
    {
        public Item()
        {
            SubItens = new List<Item>();
        }

        //public int Quantity { get; set; }

        private int _quantity;
        public int Quantity
        {
            set { SetProperty(ref _quantity, value); }
            get { return _quantity; }
        }

        public decimal Price { get; set; }

        public string PricePresentation => Price.ToString("C");

        public decimal PriceByQuantity => (Quantity * Price);

        private string _priceByQuantityPresentation;
        public string PriceByQuantityPresentation
        {
            set { SetProperty(ref _priceByQuantityPresentation, value); }
            get { return _priceByQuantityPresentation; }
        }

        public List<Item> SubItens { get; set; }

        public Item Parent { get; set; }

        public bool HasSubItens { get { return SubItens?.Count > 0; } }

        public bool NotHasSubItens { get { return !HasSubItens; } }

        public bool IsSubItem { get; set; }

        public int RequiredSubItensCount { get; set; }

        
    }

    public static class ItemExtention
    {
        public static Item MountByList(this List<Item> listItemToMount)
        {
            var parent = listItemToMount.Select(x => x.Parent).FirstOrDefault();

            var itemReturn = new Item
            {
                Price = parent.Price,
                Title = parent.Title + ":\n"
            };

            foreach (var item in listItemToMount)
            {
                itemReturn.Title += "(" + item.Quantity + ") " + item.Title + "\n";
            }

            return itemReturn;
        }

        public static Item AddSubItens(this Item parent, List<Item> subItensToAdd, int requiredSubItensCount = 0)
        {
            //subItensToAdd.Select(x =>
            //{
            //     = true;
            //    return x;
            //}).ToList();

            foreach (var item in subItensToAdd)
            {
                item.Parent = parent;
                //item.Price = this.Price;
                item.IsSubItem = true;
            }

            parent.SubItens = subItensToAdd;
            parent.RequiredSubItensCount = requiredSubItensCount;

            return parent;
        }
    }

}
