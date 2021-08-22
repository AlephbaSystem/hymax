using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using hymax.ViewModels;
using Splat;
using hymax.Models;

namespace hymax.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }
        static internal WelcomeViewModel ViewModel { get; set; } = Locator.Current.GetService<WelcomeViewModel>();
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Services.Settings.LastPage = "Welcome";
        }
        public void carouselView_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            var item = e.CurrentItem as WelcomeModel;
            var index = ViewModel.Welcomes.IndexOf(item);

            if (ViewModel.Welcomes.Count == (index + 1))
            {
                Skip.IsVisible = true;
            }
        }
    }
}