using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Rollup property value object.
    /// </summary>
    public class RollupPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Rollup;

        [JsonProperty("rollup")]
        public RollupValue Rollup { get; set; }
    }

    /// <summary>
    ///     Object containing rollup type-specific data.
    /// </summary>
    public class RollupValue
    {
        /// <summary>
        ///     The type of rollup. Possible values are "number", "date", and "array".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Number rollup property values contain a number
        /// </summary>
        [JsonProperty("number")]
        public double? Number { get; set; }

        /// <summary>
        ///     Date rollup property values contain a date property value.
        /// </summary>
        [JsonProperty("date")]
        public DatePropertyValue Date { get; set; }

        /// <summary>
        ///     Array rollup property values contain an array of element objects.
        ///     Array containing the property value object will not contain value for Id field
        /// </summary>
        [JsonProperty("array")]
        public List<PropertyValue> Array { get; set; }
    }
}
