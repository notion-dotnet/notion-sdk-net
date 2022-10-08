using Newtonsoft.Json;

namespace Notion.Client
{
    public class MultiSelectUpdatePropertySchema : UpdatePropertySchema
    {
        [JsonProperty("multi_select")]
        public OptionWrapper<SelectOption> MultiSelect { get; set; }
    }
}
