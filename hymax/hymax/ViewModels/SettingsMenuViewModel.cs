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
using System.Resources;
using hymax.Services;
using System.Linq;
using Xamarin.Essentials;
using hymax.Services.SMS;

namespace hymax.ViewModels
{
    class SettingsMenuViewModel : BaseViewModel
    {
        private readonly IRoutingService routingService;
        private readonly ISMSService smsService;
        private ResourceManager rs;
        private Services.SMS.SMSHandler iSMSReciver;
        public string DeviceNumber { get; set; }

        public ICommand OpenInfoCommand { get; }
        public ICommand OpenVersionCommand { get; }
        public ICommand OpenCatalogCommand { get; }
        public ICommand OpenWWWCommand { get; }
        public ICommand OpenSupportCommand { get; }
        public ICommand OpenUsersSettingsCommand { get; }
        public SettingsMenuViewModel(IRoutingService routingService = null)
        {
            //Xamarin.Forms.SetFlags("IndicatorView_Experimental");
            this.BackgroundColor = Services.ColorServer.GetResource("MainSecondaryColor");
            this.routingService = routingService ?? Locator.Current.GetService<IRoutingService>();
            this.smsService = smsService ?? Locator.Current.GetService<ISMSService>();
            iSMSReciver = new Services.SMS.SMSHandler();
            iSMSReciver.Recived += new Action<string, string>(SMSReciveHandler);
            rs = hymax.Localization.Localizations.GetResource();

            this.DeviceNumber = Settings.UserSetting[0].Phone;
            OpenInfoCommand = new Command(OpenInfoCommandClick);
            OpenVersionCommand = new Command(OpenVersionCommandClick);
            OpenCatalogCommand = new Command(OpenCatalogCommandClick);
            OpenWWWCommand = new Command(OpenWWWCommandClick);
            OpenSupportCommand = new Command(OpenSupportCommandClick);
            OpenUsersSettingsCommand = new Command(OpenUsersSettingsCommandClick);
        }
        private async void SMSReciveHandler(string body, string number)
        {
            if (number == DeviceNumber && Settings.UserSetting[0].Verified)
            {
                string[] msgs = body.Split('\n');
                if (msgs[0] == "درباره")
                {
                    string msg = rs.GetString("PopupClose"); 
                    await App.Current.MainPage.DisplayAlert(msgs[0], string.Join("\n", msgs.Skip(1).ToArray()), msg);
                }
            }
        }
        private async void OpenInfoCommandClick()
        {
            string msgC = rs.GetString("PopupClose");
            string msgH = rs.GetString("AppVersionHeader");
            string msg = rs.GetString("AppVersion");
            await App.Current.MainPage.DisplayAlert(msgH, msg, msgC);
        }
        private async void OpenVersionCommandClick()
        {
            await this.smsService.SendSms("نسخه", DeviceNumber);
        }
        private async void OpenCatalogCommandClick()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new PDFViewer());
        }
        private async void OpenWWWCommandClick()
        {
            try
            {
                await Browser.OpenAsync("http://radyabe.ir/#!/", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }
        private async void OpenSupportCommandClick()
        {
            try
            {
                await Browser.OpenAsync("http://radyabe.ir/#!/", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }
        private async void OpenUsersSettingsCommandClick()
        {
            try
            {
                await Browser.OpenAsync("http://radyabe.ir/#!/", BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        } 
    }
}
