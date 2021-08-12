using System;

namespace hymax.Models
{
    public class SettingsModel
    {
        public string Username { get; set; }
        public string LastLogin { get; set; }
        public string Phone { get; set; }
        public bool Verified { get; set; }
    }
}