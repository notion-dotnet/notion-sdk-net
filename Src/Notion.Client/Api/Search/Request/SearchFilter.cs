using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class SearchFilter
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public SearchObjectType Value { get; set; }

        public string Property => "object";
    }
}
