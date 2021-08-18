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
            this.loc.Text = "location"; 
        }
        internal MapViewModel ViewModel { get; set; } = Locator.Current.GetService<MapViewModel>();

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}