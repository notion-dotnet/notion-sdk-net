using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Number formula property value object.
    /// </summary>
    public class NumberPropertyInputValue : PropertyInputValue
    {
        /// <summary>
        /// Value of number
        /// </summary>
        [JsonProperty("number")]
        public double? Number { get; set; }
    }
}
