using App.Handlers;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace App.Objects
{
    public class RCNSimulcastScheduleObject
    {
        public int DishChannel {  get; set; }
        public string EventName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsActive { get; set; }
        public (bool ChannelInUse, ReceiverObject? Receiver, TunerObject? Tuner) Activity { get; set; }

        public static async Task<List<RCNSimulcastScheduleObject>> GetSimulcastRaces()
        {
            List<RCNSimulcastScheduleObject> Schedule = new List<RCNSimulcastScheduleObject>();
            HttpClient client = new HttpClient();
            try
            {
                var response = await client.GetAsync("https://www.rtn.tv/rcnschedule/rcnschedule.aspx");
                response.EnsureSuccessStatusCode();
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(await response.Content.ReadAsStringAsync());

                // Find the target table by id
                HtmlNode targetTable = doc.GetElementbyId("MainContent_tblScheduleList");

                // Check if the table was found
                if (targetTable != null)
                {
                    // Get all rows in the table, skipping the first and last rows
                    IEnumerable<HtmlNode> rows = targetTable.Descendants("tr").Skip(1).Take(targetTable.Descendants("tr").Count() - 2);

                    foreach (HtmlNode row in rows)
                    {
                        // Get all the cells in the row
                        IEnumerable<HtmlNode> cells = row.Descendants("td");

                        if (cells.Count() == 4)
                        {
                            string DishChannelString = cells.ElementAt(0).InnerText.Trim();
                            string EventNameString = HttpUtility.HtmlDecode(cells.ElementAt(1).InnerText.Trim());
                            
                            DateTime StartTime = TimeZoneInfo.ConvertTimeToUtc(DateTime.ParseExact(cells.ElementAt(2).InnerText.Trim().Replace(".", ""), "h:mm tt", CultureInfo.InvariantCulture));
                            string DurationString = cells.ElementAt(3).InnerText.Trim();
                            TimeSpan Duration = new TimeSpan(1, 0, 0, 0);
                            if (DurationString != "24:00")
                            {
                                Duration = TimeSpan.ParseExact(DurationString, "h\\:mm", CultureInfo.InvariantCulture);
                            }
                            DateTime EndTime = StartTime + Duration;
                            bool MyIsActive = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now) >= StartTime && TimeZoneInfo.ConvertTimeToUtc(DateTime.Now) <= EndTime;
                            if (Duration.Days > 0)
                                MyIsActive = true;
                            (bool ChannelInUse, ReceiverObject? Receiver, TunerObject? Tuner) MyActivity = (false, null, null);
                            foreach (ReceiverObject Receiver in Program.Receivers)
                            {
                                if(Receiver.FirstTuner.TunerChannel.DishChannel == int.Parse(DishChannelString))
                                {
                                    MyActivity = (true, Receiver, Receiver.FirstTuner);
                                    break;
                                }
                                else if(Receiver.SecondTuner.TunerChannel.DishChannel == int.Parse(DishChannelString))
                                {
                                    MyActivity = (true, Receiver, Receiver.SecondTuner);
                                    break;
                                }
                            }

                            Schedule.Add(new RCNSimulcastScheduleObject {
                                DishChannel = int.Parse(DishChannelString),
                                EventName = EventNameString,
                                StartTime = StartTime,
                                Duration = Duration,
                                IsActive = MyIsActive,
                                Activity = MyActivity,
                                EndTime = EndTime
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<RCNSimulcastScheduleObject>();
            }
            return Schedule;
        }

    }
}
