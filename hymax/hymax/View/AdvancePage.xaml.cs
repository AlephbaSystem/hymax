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
    public partial class AdvancePage : ContentPage
    {
        public AdvancePage()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }
        static internal AdvanceViewModel ViewModel { get; set; } = Locator.Current.GetService<AdvanceViewModel>();

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Services.Settings.LastPage = "Advance";
        }
    }
}