using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinUI.AddToShoppingCard.Extention;
using XamarinUI.AddToShoppingCard.Models;

namespace XamarinUI.AddToShoppingCard
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private void StackLayout_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void StackLayout_ChildAdded(object sender, ElementEventArgs e)
        {

        }

        private void StackLayout_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var parameter = (TappedEventArgs)e;
            Navigation.PushModalAsync(new ItemDetailPage((Item)parameter.Parameter), true);
        }
    }
}
