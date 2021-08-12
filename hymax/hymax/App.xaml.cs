﻿using System;
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
            InitializeDi();
            InitializeComponent();
            InitializeDb();

            MainPage = new MasterShell();
            return;

            if (Settings.UserSetting[0].Verified)
            {
                MainPage = new MasterShell();
            }
            else
            {
                MainPage = new AppShell();
            }

        }
        private async void InitializeDb()
        {
            Settings.UserSetting = await Settings.Database.GetSettingsAsync();
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
