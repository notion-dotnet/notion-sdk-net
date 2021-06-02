using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CreatedTimeProperty : Property
    {
        public override PropertyType Type => PropertyType.CreatedTime;

        [JsonProperty("created_time")]
        public Dictionary<string, object> CreatedTime { get; set; }
    }
}
