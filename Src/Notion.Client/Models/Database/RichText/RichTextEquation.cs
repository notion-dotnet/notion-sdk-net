using Newtonsoft.Json;

namespace Notion.Client
{
    public class RichTextEquation : RichTextBase
    {
        public override RichTextType Type => RichTextType.Equation;

        [JsonProperty("equation")]
        public Equation Equation { get; set; }
    }

    public class Equation
    {
        [JsonProperty("expression")]
        public string Expression { get; set; }
    }
}
