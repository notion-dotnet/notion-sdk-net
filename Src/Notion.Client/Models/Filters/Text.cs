using Newtonsoft.Json;

namespace Notion.Client
{
    public class TextFilter : SinglePropertyFilter
    {
        [JsonProperty("equals")]
        public string Equal { get; set; }

        [JsonProperty("does_not_equal")]
        public string DoesNotEqual { get; set; }

        public string Contains { get; set; }

        [JsonProperty("does_not_contain")]
        public string DoesNotContain { get; set; }

        [JsonProperty("starts_with")]
        public string StartsWith { get; set; }

        [JsonProperty("ends_with")]
        public string EndsWith { get; set; }

        [JsonProperty("is_empty")]
        public bool IsEmpty => true;

        [JsonProperty("is_not_empty")]
        public bool IsNotEmpty => true;
    }
}