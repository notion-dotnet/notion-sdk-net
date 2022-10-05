using Newtonsoft.Json;

namespace Notion.Client
{
    /// <summary>
    ///     Phone number property value object.
    /// </summary>
    public class PhoneNumberPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.PhoneNumber;

        /// <summary>
        ///     Phone number value
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
