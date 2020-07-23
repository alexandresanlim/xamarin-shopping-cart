using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinUI.AddToShoppingCard.Behavior;

namespace XamarinUI.AddToShoppingCard.Controls
{
    public class CustomButton : CustomFrame
    {
        private static CustomLabel TexButtonValue { get; set; }

        private static TapViewBehavior TapButtonValue { get; set; }

        public CustomButton()
        {
            Margin = new Thickness(0, 5);
            //BackgroundGradientStartColor = App.Style.SecondaryDarkColor;
            BackgroundColor = App.Style.Accent;
            CornerRadius = new CornerRadius(25, 0, 25, 25);
            Content = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(15),
                Children =
                {
                    AddText(),
                }
            };
            Behaviors.Add(AddTapBehavior());
        }

        private CustomLabel AddText()
        {
            TexButtonValue = new CustomLabel() { HorizontalOptions = LayoutOptions.CenterAndExpand, FontAttributes = FontAttributes.Bold, TextColor = App.Style.Icons };

            return TexButtonValue;
        }

        private Xamarin.Forms.Behavior AddTapBehavior()
        {
            TapButtonValue = new TapViewBehavior();
            return TapButtonValue;
        }

        public static readonly BindableProperty TextButtonProperty =
            BindableProperty.Create(nameof(TextButton), typeof(string), typeof(CustomButton), null, BindingMode.Default, null, propertyChanged: (BindableObject bindable, object oldValue, object newValue) =>
            {
                TexButtonValue.Text = (string)newValue;
            });

        public string TextButton
        {
            get { return (string)GetValue(TextButtonProperty); }
            set { SetValue(TextButtonProperty, value); }
        }

        public static readonly BindableProperty TapButtonCommandProperty =
            BindableProperty.Create(nameof(TapButtonCommand), typeof(ICommand), typeof(CustomButton), propertyChanged: (BindableObject bindable, object oldValue, object newValue) =>
            {
                TapButtonValue.Command = (ICommand)newValue;
            });

        public ICommand TapButtonCommand
        {
            get { return (ICommand)GetValue(TapButtonCommandProperty); }
            set { SetValue(TapButtonCommandProperty, value); }
        }


        public static readonly BindableProperty TapButtonCommandParameterProperty =
            BindableProperty.Create(nameof(TapButtonCommandParameter), typeof(object), typeof(CustomButton), propertyChanged: (BindableObject bindable, object oldValue, object newValue) =>
            {
                TapButtonValue.CommandParameter = (object)newValue;
            });

        public object TapButtonCommandParameter
        {
            get { return (object)GetValue(TapButtonCommandParameterProperty); }
            set { SetValue(TapButtonCommandParameterProperty, value); }
        }

        public string LeftIcon
        {
            get { return (string)GetValue(LeftIconProperty); }
            set { SetValue(LeftIconProperty, value); }
        }

        public static readonly BindableProperty LeftIconProperty =
            BindableProperty.Create(nameof(LeftIcon), typeof(string), typeof(CustomButton), propertyChanged: (BindableObject bindable, object oldValue, object newValue) =>
            {

            });
    }
}
