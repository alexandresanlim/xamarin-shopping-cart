using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinUI.AddToShoppingCard.Models.Base;

namespace XamarinUI.AddToShoppingCard
{
    public class CheckOutViewModel : ViewModelBase
    {
        public CheckOutViewModel()
        {
            ResetProps();
        }

        private void ResetProps()
        {

        }

        public Command NavigateToFinishCommand => new Command(async () =>
        {
            await NavigateModalAsync(new FinishPage());
        });
    }
}
