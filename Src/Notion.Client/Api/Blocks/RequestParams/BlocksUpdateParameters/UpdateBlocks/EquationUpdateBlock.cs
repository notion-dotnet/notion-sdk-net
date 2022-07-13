using Newtonsoft.Json;

namespace Notion.Client
{
    public class EquationUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("equation")]
        public Data Equation { get; set; }

        public class Data
        {
            [JsonProperty("expression")]
            public string Expression { get; set; }
        }
    }
}
