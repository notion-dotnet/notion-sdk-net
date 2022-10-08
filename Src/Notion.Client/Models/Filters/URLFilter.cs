using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Notion.Client
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class URLFilter : SinglePropertyFilter
    {
        public URLFilter(
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

            URL = new TextFilter.Condition(
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

        [JsonProperty("url")]
        public TextFilter.Condition URL { get; set; }
    }
}
