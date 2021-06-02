using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CheckboxFilter : SinglePropertyFilter
    {
        public Condition Checkbox { get; set; }

        public class Condition
        {
            [JsonProperty("equals")]
            public Nullable<bool> Equal { get; set; }

            [JsonProperty("does_not_equal")]
            public Nullable<bool> DoesNotEqual { get; set; }
        }
    }
}