using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CreatedTimePropertyItem : SimplePropertyItem
    {
        public override string Type => "created_time";

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }
    }
}
