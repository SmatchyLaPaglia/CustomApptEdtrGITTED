using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TeenyPlanner
{
    public partial class AnimatePreparedDispatchView : ContentView
    {
        public bool ViewIsVisible { get; set; }

        public AnimatePreparedDispatchView()
        {
            InitializeComponent();
            InputTransparent = true;
            ViewIsVisible = false;
        }

        //protected override void OnSizeAllocated(double width, double height)
        //{
        //    base.OnSizeAllocated(width, height);
        //    if (ViewIsVisible == false) {
        //        PreparedDispatchGrid.TranslationX = this.Width;
        //    } else {
        //        PreparedDispatchGrid.TranslationX = 0;
        //    }
        //}
    }
}
