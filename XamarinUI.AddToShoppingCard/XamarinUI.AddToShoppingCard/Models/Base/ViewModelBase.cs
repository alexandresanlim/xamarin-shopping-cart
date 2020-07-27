using System.Threading.Tasks;
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

        public async Task NavigateModalAsync(Page page)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(page, true);
        }

        public Command NavigateToMainCommand => new Command(async () =>
        {
            await NavigateToMain();
        });

        public async Task NavigateToMain()
        {
            await App.Current.MainPage.Navigation.PopToRootAsync(true);
        }
    }
}
