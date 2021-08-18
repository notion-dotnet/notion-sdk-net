using Newtonsoft.Json;

namespace Notion.Client
{
    public class MultiSelectPropertySchema : IPropertySchema
    {
        [JsonProperty("multi_select")]
        public OptionWrapper<MultiSelectOptionSchema> MultiSelect { get; set; }
    }
}
