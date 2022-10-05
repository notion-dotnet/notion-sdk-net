using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Email property value object.
    /// </summary>
    public class EmailPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.Email;

        /// <summary>
        ///     Describes an email address.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
