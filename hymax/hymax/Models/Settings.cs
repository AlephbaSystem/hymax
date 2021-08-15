using SQLite;
using System;

namespace hymax.Models
{
    [Table("Settings")]
    public class SettingsModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }  
        public string Username { get; set; }
        public DateTime LastLogin { get; set; }
        public string Phone { get; set; }
        public bool Verified { get; set; }
    }
}