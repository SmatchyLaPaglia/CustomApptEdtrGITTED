using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TeenyPlanner
{
    public partial class TeenySchedule : ContentView
    {
        public TeenySchedule()
        {
            InitializeComponent();
        }

		void Handle_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
		{
			addressEditor.Text = "";
		}
    }
}
