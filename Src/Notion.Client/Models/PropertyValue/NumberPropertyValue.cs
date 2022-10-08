using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Number formula property value object.
    /// </summary>
    public class NumberPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Number;

        /// <summary>
        ///     Value of number
        /// </summary>
        [JsonProperty("number")]
        public double? Number { get; set; }
    }
}
