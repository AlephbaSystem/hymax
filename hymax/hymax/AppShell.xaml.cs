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
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell(bool step = true)
        {
            InitializeComponent();
             
            Routing.RegisterRoute("main/login", typeof(LoginPage));
            Routing.RegisterRoute("login/loginverify", typeof(LoginVerifyPage));
            Routing.RegisterRoute("login/securelogin", typeof(SecureLoginPage));
            Routing.RegisterRoute("login/setsecure", typeof(SetSecurePage));
            Routing.RegisterRoute("login/welcome", typeof(WelcomePage));
            BindingContext = this;
        } 
    }
}