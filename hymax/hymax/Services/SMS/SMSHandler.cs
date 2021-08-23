using System;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Plugin.Messaging;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using hymax.Services.Database;

namespace hymax.Services.SMS
{
    public class SMSHandler : ISMSService
    {
        public event Action<string, string> Recived;
        private Queue<Tuple<string, string>> SendQueue;
        private Queue<Tuple<string, string>> ReciveQueue;
        private string recipient;

        public string Getrecipient()
        {
            return recipient;
        }

        public void Setrecipient(string value)
        {
            recipient = value;
        }

        public SMSHandler()
        {
            SubscribeToOtpReceiving();
            SendQueue = new Queue<Tuple<string, string>>();
            ReciveQueue = new Queue<Tuple<string, string>>();
        }

        private void SubscribeToOtpReceiving()
        {
            string[] Qulified = { "Main", "Advance", "LVPage", "Settings", "Map" };
            MessagingCenter.Subscribe<hymax.Services.SMS.SMSHandler, System.Tuple<string, string>>(this, "HymaxOtpReceived", (sender, code) =>
            {
                if (Qulified.Contains<string>(Services.Settings.LastPage))
                {
                    Recived(code.Item1, code.Item2);
                }
            });
        }

        public async Task SendSms(string messageText)
        {
            SendQueue.Enqueue(Tuple.Create<string, string>(this.Getrecipient(), messageText));
            while (SendQueue.Count > 0)
            {
                await sendSms();
            }
        }
        public async Task SendSms(string messageText, string recipient)
        {
            SendQueue.Enqueue(Tuple.Create<string, string>(recipient, messageText));
            while (SendQueue.Count > 0)
            {
                await sendSms();
            }
        }
        public void ClearQueue()
        {
            SendQueue.Clear();
        }
        private async Task sendSms()
        {
            Tuple<string, string> current = SendQueue.Dequeue();
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync<SmsPermission>();
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Sms))
                    {
                        //Gunna need that location
                    }

                    status = await CrossPermissions.Current.RequestPermissionAsync<SmsPermission>();
                }

                if (status == PermissionStatus.Granted)
                {
                    var smsMessenger = CrossMessaging.Current.SmsMessenger;
                    if (smsMessenger.CanSendSms)
                    {
                        smsMessenger.SendSmsInBackground(current.Item1, current.Item2);
                        return;
                    }
                }
                else if (status != PermissionStatus.Unknown)
                {
                    //location denied
                }
            }
            catch (Exception ex)
            {
                //Something went wrong
            }
            SendQueue.Enqueue(current);
        }
    }
}