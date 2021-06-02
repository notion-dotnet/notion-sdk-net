using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class LastEditedTimeProperty : Property
    {
        public override PropertyType Type => PropertyType.LastEditedTime;

        [JsonProperty("last_edited_time")]
        public Dictionary<string, object> LastEditedTime { get; set; }
    }
}
