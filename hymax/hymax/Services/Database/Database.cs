using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using hymax.Models;
using System.Threading.Tasks;
using hymax.Services;
using System.IO;

namespace hymax.Services.Database
{
    class Database : IDatabaseService
    {
        readonly SQLiteAsyncConnection _database;

        public Database()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "hymax.db3");

            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<SettingsModel>().Wait();
        }
        public async Task Reset()
        {
            SettingsModel sm = new SettingsModel();
            sm.LastLogin = DateTime.Now;
            sm.Verified = false;
            sm.Username = Environment.MachineName;
            sm.Phone = null;
            sm.Welcome = true;
            sm.SecurityType = 0;
            await _database.QueryAsync<SettingsModel>("DELETE FROM Settings");
            await _database.CreateTableAsync<SettingsModel>();

            await this.SaveSettingsAsync(sm);
        }
        public Task<List<SettingsModel>> GetSettingsAsync()
        {
            var sm = _database.QueryAsync<SettingsModel>("SELECT * FROM Settings");
            return sm;
            //return _database.Table<SettingsModel>().ToListAsync();
        }
        public List<SettingsModel> GetSettings()
        {
            var sm = GetSettingsAsync().Result;
            return sm;
        }
        public Task<int> SaveSettingsAsync(SettingsModel person)
        {
            return _database.InsertAsync(person);
        }
        public Task<int> UpdateSettingsAsync(SettingsModel person)
        {
            return _database.UpdateAsync(person);
        }
    }
}