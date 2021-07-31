using hymax.Services.Routing;
using hymax.Services.Cars;
using Splat;
using Xamarin.Forms;
using hymax.Models;
using System.Collections.ObjectModel;
using System;
using System.Windows.Input;

namespace hymax.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private readonly IRoutingService routingService;
        private readonly ICarsService carService;
        private ObservableCollection<CarsModel> _cars;
        public ObservableCollection<CarsModel> Cars
        {
            get
            {
                return _cars;
            }
            set
            {
                if (_cars != value)
                {
                    _cars = value;
                    this.OnPropertyChanged("Cars");
                }
            }
        }

        public ICommand OpenSettingsCommand { get; }

        public MainViewModel(IRoutingService routingService = null)
        {
            this.BackgroundColor = Services.ColorServer.GetResource("MainTernaryColor");
            this.routingService = routingService ?? Locator.Current.GetService<IRoutingService>();
            this.carService = carService ?? Locator.Current.GetService<ICarsService>();

            var rs = hymax.Localization.Localizations.GetResource();
            this.Cars = this.carService.CarLists();

            OpenSettingsCommand = new Command(executeSettings);
        }
        private async void executeSettings(object obj) 
        {
            try
            {
                await this.routingService.NavigateTo("main/settings");
            }
            catch (Exception ex)
            {
                _ = ex;
            }
        }

        public void OnSettingsTapped(object sender, EventArgs args)
        {
            executeSettings(sender);
        }
        public async void UpdateCar()
        {
            for (int i = 0; i < this.Cars.Count; i++)
            {
                CarsModel current =   await this.carService.Status(this.Cars[i]);
                //this.Cars.Remove(this._cars[i]);
                this.Cars.Add(current);
            }
        }
        public async void UpdateCar(string id)
        { 
            for (int i = 0; i < this.Cars.Count; i++)
            {
                CarsModel current = this.Cars[i];
                if (current.ID == id)
                {
                    current = await this.carService.Status(current);
                    //this.Cars.Remove(this.Cars[i]);
                    this.Cars.Add(current);
                    break;
                }
            }
        }
        public void OnCarTapped(object sender, EventArgs args)
        {
            Image img = (Image)sender;
            ImageSource s = img.Source;
            UpdateCar(s.ClassId);
        }
    }
}