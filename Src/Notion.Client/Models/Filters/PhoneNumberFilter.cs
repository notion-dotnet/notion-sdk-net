using Newtonsoft.Json;

namespace Notion.Client
{
    public class PhoneNumberFilter : SinglePropertyFilter
    {
        public PhoneNumberFilter(
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

            Text = new TextFilter.Condition(
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

        [JsonProperty("phone_number")]
        public TextFilter.Condition Text { get; set; }
    }
}
