using Newtonsoft.Json;

namespace Notion.Client
{
    public class MultiSelectDataSourcePropertyConfig : DataSourcePropertyConfig
    {
        public override string Type => DataSourcePropertyTypes.MultiSelect;

        [JsonProperty("multi_select")]
        public OptionWrapper<SelectOptionResponse> MultiSelect { get; set; }
    }
}
