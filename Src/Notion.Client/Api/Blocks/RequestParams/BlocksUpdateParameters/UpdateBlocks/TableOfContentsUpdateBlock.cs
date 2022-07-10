using Newtonsoft.Json;

namespace Notion.Client
{
    public class TableOfContentsUpdateBlock : IUpdateBlock
    {
        public bool Archived { get; set; }

        [JsonProperty("table_of_contents")]
        public Info TableOfContents { get; set; }

        public class Info
        {
        }

        public TableOfContentsUpdateBlock()
        {
            TableOfContents = new Info();
        }
    }
}
