using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Select property value object.
    /// </summary>
    public class SelectPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Select;

        [JsonProperty("select", NullValueHandling = NullValueHandling.Include)]
        public SelectOption Select { get; set; }
    }
}
