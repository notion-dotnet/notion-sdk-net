using Newtonsoft.Json;

namespace Notion.Client
{
    public class CheckboxFilter : SinglePropertyFilter, IRollupSubPropertyFilter
    {
        public CheckboxFilter(
            string propertyName,
            bool? equal = null,
            bool? doesNotEqual = null)
        {
            Property = propertyName;
            Checkbox = new Condition(equal, doesNotEqual);
        }

        [JsonProperty("checkbox")]
        public Condition Checkbox { get; set; }

        public class Condition
        {
            public Condition(bool? equal = null, bool? doesNotEqual = null)
            {
                Equal = equal;
                DoesNotEqual = doesNotEqual;
            }

            [JsonProperty("equals")]
            public bool? Equal { get; set; }

            [JsonProperty("does_not_equal")]
            public bool? DoesNotEqual { get; set; }
        }
    }
}
