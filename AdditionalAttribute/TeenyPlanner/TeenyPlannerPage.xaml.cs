using System;
using System.Collections.Generic;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace TeenyPlanner
{
    public partial class TeenyPlannerPage : ContentPage
    {
        public TeenyPlannerPage()
        {
            InitializeComponent();
            background.Source = ImageSource.FromResource("AdditionalAttribute.flower.jpg");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            teenySchedule.SendButton.Clicked += (s, e) => {
                Debug.WriteLine("dat button got cleeeeked!!");
                animatingView.AnimateIn();
            };

            Debug.WriteLine(this.Padding.Top);
            Debug.WriteLine(On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets().Top);
            var safeInsets = new Thickness();
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    safeInsets = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
                    break;
                default:
                    break;
            }

            mainGrid.Padding = safeInsets;
        }
    }
}
