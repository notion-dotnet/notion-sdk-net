using Newtonsoft.Json;

namespace Notion.Client
{
    public class MultiSelectFilter : SinglePropertyFilter
    {
        public string Contains { get; set; }

        [JsonProperty("does_not_contain")]
        public string DoesNotContain { get; set; }

        [JsonProperty("is_empty")]
        public bool IsEmpty => true;

        [JsonProperty("is_not_empty")]
        public bool IsNotEmpty => true;
    }
}