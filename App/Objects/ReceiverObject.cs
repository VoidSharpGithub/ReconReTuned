using App.Handlers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace App.Objects
{
    public class ReceiverObject
    {
        public string ReceiverName { get; set; }
        public string ReceiverID { get; set; }
        public IPAddress ReceiverIP { get; set; }
        public string ReceiverModel { get; set; }
        public string ReceiverVersion {  get; set; }
        public (bool UpdatesEnabled, TimeSpan? UpdateTime) ReceiverUpdates { get; set; }
        public (bool StandbyEnabled, TimeSpan? InactivityTime) ReceiverInactivity { get; set; }
        public TunerObject FirstTuner { get; set; }
        public TunerObject SecondTuner { get; set; }

        public static async Task<ReceiverObject?> CreateReceiverObject(string Name, IPAddress IP)
        {
            ReceiverObject Receiver = new ReceiverObject();
            TunerObject Tuner1 = new TunerObject();
            TunerObject Tuner2 = new TunerObject();
            ChannelObject Tuner1Channel = new ChannelObject();
            ChannelObject Tuner2Channel = new ChannelObject();
            XmlDocument GetSystemInformationEnvelope = SOAPHandler.GenerateSoapEnvelope("GetSystemInformation", null);
            XmlDocument GetSystemInformationResponse = await SOAPHandler.PostSoapRequest(IP, GetSystemInformationEnvelope, ServiceType.EchoSTB2);

            if (GetSystemInformationResponse == null)
                return null;

            XmlDocument GetTuner1StatusEnvelope = SOAPHandler.GenerateSoapEnvelope("GetTunerStatus", new Dictionary<string, string>() { { "Tuner", "0" } });
            XmlDocument GetTuner1StatusResponse = await SOAPHandler.PostSoapRequest(IP, GetTuner1StatusEnvelope, ServiceType.EchoSTB2);
            XmlDocument GetChannelInfoTuner1Envelope = SOAPHandler.GenerateSoapEnvelope("GetChannelInfo", new Dictionary<string, string>() { { "Tuner", "0" } });
            XmlDocument GetChannelInfoTuner1Response = await SOAPHandler.PostSoapRequest(IP, GetChannelInfoTuner1Envelope, ServiceType.EchoSTB2);

            XmlDocument GetTuner2StatusEnvelope = SOAPHandler.GenerateSoapEnvelope("GetTunerStatus", new Dictionary<string, string>() { { "Tuner", "1" } });
            XmlDocument GetTuner2StatusResponse = await SOAPHandler.PostSoapRequest(IP, GetTuner2StatusEnvelope, ServiceType.EchoSTB2);
            XmlDocument GetChannelInfoTuner2Envelope = SOAPHandler.GenerateSoapEnvelope("GetChannelInfo", new Dictionary<string, string>() { { "Tuner", "1" } });
            XmlDocument GetChannelInfoTuner2Response = await SOAPHandler.PostSoapRequest(IP, GetChannelInfoTuner2Envelope, ServiceType.EchoSTB2);

            //Channel Setup
            Tuner1Channel.DishChannel = int.Parse(SOAPHandler.ReadFromXDoc(GetTuner1StatusResponse, ServiceType.EchoSTB2, "Channel"));
            Tuner1Channel.EventName = SOAPHandler.ReadFromXDoc(GetChannelInfoTuner1Response, ServiceType.EchoSTB2, "Event_Name");
            Tuner1Channel.EventDescription = SOAPHandler.ReadFromXDoc(GetChannelInfoTuner1Response, ServiceType.EchoSTB2, "Event_Description");
            Tuner1Channel.ChannelName = SOAPHandler.ReadFromXDoc(GetChannelInfoTuner1Response, ServiceType.EchoSTB2, "Channel_Name");
            Tuner1Channel.ChannelRating = SOAPHandler.ReadFromXDoc(GetChannelInfoTuner1Response, ServiceType.EchoSTB2, "Rating");
            Tuner1Channel.StartTime = TimeHandler.EpochToDate(SOAPHandler.ReadFromXDoc(GetChannelInfoTuner1Response, ServiceType.EchoSTB2, "Start"));
            Tuner1Channel.EndTime = TimeHandler.EpochToDate(SOAPHandler.ReadFromXDoc(GetChannelInfoTuner1Response, ServiceType.EchoSTB2, "End"));
            Tuner1Channel.Duration = TimeHandler.GetDurationBetweenTimes(Tuner1Channel.StartTime, Tuner1Channel.EndTime);

            Tuner2Channel.DishChannel = int.Parse(SOAPHandler.ReadFromXDoc(GetTuner2StatusResponse, ServiceType.EchoSTB2, "Channel"));
            Tuner2Channel.EventName = SOAPHandler.ReadFromXDoc(GetChannelInfoTuner2Response, ServiceType.EchoSTB2, "Event_Name");
            Tuner2Channel.EventDescription = SOAPHandler.ReadFromXDoc(GetChannelInfoTuner2Response, ServiceType.EchoSTB2, "Event_Description");
            Tuner2Channel.ChannelName = SOAPHandler.ReadFromXDoc(GetChannelInfoTuner2Response, ServiceType.EchoSTB2, "Channel_Name");
            Tuner2Channel.ChannelRating = SOAPHandler.ReadFromXDoc(GetChannelInfoTuner2Response, ServiceType.EchoSTB2, "Rating");
            Tuner2Channel.StartTime = TimeHandler.EpochToDate(SOAPHandler.ReadFromXDoc(GetChannelInfoTuner2Response, ServiceType.EchoSTB2, "Start"));
            Tuner2Channel.EndTime = TimeHandler.EpochToDate(SOAPHandler.ReadFromXDoc(GetChannelInfoTuner2Response, ServiceType.EchoSTB2, "End"));
            Tuner2Channel.Duration = TimeHandler.GetDurationBetweenTimes(Tuner2Channel.StartTime, Tuner2Channel.EndTime);


            //Tuner Setup
            Tuner1.TunerID = 0;
            Tuner1.TunerType = SOAPHandler.ReadFromXDoc(GetTuner1StatusResponse, ServiceType.EchoSTB2, "TunerType");
            Tuner1.TunerSignalStrength = SOAPHandler.ReadFromXDoc(GetTuner1StatusResponse, ServiceType.EchoSTB2, "TunerSignalStrength");
            Tuner1.TunerStandby = SOAPHandler.ReadFromXDoc(GetTuner1StatusResponse, ServiceType.EchoSTB2, "AV_Status") == "Started";
            Tuner1.TunerChannel = Tuner1Channel;

            Tuner2.TunerID = 1;
            Tuner2.TunerType = SOAPHandler.ReadFromXDoc(GetTuner2StatusResponse, ServiceType.EchoSTB2, "TunerType");
            Tuner2.TunerSignalStrength = SOAPHandler.ReadFromXDoc(GetTuner2StatusResponse, ServiceType.EchoSTB2, "TunerSignalStrength");
            Tuner2.TunerStandby = SOAPHandler.ReadFromXDoc(GetTuner2StatusResponse, ServiceType.EchoSTB2, "AV_Status") == "Started";
            Tuner2.TunerChannel = Tuner2Channel;

            //Receiver Setup
            Receiver.ReceiverName = Name;
            Receiver.ReceiverIP = IP;
            Receiver.ReceiverID = SOAPHandler.ReadFromXDoc(GetSystemInformationResponse, ServiceType.EchoSTB2, "Receiver_ID").Split("-")[0];
            Receiver.ReceiverModel = SOAPHandler.ReadFromXDoc(GetSystemInformationResponse, ServiceType.EchoSTB2, "Model");
            Receiver.ReceiverVersion = SOAPHandler.ReadFromXDoc(GetSystemInformationResponse, ServiceType.EchoSTB2, "Software_Version");
            string UpdateResult = SOAPHandler.ReadFromXDoc(GetSystemInformationResponse, ServiceType.EchoSTB2, "Updates");
            var parts = UpdateResult.Split(new[] { ',' }, 2); 

            bool updatesEnabled = parts[0].Trim().Equals("Enabled", StringComparison.OrdinalIgnoreCase);
            TimeSpan? updateTime = null;

            if (updatesEnabled && parts.Length > 1 && DateTime.TryParseExact(parts[1].Trim(), "hh:mmtt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedTime))
            {
                updateTime = parsedTime.TimeOfDay;
            }
            Receiver.ReceiverUpdates = (updatesEnabled, updateTime);

            string InactivityResult = SOAPHandler.ReadFromXDoc(GetSystemInformationResponse, ServiceType.EchoSTB2, "Inactivity_Standby");
            parts = InactivityResult.Split(new[] { ',' }, 2);

            bool inactivityEnabled = parts[0].Trim().Equals("Enabled", StringComparison.OrdinalIgnoreCase);
            TimeSpan? inactivityTime = null;

            if (inactivityEnabled && parts.Length > 1 && DateTime.TryParseExact(parts[1].Trim(), "HH' Hours'", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedTime2))
            {
                inactivityTime = parsedTime2.TimeOfDay;
            }
            Receiver.ReceiverInactivity = (inactivityEnabled, inactivityTime);
            Receiver.FirstTuner = Tuner1;
            Receiver.SecondTuner = Tuner2;

            return Receiver;
        }

        public async Task<bool> UpdateReceiverObject()
        {
            ReceiverObject NewReceiver = await CreateReceiverObject(this.ReceiverName, this.ReceiverIP);
            if(NewReceiver == null)
            {
                return false;
            }
            this.ReceiverName = NewReceiver.ReceiverName;
            this.ReceiverID = NewReceiver.ReceiverID;
            this.ReceiverIP = NewReceiver.ReceiverIP;
            this.ReceiverModel = NewReceiver.ReceiverModel;
            this.ReceiverVersion = NewReceiver.ReceiverVersion;
            this.ReceiverUpdates = NewReceiver.ReceiverUpdates;
            this.ReceiverInactivity = NewReceiver.ReceiverInactivity;
            this.FirstTuner = NewReceiver.FirstTuner;
            this.SecondTuner = NewReceiver.SecondTuner;
            return true;
        }
        public async Task<bool> ToggleStandby(TunerObject Tuner)
        {
            if (Tuner.TunerStandby)
            {
                XmlDocument GetStandbyEnvelope = SOAPHandler.GenerateSoapEnvelope("Standby", new Dictionary<string, string>() { { "Tuner", Tuner.TunerID.ToString() } });
                XmlDocument GetStandbyResponse = await SOAPHandler.PostSoapRequest(this.ReceiverIP, GetStandbyEnvelope, ServiceType.EchoSTB2);
                if (GetStandbyResponse == null)
                    return false;
            }
            else
            {
                XmlDocument GetWakeupEnvelope = SOAPHandler.GenerateSoapEnvelope("WakeUp", new Dictionary<string, string>() { { "Tuner", Tuner.TunerID.ToString() } });
                XmlDocument GetWakeupResponse = await SOAPHandler.PostSoapRequest(this.ReceiverIP, GetWakeupEnvelope, ServiceType.EchoSTB2);
                if (GetWakeupResponse == null)
                    return false;
            }
            return true;
        }
        public override string ToString()
        {
            return this.ReceiverName;
        }
    }
}
