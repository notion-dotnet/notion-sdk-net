using Newtonsoft.Json;

namespace Notion.Client
{
    public class PhoneNumberPropertyItem : SimplePropertyItem
    {
        public override string Type => "phone_number";

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
