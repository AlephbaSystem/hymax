using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace hymax.Models
{
    class CarsModel
    {
        public string Title { get; set; }
        public ImageSource ImagePath { get; set; }
        public string ID { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpdateTimeLabel { get; set; }
    }
}
