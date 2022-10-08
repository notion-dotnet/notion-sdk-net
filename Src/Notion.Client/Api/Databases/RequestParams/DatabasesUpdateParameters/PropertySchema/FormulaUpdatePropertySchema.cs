using Newtonsoft.Json;

namespace Notion.Client
{
    public class FormulaUpdatePropertySchema : UpdatePropertySchema
    {
        [JsonProperty("formula")]
        public Formula Formula { get; set; }
    }
}
