using Newtonsoft.Json;

namespace Notion.Client
{
    public class FormulaPropertyItem : SimplePropertyItem
    {
        public override string Type => "formula";

        [JsonProperty("formula")]
        public FormulaValue Formula { get; set; }
    }
}
