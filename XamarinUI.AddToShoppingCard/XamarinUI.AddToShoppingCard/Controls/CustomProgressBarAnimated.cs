using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinUI.AddToShoppingCard.Controls
{
    public class CustomProgressBarAnimated : ProgressBar
    {
        public CustomProgressBarAnimated()
        {
            ProgressColor = App.Style.Accent;

            Task.Run(async () =>
            {
                while (true)
                {
                    var a = 0.0;

                    for (int i = 0; i <= 5; i++)
                    {
                        await this.ProgressTo(a, 500, Easing.Linear);

                        a += 0.20;
                    }
                }
            });
        }
    }
}
