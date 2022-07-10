using Newtonsoft.Json;

namespace Notion.Client
{
    public class EmailFilter : SinglePropertyFilter
    {
        [JsonProperty("email")]
        public TextFilter.Condition Email { get; set; }

        public EmailFilter(
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
            Email = new TextFilter.Condition(
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
    }
}
