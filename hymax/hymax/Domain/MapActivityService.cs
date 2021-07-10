using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;
 

namespace hymax.Domain
{
    public class MapActivityService : IMapActivityService
    {

        private readonly List<String> _activities = new List<String>();

        public Task<List<String>> GetActivitiesAsync()
        {
            return null;
        }

        public Task<String> GetActivityAsync(string id)
        {
            return null;
        }

        private Task<String> GetActivityByResourceName(string resourceName)
        {
            return null;
        }
    }
}
