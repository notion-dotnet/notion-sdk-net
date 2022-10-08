using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class UrlUpdatePropertySchema : UpdatePropertySchema
    {
        [JsonProperty("url")]
        public Dictionary<string, object> Url { get; set; }
    }
}
