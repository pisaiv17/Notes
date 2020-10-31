using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteSingle : ContentPage
    {
        public NoteSingle()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Textarea focus
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            Editor.Focus();
        }

        /// <summary>
        /// On textarea switch save note
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Editor_OnSwitched(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (note.Text != "")
            {
                await App.Database.SaveNoteAsync(note);
            }
            else
            {
                await Navigation.PopAsync();
            }
        }

        /// <summary>
        /// Delete note
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Delete_OnClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (note.ID != 0)
            {
                await App.Database.DeleteNoteAsync(note);
            }
            
            await Navigation.PopAsync();
        }
    }
}