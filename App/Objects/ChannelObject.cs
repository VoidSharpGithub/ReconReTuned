using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Objects
{
    public class ChannelObject
    {
        public int DishChannel { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string ChannelName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string ChannelRating { get; set; }
    }
}
