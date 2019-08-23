using System;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        private void SaveToolbarItem_OnClicked(object sender, EventArgs e)
        {
            var post = new Post
            {
                Experience = experienceEntry.Text
            };

            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                var rows = conn.Insert(post);

                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience successfully inserted", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Experience failed to be inserted", "Ok");
                }
            }
        }
    }
}