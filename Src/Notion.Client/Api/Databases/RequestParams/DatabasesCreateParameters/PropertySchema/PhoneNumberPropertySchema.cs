using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class PhoneNumberPropertySchema : IPropertySchema
    {
        [JsonProperty("phone_number")]
        public Dictionary<string, object> PhoneNumber { get; set; }
    }
}
