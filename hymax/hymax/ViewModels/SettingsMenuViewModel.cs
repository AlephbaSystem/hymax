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

namespace hymax.ViewModels
{
    class SettingsMenuViewModel : BaseViewModel
    {
        private readonly IRoutingService routingService;
        public SettingsMenuViewModel(IRoutingService routingService = null)
        {
            //Xamarin.Forms.SetFlags("IndicatorView_Experimental");
            this.BackgroundColor = Services.ColorServer.GetResource("MainSecondaryColor");
            this.routingService = routingService ?? Locator.Current.GetService<IRoutingService>();
        }


        //public ICommand WindowCommand { get; }

        //private async void WindowCommandClick(object obj)
        //{
        //    this.IsBusy = true;
        //    string msg = rs.GetString("DisplayAlertWindow");
        //    string first = rs.GetString("DisplayAlertWindowFirst");
        //    string second = rs.GetString("DisplayAlertWindowSecond");
        //    string third = rs.GetString("DisplayAlertWindowThird");
        //    bool answer = await App.Current.MainPage.DisplayAlert(msg, third, first, second);

        //    if (answer)
        //    {
        //        await new Services.ISMSHandler().SendSms("شیشه", DeviceNumber);
        //        this.IsBusy = false;
        //    }
        //    else
        //    {
        //    }
        //}
    }
}
