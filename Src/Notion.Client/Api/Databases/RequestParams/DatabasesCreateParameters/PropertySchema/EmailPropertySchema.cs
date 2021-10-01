using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class EmailPropertySchema : IPropertySchema
    {
        [JsonProperty("email")]
        public Dictionary<string, object> Email { get; set; }
    }
}
