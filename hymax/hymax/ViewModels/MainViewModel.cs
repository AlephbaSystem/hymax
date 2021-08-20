﻿using hymax.Services.Routing;
using hymax.Services.Cars;
using Splat;
using Xamarin.Forms;
using hymax.Models;
using System.Collections.ObjectModel;
using System;
using System.Windows.Input;
using hymax.Services;
using System.Threading.Tasks;
using hymax.View;
using System.Resources;

namespace hymax.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private readonly IRoutingService routingService;
        private readonly ICarsService carService;
        private ObservableCollection<CarsModel> _cars;
        private ResourceManager rs;

        public string _BatteryVultag;
        private string _GPSSignal;
        public string GPSSignal
        {
            get => _GPSSignal;
            set
            {
                if (_GPSSignal == value)
                    return;
                else
                {
                    _GPSSignal = value + " %";
                    OnPropertyChanged(nameof(GPSSignal));
                }
            }
        }
        public string BatteryVultag
        {
            get => _BatteryVultag;
            set
            {
                if (_BatteryVultag == value)
                    return;
                else
                {
                    _BatteryVultag = value + " V";
                    OnPropertyChanged(nameof(BatteryVultag));
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
        public ICommand WindowCommand { get; }

        private async void WindowCommandClick(object obj)
        {
            this.IsBusy = true;
            string msg = rs.GetString("DisplayAlertWindow");
            string first = rs.GetString("DisplayAlertWindowFirst");
            string second = rs.GetString("DisplayAlertWindowSecond");
            string third = rs.GetString("DisplayAlertWindowThird");
            bool answer = await App.Current.MainPage.DisplayAlert(msg, third, first, second);

            if (answer)
            {
                await new Services.ISMSHandler().SendSms("شیشه", DeviceNumber);
                this.IsBusy = false;
            }
            else
            {
            }
        }
        private async void StartCommandClick(object obj)
        {
            string msg = rs.GetString("DisplayAlertForceStop");
            string first = rs.GetString("DisplayAlertForceStopFirst");
            string second = rs.GetString("DisplayAlertForceStopSecond");
            string third = rs.GetString("DisplayAlertForceStopThird");
            string action = await App.Current.MainPage.DisplayActionSheet(msg,
                                                                          third,
                                                                          null,
                                                                          first,
                                                                          second);
            if (action == first)
            {
                await new Services.ISMSHandler().SendSms("خاموش", DeviceNumber);
            }
            else if (action == second)
            {
                await new Services.ISMSHandler().SendSms("روشن", DeviceNumber);
            }
            else if (action == third)
            {
            }
            else
            {
            }
        }
        private async void PanicCommandClick(object obj)
        {
            string msg = rs.GetString("DisplayAlertAlertCar");
            string first = rs.GetString("DisplayAlertAlertCarFirst");
            string second = rs.GetString("DisplayAlertAlertCarSecond");
            string third = rs.GetString("DisplayAlertAlertCarThird");
            bool answer = await App.Current.MainPage.DisplayAlert(msg, third, first, second);

            if (answer)
            {
                await new Services.ISMSHandler().SendSms("جستجو", DeviceNumber);
            }
            else
            {
            }
        }
        private async void LockCommandClick(object obj)
        {
            string msg = rs.GetString("DisplayAlertClose");
            string first = rs.GetString("DisplayAlertCloseFirst");
            string second = rs.GetString("DisplayAlertCloseSecond");
            string third = rs.GetString("DisplayAlertCloseThird");
            string action = await App.Current.MainPage.DisplayActionSheet(msg,
                                                                          third,
                                                                          null,
                                                                          first,
                                                                          second);
            if (action == first)
            {
                await new Services.ISMSHandler().SendSms("قفل", DeviceNumber);
            }
            else if (action == second)
            {
                await new Services.ISMSHandler().SendSms("0000F", DeviceNumber);
            }
            else if (action == third)
            {
            }
            else
            {
            }
        }
        private async void OpenCommandClick(object obj)
        {
            string msg = rs.GetString("DisplayAlertOpen");
            string first = rs.GetString("DisplayAlertOpenFirst");
            string second = rs.GetString("DisplayAlertOpenSecond");
            string third = rs.GetString("DisplayAlertOpenThird");
            string action = await App.Current.MainPage.DisplayActionSheet(msg,
                                                                          third,
                                                                          null,
                                                                          first,
                                                                          second);
            if (action == first)
            {
                await new Services.ISMSHandler().SendSms("باز", DeviceNumber);
            }
            else if (action == second)
            {
                await new Services.ISMSHandler().SendSms("0000O", DeviceNumber);
            }
            else if (action == third)
            {
            }
            else
            {
            }
        }
        private async void ForceStopCommandClick(object obj)
        {
            string msg = rs.GetString("DisplayAlertForceStop");
            string first = rs.GetString("DisplayAlertForceStopFirst");
            string second = rs.GetString("DisplayAlertForceStopSecond");
            string third = rs.GetString("DisplayAlertForceStopThird");
            string action = await App.Current.MainPage.DisplayActionSheet(msg,
                                                                          third,
                                                                          null,
                                                                          first,
                                                                          second);
            if (action == first)
            {
                await new Services.ISMSHandler().SendSms("خاموش", DeviceNumber);
            }
            else if (action == second)
            {
                await new Services.ISMSHandler().SendSms("روشن", DeviceNumber);
            }
            else if (action == third)
            {
            }
            else
            {
            }
        }
        private async void OpenTrunkCommandClick(object obj)
        {
            string msg = rs.GetString("DisplayAlertTrunk");
            string first = rs.GetString("DisplayAlertTrunkFirst");
            string second = rs.GetString("DisplayAlertTrunkSecond");
            string third = rs.GetString("DisplayAlertTrunkThird");
            string action = await App.Current.MainPage.DisplayActionSheet(msg,
                                                                          third,
                                                                          null,
                                                                          first,
                                                                          second);
            if (action == first)
            {
                await new Services.ISMSHandler().SendSms("صندوق", DeviceNumber);
            }
            else if (action == second)
            {
                await new Services.ISMSHandler().SendSms("0000H", DeviceNumber);
            }
            else if (action == third)
            {
            }
            else
            {
            }
        }
        private async void LocationCommandClick(object obj)
        {
            string msg = rs.GetString("DisplayAlertLocation");
            string first = rs.GetString("DisplayAlertLocationFirst");
            string second = rs.GetString("DisplayAlertLocationSecond");
            string third = rs.GetString("DisplayAlertLocationThird");
            string action = await App.Current.MainPage.DisplayActionSheet(msg,
                                                                          third,
                                                                          null,
                                                                          first,
                                                                          second);
            if (action == first)
            {
                await new Services.ISMSHandler().SendSms("موقعیت", DeviceNumber);
            }
            else if (action == second)
            {
                await new Services.ISMSHandler().SendSms("محدوده", DeviceNumber);
            }
            else if (action == third)
            {
            }
            else
            {
            }
        }
        private async void ChildLockCommandClick(object obj)
        {
            string msg = rs.GetString("DisplayAlertChildLock");
            string first = rs.GetString("DisplayAlertChildLockFirst");
            string second = rs.GetString("DisplayAlertChildLockSecond");
            string third = rs.GetString("DisplayAlertChildLockThird");
            string action = await App.Current.MainPage.DisplayActionSheet(msg,
                                                                          third,
                                                                          null,
                                                                          first,
                                                                          second);
            if (action == first)
            {
                await new Services.ISMSHandler().SendSms("25", DeviceNumber);
            }
            else if (action == second)
            {
                await new Services.ISMSHandler().SendSms("250", DeviceNumber);
            }
            else if (action == third)
            {
            }
            else
            {
            }
        }
        private Services.SMS.SMSReceiver iSMSReciver;
        private void SMSReciveHandler(string body, string number)
        {
            _ = body;
        }
        public MainViewModel(IRoutingService routingService = null)
        { 
            this.IsBusy = true;
            iSMSReciver = new Services.SMS.SMSReceiver();
            iSMSReciver.Recived += new Action<string, string>(SMSReciveHandler);
            this.BackgroundColor = Services.ColorServer.GetResource("MainSecondaryColor");
            this.routingService = routingService ?? Locator.Current.GetService<IRoutingService>();
            this.carService = carService ?? Locator.Current.GetService<ICarsService>();

            this.GPSSignal = new Random(222).Next(70, 95).ToString();
            this.BatteryVultag = new Random(342).Next(10, 20).ToString();
            if (Settings.AccessToken == "")
            {
                SetSecurePage.ViewModel.Reset();
                this.routingService.NavigateTo("main/setsecure");
            }

            rs = hymax.Localization.Localizations.GetResource();
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
            this.WindowCommand = new Command(WindowCommandClick);
            this.IsBusy = false;
        }
        private async void executeMap(object obj)
        {
            this.IsBusy = true;
            await this.routingService.NavigateTo("main/map");
        }
        private async void executeSettings(object obj)
        {
            this.IsBusy = true;
            await this.routingService.NavigateTo("main/settings");
        }
        private async void executeAdvance(object obj)
        {
            this.IsBusy = true;
            await this.routingService.NavigateTo("main/advance");
        }

        public void OnSettingsTapped(object sender, EventArgs args)
        {
            this.IsBusy = true;
            executeSettings(sender);
        }
        public async void UpdateCar()
        {
            this.IsBusy = true;
            for (int i = 0; i < this.Cars.Count; i++)
            {
                CarsModel current = await this.carService.Status(this._cars[i]);
                //this._cars.Remove(this._cars[i]);
                this._cars.Add(current);
            }
            this.IsBusy = false;
        }
        public async void UpdateCar(string id)
        {
            this.IsBusy = true;
            this.GPSSignal = new Random(222).Next(70, 95).ToString();
            this.BatteryVultag = new Random(342).Next(10, 20).ToString();
            for (int i = 0; i < this.Cars.Count; i++)
            {
                CarsModel current = this._cars[i];
                await Task.Run(() =>
                {
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
            this.IsBusy = false;
        }
        public void OnCarTapped(object sender, EventArgs args)
        {
            Image img = (Image)sender;
            ImageSource s = img.Source;
            UpdateCar(s.ClassId);
        }
    }
}