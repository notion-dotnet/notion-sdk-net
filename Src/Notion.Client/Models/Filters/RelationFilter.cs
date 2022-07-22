using Newtonsoft.Json;

namespace Notion.Client
{
    public class RelationFilter : SinglePropertyFilter, IRollupSubPropertyFilter
    {
        [JsonProperty("relation")]
        public Condition Relation { get; set; }

        public RelationFilter(
            string propertyName,
            string contains = null,
            string doesNotContain = null,
            bool? isEmpty = null,
            bool? isNotEmpty = null)
        {
            Property = propertyName;
            Relation = new Condition(
                contains: contains,
                doesNotContain: doesNotContain,
                isEmpty: isEmpty,
                isNotEmpty: isNotEmpty
            );
        }

        public class Condition
        {
            [JsonProperty("contains")]
            public string Contains { get; set; }

            [JsonProperty("does_not_contain")]
            public string DoesNotContain { get; set; }

            [JsonProperty("is_empty")]
            public bool? IsEmpty { get; set; }

            [JsonProperty("is_not_empty")]
            public bool? IsNotEmpty { get; set; }

            public Condition(
                string contains = null,
                string doesNotContain = null,
                bool? isEmpty = null,
                bool? isNotEmpty = null)
            {
                Contains = contains;
                DoesNotContain = doesNotContain;
                IsEmpty = isEmpty;
                IsNotEmpty = isNotEmpty;
            }
        }
    }
}
