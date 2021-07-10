using hymax.Models;
using hymax.ViewModels;
using Splat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace hymax.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    { 

        public MapPage()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }

        internal SecureLoginViewModel ViewModel { get; set; } = Locator.Current.GetService<SecureLoginViewModel>();

        protected override void OnAppearing()
        {
            base.OnAppearing(); 
        }
    }
}