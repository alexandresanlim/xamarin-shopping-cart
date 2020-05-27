using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinUI.AddToShoppingCard.Models;

namespace XamarinUI.AddToShoppingCard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailViewModel ItemDetailVM => (ItemDetailViewModel)BindingContext;

        public ItemDetailPage(Item itemDetail)
        {
            InitializeComponent();
            ItemDetailVM.CurrentItem = itemDetail;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                await Navigation.PopModalAsync();
            });
        }
    }
}