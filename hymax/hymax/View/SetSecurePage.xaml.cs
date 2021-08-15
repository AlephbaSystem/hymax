using hymax.Services;
using hymax.ViewModels;
using Plugin.Fingerprint.Abstractions;
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
    public partial class SetSecurePage : ContentPage
    {
        public SetSecurePage()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }
        private void ResetClicked(object sender, EventArgs e)
        {
            ViewModel.Reset();
        }
        static internal SetSecureViewModel ViewModel { get; set; } = Locator.Current.GetService<SetSecureViewModel>();
        public static void InitPage()
        {
        }
        protected virtual void OnResume()
        {
            ViewModel.Reset();
        }
        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}