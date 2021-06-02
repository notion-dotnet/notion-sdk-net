using Newtonsoft.Json;

namespace Notion.Client
{
    public class LastEditedTimePropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.LastEditedTime;

        [JsonProperty("last_edited_time")]
        public string LastEditedTime { get; set; }
    }

}
