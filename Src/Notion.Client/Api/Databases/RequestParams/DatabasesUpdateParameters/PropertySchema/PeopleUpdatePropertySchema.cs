using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class PeopleUpdatePropertySchema : UpdatePropertySchema
    {
        [JsonProperty("people")]
        public Dictionary<string, object> People { get; set; }
    }
}
