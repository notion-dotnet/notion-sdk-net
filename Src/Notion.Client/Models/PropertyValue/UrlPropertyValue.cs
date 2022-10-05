using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     URL property value object.
    /// </summary>
    public class UrlPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Url;

        /// <summary>
        ///     Describes a web address
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
