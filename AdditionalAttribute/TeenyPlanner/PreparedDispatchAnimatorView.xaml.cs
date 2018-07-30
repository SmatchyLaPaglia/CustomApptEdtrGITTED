using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;


namespace TeenyPlanner
{
    public partial class PreparedDispatchAnimatorView : ContentView
    {
		public bool preparedDispatchShowing { get; set; }
        
        public PreparedDispatchAnimatorView()
        {
            InitializeComponent();
            InputTransparent = true;
            
        }

        public void AnimateOut()
        {
            Debug.WriteLine("supposed to be animating out");
            preparedDispatch.TranslateTo(this.Width, 0, 400, Easing.CubicInOut);
            preparedDispatchShowing = false;        }

        public void AnimateIn()
        {
            Debug.WriteLine("supposed to be animating in");
            preparedDispatch.TranslateTo(0, 0, 400, Easing.CubicInOut);
            preparedDispatchShowing = true;
        }

        //protected override void OnSizeAllocated(double width, double height)
        //{
        //    base.OnSizeAllocated(width, height);
        //    if (preparedDispatchShowing == false) {
        //        preparedDispatch.TranslationX = this.Width;
        //    } else {
        //        preparedDispatch.TranslationX = 0;
        //    }
        //}

    }
}
