using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CheckboxFilter : SinglePropertyFilter
    {
        public CheckboxFilterCondition Checkbox { get; set; }
    }

    public class CheckboxFilterCondition
    {
        [JsonProperty("equals")]
        public Nullable<bool> Equal { get; set; }

        [JsonProperty("does_not_equal")]
        public Nullable<bool> DoesNotEqual { get; set; }
    }
}