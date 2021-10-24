using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Last edited time property value object.
    /// </summary>
    public class LastEditedTimePropertyInputValue : PropertyInputValue
    {
        /// <summary>
        /// The date and time when this page was last updated.
        /// </summary>
        [JsonProperty("last_edited_time")]
        public string LastEditedTime { get; set; }
    }
}
