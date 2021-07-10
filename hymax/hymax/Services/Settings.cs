using hymax.Localization;
using hymax.Models;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace hymax.Services
{
    class Settings
    {
        private static ISettings AppSettings =>
    CrossSettings.Current;

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
