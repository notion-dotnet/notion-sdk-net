using Newtonsoft.Json;

namespace Notion.Client
{
    public class FormulaUpdatePropertySchema : UpdatePropertySchema, IUpdatePropertySchema
    {
        [JsonProperty("checkbox")]
        public Formula Formula { get; set; }
    }
}
