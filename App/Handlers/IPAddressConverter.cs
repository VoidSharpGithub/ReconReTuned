using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Handlers
{
    public class IPAddressConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IPAddress);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            IPAddress ip = value as IPAddress;
            if (ip == null)
            {
                writer.WriteNull();
            }
            else
            {
                // Serialize as a string; handle IPv6 scope ids correctly
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6 && ip.IsIPv6LinkLocal)
                {
                    writer.WriteValue(ip.ToString() + "%" + ip.ScopeId);
                }
                else
                {
                    writer.WriteValue(ip.ToString());
                }
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            string ipString = (string)reader.Value;
            // Handle IPv6 with scope id
            if (ipString.Contains("%"))
            {
                int lastIndex = ipString.LastIndexOf('%');
                string addressPart = ipString.Substring(0, lastIndex);
                long scopeId = long.Parse(ipString.Substring(lastIndex + 1));
                IPAddress ip = IPAddress.Parse(addressPart);
                ip.ScopeId = scopeId;
                return ip;
            }
            return IPAddress.Parse(ipString);
        }
    }
}
