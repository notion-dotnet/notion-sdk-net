using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CheckboxFilter : SinglePropertyFilter
    {
        [JsonProperty("checkbox")]
        public Condition Checkbox { get; set; }

        public CheckboxFilter(
            string propertyName,
            bool? equal = null,
            bool? doesNotEqual = null)
        {
            Property = propertyName;
            Checkbox = new Condition(equal: equal, doesNotEqual: doesNotEqual);
        }

        public class Condition
        {
            [JsonProperty("equals")]
            public bool? Equal { get; set; }

            [JsonProperty("does_not_equal")]
            public bool? DoesNotEqual { get; set; }

            public Condition(Nullable<bool> equal = null, Nullable<bool> doesNotEqual = null)
            {
                Equal = equal;
                DoesNotEqual = doesNotEqual;
            }
        }
    }
}
