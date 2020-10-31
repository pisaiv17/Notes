using System;
using Xamarin.Forms;
using Notes.Models;

namespace Notes
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Set item sources
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            ListView.ItemsSource = await App.Database.GetNotesAsync();
        }

        /// <summary>
        /// On single note click show detail of note
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void SingleNote_OnClicked(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NoteSingle
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }

        /// <summary>
        /// Add new note on button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void AddNote_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteSingle
            {
                BindingContext = new Note()
            });
        }
    }
}