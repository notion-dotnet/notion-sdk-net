using Newtonsoft.Json;

namespace Notion.Client
{
    public class TableOfContentsUpdateBlock : IUpdateBlock
    {
        public bool Archived { get; set; }

        [JsonProperty("table_of_contents")]
        public Data TableOfContents { get; set; }

        public class Data
        {
        }

        public TableOfContentsUpdateBlock()
        {
            TableOfContents = new Data();
        }
    }
}
