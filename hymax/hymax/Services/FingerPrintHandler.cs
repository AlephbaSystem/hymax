using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace hymax.Services
{
    class FingerPrintHandler
    {
        public async Task<bool> CheckFingers(string reason, string cancel = null, string fallback = null, string tooFast = null)
        {
            //_cancel = false ? new CancellationTokenSource(TimeSpan.FromSeconds(10)) : new CancellationTokenSource();

            var dialogConfig = new AuthenticationRequestConfiguration("ورود با اثر انگشت", reason)
            {
                CancelTitle = cancel,
                FallbackTitle = fallback,
                AllowAlternativeAuthentication = true,
                ConfirmationRequired = false
            };

            dialogConfig.HelpTexts.MovedTooFast = tooFast;
            var result = await Plugin.Fingerprint.CrossFingerprint.Current.AuthenticateAsync(dialogConfig);
            if (result.Authenticated)
            {
                Settings.AccessToken = result.Status.ToString();
                return true;
            }
            return false;
        }

    }
}
