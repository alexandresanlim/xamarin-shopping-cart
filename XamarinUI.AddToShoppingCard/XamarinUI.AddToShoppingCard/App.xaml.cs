using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinUI.AddToShoppingCard
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new CheckOutPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
