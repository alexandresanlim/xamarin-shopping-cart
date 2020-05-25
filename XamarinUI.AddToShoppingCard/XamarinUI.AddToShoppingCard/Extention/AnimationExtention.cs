using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinUI.AddToShoppingCard.Extention
{
    public static class AnimationExtention
    {
        public static void SetTapAnimation(this View view)
        {
            view.AnchorX = 0.48;
            view.AnchorY = 0.48;

            Task.Run(async () =>
            {
                await view.ScaleTo(0.8, 50, Easing.Linear);
                await Task.Delay(100);
                await view.ScaleTo(1, 50, Easing.Linear);
            });
        }
    }
}
