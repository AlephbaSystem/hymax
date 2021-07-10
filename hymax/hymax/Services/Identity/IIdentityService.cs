using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace hymax.Services.Identity
{

    interface IIdentityService
    {
        Task<bool> VerifyRegistration();
        Task<bool> Authenticate();
    }
}
