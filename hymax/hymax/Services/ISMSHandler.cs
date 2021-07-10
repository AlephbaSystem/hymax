using Plugin.Messaging;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks; 

namespace hymax.Services
{
    class ISMSHandler
    { 
        public async Task SendSms(string messageText, string recipient)
        {
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
                        smsMessenger.SendSmsInBackground(recipient, messageText);
                }
                else if (status != PermissionStatus.Unknown)
                {
                    //location denied
                }
            }
            catch (Exception ex)
            {
                _ = ex;
                //Something went wrong
            }
        } 
    }
}
