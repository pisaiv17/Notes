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
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            ListView.ItemsSource = await App.Database.GetNotesAsync();
        }

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

        async void AddNote_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteSingle
            {
                BindingContext = new Note()
            });
        }
    }
}