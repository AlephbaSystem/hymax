using hymax.Services;
using hymax.ViewModels;
using Splat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using hymax.Models;

namespace hymax.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = ViewModel;
            BackgroundColor = ColorServer.GetResource("MainTernaryColor");
        }
        static internal MainViewModel ViewModel { get; set; } = Locator.Current.GetService<MainViewModel>();
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        public void carouselView_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            var item = e.CurrentItem as CarsModel;
            var index = ViewModel.Cars.IndexOf(item);
            ViewModel.UpdateCar(item.ID);
        }
        void OnCarTapped(object sender, EventArgs args)
        {
            ViewModel.OnCarTapped(sender, args);
        }
    }
}
