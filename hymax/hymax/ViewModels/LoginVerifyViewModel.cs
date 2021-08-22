using hymax.Models;
using hymax.Services;
using hymax.Services.Database;
using hymax.Services.Identity;
using hymax.Services.Routing;
using hymax.Services.SMS;
using hymax.View;
using Splat;
using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace hymax.ViewModels
{
    class LoginVerifyViewModel : BaseViewModel
    {
        private IRoutingService routingService;
        private readonly ISMSService smsService;
        private readonly IDatabaseService db;
        private bool Verified = false;
        private ResourceManager rs;
        public LoginVerifyViewModel(IRoutingService navigationService = null)
        {
            this.IsBusy = true;
            this.routingService = navigationService ?? Locator.Current.GetService<IRoutingService>();
            this.smsService = smsService ?? Locator.Current.GetService<ISMSService>();
            this.smsService.Setrecipient(this.PhoneNumber);
            this.db = this.db ?? Locator.Current.GetService<IDatabaseService>();

            this.ExecuteVerfiy = new Command(() => Verfiy());
            this.ExecuteBack = new Command(() => Back());


            rs = hymax.Localization.Localizations.GetResource();
            this.smsService.Recived += new Action<string, string>(SMSReciveHandler);

            this.IsBusy = false;
        }
        public async Task CodeSend()
        {
            await Task.Delay(100);
            await this.smsService.SendSms("حافظه", this.PhoneNumber);
        }
        public string VerifyCode { get; set; }
        public string PhoneNumber { get; set; }
        public ICommand ExecuteVerfiy { get; set; }
        public ICommand ExecuteBack { get; set; }

        public async void Back()
        {
            this.IsBusy = true;
            await this.routingService.GoBack();
            this.IsBusy = false;
        }
        private void SMSReciveHandler(string body, string number)
        {
            this.IsBusy = true;
            if (number == this.PhoneNumber)
            {
                if (body.Contains("مالک اصلی"))
                {
                    Verified = true;
                    ExecuteVerfiy.Execute(this);
                    this.IsBusy = false;
                }
                else
                {
                    Acr.UserDialogs.UserDialogs.Instance.Toast(rs.GetString("VerifyLoginFailedMessage"), new TimeSpan(3));
                }
            }
        }

        private async void Verfiy()
        {
            this.IsBusy = true;
            await Task.Delay(100);
            if (!Verified) return;
            //await this.db.Reset();
            Settings.UserSetting = this.db.GetSettingsAsync().Result;
            await Task.Delay(100);
            SettingsModel sm = Settings.UserSetting[0];
            sm.Phone = this.PhoneNumber;
            sm.Verified = true;
            await this.db.UpdateSettingsAsync(sm);
            Settings.UserSetting = await this.db.GetSettingsAsync();
            await this.routingService.NavigateTo("login/securelogin");
        }
    }
}