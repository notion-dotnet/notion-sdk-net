using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class SearchFilter
    {
        /// <summary>
        /// Limits the results to pages or data sources. Leave unset to filter on <see cref="InTrash" /> only.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SearchObjectType? Value { get; set; }

        /// <summary>
        /// Always "object" when <see cref="Value" /> is set; omitted otherwise.
        /// </summary>
        public string Property => Value.HasValue ? "object" : null;

        /// <summary>
        /// When set, limits the results to items that are (true) or are not (false) in the trash.
        /// Can be used on its own or together with <see cref="Value" />.
        /// </summary>
        [JsonProperty("in_trash")]
        public bool? InTrash { get; set; }
    }
}
