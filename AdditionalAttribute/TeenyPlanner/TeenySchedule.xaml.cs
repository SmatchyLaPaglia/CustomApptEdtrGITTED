﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using TeenyPlanner;
using System.Diagnostics;

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
            setupTimePicker();
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

        //Makes placeholder label over TimePicker disappear when tapped, and calls up timepicker
        void Handle_TimePickerPlaceholder_Tapped(object sender, System.EventArgs e)
        {
            timePickerPlaceholderFrame.IsVisible = false;
            timePicker.Focus();
        }

        //Determines whether or not the send dispatch button should be enabled
        void Handle_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
                Debug.WriteLine("Handle_PropertyChanged was called");
            if (addressEditor != null) {
                var editorTextIsValid = addressEditor.Text != editorPlaceholderText && String.IsNullOrWhiteSpace(addressEditor.Text) == false;
                var timeHasBeenSet = timePicker.Time != TimeSpan.Zero;
                if (editorTextIsValid && timeHasBeenSet) {
                    sendDispatchButton.IsEnabled = true;
                    sendDispatchButton.TextColor = Color.White;
                    sendDispatchButton.BackgroundColor = Color.Blue;

                    sendDispatchButtonFrame.BackgroundColor = Color.Blue;
                } else {
                    sendDispatchButton.IsEnabled = false;
                    sendDispatchButton.BackgroundColor = Color.White;
                    sendDispatchButtonFrame.BackgroundColor = Color.White;
                    sendDispatchButton.Style = this.Resources["textStyle"] as Style;
                }
            }
        }

        //DRY for setting placeholder editor text and color
        void setupEditorPlaceholder()
        {
            addressEditor.Text = editorPlaceholderText;
            addressEditor.TextColor = editorPlaceholderTextColor;
        }

        void setupTimePicker() {
            timePicker.Time = TimeSpan.Zero;
        }
    }
}
