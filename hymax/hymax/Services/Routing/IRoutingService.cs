using System.Threading.Tasks;
using Xamarin.Forms;

namespace hymax.Services.Routing
{
    public interface IRoutingService
    {
        Task GoBack();
        Task GoBackModal();
        Task NavigateTo(string route);
        void CleanNavigationStack();
        void CleanModalStack();
        Task PopToRoot();
        void NewShell();
        void MasterShell();
    }
}
