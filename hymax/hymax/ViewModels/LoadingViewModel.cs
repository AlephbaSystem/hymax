using hymax.Services.Identity;
using hymax.Services.Routing;
using hymax.View;
using Splat;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace hymax.ViewModels
{
    class LoadingViewModel : BaseViewModel
    {
        private readonly IRoutingService routingService;
        private readonly ICarsService identityService; 

        public LoadingViewModel(IRoutingService routingService = null, ICarsService identityService = null)
        {
            this.routingService = routingService ?? Locator.Current.GetService<IRoutingService>();
            this.identityService = identityService ?? Locator.Current.GetService<ICarsService>();
        }

        // Called by the views OnAppearing method
        public async void Init()
        {
            var isAuthenticated = await this.identityService.VerifyRegistration(); 
            if (isAuthenticated)
            { 
                await this.routingService.NavigateTo("///main");
            }
            else
            { 
                await this.routingService.NavigateTo("///login");
            }
        }
    }
}
