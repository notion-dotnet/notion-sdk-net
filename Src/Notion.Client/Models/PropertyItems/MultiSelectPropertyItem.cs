using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class MultiSelectPropertyItem : SimplePropertyItem
    {
        public override string Type => "multi_select";

        [JsonProperty("multi_select")]
        public IEnumerable<SelectOption> MultiSelect { get; set; }
    }
}
