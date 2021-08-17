using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using hymax.Models;
using System.Threading.Tasks;

namespace hymax.Controls
{
    class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<SettingsModel>().Wait();
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