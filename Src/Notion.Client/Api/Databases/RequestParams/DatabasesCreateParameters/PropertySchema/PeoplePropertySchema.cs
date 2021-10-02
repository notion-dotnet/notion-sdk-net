using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class PeoplePropertySchema : IPropertySchema
    {
        [JsonProperty("people")]
        public Dictionary<string, object> People { get; set; }
    }
}
