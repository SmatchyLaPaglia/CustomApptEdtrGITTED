using System;

using Xamarin.Forms;

namespace TeenyPlanner
{
    public class EditorPlaceHolder : Editor
    {

        String placeHolderText = "";

        public EditorPlaceHolder(String placeholder)
        {
            Text = placeholder;
            TextColor = Color.LightGray;
            this.Focused += EditorPlaceHolder_Focused;
            this.Unfocused += EditorPlaceHolder_Unfocused;
            this.placeHolderText = placeholder;
        }

        private void EditorPlaceHolder_Focused(object sender, FocusEventArgs e) //triggered when the user taps on the Editor to interact with it
        {
            if (Empty())
            {
                base.Text = "";
                this.TextColor = Color.Black;
            }
        }

        private void EditorPlaceHolder_Unfocused(object sender, FocusEventArgs e) //triggered when the user taps "Done" or outside of the Editor to finish the editing
        {
            if (Empty()) //if there is text there, leave it, if the user erased everything, put the placeholder Text back and set the TextColor to gray
            {
                this.Text = placeHolderText;
                this.TextColor = Color.LightGray;
            }
        }

        public String PlaceHolderText
        {
            get
            {
                return this.placeHolderText;
            }
            set
            {
                if (this.Empty())
                {
                    this.Text = value;
                    this.TextColor = Color.LightGray;
                }
                this.placeHolderText = value;

            }
        }

        public bool Empty()
        {
            return (this.Text.Equals("") || this.Text.Equals(this.placeHolderText));
        }

        public virtual new string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                if (Empty())
                {
                    this.TextColor = Color.LightGray;
                    base.Text = this.placeHolderText;
                }
                else
                {
                    this.TextColor = Color.Black;
                }

            }

        }
    }
}

