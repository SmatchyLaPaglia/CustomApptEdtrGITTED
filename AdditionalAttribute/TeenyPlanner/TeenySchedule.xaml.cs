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
            setupEditorPlaceholder();
        }

        //Remove editor placeholder text when focused
        void Handle_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            if (addressEditor.Text == editorPlaceholderText)
            {
                addressEditor.Text = "";
                addressEditor.TextColor = Color.Black;
            }
        }

        //Reset editor placeholder text if editor is empty
        void Handle_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            if (addressEditor.Text == "")
            {
                setupEditorPlaceholder();
                return;
            }
        }

        //DRY for setting placeholder editor text and color
        void setupEditorPlaceholder()
        {
            addressEditor.Text = editorPlaceholderText;
            addressEditor.TextColor = editorPlaceholderTextColor;
        }


        void Handle_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
        }

        //Makes placeholder label over TimePicker disappear when tapped, and calls up timepicker
        void Handle_TimePickerPlaceholder_Tapped(object sender, System.EventArgs e)
        {
            timePickerPlaceholderFrame.IsVisible = false;
            timePicker.Focus();
        }
    }
}
