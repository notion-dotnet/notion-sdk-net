using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class EmailUpdatePropertySchema : UpdatePropertySchema, IUpdatePropertySchema
    {
        [JsonProperty("email")]
        public Dictionary<string, object> Email { get; set; }
    }
}
