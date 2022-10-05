using Newtonsoft.Json;

namespace Notion.Client
{
    public class SelectFilter : SinglePropertyFilter, IRollupSubPropertyFilter
    {
        public SelectFilter(
            string propertyName,
            string equal = null,
            string doesNotEqual = null,
            bool? isEmpty = null,
            bool? isNotEmpty = null)
        {
            Property = propertyName;

            Select = new Condition(
                equal,
                doesNotEqual,
                isEmpty,
                isNotEmpty
            );
        }

        [JsonProperty("select")]
        public Condition Select { get; set; }

        public class Condition
        {
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

            [JsonProperty("equals")]
            public string Equal { get; set; }

            [JsonProperty("does_not_equal")]
            public string DoesNotEqual { get; set; }

            [JsonProperty("is_empty")]
            public bool? IsEmpty { get; set; }

            [JsonProperty("is_not_empty")]
            public bool? IsNotEmpty { get; set; }
        }
    }
}
