using System;
using System.Collections.Generic;
using System.Text;
using XamarinUI.AddToShoppingCard.Models.Base;

namespace XamarinUI.AddToShoppingCard.Models
{
    public class Parent : ModelBase
    {
        public List<Item> ChildList { get; set; }
    }
}
