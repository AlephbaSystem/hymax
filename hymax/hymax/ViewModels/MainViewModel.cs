using hymax.Services.Routing;
using hymax.Services.Cars;
using Splat;
using Xamarin.Forms;
using hymax.Models;
using System.Collections.ObjectModel;
using System;
using System.Windows.Input;
using hymax.Services;
using System.Threading.Tasks;

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
        public ICommand OpenAdvanceCommand { get; }
        public ICommand OpenMapCommand { get; }
        public string DeviceNumber { get; set; }
        public ICommand LockCommand { get; }
        public ICommand OpenCommand { get; }
        public ICommand ForceStopCommand { get; }
        public ICommand OpenTrunkCommand { get; }
        public ICommand LocationCommand { get; }
        public ICommand ChildLockCommand { get; }
        public ICommand PanicCommand { get; }
        public ICommand StartCommand { get; }
        private async void StartCommandClick(object obj)
        {
            await new Services.ISMSHandler().SendSms("روشن", DeviceNumber);
        }
        private async void PanicCommandClick(object obj)
        {
            await new Services.ISMSHandler().SendSms("جستجو", DeviceNumber);
        }
        private async void LockCommandClick(object obj)
        {
            await new Services.ISMSHandler().SendSms("قفل", DeviceNumber);
        }
        private async void OpenCommandClick(object obj)
        {
            await new Services.ISMSHandler().SendSms("باز", DeviceNumber);
        }
        private async void ForceStopCommandClick(object obj)
        {
            await new Services.ISMSHandler().SendSms("خاموش", DeviceNumber);
        }
        private async void OpenTrunkCommandClick(object obj)
        {
            await new Services.ISMSHandler().SendSms("صندوق", DeviceNumber);
        }
        private async void LocationCommandClick(object obj)
        {
            await new Services.ISMSHandler().SendSms("محدوده", DeviceNumber);
        }
        private async void ChildLockCommandClick(object obj)
        {
            await new Services.ISMSHandler().SendSms("محدوده", DeviceNumber);
        }
        public MainViewModel(IRoutingService routingService = null)
        {
            this.BackgroundColor = Services.ColorServer.GetResource("MainTernaryColor");
            this.routingService = routingService ?? Locator.Current.GetService<IRoutingService>();
            this.carService = carService ?? Locator.Current.GetService<ICarsService>();

            var rs = hymax.Localization.Localizations.GetResource();
            this._cars = this.carService.CarLists();

            this.OpenSettingsCommand = new Command(executeSettings);
            this.OpenAdvanceCommand = new Command(executeAdvance);
            this.OpenMapCommand = new Command(executeMap);
            this.DeviceNumber = Settings.UserSetting[0].Phone;
            this.LockCommand = new Command(LockCommandClick);
            this.OpenCommand = new Command(OpenCommandClick);
            this.ForceStopCommand = new Command(ForceStopCommandClick);
            this.OpenTrunkCommand = new Command(OpenTrunkCommandClick);
            this.LocationCommand = new Command(LocationCommandClick);
            this.ChildLockCommand = new Command(ChildLockCommandClick);
            this.PanicCommand = new Command(PanicCommandClick);
            this.StartCommand = new Command(StartCommandClick);
        }
        private async void executeMap(object obj)
        {
            try
            {
                await this.routingService.NavigateTo("///map");
            }
            catch (Exception ex)
            {
                _ = ex;
            }
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
        private async void executeAdvance(object obj)
        {
            try
            {
                await this.routingService.NavigateTo("main/advance");
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
                CarsModel current = await this.carService.Status(this._cars[i]);
                //this._cars.Remove(this._cars[i]);
                this._cars.Add(current);
            }
        }
        public async void UpdateCar(string id)
        {
            for (int i = 0; i < this.Cars.Count; i++)
            {
                CarsModel current = this._cars[i];
                await Task.Run(() => {
                    current.ImagePath = "caron.png";
                    Task.Delay(3000);
                    current.ImagePath = "caroff.png";
                });
                if (current.ID == id)
                {
                    current = await this.carService.Status(current);
                    //this._cars.Remove(this._cars[i]);
                    this._cars.Add(current);


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