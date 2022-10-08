using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Select property value object.
    /// </summary>
    public class SelectPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Select;

        [JsonProperty("select")]
        public SelectOption Select { get; set; }
    }
}
