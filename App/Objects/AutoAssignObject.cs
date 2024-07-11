using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Objects
{
    public class AutoAssignObject
    {
        public static List<AutoAssignObject> DefaultAutoAssignIntervals = new List<AutoAssignObject>
        {
            new AutoAssignObject { AutoAssignTimeSpan = TimeSpan.FromMinutes(15) },
            new AutoAssignObject { AutoAssignTimeSpan = TimeSpan.FromMinutes(20) },
            new AutoAssignObject { AutoAssignTimeSpan = TimeSpan.FromMinutes(25) },
            new AutoAssignObject { AutoAssignTimeSpan = TimeSpan.FromMinutes(30) },
            new AutoAssignObject { AutoAssignTimeSpan = TimeSpan.FromMinutes(35) },
            new AutoAssignObject { AutoAssignTimeSpan = TimeSpan.FromMinutes(40) },
            new AutoAssignObject { AutoAssignTimeSpan = TimeSpan.FromMinutes(45) }
        };
        public static List<AutoAssignObject> DefaultAutoAssignOverdueIntervals = new List<AutoAssignObject>
        {
            new AutoAssignObject { AutoAssignTimeSpan = TimeSpan.FromMinutes(5) },
            new AutoAssignObject { AutoAssignTimeSpan = TimeSpan.FromMinutes(10) },
            new AutoAssignObject { AutoAssignTimeSpan = TimeSpan.FromMinutes(15) }
        };
        public TimeSpan AutoAssignTimeSpan { get; set; }

        public override string ToString()
        {
            return $"Auto Assign ({AutoAssignTimeSpan.ToString("mm")}min)";
        }
    }
}
