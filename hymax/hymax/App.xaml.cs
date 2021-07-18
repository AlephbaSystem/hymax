using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using hymax.View;
using hymax.Services.Routing;
using Splat;
using hymax.Services.Identity;
using hymax.ViewModels;
using hymax.Services.Cars;

namespace hymax
{
    public partial class App : Application
    {
        public App()
        {
            InitializeDi();
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new MasterShell();

        }
        private void InitializeDi()
        {
            // Services
            Locator.CurrentMutable.RegisterLazySingleton<IRoutingService>(() => new ShellRoutingService());
            Locator.CurrentMutable.RegisterLazySingleton<IIdentityService>(() => new IdentityServiceStub());
            Locator.CurrentMutable.RegisterLazySingleton<ICarsService>(() => new CarsServiceStub());
            

            // ViewModels
            Locator.CurrentMutable.Register(() => new LoadingViewModel());
            Locator.CurrentMutable.Register(() => new LoginViewModel());
            Locator.CurrentMutable.Register(() => new LoginVerifyViewModel());
            Locator.CurrentMutable.Register(() => new SecureLoginViewModel());
            Locator.CurrentMutable.Register(() => new MapViewModel());
            Locator.CurrentMutable.Register(() => new SetSecureViewModel());
            Locator.CurrentMutable.Register(() => new WelcomeViewModel());
            Locator.CurrentMutable.Register(() => new MainViewModel());
            Locator.CurrentMutable.Register(() => new SettingsMenuViewModel());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
