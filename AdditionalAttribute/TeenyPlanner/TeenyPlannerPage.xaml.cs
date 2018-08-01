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

            ConfigureSendButtonAction();

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

        private void ConfigureSendButtonAction() {
            animatingView.DispatchTime.Text = teenySchedule.ThisTimePicker.Time.ToString();
            animatingView.DispatchData.Text = teenySchedule.ThisEditor.Text.ToString();
            teenySchedule.SendButton.Clicked += (s, e) => {
                animatingView.AnimateIn();
            };
        }
    }
}
