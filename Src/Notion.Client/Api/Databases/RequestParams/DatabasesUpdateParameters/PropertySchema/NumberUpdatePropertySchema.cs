using Newtonsoft.Json;

namespace Notion.Client
{
    public class NumberUpdatePropertySchema : UpdatePropertySchema
    {
        [JsonProperty("number")]
        public Number Number { get; set; }
    }
}
