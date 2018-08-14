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
            teenySchedule.SendButton.Clicked += (s, e) => {
                var timeString = teenySchedule.
                var timeString = DateTime.Today.Add(teenySchedule.ThisTimePicker.Time).ToString(teenySchedule.ThisTimePicker.Format);
                animatingView.DispatchTime.Text = timeString;
                animatingView.DispatchData.Text = teenySchedule.EditorText;
                teenySchedule.SetSendButtonActive(false);
                animatingView.AnimateIn();
            };
        }
    }
}
