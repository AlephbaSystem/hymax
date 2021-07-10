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
        private readonly MapActivityService _activityService;
        private readonly IRoutingService routingService;
        private readonly ICarsService identityService;
         
        public MapViewModel(IRoutingService routingService = null, ICarsService identityService = null)
        {
            Title = "Location History";
            this.routingService = routingService ?? Locator.Current.GetService<IRoutingService>();
            this.identityService = identityService ?? Locator.Current.GetService<ICarsService>();
            _activityService = new MapActivityService();
        } 

    }
}
