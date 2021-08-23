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
using hymax.Services.Core;

namespace hymax.View
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        { 
            InitializeComponent();
            
            BindingContext = ViewModel;
        }
        static internal MainViewModel ViewModel { get; set; } = Locator.Current.GetService<MainViewModel>();
        private long lastPress = 0;
        protected override bool OnBackButtonPressed()
        {
            long currentTime = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;
            if (currentTime - lastPress > 5000)
            {
                Acr.UserDialogs.UserDialogs.Instance.Toast("Press again to exit", new TimeSpan(3));
                lastPress = currentTime;
            }
            else
            {
                if (Device.RuntimePlatform == Device.Android)
                    DependencyService.Get<IAndroidMethods>().CloseApp();
            }
            return base.OnBackButtonPressed();
        }
        public void carouselView_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            var item = e.CurrentItem as CarsModel; 
            ViewModel.UpdateCar(item.ID); 
        }
        void OnCarTapped(object sender, EventArgs args)
        {
            ViewModel.OnCarTapped(sender, args);
        }
        void OpenMapCommand(object sender, EventArgs args)
        {
            ViewModel.OpenMapCommand.Execute(sender);
        }

        protected async override void OnAppearing()
        { 
            base.OnAppearing();
            Services.Settings.LastPage = "Main";
        }
    }
}