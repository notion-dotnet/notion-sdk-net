using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class NumberFilter : SinglePropertyFilter
    {
        public NumberFilterCondition Number { get; set; }
    }

    public class NumberFilterCondition
    {
        [JsonProperty("equals")]
        public Nullable<double> Equal { get; set; }

        [JsonProperty("does_not_equal")]
        public Nullable<double> DoesNotEqual { get; set; }

        [JsonProperty("greater_than")]
        public Nullable<double> GreaterThan { get; set; }

        [JsonProperty("less_than")]
        public Nullable<double> LessThan { get; set; }

        [JsonProperty("greater_than_or_equal_to")]
        public Nullable<double> GreaterThanOrEqualTo { get; set; }

        [JsonProperty("less_than_or_equal_to")]
        public Nullable<double> LessThanOrEqualTo { get; set; }

        [JsonProperty("is_empty")]
        public Nullable<bool> IsEmpty { get; set; }

        [JsonProperty("is_not_empty")]
        public Nullable<bool> IsNotEmpty { get; set; }
    }
}