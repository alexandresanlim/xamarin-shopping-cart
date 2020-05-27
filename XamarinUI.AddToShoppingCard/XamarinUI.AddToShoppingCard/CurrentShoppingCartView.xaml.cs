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
        public CurrentShoppingCartView()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CheckOutPage((CurrentShoppingCartViewModel)BindingContext), true);
        }

        private void L_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(CollectionView.ItemsSource)))
            {
                var c = (CollectionView)sender;

                Task.Run(async () =>
                {
                    c.Opacity = 0;
                    await c.FadeTo(1, 500);
                });
            }
        }
    }
}