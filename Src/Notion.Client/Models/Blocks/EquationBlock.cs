using Newtonsoft.Json;

namespace Notion.Client
{
    public class EquationBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        public override BlockType Type => BlockType.Equation;

        [JsonProperty("equation")]
        public Info Equation { get; set; }

        public class Info
        {
            [JsonProperty("expression")]
            public string Expression { get; set; }
        }
    }
}
