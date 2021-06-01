using Newtonsoft.Json;

namespace Notion.Client
{
    public class SelectFilter : SinglePropertyFilter
    {
        [JsonProperty("equals")]
        public string Equal { get; set; }

        [JsonProperty("does_not_equal")]
        public string DoesNotEqual { get; set; }

        [JsonProperty("is_empty")]
        public bool IsEmpty => true;

        [JsonProperty("is_not_empty")]
        public bool IsNotEmpty => true;
    }
}