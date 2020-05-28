using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinUI.AddToShoppingCard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentShoppingCartView : ContentView
    {
        public CurrentShoppingCartViewModel CurrentShoppingCartVM => (CurrentShoppingCartViewModel)BindingContext;

        public CurrentShoppingCartView()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (!(CurrentShoppingCartVM.CurrentCart.ItensCount > 0))
            {
                App.Current.MainPage.DisplayAlert("Ops!", "The Current Cart does not contains items", "Ok");
                return;
            }

            Navigation.PushModalAsync(new CheckOutPage(CurrentShoppingCartVM), true);
        }
    }
}