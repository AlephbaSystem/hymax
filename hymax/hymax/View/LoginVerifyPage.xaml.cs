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
    public partial class LoginVerifyPage : ContentPage
    {
        public LoginVerifyPage()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }
        static internal LoginVerifyViewModel ViewModel { get; set; } = Locator.Current.GetService<LoginVerifyViewModel>();
        public static void InitPage(string phonenumber)
        { 
            ViewModel.PhoneNumber = phonenumber;
        }
    }
}