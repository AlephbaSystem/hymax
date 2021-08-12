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
            return _database.Table<SettingsModel>().ToListAsync();
        }

        public Task<int> SaveSettingsAsync(SettingsModel person)
        {
            return _database.InsertAsync(person);
        }
    }
}