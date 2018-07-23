using System;
using System.Collections.Generic;
using Xamarin.Forms;
using TeenyPlanner;

namespace TeenyPlanner
{
    public partial class TeenySchedule : ContentView
    {
        string editorPlaceholderText = "enter address";
        Color editorPlaceholderTextColor = Color.Gray;

        //Start app and setup placholder editor text and style
        public TeenySchedule()
        {
            InitializeComponent();
            setupPlaceholderEditor();
        }

        //Remove editor placeholder text when focused
		void Handle_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
		{
            if (addressEditor.Text == editorPlaceholderText) {
                addressEditor.Text = "";
                addressEditor.TextColor = Color.Black;
            }
		}

        void Handle_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            if (addressEditor.Text == "")
            {
                setupPlaceholderEditor();
                return;
            }        }

        //Change editor text to placeholder if editor is empty
        //void Handle_Unfocused(object sender, Xamarin.Forms.TextChangedEventArgs e)
        //{
            //if (addressEditor.Text == "")
            //{
            //    setupPlaceholderEditor();
            //    return;
            //}
        //}

        //DRY for setting placeholder editor text and color
        void setupPlaceholderEditor() {
            addressEditor.Text = editorPlaceholderText;
            addressEditor.TextColor = editorPlaceholderTextColor;
        }
    }
}
