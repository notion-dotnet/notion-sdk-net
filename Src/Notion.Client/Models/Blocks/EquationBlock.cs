using Newtonsoft.Json;

namespace Notion.Client
{
    public class EquationBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("equation")]
        public Info Equation { get; set; }

        public override BlockType Type => BlockType.Equation;

        public class Info
        {
            [JsonProperty("expression")]
            public string Expression { get; set; }
        }
    }
}
