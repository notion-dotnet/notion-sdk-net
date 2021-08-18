using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CreatedTimeUpdatePropertySchema : IUpdatePropertySchema
    {
        [JsonProperty("created_time")]
        public Dictionary<string, object> CreatedTime { get; set; }
    }
}
