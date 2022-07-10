using Newtonsoft.Json;

namespace Notion.Client
{
    public class SelectFilter : SinglePropertyFilter
    {
        [JsonProperty("select")]
        public Condition Select { get; set; }

        public SelectFilter(
            string propertyName,
            string equal = null,
            string doesNotEqual = null,
            bool? isEmpty = null,
            bool? isNotEmpty = null)
        {
            Property = propertyName;
            Select = new Condition(
                equal: equal,
                doesNotEqual: doesNotEqual,
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

            [JsonProperty("is_empty")]
            public bool? IsEmpty { get; set; }

            [JsonProperty("is_not_empty")]
            public bool? IsNotEmpty { get; set; }

            public Condition(
                string equal = null,
                string doesNotEqual = null,
                bool? isEmpty = null,
                bool? isNotEmpty = null)
            {
                Equal = equal;
                DoesNotEqual = doesNotEqual;
                IsEmpty = isEmpty;
                IsNotEmpty = isNotEmpty;
            }
        }
    }
}
