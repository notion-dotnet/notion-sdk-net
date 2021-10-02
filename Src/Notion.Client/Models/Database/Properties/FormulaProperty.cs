using Newtonsoft.Json;

namespace Notion.Client
{
    public class FormulaProperty : Property
    {
        public override PropertyType Type => PropertyType.Formula;

        [JsonProperty("formula")]
        public Formula Formula { get; set; }
    }

    public class Formula
    {
        [JsonProperty("expression")]
        public string Expression { get; set; }
    }
}
