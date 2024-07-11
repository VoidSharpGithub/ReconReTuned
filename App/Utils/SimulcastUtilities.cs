using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using Adobe.PDFServicesSDK.auth;
using Adobe.PDFServicesSDK.io;
using Adobe.PDFServicesSDK.options.exportpdf;
using Adobe.PDFServicesSDK.pdfops;
using HtmlAgilityPack;
using OfficeOpenXml;
using UglyToad.PdfPig;

namespace App.Utils
{
    public class SimulcastUtilities
    {
        public static async Task LoadSimulcastRaces(DataGridView data, List<string> FilterList, Dictionary<int,string> ActiveChannels)
        {
            data.Rows.Clear();
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
                            string channel = cells.ElementAt(0).InnerText.Trim();
                            string channelName = HttpUtility.HtmlDecode(cells.ElementAt(1).InnerText.Trim());
                            /*
                            string AirTime = cells.ElementAt(2).InnerText.Trim().Replace(".", "");
                            string AMPM = AirTime.Split(" ")[1].ToLower();
                            int Hour = int.Parse(AirTime.Split(":")[0]) + (AMPM == "am" ? 0 : 12);
                            int Minute = int.Parse(AirTime.Split(":")[1].Split(" ")[0]);
                            DateTime StartTime;
                            if (Hour == 12 && AMPM == "am")
                            {
                                StartTime = DateTime.Today.AddMinutes(Minute);
                            }
                            else
                            {
                                StartTime = DateTime.Today.AddHours(Hour).AddMinutes(Minute);
                            }
                            string DurationString = cells.ElementAt(3).InnerText.Trim();
                            int Hours = int.Parse(DurationString.Split(":")[0]);
                            int Minutes = int.Parse(DurationString.Split(":")[1]);
                            TimeSpan Duration = new TimeSpan(Hours, Minutes, 0);
                            DateTime EndTime = StartTime.Add(Duration);
                            */

                            bool ActiveRace = false;

                            DateTime StartTime = ConvertToDateTimeEst(cells.ElementAt(2).InnerText.Trim());
                            DateTime EndTime = AddDuration(StartTime, cells.ElementAt(3).InnerText.Trim());
                            TimeSpan Duration = GetDuration(cells.ElementAt(3).InnerText.Trim());

                            if (DateTime.Now >= StartTime && DateTime.Now <= EndTime)
                            {
                                ActiveRace = true;
                            }
                            else
                            {
                                ActiveRace = false;
                            }
                            int rowAdded = -1;

                            if(FilterList != null && FilterList.Count >= 1)
                            {
                                // Normalize the channelName for comparison (e.g., to lower case)
                                var normalizedChannelName = channelName.ToLower();

                                // Iterate over each filter and check for a match
                                foreach (var filter in FilterList)
                                {
                                    // Normalize the filter for comparison
                                    var normalizedFilter = filter.ToLower();

                                    var words1 = normalizedChannelName.Split(new[] { ' ', '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
                                    var words2 = normalizedFilter.Split(new[] { ' ', '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);

                                    if(words2.All(word2 => words1.Any(word1 => word1.StartsWith(word2))))
                                    {
                                        rowAdded = data.Rows.Add(ActiveRace, channel, channelName);
                                    }
                                }
                            }
                            else
                            {
                                rowAdded = data.Rows.Add(ActiveRace, channel, channelName);
                            }

                            if (ActiveChannels.Keys.Contains(Int32.Parse(channel)) && ActiveChannels.Values.Contains(channelName)){
                                foreach(DataGridViewCell cell in data.Rows[rowAdded].Cells)
                                {
                                    if (!ActiveRace)
                                    {
                                        cell.Style.ForeColor = Color.Red;
                                    }
                                    else
                                    {
                                        cell.Style.ForeColor = Color.Green;
                                    }
                                }
                            }
                            if (ActiveChannels.Keys.Contains(Int32.Parse(channel)))
                            {
                                string ChannelName_ = ActiveChannels[Int32.Parse(channel)];
                                if (ChannelName_ == "Simulcast Guide")
                                {
                                    foreach (DataGridViewCell cell in data.Rows[rowAdded].Cells)
                                    {
                                        cell.Style.ForeColor = Color.Red;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static DateTime AddDuration(DateTime initialDateTime, string duration)
        {
            TimeSpan durationTimeSpan;
            if (duration == "24:00")
            {
                durationTimeSpan = TimeSpan.FromDays(1); // Represents 24 hours as a full day
            }
            else
            {
                durationTimeSpan = TimeSpan.ParseExact(duration, "h\\:mm", CultureInfo.InvariantCulture);
            }
            DateTime newDateTime = initialDateTime.Add(durationTimeSpan);

            return newDateTime;
        }

        public static TimeSpan GetDuration(string duration)
        {
            if (duration == "24:00")
            {
                return TimeSpan.FromDays(1); // Represents 24 hours as a full day
            }
            else
            {
                return TimeSpan.ParseExact(duration, "h\\:mm", CultureInfo.InvariantCulture);
            }
        }

        public static string DateTimeToStringWithAmPm(DateTime dateTime)
        {
            return dateTime.ToString("h:mm tt", CultureInfo.InvariantCulture);
        }
        public static DateTime ConvertToDateTimeEst(string timeText)
        {
            // Adjusting format strings to recognize "a.m." and "p.m." correctly
            var formats = new[] { "h:mm tt", "h:mm t\\.m\\." }; // Including an escape for periods
            var provider = CultureInfo.InvariantCulture;

            DateTime parsedTime;
            if (!DateTime.TryParseExact(timeText.Replace("a.m.", "AM").Replace("p.m.", "PM"), // Replace a.m. and p.m. with AM and PM
                                        formats,
                                        provider,
                                        DateTimeStyles.None,
                                        out parsedTime))
            {
                throw new FormatException($"The provided time '{timeText}' is not in an expected format.");
            }

            // Assuming the time is given in local time, and we want to convert it to EST
            TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime estTime = TimeZoneInfo.ConvertTime(parsedTime, TimeZoneInfo.Local, estZone);

            return estTime;
        }

        public static async Task<string> GetSimulcastSchedule(int channel, string channelName)
        {
            HttpClient client = new HttpClient();
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
                        if(cells.ElementAt(0).InnerText.Trim() == channel.ToString() && HttpUtility.HtmlDecode(cells.ElementAt(1).InnerText.Trim()) == channelName)
                        {
                            bool ActiveRace = false;

                            DateTime StartTime = ConvertToDateTimeEst(cells.ElementAt(2).InnerText.Trim());
                            DateTime EndTime = AddDuration(StartTime, cells.ElementAt(3).InnerText.Trim());
                            TimeSpan Duration = GetDuration(cells.ElementAt(3).InnerText.Trim());

                            if (DateTime.Now >= StartTime && DateTime.Now <= EndTime)
                            {
                                ActiveRace = true;
                            }
                            else
                            {
                                ActiveRace = false;
                            }
                            return $"{StartTime.ToString("hh:mmtt")}-{EndTime.ToString("hh:mmtt")}";
                        }
                    }
                }
            }
            return "N/A";
        }

        //Filter Util
        private static string SavePath = "//dcgwinfile01/DCG_Groups/DCG_Everyone/Recon ReTuned/Hidden/";
        private static async Task<bool> IsUrlAccessible(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    return response.IsSuccessStatusCode && response.Content.Headers.ContentType.MediaType == "application/pdf";
                }
            }
            catch
            {
                return false; // URL not accessible or not a PDF
            }
        }
        private static async Task<bool> IsValidPdfLink(string url)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult))
            {
                return false; // Not a valid URL
            }

            if (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps)
            {
                return false; // Not a HTTP or HTTPS URL
            }

            if (!uriResult.Host.Equals("www.kentuckyderby.com", StringComparison.OrdinalIgnoreCase))
            {
                return false; // Domain check
            }

            if (!uriResult.AbsolutePath.StartsWith("/wp-content/uploads/", StringComparison.OrdinalIgnoreCase))
            {
                return false; // Path check
            }

            if (!uriResult.AbsoluteUri.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                return false; // File extension check
            }

            // Optional: Check if the URL is accessible
            return await IsUrlAccessible(url);
        }
        private static Stream GetStreamFromURL(string url)
        {
            byte[] imageData = null;

            using (var wc = new WebClient())
                imageData = wc.DownloadData(url);

            return new MemoryStream(imageData);
        }
        public static bool IsNetworkDirectoryAccessible()
        {
            try
            {
                // Attempt to access the directory
                // This can be an operation like listing files or directories
                var directoryInfo = new DirectoryInfo(SavePath);
                directoryInfo.GetDirectories();

                // If no exception is thrown, the directory is accessible
                return true;
            }
            catch (Exception)
            {
                // If an exception is caught, the directory is not accessible
                return false;
            }
        }
        public static async Task<string> GetScheduleDate(string url)
        {
            if (!await IsValidPdfLink(url))
            {
                MessageBox.Show("Please enter a valid PDF URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            // Download PDF from URL
            byte[] pdfData;
            using (var httpClient = new HttpClient())
            {
                pdfData = await httpClient.GetByteArrayAsync(url);
            }

            // Read PDF and extract text
            string extractedText;
            using (var pdf = PdfDocument.Open(pdfData))
            {
                var page = pdf.GetPage(1); // Assuming the words are on the first page

                // Extract words and their locations
                var wordsWithLocations = page.GetWords()
                    .OrderByDescending(w => w.BoundingBox.Bottom) // Sort by Y-coordinate (top to bottom)
                    .ThenBy(w => w.BoundingBox.Left)            // Then by X-coordinate (left to right)
                    .ToList();

                // Combine words into a single string
                extractedText = string.Join(" ", wordsWithLocations.Select(w => w.Text));
            }

            // Extract the first two words
            var words = extractedText.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length >= 2 ? $"{words[0]} - {words[1]}" : string.Empty;
        }
        public static bool DoesScheduleFileExist(string fileName)
        {
            if (IsNetworkDirectoryAccessible())
            {
                if (File.Exists(SavePath + fileName + ".xlsx"))
                    return true;

                return false;
            }
            MessageBox.Show("Can not find directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        public static async Task CreateXLSXFromURL(string url, string scheduleDate)
        {
            Stream stream = GetStreamFromURL(url);
            await Task.Run(() =>
            {
                try
                {
                    string FileNamePath = $"{SavePath}{scheduleDate}.xlsx";
                    if (!File.Exists(FileNamePath))
                    {
                        //Credentials to the PDF Services API
                        //Note: Please do not use these unless you know what you are doing.
                        //Abuse of this will result in this feature being removed from this application.
                        Credentials credentials = Credentials.ServicePrincipalCredentialsBuilder()
                            .WithClientId("5cfb7cc8a8e546fdbefe4b512c7cc365")
                            .WithClientSecret("p8e-A7hQPpUxelbmJJg3n_b13BByRwM5MWs9")
                            .Build();
                        Adobe.PDFServicesSDK.ExecutionContext context = Adobe.PDFServicesSDK.ExecutionContext.Create(credentials);
                        ExportPDFOperation exportPdfOperation = ExportPDFOperation.CreateNew(ExportPDFTargetFormat.XLSX);
                        exportPdfOperation.SetInput(FileRef.CreateFromStream(stream, "application/pdf"));
                        ExportPDFOperation.SupportedSourceFormat.PDF.GetMediaType();
                        FileRef result = exportPdfOperation.Execute(context);
                        result.SaveAs(FileNamePath);
                        MessageBox.Show("PDF Loaded!\n\nMonth has now been added.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Something went wrong!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }
        public static async Task<bool> LoadFilterData(DataGridView DGV, string ScheduleFilePath, List<string> FilterList)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            Stream s = new FileStream(ScheduleFilePath, FileMode.Open,FileAccess.Read,FileShare.ReadWrite);
            ExcelRange ScheduleDayRange;
            DGV.Rows.Clear();
            FilterList.Clear();
            using (var package = new ExcelPackage())
            {
                package.Load(s);
                var worksheet = package.Workbook.Worksheets[0];
                ExcelRange TempRange = null;

                //Find todays day cell in the sheet
                for (int row = 1; row <= worksheet.Dimension.End.Row; row++)
                {
                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        // Check if the current cell has the search value
                        if (worksheet.Cells[row, col].Value != null && int.TryParse(worksheet.Cells[row, col].Value.ToString(), out int cellValue) && cellValue == DateTime.Now.Day) // DateTime.Now.Day
                        {
                            // When found, print the address of the cell
                            TempRange = worksheet.Cells[row, col];
                            break; // Remove this if you want to find all occurrences
                        }
                    }
                }

                //Check if todays day cell is null
                if (TempRange == null)
                {
                    MessageBox.Show("Failed to find todays events.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //Get range of entire day (ScheduleDayRange)
                int startRow = TempRange.Start.Row;
                int startCol = TempRange.Start.Column;
                int endRow = 0;
                int endcol = 0;
                for (int row = startRow; row <= worksheet.Dimension.End.Row; row++)
                {
                    // Check if the cell at the current row in the target column has a bottom border
                    var cell = worksheet.Cells[row, startCol];
                    if (cell.Style.Border.Bottom.Style != OfficeOpenXml.Style.ExcelBorderStyle.None)
                    {
                        endRow = row - 1;
                        if(cell.Style.Border.Right.Style != OfficeOpenXml.Style.ExcelBorderStyle.None)
                            endcol = startCol;
                        else
                            endcol = startCol + 1;
                        break; // Stop after finding the first cell with a bottom border
                    }
                    if(row == worksheet.Dimension.End.Row)
                    {
                        endRow = row - 1;
                        if (cell.Style.Border.Right.Style != OfficeOpenXml.Style.ExcelBorderStyle.None)
                            endcol = startCol;
                        else
                            endcol = startCol + 1;
                        break;
                    }
                }
                ScheduleDayRange = worksheet.Cells[startRow, startCol, endRow, endcol];

                //Add Events to the Filter
                int BeginRow = ScheduleDayRange.Start.Row;
                int EndRow = ScheduleDayRange.End.Row;
                int EventTimeColumn = ScheduleDayRange.Start.Column;
                int EventNameColumn = ScheduleDayRange.End.Column;
                for(int row = BeginRow + 1; row <= EndRow; row++)
                {
                    if(row == BeginRow + 1 && (worksheet.Cells[row, EventNameColumn].Value == null || worksheet.Cells[row, EventTimeColumn].Value == null))
                    {
                        MessageBox.Show("There are no races today.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return false;
                    }

                    if (worksheet.Cells[row, EventTimeColumn].Value == null || worksheet.Cells[row, EventNameColumn].Value == null)
                        break;

                    FilterList.Add(worksheet.Cells[row, EventNameColumn].Value.ToString());
                    DGV.Rows.Add(worksheet.Cells[row, EventTimeColumn].Value.ToString(), worksheet.Cells[row, EventNameColumn].Value.ToString());
                }

            }
            return true;
        }
    }
}
