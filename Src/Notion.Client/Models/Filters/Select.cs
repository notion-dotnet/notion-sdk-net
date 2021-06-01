using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class SelectFilter : SinglePropertyFilter
    {
        public SelectFilterCondition Select { get; set; }
    }

    public class SelectFilterCondition
    {
        [JsonProperty("equals")]
        public string Equal { get; set; }

        [JsonProperty("does_not_equal")]
        public string DoesNotEqual { get; set; }

        [JsonProperty("is_empty")]
        public Nullable<bool> IsEmpty { get; set; }

        [JsonProperty("is_not_empty")]
        public Nullable<bool> IsNotEmpty { get; set; }
    }
}