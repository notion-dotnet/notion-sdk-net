using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class LastEditedTimePropertySchema : IPropertySchema
    {
        [JsonProperty("last_edited_time")]
        public Dictionary<string, object> LastEditedTime { get; set; }
    }
}
