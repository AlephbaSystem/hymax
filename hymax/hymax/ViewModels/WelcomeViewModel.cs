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
    class WelcomeViewModel : BaseViewModel
    {
        private readonly IRoutingService routingService;
        private ObservableCollection<WelcomeModel> _welcomes;
        public WelcomeViewModel(IRoutingService routingService = null)
        {
            //Xamarin.Forms.SetFlags("IndicatorView_Experimental");
            this.BackgroundColor = Services.ColorServer.GetResource("MainSecondaryColor");
            this.routingService = routingService ?? Locator.Current.GetService<IRoutingService>();
            var rs = hymax.Localization.Localizations.GetResource();
            this._welcomes = new ObservableCollection<WelcomeModel>();
            this._welcomes.Add(new WelcomeModel { Description = rs.GetString("Welcome1Description"), Title = rs.GetString("Welcome1Header"), ImagePath = "welcome1.png" });
            this._welcomes.Add(new WelcomeModel { Description = rs.GetString("Welcome2Description"), Title = rs.GetString("Welcome2Header"), ImagePath = "welcome2.png" });
            this._welcomes.Add(new WelcomeModel { Description = rs.GetString("Welcome3Description"), Title = rs.GetString("Welcome3Header"), ImagePath = "welcome3.png" });

            this.ExecuteSkip = new Command(() => Skip());
        }
        public ObservableCollection<WelcomeModel> Welcomes
        {
            get
            {
                return _welcomes;
            }
            set
            {
                if (_welcomes != value)
                {
                    _welcomes = value;
                    this.OnPropertyChanged("Welcomes");
                }
            }
        }
        public ICommand ExecuteSkip { get; set; }
        private async void Skip()
        {
            try
            {
                this.routingService.MasterShell();
                await this.routingService.NavigateTo("main/home");
            }
            catch (Exception ex)
            {
                _ = ex;
            }
        }
    }
}