using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using hymax.View;
using hymax.Services.Routing;
using Splat;
using hymax.Services.Identity;
using hymax.ViewModels;
using hymax.Services.Cars;
using hymax.Controls;
using hymax.Services;
using hymax.Models;
using System.Collections.Generic;

namespace hymax
{
    public partial class App : Application
    {
        public App()
        {
            InitializeDb();
            InitializeDi();
            InitializeComponent();

            //MainPage = new MasterShell();
            //return;

            if (Settings.UserSetting.Count == 0)
            {
                SettingsModel sm = new SettingsModel();
                sm.LastLogin = DateTime.Now;
                sm.Verified = false;
                sm.Username = Environment.MachineName;
                sm.Phone = null;
                Settings.UserSetting = Settings.Database.GetSettings();
                _ = Settings.Database.SaveSettingsAsync(sm);
                MainPage = new AppShell();
            }
            else if (Settings.UserSetting[0].Phone != null)
            {
                MainPage = new MasterShell();
            }
            else
            {
                MainPage = new AppShell();
            }
        }
        private void InitializeDb()
        {
            Settings.UserSetting = Settings.Database.GetSettings();
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
            Locator.CurrentMutable.Register(() => new AdvanceViewModel());
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
