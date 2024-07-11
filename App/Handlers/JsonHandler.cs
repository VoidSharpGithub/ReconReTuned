using App.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Handlers
{
    public static class JsonHandler
    {
        public static string SerializedReceiverList()
        {
            string json = JsonConvert.SerializeObject(Program.Receivers, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                Converters = new List<JsonConverter> { new IPAddressConverter() }
            });
            return json;
        }

        public static BindingList<ReceiverObject> DeserializeReceiverList(string jsonData)
        {
            return JsonConvert.DeserializeObject<BindingList<ReceiverObject>>(jsonData, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                Converters = new List<JsonConverter> { new IPAddressConverter() }
            });
        }
    }
}
