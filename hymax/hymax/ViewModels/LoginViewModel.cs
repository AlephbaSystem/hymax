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
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace hymax.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private IRoutingService routingService;
        private ResourceManager rs;

        public LoginViewModel(IRoutingService navigationService = null)
        {
            this.routingService = navigationService ?? Locator.Current.GetService<IRoutingService>();
            this.ExecuteLogin = new Command(() => Login());
            rs = hymax.Localization.Localizations.GetResource();
        }

        public string PhoneNumber { get; set; }
        public ICommand ExecuteLogin { get; set; }
        public bool IsValidPhone(string Phone)
        {
            try
            {
                if (string.IsNullOrEmpty(Phone))
                    return false;
                var r = new Regex(@"^(?:0|98|\+98|\+980|0098|098|00980)?(9\d{9})$");
                return r.IsMatch(Phone);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void Login()
        {
            if (IsValidPhone(PhoneNumber))
            {
                if (this.PhoneNumber.StartsWith("0"))
                {
                    this.PhoneNumber = "+98" + this.PhoneNumber.Substring(1);
                }
                LoginVerifyPage.InitPage(PhoneNumber);
                await this.routingService.NavigateTo("login/loginverify");
            }
            else
            {
                Acr.UserDialogs.UserDialogs.Instance.Toast(rs.GetString("VerifyLoginFailedMessage"), new TimeSpan(3));
            }
        }
    }
}
