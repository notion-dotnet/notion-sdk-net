using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Formula property value object.
    /// </summary>
    public class FormulaPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Formula;

        /// <summary>
        ///     A formula described in the database's properties.
        /// </summary>
        [JsonProperty("formula")]
        public FormulaValue Formula { get; set; }
    }

    /// <summary>
    ///     Formula value object.
    /// </summary>
    public class FormulaValue
    {
        /// <summary>
        ///     Formula value type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        ///     String formula value.
        /// </summary>
        [JsonProperty("string")]
        public string String { get; set; }

        /// <summary>
        ///     Number formula value.
        /// </summary>
        [JsonProperty("number")]
        public double? Number { get; set; }

        /// <summary>
        ///     Boolean formula value.
        /// </summary>
        [JsonProperty("boolean")]
        public bool? Boolean { get; set; }

        /// <summary>
        ///     Date formula value
        /// </summary>
        [JsonProperty("date")]
        public Date Date { get; set; }
    }
}
