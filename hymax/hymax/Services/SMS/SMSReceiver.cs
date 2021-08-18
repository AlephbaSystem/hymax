using System;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace hymax.Services.SMS
{
    public class SMSReceiver
    {
        public event Action<string, string> Recived;

        public SMSReceiver()
        {
            SubscribeToOtpReceiving();
        }

        private void SubscribeToOtpReceiving()
        {
            MessagingCenter.Subscribe<hymax.Services.SMS.SMSReceiver, System.Tuple<string, string>>(this, "OtpReceived", (sender, code) =>
            {
                Recived(code.Item1, code.Item2); 
            });
        }
    }
}