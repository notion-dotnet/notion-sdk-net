using Newtonsoft.Json;

namespace Notion.Client
{
    public class EquationUpdateBlock : UpdateBlock
    {
        [JsonProperty("equation")]
        public Info Equation { get; set; }

        public class Info
        {
            [JsonProperty("expression")]
            public string Expression { get; set; }
        }
    }
}
