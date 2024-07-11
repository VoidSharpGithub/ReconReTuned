using Adobe.PDFServicesSDK.auth;
using App.Objects;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace App.Handlers
{
    public class ServiceType
    {
        public string Name { get; private set; }
        public int Port { get; private set; }
        public string ControlURLExtension { get; private set; }
        public string EventURLExtension { get; private set; }
        public string ServiceSchema { get; private set; }
        public string ServiceSCPDURL { get; private set; }

        private ServiceType(string name, int port, string controlurlextension, string eventurlextension, string serviceschema, string servicescpdurl)
        {
            Name = name;
            Port = port;
            ControlURLExtension = controlurlextension;
            EventURLExtension = eventurlextension;
            ServiceSchema = serviceschema;
            ServiceSCPDURL = servicescpdurl;
        }

        //EchoSTB_SCPD.xml for documentation
        //EchoSTB2_SCPD.xml for documentation
        public static readonly ServiceType EchoSTB1 = new ServiceType("EchoSTB1", 49200,"/upnp/control/EchoSTB1", "/upnp/event/EchoSTB1", "urn:schemas-echostar-com:service:EchoSTB:1", "/EchoSTB_SCPD.xml");
        public static readonly ServiceType EchoSTB2 = new ServiceType("EchoSTB2", 49200, "/upnp/control/EchoSTB2", "/upnp/event/EchoSTB2", "urn:schemas-echostar-com:service:EchoSTB:2", "/EchoSTB2_SCPD.xml");

        public override string ToString()
        {
            return Name;
        }
    }
    public class SOAPHandler
    {
        private static HttpClient client;
        public static async Task<XmlDocument?> PostSoapRequest(IPAddress IP, XmlDocument SoapEnvelope, ServiceType Service, TimeSpan? Timeout = null)
        {
            string SoapURL = PrepareURL(IP, Service);
            string SoapActionName = GetSoapActionFromEnvelope(SoapEnvelope, Service);
            string SoapSchema = Service.ServiceSchema;
            if (SoapActionName == string.Empty)
                return null;
            if (client != null)
                return null;
            client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Linux", "2.6.33.6-147.fc13.i686.PAE"));
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("UPnP", "1.0"));
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("PortableSDKForUPnPDevices", "1.6.6"));
            client.DefaultRequestHeaders.Add("SOAPACTION", $"\"{SoapSchema}#{SoapActionName}\"");
            if(Timeout == null)
                client.Timeout = TimeSpan.FromSeconds(2);
            else
                client.Timeout = Timeout.Value;
            var httpContent = new StringContent(SoapEnvelope.OuterXml, Encoding.UTF8, "text/xml");
            try
            {
                var response = await client.PostAsync(SoapURL, httpContent);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                client.Dispose();
                client = null;
                return ConvertXDocumentToXmlDocument(XDocument.Parse(responseBody));
            }
            catch (TaskCanceledException e)
            {
                client.Dispose();
                client = null;
            }
            catch (HttpRequestException ex)
            {
                LogHandler.LogMessage(typeof(SOAPHandler).FullName + ex.Message);
                Debug.WriteLine("Not Success");
            }
            client = null;
            return null;
        }
        public static XmlDocument GenerateSoapEnvelope(string SoapActionName, Dictionary<string, string>? SoapArguments)
        {
            (XmlDocument doc, XmlElement soapaction) = SetupSoapEnvelope(SoapActionName);
            if (SoapArguments == null)
                return doc;
            foreach (KeyValuePair<string, string> SoapArg in SoapArguments)
            {
                XmlElement soapargument = doc.CreateElement(SoapArg.Key);
                soapargument.InnerText = SoapArg.Value;
                soapaction.AppendChild(soapargument);
            }
            return doc;
        }
        public static string ReadFromXDoc(XmlDocument SoapEnvelope, ServiceType Service, string SoapElement)
        {
            string SoapAction = GetSoapActionFromEnvelope(SoapEnvelope, Service);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(SoapEnvelope.NameTable);
            nsmgr.AddNamespace("s", "http://schemas.xmlsoap.org/soap/envelope/");
            nsmgr.AddNamespace("u", Service.ServiceSchema);

            string xpath = $"/s:Envelope/s:Body/u:{SoapAction}/{SoapElement}";

            XmlNode node = SoapEnvelope.SelectSingleNode(xpath, nsmgr);
            return node?.InnerText ?? string.Empty;
        }

        public static async Task<List<SOAPActionObject>> GetSOAPActionsForService(IPAddress IP, ServiceType Service)
        {

            string xml = await FetchXMLFromURL(PrepareURL(IP, Service, Service.ServiceSCPDURL));

            XDocument doc = XDocument.Parse(xml);
            XNamespace ns = "urn:schemas-upnp-org:service-1-0";
            var actions = new List<SOAPActionObject>();

            foreach (var actionElement in doc.Descendants(ns + "action"))
            {
                var action = new SOAPActionObject();
                action.Name = actionElement.Element(ns + "name")?.Value;

                var argumentList = actionElement.Element(ns + "argumentList");
                if (argumentList != null)
                {
                    action.Arguments = new List<SOAPActionArgument>();
                    foreach (var argElement in argumentList.Elements(ns + "argument"))
                    {
                        var argument = new SOAPActionArgument
                        {
                            Name = argElement.Element(ns + "name")?.Value,
                            Direction = argElement.Element(ns + "direction")?.Value,
                            RelatedStateVariable = argElement.Element(ns + "relatedStateVariable")?.Value
                        };
                        action.Arguments.Add(argument);
                    }
                }
                else
                {
                    action.Arguments = null;
                }

                actions.Add(action);
            }

            return actions;
        }
        public static async Task<List<SOAPActionStateVariable>> GetSOAPActionVariablesForService(IPAddress IP, ServiceType Service)
        {
            string xml = await FetchXMLFromURL(PrepareURL(IP, Service, Service.ServiceSCPDURL));

            XDocument doc = XDocument.Parse(xml);
            XNamespace ns = "urn:schemas-upnp-org:service-1-0";
            var stateVariables = new List<SOAPActionStateVariable>();

            foreach (var stateVariableElement in doc.Descendants(ns + "stateVariable"))
            {
                var stateVariable = new SOAPActionStateVariable();
                stateVariable.Name = stateVariableElement.Element(ns + "name")?.Value;
                stateVariable.DataType = stateVariableElement.Element(ns + "dataType")?.Value;

                var allowedValueRangeList = stateVariableElement.Element(ns + "allowedValueRange");
                if (allowedValueRangeList != null)
                {
                    stateVariable.AllowedValueRange = new ValueRange() { 
                        Minimum = int.Parse(allowedValueRangeList.Element(ns + "minimum")?.Value), 
                        Maximum = int.Parse(allowedValueRangeList.Element(ns + "maximum")?.Value)
                    };
                }
                else
                {
                    stateVariable.AllowedValueRange = null;
                }

                var allowedValueList = stateVariableElement.Element(ns + "allowedValueList");
                if (allowedValueList != null)
                {
                    stateVariable.AllowedValues = new List<string>();
                    foreach (var allowedValueElement in allowedValueList.Elements(ns + "allowedValue"))
                    {
                        stateVariable.AllowedValues.Add(allowedValueElement?.Value);
                    }
                }
                else
                {
                    stateVariable.AllowedValues = null;
                }

                stateVariables.Add(stateVariable);
            }

            return stateVariables;
        }
        public static async Task<List<int>> GetAuthChannelList(IPAddress IP, ServiceType Service)
        {
            List<int> AuthChannelList = new List<int>();
            XmlDocument xmlEnv = SOAPHandler.GenerateSoapEnvelope("GetAuthChannelList", null);
            XmlDocument xml = await SOAPHandler.PostSoapRequest(IP, xmlEnv, Service);
            if(xml != null)
            {
                string result = ReadFromXDoc(xml, Service, "Result");
                string AuthXML = await FetchXMLFromURL(PrepareURL(IP, Service, result));
                XDocument doc = XDocument.Parse(AuthXML);
                foreach (var channelElement in doc.Descendants("Channel"))
                {
                    int channelNumber = int.Parse(channelElement.Attribute("channel").Value);

                    AuthChannelList.Add(channelNumber);
                }
            }
            return AuthChannelList;
        }

        private static async Task<string> FetchXMLFromURL(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode(); // Throws an exception if the HTTP response status is an error
                    string xmlData = await response.Content.ReadAsStringAsync();
                    return xmlData;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return null;
                }
            }
        }
        private static string GetSoapActionFromEnvelope(XmlDocument SoapEnvelope, ServiceType Service)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(SoapEnvelope.NameTable);
            nsmgr.AddNamespace("u", Service.ServiceSchema);

            XmlNode actionNode = SoapEnvelope.SelectSingleNode("//u:*", nsmgr);

            if (actionNode != null)
            {
                return actionNode.LocalName;
            }

            return string.Empty;
        }
        private static XmlDocument ConvertXDocumentToXmlDocument(XDocument xDocument)
        {
            XmlDocument xmlDocument = new XmlDocument();
            using (var reader = xDocument.CreateReader())
            {
                xmlDocument.Load(reader);
            }
            return xmlDocument;
        }
        private static (XmlDocument, XmlElement) SetupSoapEnvelope(string SoapActionName)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement envelope = doc.CreateElement("s", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");
            envelope.SetAttribute("encodingStyle", "http://schemas.xmlsoap.org/soap/envelope/", "http://schemas.xmlsoap.org/soap/encoding/");
            doc.AppendChild(envelope);

            XmlElement body = doc.CreateElement("s", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
            envelope.AppendChild(body);

            XmlElement soapaction = doc.CreateElement("u", SoapActionName, "urn:schemas-echostar-com:service:EchoSTB:2");
            body.AppendChild(soapaction);

            return (doc, soapaction);
        }
        private static string PrepareURL(IPAddress IP, ServiceType type)
        {
            return $"http://{IP}:{type.Port}{type.ControlURLExtension}";
        }
        private static string PrepareURL(IPAddress IP, ServiceType type, string ext)
        {
            return $"http://{IP}:{type.Port}{ext}";
        }



    }
}
