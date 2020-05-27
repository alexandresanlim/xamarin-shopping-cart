using Xamarin.Forms;

namespace XamarinUI.AddToShoppingCard.Models.Base
{
    public class ViewModelBase : NotifyObjectBase
    {
        private CurrentShoppingCartViewModel _currentShoppingCartVM;
        public CurrentShoppingCartViewModel CurrentShoppingCartVM
        {
            set { SetProperty(ref _currentShoppingCartVM, value); }
            get { return _currentShoppingCartVM; }
        }
    }
}
