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

        static internal LoginViewModel ViewModel { get; set; } = Locator.Current.GetService<LoginViewModel>();

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}