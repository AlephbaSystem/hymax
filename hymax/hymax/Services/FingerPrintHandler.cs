using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace hymax.Services
{
    class FingerPrintHandler
    {
        public static async Task<bool> CheckFingers()
        {
            _ = await Task.FromResult(false);
            return true;
            //var fpService = Mvx.Resolve<IFingerprint>(); 
            //var rs = Localization.Localizations.GetResource();
            //var request = new AuthenticationRequestConfiguration(rs.GetString("PutFingerHeader"), rs.GetString("PutFinger"));
            //var result = await fpService.AuthenticateAsync(request);
            //if (result.Authenticated)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
    }
}
