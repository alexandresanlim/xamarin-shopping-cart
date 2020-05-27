using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinUI.AddToShoppingCard.Models;

namespace XamarinUI.AddToShoppingCard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckOutPage : ContentPage
    {
        public CheckOutViewModel CheckOutVM => (CheckOutViewModel)BindingContext;

        public CheckOutPage(CurrentShoppingCartViewModel _currentCart)
        {
            InitializeComponent();

            CheckOutVM.CurrentShoppingCartVM = _currentCart;
            CheckOutVM.CurrentShoppingCartVM.CheckOutButtonVisible = true;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                CheckOutVM.CurrentShoppingCartVM.CheckOutButtonVisible = false;
                await Navigation.PopModalAsync();
            });
        }
    }
}