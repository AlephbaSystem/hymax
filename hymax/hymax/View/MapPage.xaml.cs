using hymax.Models;
using hymax.ViewModels;
using Splat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace hymax.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {

        public MapPage()
        {
            InitializeComponent();
            BindingContext = ViewModel;

            this.map.MyLocationEnabled = true;
            this.map.UiSettings.MyLocationButtonEnabled = false;
            this.loc.Text = "location";
            var geocoder = new Xamarin.Forms.GoogleMaps.Geocoder();

            Position startPos = new Position(41.9027835, 12.4963655);
            var addresss = geocoder.GetAddressesForPositionAsync(startPos).Result;
            if (addresss.Count() > 0)
            {
                var pos = addresss.First();
                map.MoveToRegion(MapSpan.FromCenterAndRadius(startPos, Distance.FromMeters(5000)));
                var reg = map.Region;
                this.loc.Text = pos;
            }
            //else
            //{
            //    this.DisplayAlert("Not found", "Geocoder returns no results", "Close");
            //}
        }

        internal SecureLoginViewModel ViewModel { get; set; } = Locator.Current.GetService<SecureLoginViewModel>();

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}