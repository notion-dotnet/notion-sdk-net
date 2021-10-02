using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class DatePropertySchema : IPropertySchema
    {
        [JsonProperty("date")]
        public Dictionary<string, object> Date { get; set; }
    }
}
