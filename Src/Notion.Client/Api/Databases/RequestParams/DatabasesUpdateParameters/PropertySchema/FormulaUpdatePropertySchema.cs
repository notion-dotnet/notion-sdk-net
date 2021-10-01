using Newtonsoft.Json;

namespace Notion.Client
{
    public class FormulaUpdatePropertySchema : UpdatePropertySchema, IUpdatePropertySchema
    {
        [JsonProperty("formula")]
        public Formula Formula { get; set; }
    }
}
