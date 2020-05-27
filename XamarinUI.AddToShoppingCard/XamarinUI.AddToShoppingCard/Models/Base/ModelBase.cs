using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace XamarinUI.AddToShoppingCard.Models.Base
{
    public class ModelBase : NotifyObjectBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Images from https://unsplash.com/s/photos/product?orientation=squarish
        /// </summary>
        public string ImageUri { get; set; }
    }
}
