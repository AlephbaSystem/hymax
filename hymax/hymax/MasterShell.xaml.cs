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

            Routing.RegisterRoute("main/setsecure", typeof(SetSecurePage)); 
            BindingContext = this;
        }
        public ICommand ExecuteLogout => new Command(async () => await GoToAsync("main/login"));
    }
}