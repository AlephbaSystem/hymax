using System;
using System.Threading.Tasks;
 

namespace hymax.Domain
{
    public interface IMapActivityService
    {
        Task<System.Collections.Generic.List<string>> GetActivitiesAsync();
        Task<string> GetActivityAsync(string id);
    }
}