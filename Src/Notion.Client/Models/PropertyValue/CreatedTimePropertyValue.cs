using Newtonsoft.Json;

namespace Notion.Client
{
    public class CreatedTimePropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.CreatedTime;

        [JsonProperty("created_time")]
        public string CreatedTime { get; set; }
    }

}
