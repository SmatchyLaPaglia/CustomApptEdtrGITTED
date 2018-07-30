using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace TeenyPlanner
{
    public partial class AnimationTestPage : ContentPage
    {
        public AnimationTestPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Debug.WriteLine("Handle_Clicked was clicked in AnimationTestPage");
            if (preparedDispatchAnimator.preparedDispatchShowing)
            {
                preparedDispatchAnimator.AnimateOut();
            }
            else
            {
                preparedDispatchAnimator.AnimateIn();
            }
        }
    }
}
