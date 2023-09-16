using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class UniqueIdProperty : Property
    {
        public override PropertyType Type => PropertyType.UniqueId;

        [JsonProperty("unique_id")]
        public Dictionary<string, object> UniqueId { get; set; }
    }
}

