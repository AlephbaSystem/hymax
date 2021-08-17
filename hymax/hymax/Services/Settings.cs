using hymax.Controls;
using hymax.Localization;
using hymax.Models;
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace hymax.Services
{
    class Settings
    {
        private static ISettings AppSettings =>
    CrossSettings.Current;

        static Database database = null;
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "hymax.db3"));
                }
                return database;
            }
        }

        public static List<SettingsModel> UserSetting
        {
            get
            {
                var storeString = CrossSettings.Current.GetValueOrDefault(nameof(UserSetting), string.Empty);
                List<SettingsModel> model = null;
                if (!string.IsNullOrEmpty(storeString))
                {
                    model = JsonConvert.DeserializeObject<List<SettingsModel>>(storeString);
                } 
                return model;
            }
            set => AppSettings.AddOrUpdateValue(nameof(UserSetting), JsonConvert.SerializeObject(value));
        }
        public static string AccessToken
        {
            get => AppSettings.GetValueOrDefault(nameof(AccessToken), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(AccessToken), value);
        }
        public static DateTime AccessTokenExpiration
        {
            get => AppSettings.GetValueOrDefault(nameof(AccessTokenExpiration), DateTime.Now);
            set => AppSettings.AddOrUpdateValue(nameof(AccessTokenExpiration), value);
        }

        public static string Language
        {
            get => AppSettings.GetValueOrDefault(nameof(Language), "FA");
            set => AppSettings.AddOrUpdateValue(nameof(Language), value);
        }

        public static SecurityTypes Security
        {
            get
            {
                return (SecurityTypes)Enum.Parse(typeof(SecurityTypes), AppSettings.GetValueOrDefault(nameof(SecurityTypes), SecurityTypes.Password.ToString()));
            }
            set
            {
                AppSettings.AddOrUpdateValue(nameof(SecurityTypes), value.ToString());
            }
        }
    }
}
