using hymax.Models;
using hymax.Services;
using hymax.Services.Identity;
using hymax.Services.Routing;
using hymax.View;
using hymax.ViewModels;
using Splat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace hymax.ViewModels
{
    class MapViewModel : BaseViewModel
    {
        private Services.SMS.SMSReceiver iSMSReciver;
        private ResourceManager rs;
        private readonly IRoutingService routingService;

        public MapViewModel(IRoutingService routingService = null, IIdentityService identityService = null)
        {
            Title = "Map";
            this.routingService = routingService ?? Locator.Current.GetService<IRoutingService>();

            rs = hymax.Localization.Localizations.GetResource();
            iSMSReciver = new Services.SMS.SMSReceiver();
            iSMSReciver.Recived += new Action<string, string>(SMSReciveHandler);

            _ = this.CodeSend();
        }

        private async Task CodeSend()
        {
            await Task.Delay(100);
            ISMSHandler ismsh = new ISMSHandler();
            //await ismsh.SendSms("حافظه", this.PhoneNumber);
        }
        private void SMSReciveHandler(string body, string number)
        {
            Settings.UserSetting = Settings.Database.GetSettings();
            if (number == Settings.UserSetting[0].Phone)
            {
                if (body.Contains("مالک اصلی"))
                {
                    var geocoder = new Xamarin.Forms.GoogleMaps.Geocoder();

                    Position startPos = new Position(41.9027835, 12.4963655);
                    var addresss = geocoder.GetAddressesForPositionAsync(startPos).Result;
                    if (addresss.Count() > 0)
                    {
                        // With EVENT IN MAIN PAGE I SHOULD CREATE NAVIGATION
                        //var pos = addresss.First();
                        //MapPage.map.MoveToRegion(MapSpan.FromCenterAndRadius(startPos, Distance.FromMeters(5000)));
                        //var reg = MapPage.map.Region;
                        //MapPage.loc.Text = pos;
                    }
                }
                else
                {
                    Acr.UserDialogs.UserDialogs.Instance.Toast(rs.GetString("VerifyLoginFailedMessage"), new TimeSpan(3));
                }
            }
        }
    }
}