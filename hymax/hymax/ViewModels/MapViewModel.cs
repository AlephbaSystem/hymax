using hymax.Domain;
using hymax.Services.Identity;
using hymax.Services.Routing;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;

namespace hymax.ViewModels
{
    class MapViewModel : BaseViewModel
    {
        private readonly IRoutingService routingService;

        public MapViewModel(IRoutingService routingService = null, IIdentityService identityService = null)
        {
            Title = "Map";
            this.routingService = routingService ?? Locator.Current.GetService<IRoutingService>(); 
        }

    }
}
