using Newtonsoft.Json;

namespace Notion.Client
{
    public class DividerUpdateBlock : IUpdateBlock
    {
        public bool Archived { get; set; }

        [JsonProperty("divider")]
        public Data Divider { get; set; }

        public class Data
        {

        }

        public DividerUpdateBlock()
        {
            Divider = new Data();
        }
    }
}
