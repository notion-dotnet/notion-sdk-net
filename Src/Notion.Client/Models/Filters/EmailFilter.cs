using Newtonsoft.Json;

namespace Notion.Client
{
    public class EmailFilter : SinglePropertyFilter
    {
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
                equal,
                doesNotEqual,
                contains,
                doesNotContain,
                startsWith,
                endsWith,
                isEmpty,
                isNotEmpty
            );
        }

        [JsonProperty("email")]
        public TextFilter.Condition Email { get; set; }
    }
}
