using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Objects
{
    public class TunerObject
    {
        public int TunerID { get; set; }
        public ChannelObject TunerChannel { get; set; }
        public string TunerSignalStrength { get; set; }
        public string TunerType { get; set; }
        public bool TunerStandby { get; set; }
    }
}
