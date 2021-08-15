using hymax.Services;
using hymax.Services.Identity;
using hymax.Services.Routing;
using hymax.View;
using Splat;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using hymax.Localization;
using Plugin.Fingerprint.Abstractions;

namespace hymax.ViewModels
{
    class SetSecureViewModel : BaseViewModel
    {
        private readonly IRoutingService routingService;
        public string Header { get; set; }
        public string Details { get; set; }
        public FontImageSource Icon { get; set; }
        public SetSecureViewModel(IRoutingService routingService = null)
        {
            this.routingService = routingService ?? Locator.Current.GetService<IRoutingService>();
            Reset();
        }
        public async void Reset()
        {
            var currentResource = Localization.Localizations.GetResource();
            switch (Settings.Security)
            {
                case Models.SecurityTypes.FingerPrint:
                    bool at = false;
                    FingerPrintHandler fp = new FingerPrintHandler();
                    var authType = await Plugin.Fingerprint.CrossFingerprint.Current.GetAuthenticationTypeAsync();
                    if (authType == AuthenticationType.Fingerprint)
                    {
                        at = await fp.CheckFingers("ورود با اثر انگشت فعال است. برای ورود به برنامه می بایست احراز هویت اثر انگشت انجام شود");
                    }
                    if (at)
                    {
                        this.Details = currentResource.GetString("SetSecureDetailsFingerPrint");
                        this.Header = currentResource.GetString("SecureFinger");
                        this.Icon = (FontImageSource)IconServer.GetResource("FingerPrint");
                    }
                    else
                    {
                        await this.routingService.GoBack();
                    }

                    break;
                case Models.SecurityTypes.Password:
                    this.Details = currentResource.GetString("SetSecureDetailsPassword");
                    this.Header = currentResource.GetString("SecurePassword");
                    this.Icon = (FontImageSource)IconServer.GetResource("Password");
                    break;
                case Models.SecurityTypes.Pattern:
                    this.Details = currentResource.GetString("SetSecureDetailsPattern");
                    this.Header = currentResource.GetString("SecurePattern");
                    this.Icon = (FontImageSource)IconServer.GetResource("Pattern");
                    break;
                case Models.SecurityTypes.Pin:
                    this.Details = currentResource.GetString("SetSecureDetailsPin");
                    this.Header = currentResource.GetString("SecurePin");
                    this.Icon = (FontImageSource)IconServer.GetResource("Pin");
                    break;
                default:
                    break;
            }
            this.Icon.Size = 100;
        }


        public async Task waitandgo()
        {
            await Task.Delay(100);
            try
            {
                await this.routingService.NavigateTo("login/welcome");
            }
            catch (Exception ex)
            {
                _ = ex;
                throw;
            }
        }
    }
}
