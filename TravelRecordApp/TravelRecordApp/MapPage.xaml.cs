using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            locator.PositionChanged += Locator_PositionChanged;
            await locator.StartListeningAsync(new TimeSpan(),100);

            var position = await locator.GetPositionAsync();
            locationsMap.MoveToRegion(new Xamarin.Forms.Maps.MapSpan(new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude), 2, 2));
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            locationsMap.MoveToRegion(new Xamarin.Forms.Maps.MapSpan(new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude), 2, 2));
        }
    }
}