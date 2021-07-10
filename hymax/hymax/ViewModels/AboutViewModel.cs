using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace hymax.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            DeviceNumber = "+989337554330";
            LockCommand = new Command(LockCommandClick);
            OpenCommand = new Command(OpenCommandClick);
            ForceStopCommand = new Command(ForceStopCommandClick);
            OpenTrunkCommand = new Command(OpenTrunkCommandClick);
            LocationCommand = new Command(LocationCommandClick);
        }
         
        public string DeviceNumber { get; set; }
        public ICommand LockCommand { get; }
        public ICommand OpenCommand { get; }
        public ICommand ForceStopCommand { get; }
        public ICommand OpenTrunkCommand { get; }
        public ICommand LocationCommand { get; }

        private async void LockCommandClick(object obj)
        {
            await new Services.ISMSHandler().SendSms("قفل", DeviceNumber);
        }
        private async void OpenCommandClick(object obj)
        {
            await new Services.ISMSHandler().SendSms("باز", DeviceNumber);
        }
        private async void ForceStopCommandClick(object obj)
        {
            await new Services.ISMSHandler().SendSms("خاموش", DeviceNumber);
        }
        private async void OpenTrunkCommandClick(object obj)
        {
            await new Services.ISMSHandler().SendSms("صندوق", DeviceNumber);
        }
        private async void LocationCommandClick(object obj)
        {
            await new Services.ISMSHandler().SendSms("محدوده", DeviceNumber);
        }
    }
}