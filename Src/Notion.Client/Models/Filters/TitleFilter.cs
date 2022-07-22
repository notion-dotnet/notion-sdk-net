using Newtonsoft.Json;

namespace Notion.Client
{
    public class TitleFilter : SinglePropertyFilter
    {
        [JsonProperty("title")]
        public TextFilter.Condition Title { get; set; }

        public TitleFilter(
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
            Title = new TextFilter.Condition(
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
