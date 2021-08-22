using hymax.Services.Core;
using hymax.ViewModels;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace hymax.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing(); 
            Services.Settings.LastPage = "Login";
        }
        static internal LoginViewModel ViewModel { get; set; } = Locator.Current.GetService<LoginViewModel>();
         
        private long lastPress = 0;
        protected override bool OnBackButtonPressed()
        {
            long currentTime = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;
            if (currentTime - lastPress > 5000)
            {
                Acr.UserDialogs.UserDialogs.Instance.Toast("Press again to exit", new TimeSpan(3));
                lastPress = currentTime;
            }
            else
            {
                if (Device.RuntimePlatform == Device.Android)
                    DependencyService.Get<IAndroidMethods>().CloseApp();
            }
            return base.OnBackButtonPressed();
        }
    }
}