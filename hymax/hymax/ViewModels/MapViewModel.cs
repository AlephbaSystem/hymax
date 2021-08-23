using hymax.Models;
using hymax.Services;
using hymax.Services.Database;
using hymax.Services.Identity;
using hymax.Services.Routing;
using hymax.Services.SMS;
using hymax.View;
using hymax.ViewModels;
using Splat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace hymax.ViewModels
{
    class MapViewModel : BaseViewModel
    {
        public ResourceManager rs;
        private readonly IRoutingService routingService;
        private readonly ISMSService smsService;
        private readonly IDatabaseService db;
        private string PhoneNumber = string.Empty;
        public MapViewModel(IRoutingService routingService = null, IIdentityService identityService = null)
        {
            this.IsBusy = true;
            Title = "Map";
            this.routingService = routingService ?? Locator.Current.GetService<IRoutingService>();
            this.smsService = smsService ?? Locator.Current.GetService<ISMSService>();
            this.db = this.db ?? Locator.Current.GetService<IDatabaseService>();

            rs = hymax.Localization.Localizations.GetResource();
            Settings.UserSetting = this.db.GetSettingsAsync().Result;
            if (Settings.UserSetting.Count <= 0)
            {
                Acr.UserDialogs.UserDialogs.Instance.Toast(rs.GetString("PanicError"), new TimeSpan(3));
                this.routingService.GoBack().Wait();
                return;
            }
            PhoneNumber = Settings.UserSetting[0].Phone;
            this.smsService.Recived += new Action<string, string>(iReciver);
            //this.CodeSend();
        }

        public event Action<Position, string> RecivedPosition;
        public async void CodeSend()
        {
            await Task.Delay(500);
            await this.smsService.SendSms("موقعیت", this.PhoneNumber);
        }
        private bool isrunning;
        private async void iReciver(string body, string number)
        {
            await SMSReciveHandler(body, number);
        }
        private async Task SMSReciveHandler(string body, string number)
        {
            if (isrunning) return;
            if (number == PhoneNumber && Settings.UserSetting[0].Verified)
            {
                if (body.Contains("maps.google.com"))
                {
                    isrunning = true;
                    string[] msg = body.Split('\n');
                    string DoorStatus = msg[0];
                    string CarStatus = msg[1];
                    string MapStatus = msg[2];
                    string[] loc = MapStatus.Replace("maps.google.com/?q=", string.Empty).Split(',');
                    double lat = Math.Round(double.Parse(loc[0]), 3);
                    double lon = Math.Round(double.Parse(loc[1]), 3);
                    Position startPos = new Position(lat, lon);
                    var addresss = string.Empty;

                    try
                    {
                        string iURL = $"https://nominatim.openstreetmap.org/reverse?lat={startPos.Latitude}&lon={startPos.Longitude}";
                        var client = new HttpClient();
                        var response = await client.GetAsync(iURL);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            XDocument xd = XDocument.Parse(responseContent);
                            addresss = xd.Root.Element("result").Value;
                        }
                        else
                        {
                            addresss = string.Empty;
                        }
                    }
                    catch
                    {
                        addresss = string.Empty;
                    }


                    RecivedPosition(startPos, addresss);
                    isrunning = false;
                    this.IsBusy = false;
                }
                else
                {
                    this.IsBusy = true;
                    Acr.UserDialogs.UserDialogs.Instance.Toast(rs.GetString("VerifyLoginFailedMessage"), new TimeSpan(3));
                }
            }

        }
    }
}