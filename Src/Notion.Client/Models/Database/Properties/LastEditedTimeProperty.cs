using Newtonsoft.Json;
using System.Collections.Generic;

namespace Notion.Client
{
    public class LastEditedTimeProperty : Property
    {
        public override PropertyType Type => PropertyType.LastEditedTime;

        [JsonProperty("last_edited_time")]
        public Dictionary<string, object> LastEditedTime { get; set; }
    }
}
