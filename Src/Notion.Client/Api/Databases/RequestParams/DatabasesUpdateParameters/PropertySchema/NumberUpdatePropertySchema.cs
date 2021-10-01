using Newtonsoft.Json;

namespace Notion.Client
{
    public class NumberUpdatePropertySchema : UpdatePropertySchema, IUpdatePropertySchema
    {
        [JsonProperty("number")]
        public Number Number { get; set; }
    }
}
