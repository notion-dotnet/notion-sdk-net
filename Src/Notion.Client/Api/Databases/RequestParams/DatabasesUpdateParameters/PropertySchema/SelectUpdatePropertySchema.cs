using Newtonsoft.Json;

namespace Notion.Client
{
    public class SelectUpdatePropertySchema : UpdatePropertySchema
    {
        [JsonProperty("select")]
        public OptionWrapper<SelectOption> Select { get; set; }
    }
}
