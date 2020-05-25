using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using System.Windows.Input;

namespace XamarinUI.AddToShoppingCard.Controls
{
    public partial class ProgressLayout : StackLayout
    {
        public ProgressLayout()
        {
            Children.Add(AddText());
            Children.Add(AddPhase());
        }

        private static StackLayout CurrentChild { get; set; }

        private static Label CurrentTextPhase { get; set; }

        private StackLayout AddPhase()
        {
            CurrentChild = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Transparent,
            };

            return CurrentChild;
        }

        private Label AddText()
        {
            CurrentTextPhase = new Label { FontAttributes = FontAttributes.Bold };
            return CurrentTextPhase;
        }

        public static readonly BindableProperty PhasesProperty =
            BindableProperty.Create(nameof(Phases), typeof(int), typeof(ProgressLayout), 0,
                defaultBindingMode: BindingMode.Default,
                propertyChanged: (BindableObject bindable, object oldValue, object newValue) =>
                {
                    if ((int)newValue == 0)
                        return;

                    CurrentChild.Children.Clear();

                    for (int i = 0; i < (int)newValue; i++)
                    {
                        CurrentChild.Children.Add(new BoxView
                        {
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            BackgroundColor = ColorLess,
                            HeightRequest = 3
                        });
                    }

                    CurrentTextPhase.Text = "0 / " + CurrentChild.Children.Count.ToString();
                });

        public static readonly BindableProperty CurrentPhaseProperty =
            BindableProperty.Create(nameof(CurrentPhase), typeof(int), typeof(ProgressLayout), 0,
                defaultBindingMode: BindingMode.Default,
                propertyChanged: (BindableObject bindable, object oldValue, object newValue) =>
                {

                    var positive = CurrentChild.Children.Take((int)newValue);

                    foreach (var item in positive)
                    {
                        item.BackgroundColor = ColorMore;
                    }

                    var negative = CurrentChild.Children.Where(x => !positive.Contains(x));

                    foreach (var item in negative)
                    {
                        item.BackgroundColor = ColorLess;
                    }

                    CurrentTextPhase.Text = positive.Count().ToString() + " / " + CurrentChild.Children.Count.ToString();

                });

        public int Phases
        {
            get { return (int)GetValue(PhasesProperty); }
            set { SetValue(PhasesProperty, value); }
        }

        public int CurrentPhase
        {
            get { return (int)GetValue(CurrentPhaseProperty); }
            set { SetValue(CurrentPhaseProperty, value); }
        }

        public static Color ColorMore { get { return Color.FromHex("#27ae60"); } }

        public static Color ColorLess { get { return Color.FromHex("#bdc3c7"); } }
    }
}
