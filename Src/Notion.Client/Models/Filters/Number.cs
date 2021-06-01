using Newtonsoft.Json;

namespace Notion.Client
{
    public class NumberFilter : SinglePropertyFilter
    {
        [JsonProperty("equals")]
        public double Equal { get; set; }

        [JsonProperty("does_not_equal")]
        public double DoesNotEqual { get; set; }

        [JsonProperty("greater_than")]
        public double GreaterThan { get; set; }

        [JsonProperty("less_than")]
        public double LessThan { get; set; }

        [JsonProperty("greater_than_or_equal_to")]
        public double GreaterThanOrEqualTo { get; set; }

        [JsonProperty("less_than_or_equal_to")]
        public double LessThanOrEqualTo { get; set; }

        [JsonProperty("is_empty")]
        public bool IsEmpty => true;

        [JsonProperty("is_not_empty")]
        public bool IsNotEmpty => true;
    }
}