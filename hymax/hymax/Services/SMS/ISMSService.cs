using Plugin.Messaging;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace hymax.Services.SMS
{
    public interface ISMSService
    {
        Task SendSms(string messageText);
        Task SendSms(string messageText, string recipient);
        event Action<string, string> Recived;
        void ClearQueue();
        string Getrecipient();
        void Setrecipient(string value);
    }
}
