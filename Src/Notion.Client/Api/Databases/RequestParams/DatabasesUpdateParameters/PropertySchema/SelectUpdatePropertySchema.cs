using Newtonsoft.Json;

namespace Notion.Client
{
    public class SelectUpdatePropertySchema : IUpdatePropertySchema
    {
        public OptionWrapper<SelectOption> Select { get; set; }
    }

    public class MultiSelectUpdatePropertySchema : IUpdatePropertySchema
    {
        [JsonProperty("multi_select")]
        public OptionWrapper<SelectOption> MultiSelect { get; set; }
    }
}
