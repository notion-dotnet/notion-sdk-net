using Newtonsoft.Json;

namespace Notion.Client
{
    public class RichTextEquationInput : RichTextBaseInput
    {
        public override RichTextType Type => RichTextType.Equation;

        [JsonProperty("equation")]
        public Equation Equation { get; set; }
    }
}
