using Newtonsoft.Json;

namespace Notion.Client
{
    public class MultiSelectUpdatePropertySchema : IUpdatePropertySchema
    {
        [JsonProperty("multi_select")]
        public OptionWrapper<SelectOption> MultiSelect { get; set; }
    }
}
