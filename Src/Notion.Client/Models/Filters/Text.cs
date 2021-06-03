using System;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class TextFilter : SinglePropertyFilter
    {
        public Condition Text { get; set; }

        public TextFilter(
            string propertyName,
            string equal = null,
            string doesNotEqual = null,
            string contains = null,
            string doesNotContain = null,
            string startsWith = null,
            string endsWith = null,
            bool? isEmpty = null,
            bool? isNotEmpty = null)
        {
            Property = propertyName;
            Text = new Condition(
                equal: equal,
                doesNotEqual: doesNotEqual,
                contains: contains,
                doesNotContain: doesNotContain,
                startsWith: startsWith,
                endsWith: endsWith,
                isEmpty: isEmpty,
                isNotEmpty: isNotEmpty
            );
        }

        public class Condition
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
            public bool? IsEmpty { get; set; }

            [JsonProperty("is_not_empty")]
            public bool? IsNotEmpty { get; set; }

            public Condition(
                string equal = null,
                string doesNotEqual = null,
                string contains = null,
                string doesNotContain = null,
                string startsWith = null,
                string endsWith = null,
                bool? isEmpty = null,
                bool? isNotEmpty = null)
            {
                Equal = equal;
                DoesNotEqual = doesNotEqual;
                Contains = contains;
                DoesNotContain = doesNotContain;
                StartsWith = startsWith;
                EndsWith = endsWith;
                IsEmpty = isEmpty;
                IsNotEmpty = isNotEmpty;
            }
        }
    }
}