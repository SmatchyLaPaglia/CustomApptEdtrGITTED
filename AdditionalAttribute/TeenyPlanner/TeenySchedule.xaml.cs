using System;
using System.Collections.Generic;
using Xamarin.Forms;
using TeenyPlanner;
using System.Diagnostics;

namespace TeenyPlanner
{
    public partial class TeenySchedule : ContentView
    {
        public string EditorText { get {
                Debug.WriteLine("TeenySchedule: EditorText: " + addressEditor.Text);
                return addressEditor.Text;
            } 
            set {
                addressEditor.Text = value;
            } 
        }
        string editorPlaceholderText = "enter shmaddress";
        Color editorPlaceholderTextColor = Color.Gray;
        public TimePicker ThisTimePicker
        {
            get
            {
                return timePicker;
            }
        }
        public Editor ThisEditor
        {
            get
            {
                return addressEditor;
            }
        }
        public Button SendButton
        {
            get
            {
                return sendDispatchButton;
            }
        }

        //Start app and setup placholder editor text and style
        public TeenySchedule()
        {
            InitializeComponent();
            SetupEditorPlaceholder();
            SetupTimePicker();
            BindingContext = this;
        }

        //Remove editor placeholder text when focused
        void Handle_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            if (EditorText == editorPlaceholderText)
            {
                addressEditor.Text = "";
                addressEditor.TextColor = Color.Black;
            }
        }

        //Reset editor placeholder text if editor is empty
        void Handle_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            Debug.WriteLine("TeenySchedule: Handle_Unfocused: addressEditor.Text: " + EditorText);
            if (String.IsNullOrWhiteSpace(EditorText))
            {
                SetupEditorPlaceholder();
                return;
            }
        }

        //Makes placeholder label over TimePicker disappear when tapped, and calls up timepicker
        void Handle_TimePickerPlaceholder_Tapped(object sender, System.EventArgs e)
        {
            timePickerPlaceholderFrame.IsVisible = false;
            timePickerFrame.IsVisible = true;
            timePicker.Focus();
        }

        //Determines whether or not the send dispatch button should be enabled
        void Handle_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Debug.WriteLine("Handle_PropertyChanged was called");
            if (addressEditor != null)
            {
                var editorTextIsValid = EditorText != editorPlaceholderText && String.IsNullOrWhiteSpace(addressEditor.Text) == false;
                var timeHasBeenSet = timePicker.Time != TimeSpan.Zero;
                //var hopefully = DateTime.Today.Add(timePicker.Time).ToString(timePicker.Format);
                //Debug.WriteLine("TeenySchedule: Handle_PropertyChanged: timePicker.Time: " + hopefully);
                if (editorTextIsValid && timeHasBeenSet)
                {
                    SetSendButtonActive(true);
                }
                else
                {
                    SetSendButtonActive(false);
                }
            }
        }

        //DRY for setting placeholder editor text and color
        void SetupEditorPlaceholder()
        {
            EditorText = editorPlaceholderText;
            addressEditor.Text = EditorText;
            addressEditor.TextColor = editorPlaceholderTextColor;
        }


        public void SetSendButtonActive(bool shouldOrShouldNot){
            sendDispatchButton.IsEnabled = shouldOrShouldNot;
            if (shouldOrShouldNot == true) {
                SetButtonColor(Color.Blue);
                sendDispatchButton.TextColor = Color.White;
            } else {
                SetButtonColor(Color.Transparent);
                sendDispatchButton.Style = this.Resources["textStyle"] as Style;
            }
        }

        //DRY for setting button color
        void SetButtonColor(Color color) {
            sendDispatchButton.BackgroundColor = color;
            sendDispatchButtonFrame.BackgroundColor = color;
        }

        void SetupTimePicker()
        {
            timePicker.Time = TimeSpan.Zero;
        }
    }
}
