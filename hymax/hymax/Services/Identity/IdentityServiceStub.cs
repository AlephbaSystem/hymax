using System;
using System.Threading.Tasks;

namespace hymax.Services.Identity
{
    class IdentityServiceStub : IIdentityService
    {
        public async Task<bool> Authenticate()
        {
            var today = await Task.FromResult<string>(DateTime.Now.DayOfWeek.ToString());
            if (Settings.AccessToken.Length <= 0 || Settings.AccessTokenExpiration <= DateTime.Now)
            {
                Settings.AccessToken = "";
                return  false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> VerifyRegistration()
        {
            await Task.Delay(1337);
            return false;
        }
    }
}
