using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class PhoneNumberUpdatePropertySchema : UpdatePropertySchema
    {
        [JsonProperty("phone_number")]
        public Dictionary<string, object> PhoneNumber { get; set; }
    }
}
