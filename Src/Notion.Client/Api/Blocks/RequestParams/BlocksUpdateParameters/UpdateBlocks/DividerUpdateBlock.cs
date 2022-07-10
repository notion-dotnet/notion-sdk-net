using Newtonsoft.Json;

namespace Notion.Client
{
    public class DividerUpdateBlock : IUpdateBlock
    {
        public bool Archived { get; set; }

        [JsonProperty("divider")]
        public Info Divider { get; set; }

        public class Info
        {
        }

        public DividerUpdateBlock()
        {
            Divider = new Info();
        }
    }
}
