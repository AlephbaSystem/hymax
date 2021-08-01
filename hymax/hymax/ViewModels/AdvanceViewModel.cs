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
    class AdvanceViewModel : BaseViewModel
    {
        private readonly IRoutingService routingService;
        public AdvanceViewModel(IRoutingService routingService = null)
        {
            this.BackgroundColor = Services.ColorServer.GetResource("MainSecondaryColor");
            this.routingService = routingService ?? Locator.Current.GetService<IRoutingService>();
        }
    }
}
