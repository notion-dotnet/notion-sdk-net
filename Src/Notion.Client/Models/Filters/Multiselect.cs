using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class MultiSelectFilter : SinglePropertyFilter
    {
        [JsonProperty("multi_select")]
        public MultiSelectFilterCondition MultiSelect { get; set; }
    }

    public class MultiSelectFilterCondition
    {
        public string Contains { get; set; }

        [JsonProperty("does_not_contain")]
        public string DoesNotContain { get; set; }

        [JsonProperty("is_empty")]
        public Nullable<bool> IsEmpty { get; set; }

        [JsonProperty("is_not_empty")]
        public Nullable<bool> IsNotEmpty { get; set; }
    }
}