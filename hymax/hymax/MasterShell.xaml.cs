using hymax.Services;
using hymax.View;
using hymax.ViewModels;
using Splat;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace hymax
{
    public partial class MasterShell : Xamarin.Forms.Shell
    {
        public MasterShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("login/securelogin", typeof(SecureLoginPage));
            Routing.RegisterRoute("main/setsecure", typeof(SetSecurePage));
            Routing.RegisterRoute("main/settings", typeof(SettingsMenu));
            Routing.RegisterRoute("main/advance", typeof(AdvancePage));
            Routing.RegisterRoute("main/welcome", typeof(WelcomePage));
            Routing.RegisterRoute("main/map", typeof(MapPage));
            BindingContext = this;
        }
        public ICommand ExecuteLogout => new Command(async () => await GoToAsync("main/login"));
    }
}