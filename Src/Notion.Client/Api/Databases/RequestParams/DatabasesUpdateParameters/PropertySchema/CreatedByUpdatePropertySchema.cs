using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CreatedByUpdatePropertySchema : UpdatePropertySchema
    {
        [JsonProperty("created_by")]
        public Dictionary<string, object> CreatedBy { get; set; }
    }
}
