using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class PeopleUpdatePropertySchema : UpdatePropertySchema, IUpdatePropertySchema
    {
        [JsonProperty("people")]
        public Dictionary<string, object> People { get; set; }
    }
}
