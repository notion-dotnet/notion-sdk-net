using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class URLUpdatePropertySchema : UpdatePropertySchema, IUpdatePropertySchema
    {
        [JsonProperty("url")]
        public Dictionary<string, object> Url { get; set; }
    }
}
