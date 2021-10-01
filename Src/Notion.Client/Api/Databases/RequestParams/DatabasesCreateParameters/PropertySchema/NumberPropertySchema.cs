using Newtonsoft.Json;

namespace Notion.Client
{
    public class NumberPropertySchema : IPropertySchema
    {
        [JsonProperty("number")]
        public Number Number { get; set; }
    }
}
