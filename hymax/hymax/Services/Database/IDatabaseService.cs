using hymax.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace hymax.Services.Database
{
    interface IDatabaseService
    {
        Task Reset();
        Task<List<SettingsModel>> GetSettingsAsync();
        List<SettingsModel> GetSettings();
        Task<int> SaveSettingsAsync(SettingsModel person);
        Task<int> UpdateSettingsAsync(SettingsModel person);
    }
}
