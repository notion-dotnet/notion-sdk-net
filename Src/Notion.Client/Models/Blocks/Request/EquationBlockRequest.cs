using Newtonsoft.Json;

namespace Notion.Client
{
    public class EquationBlockRequest : BlockObjectRequest, IColumnChildrenBlockRequest, INonColumnBlockRequest
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
