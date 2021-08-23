using hymax.Models;
using hymax.Services;
using hymax.ViewModels;
using Splat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
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
            this.map.UiSettings.CompassEnabled = false;
            this.map.UiSettings.MapToolbarEnabled = false;
            this.map.UiSettings.ZoomControlsEnabled = false;
            this.map.UiSettings.MyLocationButtonEnabled = false;
            this.loc.Text = ViewModel.rs.GetString("LocationAddressWaiting");
            ViewModel.RecivedPosition += new Action<Position, string>(NewLocation);
            this.map.MoveToRegion(
            MapSpan.FromCenterAndRadius(new Position(36.2824, 59.5959), new Distance(300d))
);

        }
        internal MapViewModel ViewModel { get; set; } = Locator.Current.GetService<MapViewModel>();
        private async void NewLocation(Position startPos, string address)
        {
            await Task.Delay(100);
            this.map.Pins.Clear();
            this.loc.Text = address;
            Pin p = new Pin();
            p.Label = "";
            p.Position = startPos;
            p.Type = PinType.Place;
            this.map.Pins?.Add(p);
            this.map.MoveToRegion(MapSpan.FromCenterAndRadius(startPos, Distance.FromMeters(500)));
        }
        protected override void OnAppearing()
        {
            ViewModel.CodeSend();
            base.OnAppearing();
            Services.Settings.LastPage = "Map";
        }
    }
}