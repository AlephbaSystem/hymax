using hymax.Models;
using hymax.Services;
using hymax.Services.Identity;
using hymax.Services.Routing;
using hymax.View;
using Splat;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace hymax.ViewModels
{
    class SecureLoginViewModel : BaseViewModel
    {
        private readonly IRoutingService routingService;

        public SecureLoginViewModel(IRoutingService routingService = null)
        {
            this.IsBusy = true;
            this.routingService = routingService ?? Locator.Current.GetService<IRoutingService>();
            this.IsBusy = false;
        }

        private async void setDB()
        {
            this.IsBusy = true;
            SettingsModel sm = Settings.UserSetting[0];
            sm.SecurityType = ((int)Settings.Security);
            await Settings.Database.UpdateSettingsAsync(sm);
            Settings.UserSetting = Settings.Database.GetSettings();
        }
        public async void OnPinTapped(object sender, EventArgs args)
        {
            try
            {
                this.IsBusy = true;
                Settings.Security = Models.SecurityTypes.Pin;
                SetSecurePage.ViewModel.Reset();
                setDB();
                await this.routingService.NavigateTo("login/setsecure");
            }
            catch (Exception ex)
            {
                this.IsBusy = false;
                throw ex;
            }
        }
        public async void OnFingerPrintTapped(object sender, EventArgs args)
        {
            Plugin.Fingerprint.CrossFingerprint fph = new Plugin.Fingerprint.CrossFingerprint();
            

            try
            {
                this.IsBusy = true;
                Settings.Security = Models.SecurityTypes.FingerPrint;
                SetSecurePage.ViewModel.Reset();
                setDB();
                await this.routingService.NavigateTo("login/setsecure");
            }
            catch (Exception ex)
            {
                this.IsBusy = false;
                throw ex;
            }
        }
        public async void OnPasswordTapped(object sender, EventArgs args)
        {
            try
            {
                this.IsBusy = true;
                Settings.Security = Models.SecurityTypes.Password;
                SetSecurePage.ViewModel.Reset();
                setDB();
                await this.routingService.NavigateTo("login/setsecure");
            }
            catch (Exception ex)
            {
                this.IsBusy = false;
                throw ex;
            }
        }
        public async void OnPatternTapped(object sender, EventArgs args)
        {
            try
            {
                this.IsBusy = true;
                Settings.Security = Models.SecurityTypes.Pattern;
                SetSecurePage.ViewModel.Reset();
                setDB();
                await this.routingService.NavigateTo("login/setsecure");
            }
            catch (Exception ex)
            {
                this.IsBusy = false;
                throw ex;
            }
        }
    }
}
