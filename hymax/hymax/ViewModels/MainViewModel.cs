using hymax.Services.Identity;
using hymax.Services.Routing;
using hymax.Services.Cars;
using hymax.View;
using Splat;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using hymax.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using System.Reflection;

namespace hymax.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private readonly IRoutingService routingService;
        private readonly ICarsService carService;
        private ObservableCollection<CarsModel> _cars;
        public MainViewModel(IRoutingService routingService = null)
        {
            this.BackgroundColor = Services.ColorServer.GetResource("MainTernaryColor");
            this.routingService = routingService ?? Locator.Current.GetService<IRoutingService>();
            this.carService = carService ?? Locator.Current.GetService<ICarsService>();

            var rs = hymax.Localization.Localizations.GetResource();
            this._cars = this.carService.CarLists(); 
            this._cars = this.carService.CarLists(); 
        }
     public void ExecuteSettings()
        {
            try
            {
                this.routingService.MasterShell();
                  this.routingService.NavigateTo("main/settings");
            }
            catch (Exception ex)
            {
                _ = ex;
            }
        }
        public async void UpdateCar()
        {
            for (int i = 0; i < this._cars.Count; i++)
            {
                this._cars[i] = await this.carService.Status(this._cars[i]);
            }
        }
        public async void UpdateCar(string id)
        {
            for (int i = 0; i < this._cars.Count; i++)
            {
                CarsModel current = this._cars[i];
                if (current.ID == id)
                {
                    this._cars[i] = await this.carService.Status(current);
                    break;
                }
            }
        }
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
        public void OnCarTapped(object sender, EventArgs args)
        {
            Image img = (Image)sender;
            ImageSource s = img.Source;
            UpdateCar(s.ClassId);
        } 
    }
}