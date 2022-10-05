using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Checkbox property value objects contain a boolean within the checkbox property.
    /// </summary>
    public class CheckboxPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Checkbox;

        [JsonProperty("checkbox")]
        public bool Checkbox { get; set; }
    }
}
