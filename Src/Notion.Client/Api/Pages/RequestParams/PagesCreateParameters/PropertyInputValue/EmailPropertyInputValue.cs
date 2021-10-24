using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    /// Email property value object.
    /// </summary>
    public class EmailPropertyInputValue : PropertyInputValue
    {
        /// <summary>
        /// Describes an email address.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
