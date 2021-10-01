using Newtonsoft.Json;

namespace Notion.Client
{
    public class SelectPropertySchema : IPropertySchema
    {
        [JsonProperty("select")]
        public OptionWrapper<SelectOptionSchema> Select { get; set; }
    }
}
