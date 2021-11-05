using Newtonsoft.Json;

namespace Notion.Client
{
    public class CheckboxPropertyItem : SimplePropertyItem
    {
        public override string Type => "checkbox";

        [JsonProperty("checkbox")]
        public bool Checkbox { get; set; }
    }
}
