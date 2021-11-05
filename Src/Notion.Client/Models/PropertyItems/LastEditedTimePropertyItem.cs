using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class LastEditedTimePropertyItem : SimplePropertyItem
    {
        public override string Type => "last_edited_time";

        [JsonProperty("last_edited_time")]
        public DateTime LastEditedTime { get; set; }
    }
}
