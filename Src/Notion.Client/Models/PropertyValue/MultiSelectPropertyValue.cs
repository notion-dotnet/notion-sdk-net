using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class MultiSelectPropertyValue : PropertyValue
    {
        public override PropertyValueType Type => PropertyValueType.MultiSelect;

        [JsonProperty("multi_select")]
        public List<SelectOption> MultiSelect { get; set; }
    }

}
