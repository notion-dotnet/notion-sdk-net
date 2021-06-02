using Newtonsoft.Json;

namespace Notion.Client
{
    public class PhoneNumberPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.PhoneNumber;


        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
