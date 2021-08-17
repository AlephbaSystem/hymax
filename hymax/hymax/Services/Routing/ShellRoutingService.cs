using hymax.View;
using hymax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace hymax.Services.Routing
{
    public class ShellRoutingService : IRoutingService
    {
        protected readonly Dictionary<Type, Type> _mappings;
        protected Application CurrentApplication
        {
            get { return Application.Current; }
        }

        public ShellRoutingService()
        {
            _mappings = new Dictionary<Type, Type>();
        }

        public Task NavigateTo(string route)
        {
            return Shell.Current.GoToAsync(route);
        }

        public void NewShell()
        { 
            CurrentApplication.MainPage = new AppShell();
        }
        public void MasterShell()
        {
            CurrentApplication.MainPage = new MasterShell();
        }

        public void CleanNavigationStack()
        {
            var existingPages = Shell.Current.Navigation.NavigationStack.ToList();
            if (existingPages.Count <= 0)
                return;
            foreach (var page in existingPages)
            {
                if (page is Page)
                    Application.Current.MainPage.Navigation.RemovePage(page);
            }
            this.NewShell();
        }
        public async Task PopToRoot()
        {
            
            await Shell.Current.Navigation.PopToRootAsync(false);
        }
        public void CleanModalStack()
        {
            var existingModals = Shell.Current.Navigation.ModalStack.ToList();
            if (existingModals.Count <= 0)
                return;
            if (existingModals[0] is null)
                return;
            foreach (var modal in existingModals)
            {
                if (modal is Page)
                    Shell.Current.Navigation.RemovePage(modal);
            }
            this.NewShell();
        }
        public async Task GoBack()
        {
            if (CurrentApplication.MainPage is MainPage)
            {
                var mainPage = CurrentApplication.MainPage as MainPage;
                await mainPage.Navigation.PopAsync();
            }
            else if (CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync();
            }
        }

        public Task GoBackModal()
        {
            return Shell.Current.Navigation.PopModalAsync();
        }
    }
}
