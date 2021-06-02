using Newtonsoft.Json;

namespace Notion.Client
{
    public class CreatedByPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.CreatedBy;

        [JsonProperty("created_by")]
        public User CreatedBy { get; set; }
    }

}
