using hymax.Services.Identity;
using hymax.Services.Routing;
using hymax.View;
using Splat;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using hymax.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using hymax.Services;
using hymax.Services.SMS;
using System.Resources;
using System.Linq;

namespace hymax.ViewModels
{
    class AdvanceViewModel : BaseViewModel
    {
        private readonly IRoutingService routingService;
        private readonly ISMSService smsService;
        private ResourceManager rs;
        public string DeviceNumber { get; set; }
        public ICommand OpenCommand { get; }
        public ICommand LockCommand { get; }
        public ICommand OpenTrunkCommand { get; }
        public ICommand PanicCommand { get; }
        public ICommand ChildLockCommand { get; }
        public ICommand StartCommand { get; }
        public ICommand WindowCommand { get; }
        public ICommand VoiceRequestCommand { get; }
        public ICommand SpeedMetterCommand { get; }
        public ICommand ForceStopCommand { get; }
        private async void WindowCommandClick(object obj)
        {
            this.IsBusy = true;
            string msg = rs.GetString("DisplayAlertWindows");
            string first = rs.GetString("DisplayAlertWindowsFirst");
            string second = rs.GetString("DisplayAlertWindowsSecond");
            string third = rs.GetString("DisplayAlertWindowsThird");
            bool answer = await App.Current.MainPage.DisplayAlert(msg, third, first, second);

            if (answer)
            {
                await this.smsService.SendSms("شیشه", DeviceNumber);
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
                await this.smsService.SendSms("خاموش", DeviceNumber);
            }
            else if (action == second)
            {
                await this.smsService.SendSms("روشن", DeviceNumber);
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
                await this.smsService.SendSms("جستجو", DeviceNumber);
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
                await this.smsService.SendSms("قفل", DeviceNumber);
            }
            else if (action == second)
            {
                await this.smsService.SendSms("0000F", DeviceNumber);
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
                await this.smsService.SendSms("باز", DeviceNumber);
            }
            else if (action == second)
            {
                await this.smsService.SendSms("0000O", DeviceNumber);
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
                await this.smsService.SendSms("خاموش", DeviceNumber);
            }
            else if (action == second)
            {
                await this.smsService.SendSms("روشن", DeviceNumber);
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
                await this.smsService.SendSms("صندوق", DeviceNumber);
            }
            else if (action == second)
            {
                await this.smsService.SendSms("0000H", DeviceNumber);
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
                await this.smsService.SendSms("25", DeviceNumber);
            }
            else if (action == second)
            {
                await this.smsService.SendSms("250", DeviceNumber);
            }
            else if (action == third)
            {
            }
            else
            {
            }
        }
        private async void SpeedMetterCommandClick(object obj)
        {
            this.IsBusy = true;
            string msg = rs.GetString("PopupHeader");
            string first = rs.GetString("DisplayAlertWindowsFirst");
            string second = rs.GetString("DisplayAlertWindowsSecond");
            string third = rs.GetString("PopupAction");
            bool answer = await App.Current.MainPage.DisplayAlert(msg, third, first, second);

            if (answer)
            {
                await this.smsService.SendSms("سرعت", DeviceNumber);
                this.IsBusy = false;
            }
            else
            {
            }
        }
        private async void VoiceRequestCommandClick(object obj)
        {
            this.IsBusy = true;
            string msg = rs.GetString("PopupHeader");
            string first = rs.GetString("DisplayAlertWindowsFirst");
            string second = rs.GetString("DisplayAlertWindowsSecond");
            string third = rs.GetString("PopupAction");
            bool answer = await App.Current.MainPage.DisplayAlert(msg, third, first, second);

            if (answer)
            {
                await this.smsService.SendSms("شنود", DeviceNumber);
                this.IsBusy = false;
            }
            else
            {
            }
        }
        private async void SMSReciveHandler(string body, string number)
        {
            if (number == this.DeviceNumber && Settings.UserSetting[0].Verified)
            {
                string[] msgs = body.Split('\n');
                string msg = rs.GetString("PopupClose");
                await App.Current.MainPage.DisplayAlert(msgs[0], string.Join("\n", msgs.Skip(1).ToArray()), msg);
            }
        }
        public AdvanceViewModel(IRoutingService routingService = null)
        {
            this.IsBusy = true;
            this.BackgroundColor = Services.ColorServer.GetResource("MainSecondaryColor");
            this.routingService = routingService ?? Locator.Current.GetService<IRoutingService>();
            this.smsService = smsService ?? Locator.Current.GetService<ISMSService>();

            this.smsService.Recived += new Action<string, string>(SMSReciveHandler);

            rs = hymax.Localization.Localizations.GetResource();

            this.DeviceNumber = Settings.UserSetting[0].Phone;
            this.LockCommand = new Command(LockCommandClick);
            this.OpenCommand = new Command(OpenCommandClick);
            this.ForceStopCommand = new Command(ForceStopCommandClick);
            this.OpenTrunkCommand = new Command(OpenTrunkCommandClick);
            this.ChildLockCommand = new Command(ChildLockCommandClick);
            this.PanicCommand = new Command(PanicCommandClick);
            this.StartCommand = new Command(StartCommandClick);
            this.WindowCommand = new Command(WindowCommandClick);
            this.SpeedMetterCommand = new Command(SpeedMetterCommandClick);
            this.VoiceRequestCommand = new Command(VoiceRequestCommandClick);
            this.IsBusy = false;
        }
    }
}
