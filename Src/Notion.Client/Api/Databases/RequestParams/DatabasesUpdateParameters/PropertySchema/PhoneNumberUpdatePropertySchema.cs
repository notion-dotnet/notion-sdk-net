using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class PhoneNumberUpdatePropertySchema : IUpdatePropertySchema
    {
        [JsonProperty("phone_number")]
        public Dictionary<string, object> PhoneNumber { get; set; }
    }
}
