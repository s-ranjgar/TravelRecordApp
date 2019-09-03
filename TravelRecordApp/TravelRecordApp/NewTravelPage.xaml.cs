using System;
using Plugin.Geolocator;
using SQLite;
using TravelRecordApp.Logic;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var locator = CrossGeolocator.Current;
            
            //var position = await locator.GetPositionAsync();
            //var venues = VenueLogic.GetVenues(position.Latitude, position.Longitude);

            var venues = await VenueLogic.GetVenues(37.422, -122.084);
            venueListView.ItemsSource = venues;
        }
        private void SaveToolbarItem_OnClicked(object sender, EventArgs e)
        {
            try
            {

                var selectedVenue = venueListView.SelectedItem as Venue;
                var firstCategory = selectedVenue.categories.FirstOrDefault();
                var post = new Post
                {
                    Experience = experienceEntry.Text,
                    CategoryId = firstCategory.id,
                    CategoryName = firstCategory.name,
                    LocationAddress = selectedVenue.location.address,
                    Distance = selectedVenue.location.distance,
                    Latitude = selectedVenue.location.lat,
                    Longitude = selectedVenue.location.lng,
                    VenueName = selectedVenue.name
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
            catch(NullReferenceException nre)
            {

            }
            catch (Exception ex)
            {

            }
        }
    }
}