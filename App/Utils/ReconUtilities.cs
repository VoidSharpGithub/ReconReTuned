using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace App.Utils
{
    public class ReconUtilities
    {
        private static async Task<string?> NewQueryReceiver(string strSoapAction, StringBuilder aStringBuilder, string ipaddress)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Linux", "2.6.33.6-147.fc13.i686.PAE"));
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("UPnP", "1.0"));
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("PortableSDKForUPnPDevices", "1.6.6"));
            client.DefaultRequestHeaders.Add("SOAPACTION", "\"urn:schemas-echostar-com:service:EchoSTB:2#" + strSoapAction + "\"");
            var httpContent = new StringContent(aStringBuilder.ToString(), Encoding.UTF8, "text/xml");
            try
            {
                var response = await client.PostAsync("http://" + ipaddress + ":49200/upnp/control/EchoSTB2", httpContent);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                // Handle exception
                Console.WriteLine($"Request exception: {e.Message}");
            }
            return null;
        }
        private static async Task<int> QueryReceiver(string strSoapAction, StringBuilder aStringBuilder, string ipaddress)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Linux", "2.6.33.6-147.fc13.i686.PAE"));
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("UPnP", "1.0"));
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("PortableSDKForUPnPDevices", "1.6.6"));
            client.DefaultRequestHeaders.Add("SOAPACTION", "\"urn:schemas-echostar-com:service:EchoSTB:2#" + strSoapAction + "\"");
            client.Timeout = TimeSpan.FromSeconds(3);
            var httpContent = new StringContent(aStringBuilder.ToString(), Encoding.UTF8, "text/xml");
            try
            {
                var response = await client.PostAsync("http://" + ipaddress + ":49200/upnp/control/EchoSTB2", httpContent);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine("Failed to set channel. Channel does not exist.");
                return -1;
            }
            catch (TaskCanceledException e)
            {
                Debug.WriteLine("Failed to set channel. Most likely reason is not currently authorized for requested channel.");
                return -2;
            }
            return 1;
        }
        public static async Task<int> ChangeChannel(string ipaddress, int tuner, int channel)
        {
            //Add checks for AV Status
            StringBuilder aStringBuilder = new StringBuilder();
            aStringBuilder.Append("<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\" s:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">");
            aStringBuilder.Append("<s:Body>");
            aStringBuilder.Append("<u:SetChannel xmlns:u=\"urn:schemas-echostar-com:service:EchoSTB:2\">");
            aStringBuilder.AppendLine("<Tuner>" + tuner.ToString() + "</Tuner>");
            aStringBuilder.AppendLine("<Channel>" + channel.ToString() + "</Channel>");
            aStringBuilder.AppendLine("</u:SetChannel>");
            aStringBuilder.AppendLine("</s:Body>");
            aStringBuilder.AppendLine("</s:Envelope>");
            aStringBuilder.AppendLine();
            int status = await QueryReceiver("SetChannel", aStringBuilder, ipaddress);
            return status;
        }
        public static async void WakeUpTuner(string ipaddress, int tuner, bool wakeup)
        {
            StringBuilder aStringBuilder = new StringBuilder();
            aStringBuilder.Append("<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\" s:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">");
            aStringBuilder.Append("<s:Body>");
            aStringBuilder.Append("<u:" + (wakeup ? "WakeUp" : "Standby") + " xmlns:u=\"urn:schemas-echostar-com:service:EchoSTB:2\">");
            aStringBuilder.AppendLine("<Tuner>" + tuner.ToString() + "</Tuner>");
            aStringBuilder.AppendLine("</u:" + (wakeup ? "WakeUp" : "Standby") + ">");
            aStringBuilder.AppendLine("</s:Body>");
            aStringBuilder.AppendLine("</s:Envelope>");
            aStringBuilder.AppendLine();
            await NewQueryReceiver(wakeup ? "WakeUp" : "Standby", aStringBuilder, ipaddress);
        }
        /*
        public static async void SetReceiverUpdates(ReconStruct reconInfo)
        {
            if (reconInfo.updatesenabled)
            {
                foreach (Receivers receiver in reconInfo.receivers)
                {
                    string ipaddress = receiver.ipaddress;
                    if (await IsHostAccessible(ipaddress))
                    {
                        StringBuilder aStringBuilder = new StringBuilder();
                        aStringBuilder.Append("<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\" s:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">");
                        aStringBuilder.Append("<s:Body>");
                        aStringBuilder.Append("<u:Updates xmlns:u=\"urn:schemas-echostar-com:service:EchoSTB:2\">");
                        aStringBuilder.AppendLine("<Enable_disable>Enable</Enable_disable>");
                        aStringBuilder.AppendLine("<hour>" + reconInfo.updatetime.ToString("hh") + "</hour>");
                        aStringBuilder.AppendLine("<min>" + reconInfo.updatetime.ToString("mm") + "</min>");
                        aStringBuilder.AppendLine("<am_or_pm>" + (reconInfo.updatetime.ToString("tt").ToLower() == "am" ? "am" : "pm") + "</am_or_pm>");
                        aStringBuilder.AppendLine("</u:Updates>");
                        aStringBuilder.AppendLine("</s:Body>");
                        aStringBuilder.AppendLine("</s:Envelope>");
                        aStringBuilder.AppendLine();
                        await NewQueryReceiver("Updates", aStringBuilder, ipaddress);
                    }
                }
            }
        }*/
        public static async Task<XDocument> GetTunerStats(string ipaddress, int tuner)
        {
            StringBuilder aStringBuilder = new StringBuilder();
            aStringBuilder.Append("<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\" s:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">");
            aStringBuilder.Append("<s:Body>");
            aStringBuilder.Append("<u:GetTunerStatus xmlns:u=\"urn:schemas-echostar-com:service:EchoSTB:2\">");
            aStringBuilder.AppendLine("<Tuner>" + tuner.ToString() + "</Tuner>");
            aStringBuilder.AppendLine("</u:GetTunerStatus>");
            aStringBuilder.AppendLine("</s:Body>");
            aStringBuilder.AppendLine("</s:Envelope>");
            aStringBuilder.AppendLine();
            string response = await NewQueryReceiver("GetTunerStatus", aStringBuilder, ipaddress);
            return XDocument.Parse(response);
        }
        public static async Task<XDocument> GetChannelStats(string ipaddress, int tuner)
        {
            StringBuilder aStringBuilder = new StringBuilder();
            aStringBuilder.Append("<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\" s:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">");
            aStringBuilder.Append("<s:Body>");
            aStringBuilder.Append("<u:GetChannelInfo xmlns:u=\"urn:schemas-echostar-com:service:EchoSTB:2\">");
            aStringBuilder.AppendLine("<Tuner>" + tuner.ToString() + "</Tuner>");
            aStringBuilder.AppendLine("</u:GetChannelInfo>");
            aStringBuilder.AppendLine("</s:Body>");
            aStringBuilder.AppendLine("</s:Envelope>");
            aStringBuilder.AppendLine();
            string response = await NewQueryReceiver("GetChannelInfo", aStringBuilder, ipaddress);
            return XDocument.Parse(response);
        }
        public static async Task<XDocument> GetSystemStats(string ipaddress)
        {
            StringBuilder aStringBuilder = new StringBuilder();
            aStringBuilder.Append("<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\" s:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">");
            aStringBuilder.Append("<s:Body>");
            aStringBuilder.Append("<u:GetSystemInformation xmlns:u=\"urn:schemas-echostar-com:service:EchoSTB:2\">");
            aStringBuilder.AppendLine("</u:GetSystemInformation>");
            aStringBuilder.AppendLine("</s:Body>");
            aStringBuilder.AppendLine("</s:Envelope>");
            aStringBuilder.AppendLine();
            string response = await NewQueryReceiver("GetSystemInformation", aStringBuilder, ipaddress);
            return XDocument.Parse(response);
        }
        public static async Task<bool> IsHostAccessible(string ipAddress, int timeout = 100)
        {
            using (Ping pingSender = new Ping())
            {
                try
                {
                    PingReply reply = await pingSender.SendPingAsync(ipAddress, timeout);

                    return reply.Status == IPStatus.Success;
                }
                catch (PingException ex)
                {
                    Debug.WriteLine($"Ping failed: {ex.Message}");
                }
            }
            return false;
        }
        public static async Task<bool> CheckReceiverConnection(string ipaddress)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Linux", "2.6.33.6-147.fc13.i686.PAE"));
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("UPnP", "1.0"));
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("PortableSDKForUPnPDevices", "1.6.6"));
            client.Timeout = TimeSpan.FromSeconds(1);
            try
            {
                var response = await client.GetAsync("http://" + ipaddress + ":49200/upnp/control/EchoSTB2");
                return true;
            }
            catch (TaskCanceledException e)
            {
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private static string SearchXML(XDocument doc, string searchVal)
        {
            try
            {

                // Assuming that the "Updates" element is unique in the XML document
                XElement updatesElement = doc.Descendants(searchVal).FirstOrDefault();

                if (updatesElement != null)
                {
                    return updatesElement.Value;
                }
            }
            catch (Exception ex)
            {
                // Handle or log exception
                Console.WriteLine("Error parsing XML: " + ex.Message);
            }

            return null;
        }
        public static async Task<int> GetTunerAVStatus(string ipaddress, int tuner)
        {
            XDocument XDoc = await GetTunerStats(ipaddress, tuner);
            return SearchXML(XDoc, "AV_Status") == "Started" ? 1 : 0;
        }
        public static async Task<int> GetTunerStatus(string ipaddress, int tuner)
        {
            XDocument XDoc = await GetTunerStats(ipaddress, tuner);
            return SearchXML(XDoc, "TunerStatus") == "Unlocked" ? 1 : 0;
        }
        public static async Task<int> GetTunerStrength(string ipaddress, int tuner)
        {
            XDocument XDoc = await GetTunerStats(ipaddress, tuner);
            return Int32.Parse(SearchXML(XDoc, "TunerSignalStrength"));
        }
        public static async Task<int> GetTunerChannel(string ipaddress, int tuner)
        {
            XDocument XDoc = await GetTunerStats(ipaddress, tuner);
            return Int32.Parse(SearchXML(XDoc, "Channel"));
        }
        public static async Task<string> GetChannelTrueName(string ipaddress, int tuner)
        {
            XDocument XDoc = await GetChannelStats(ipaddress, tuner);
            return SearchXML(XDoc, "Channel_Name");
        }
        public static async Task<string> GetChannelRating(string ipaddress, int tuner)
        {
            XDocument XDoc = await GetChannelStats(ipaddress, tuner);
            return SearchXML(XDoc, "Rating");
        }
        public static async Task<string> GetChannelName(string ipaddress, int tuner)
        {
            XDocument XDoc = await GetChannelStats(ipaddress, tuner);
            return SearchXML(XDoc, "Event_Name");
        }
        public static async Task<string> GetChannelDesc(string ipaddress, int tuner)
        {
            XDocument XDoc = await GetChannelStats(ipaddress, tuner);
            return SearchXML(XDoc, "Event_Description");
        }
        /*
        public static async Task<DateTime> GetChannelStart(string ipaddress, int tuner)
        {
            XDocument XDoc = await GetChannelStats(ipaddress, tuner);
            return Helper.EpochToDate(SearchXML(XDoc, "Start"));
        }
        public static async Task<DateTime> GetChannelEnd(string ipaddress, int tuner)
        {
            XDocument XDoc = await GetChannelStats(ipaddress, tuner);
            return Helper.EpochToDate(SearchXML(XDoc, "End"));
        }*/
        public static async Task<string> GetReceiverModel(string ipaddress)
        {
            XDocument XDoc = await GetSystemStats(ipaddress);
            return SearchXML(XDoc, "Model");
        }
        public static async Task<string> GetReceiverSoftwareVersion(string ipaddress)
        {
            XDocument XDoc = await GetSystemStats(ipaddress);
            return SearchXML(XDoc, "Software_Version");
        }
        public static async Task<DateTime?> GetReceiverUpdates(string ipaddress)
        {
            XDocument XDoc = await GetSystemStats(ipaddress);
            string updates = SearchXML(XDoc, "Updates");
            if (updates == "Disabled")
                return null;
            string time = updates.Split(", ").Last();
            return DateTime.ParseExact(time, "hh:mmtt", CultureInfo.InvariantCulture);
        }

        public static async Task<List<string>> GetAuthChannelList(string ipaddress)
        {
            StringBuilder aStringBuilder = new StringBuilder();
            aStringBuilder.Append("<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\" s:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">");
            aStringBuilder.Append("<s:Body>");
            aStringBuilder.Append("<u:GetAuthChannelList xmlns:u=\"urn:schemas-echostar-com:service:EchoSTB:2\">");
            aStringBuilder.AppendLine("</u:GetAuthChannelList>");
            aStringBuilder.AppendLine("</s:Body>");
            aStringBuilder.AppendLine("</s:Envelope>");
            aStringBuilder.AppendLine();
            string response_1 = await NewQueryReceiver("GetAuthChannelList", aStringBuilder, ipaddress);
            XDocument XDoc = XDocument.Parse(response_1);
            string result = SearchXML(XDoc, "Result");
            HttpClient client = new HttpClient();
            List<string> channelNumbers = new List<string>();
            var response = await client.GetAsync("http://" + ipaddress + ":49200" + result);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            XDocument doc = XDocument.Parse(responseBody);

            foreach (XElement element in doc.Descendants("Channel"))
            {
                string channelNumber = element.Attribute("channel").Value;
                channelNumbers.Add(channelNumber);
            }
            return channelNumbers;
        }
    }
}
