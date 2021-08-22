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
    public partial class SecureLoginPage : ContentPage
    {
        public SecureLoginPage()
        {
            InitializeComponent();
            BindingContext = ViewModel; 
        }

        static internal SecureLoginViewModel ViewModel { get; set; } = Locator.Current.GetService<SecureLoginViewModel>();

        void OnPinTapped(object sender, EventArgs args)
        {
            ViewModel.OnPinTapped(sender, args);
        }
         void OnFingerPrintTapped(object sender, EventArgs args)
        {
            ViewModel.OnFingerPrintTapped(sender, args); 
        }
         void OnPasswordTapped(object sender, EventArgs args)
        {
            ViewModel.OnPasswordTapped(sender, args);
        }
         void OnPatternTapped(object sender, EventArgs args)
        {
            ViewModel.OnPatternTapped(sender, args);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Services.Settings.LastPage = "SLPage";
        }
    }
}