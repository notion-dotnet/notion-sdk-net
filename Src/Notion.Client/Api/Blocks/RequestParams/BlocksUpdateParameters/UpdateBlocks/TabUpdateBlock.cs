using Newtonsoft.Json;

namespace Notion.Client
{
    public class TabUpdateBlock : UpdateBlock
    {
        public TabUpdateBlock()
        {
            Tab = new Info();
        }

        [JsonProperty("tab")]
        public Info Tab { get; set; }

        public class Info
        {
        }
    }
}
