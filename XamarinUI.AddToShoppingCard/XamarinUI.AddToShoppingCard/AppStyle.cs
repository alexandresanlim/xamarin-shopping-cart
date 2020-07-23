using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinUI.AddToShoppingCard
{
    public partial class App
    {
        public static ColorStyle Style => new ColorStyle
        {
            Primary = (Color)App.Current.Resources["primary"],
            PrimaryDark = (Color)App.Current.Resources["primary_dark"],
            PrimaryLight = (Color)App.Current.Resources["primary_light"],
            Accent = (Color)App.Current.Resources["accent"],
            PrimaryText = (Color)App.Current.Resources["primary_text"],
            SecondaryText = (Color)App.Current.Resources["secondary_text"],
            Icons = (Color)App.Current.Resources["icons"],
            Divider = (Color)App.Current.Resources["divider"],
            BackgroundPage = (Color)App.Current.Resources["background_page"]
        };
    }

    public class ColorStyle
    {
        public Color Primary { get; set; }

        public Color PrimaryDark { get; set; }

        public Color PrimaryLight { get; set; }

        public Color Accent { get; set; }

        public Color PrimaryText { get; set; }

        public Color SecondaryText { get; set; }

        public Color Icons { get; set; }

        public Color Divider { get; set; }

        public Color BackgroundPage { get; set; }
    }
}
