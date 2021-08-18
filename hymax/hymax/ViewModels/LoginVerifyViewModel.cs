using hymax.Models;
using hymax.Services;
using hymax.Services.Identity;
using hymax.Services.Routing;
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
        private Services.SMS.SMSReceiver iSMSReciver;
        private bool Verified = false;
        private ResourceManager rs;
        public LoginVerifyViewModel(IRoutingService navigationService = null)
        {
            this.routingService = navigationService ?? Locator.Current.GetService<IRoutingService>();
            this.ExecuteVerfiy = new Command(() => Verfiy());
            this.ExecuteBack = new Command(() => Back());


            rs = hymax.Localization.Localizations.GetResource();
            iSMSReciver = new Services.SMS.SMSReceiver();
            iSMSReciver.Recived += new Action<string, string>(SMSReciveHandler);

            _ = this.CodeSend();
        }
        private async Task CodeSend()
        {
            await Task.Delay(100);
            ISMSHandler ismsh = new Services.ISMSHandler();
            await ismsh.SendSms("حافظه", this.PhoneNumber);
        }
        public string VerifyCode { get; set; }
        public string PhoneNumber { get; set; }
        public ICommand ExecuteVerfiy { get; set; }
        public ICommand ExecuteBack { get; set; }

        private async void Back()
        {
            await this.routingService.GoBack();
        }
        private void SMSReciveHandler(string body, string number)
        {
            if (number == this.PhoneNumber)
            {
                if (body.Contains("مالک اصلی"))
                {
                    Verified = true;
                    ExecuteVerfiy.Execute(this);
                }
                else
                {
                    Acr.UserDialogs.UserDialogs.Instance.Toast(rs.GetString("VerifyLoginFailedMessage"), new TimeSpan(3));
                }
            }
        }

        private async void Verfiy()
        {
            await Task.Delay(100);
            if (!Verified) return;
            SettingsModel sm = Settings.UserSetting[0];
            sm.Phone = this.PhoneNumber;
            sm.Verified = true;
            await Settings.Database.UpdateSettingsAsync(sm);
            Settings.UserSetting = Settings.Database.GetSettings();
            await this.routingService.NavigateTo("login/securelogin");
        }
    }
}