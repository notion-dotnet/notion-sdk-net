using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Created time property value object.
    /// </summary>
    public class CreatedTimePropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.CreatedTime;

        /// <summary>
        ///     The date and time when this page was created.
        /// </summary>
        [JsonProperty("created_time")]
        public string CreatedTime { get; set; }
    }
}
