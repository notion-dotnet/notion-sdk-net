using Newtonsoft.Json;

namespace Notion.Client
{
    public class LastEditedByPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.LastEditedBy;

        [JsonProperty("last_edited_by")]
        public User LastEditedBy { get; set; }
    }
}
