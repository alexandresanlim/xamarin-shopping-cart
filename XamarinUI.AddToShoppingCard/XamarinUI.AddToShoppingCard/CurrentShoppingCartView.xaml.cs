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
    }
}