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
    class LoginViewModel : BaseViewModel
    {
        private IRoutingService routingService;

        public LoginViewModel(IRoutingService navigationService = null)
        {
            this.routingService = navigationService ?? Locator.Current.GetService<IRoutingService>();
            this.ExecuteLogin = new Command(() => Login()); 
        }

        public string PhoneNumber { get; set; } 
        public ICommand ExecuteLogin { get; set; }

        private async void Login()
        {
            LoginVerifyPage.InitPage(PhoneNumber);
            await this.routingService.NavigateTo("login/loginverify");
        }
    }
}
