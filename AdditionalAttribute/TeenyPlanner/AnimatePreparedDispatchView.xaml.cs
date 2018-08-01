using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TeenyPlanner
{
    public partial class AnimatePreparedDispatchView : ContentView
    {
        public bool ViewIsVisible { get; set; }
        public Label DispatchTime { get; set; }
        public Label DispatchData { get; set; }

        public AnimatePreparedDispatchView()
        {
            InitializeComponent();
            InputTransparent = true;
            ViewIsVisible = false;
            DispatchTime = dispatchTime;
            DispatchData = dispatchData;
        }

        public void AnimateIn()
        {
            if (ViewIsVisible == false)
            {
                PreparedDispatchGrid.TranslateTo(0, 0, 400, Easing.CubicInOut);
                ViewIsVisible = true;
            }

            InputTransparent = false;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (PreparedDispatchGrid == null) {
                return;
            }

            if (ViewIsVisible == false)
            {
                PreparedDispatchGrid.TranslationX = this.Width;
            }
            else
            {
                PreparedDispatchGrid.TranslationX = 0;
            }
        }
    }
}
