using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class StatusProperty : Property
    {
        public override PropertyType Type => PropertyType.Status;

        [JsonProperty("status")]
        public Dictionary<string, object> Status { get; set; }
    }
}
