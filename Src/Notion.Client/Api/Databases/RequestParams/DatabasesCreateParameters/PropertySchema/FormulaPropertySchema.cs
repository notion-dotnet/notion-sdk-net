using Newtonsoft.Json;

namespace Notion.Client
{
    public class FormulaPropertySchema : IPropertySchema
    {
        [JsonProperty("formula")]
        public Formula Formula { get; set; }
    }
}
