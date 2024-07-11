using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Objects
{
    public class AutoRefreshObject
    {
        public static List<AutoRefreshObject> DefaultAutoRefreshIntervals = new List<AutoRefreshObject>
        {
            new AutoRefreshObject { AutoRefreshTimeSpan = TimeSpan.FromSeconds(1) },
            new AutoRefreshObject { AutoRefreshTimeSpan = TimeSpan.FromSeconds(3) },
            new AutoRefreshObject { AutoRefreshTimeSpan = TimeSpan.FromSeconds(5) }
        };
        public TimeSpan AutoRefreshTimeSpan { get; set; }

        public override string ToString()
        {
            return $"Auto Refresh ({AutoRefreshTimeSpan.ToString("ss")}s)";
        }
    }
}
