using hymax.Models;
using hymax.Services;
using hymax.Services.Identity;
using hymax.Services.Routing;
using hymax.View;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace hymax.ViewModels
{
    class LoginVerifyViewModel : BaseViewModel
    {
        private IRoutingService routingService;

        public LoginVerifyViewModel(IRoutingService navigationService = null)
        {
            this.routingService = navigationService ?? Locator.Current.GetService<IRoutingService>();
            this.ExecuteVerfiy = new Command(() => Verfiy());
            this.ExecuteBack = new Command(() => Back()); 
        }
        public string VerifyCode { get; set; }
        public string PhoneNumber { get; set; }
        public ICommand ExecuteVerfiy { get; set; }
        public ICommand ExecuteBack { get; set; }

        private async void Back()
        {
            await this.routingService.GoBack();
        }
        private async void Verfiy()
        {
            SettingsModel sm = Settings.UserSetting[0];
            sm.Phone = this.PhoneNumber;
            sm.Verified = true;
            await Settings.Database.UpdateSettingsAsync(sm);
            Settings.UserSetting = Settings.Database.GetSettings();
            await this.routingService.NavigateTo("login/securelogin");
        }
    }
}