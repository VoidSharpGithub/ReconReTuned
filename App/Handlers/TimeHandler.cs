using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Handlers
{
    public static class TimeHandler
    {
        public static string DateToEpoch(DateTime date)
        {
            DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (date - epochStart).TotalSeconds.ToString();
        }
        public static DateTime EpochToDate(string epochString)
        {
            if (long.TryParse(epochString, out long epoch))
            {
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(epoch);
                return dateTimeOffset.DateTime;
            }
            else
            {
                return DateTime.Today.AddDays(3);
            }
        }
        public static TimeSpan GetDurationBetweenTimes(DateTime firstdate, DateTime seconddate)
        {
            return (seconddate - firstdate).Duration();
        }


    }
}
