using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hymax.ViewModels;
using Splat;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace hymax.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsMenu : ContentPage
    {
        public SettingsMenu()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Services.Settings.LastPage = "Settings";
        }
        static internal SettingsMenuViewModel ViewModel { get; set; } = Locator.Current.GetService<SettingsMenuViewModel>();
    }
}