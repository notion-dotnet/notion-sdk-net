using Newtonsoft.Json;

namespace Notion.Client
{
    public class TableOfContentsUpdateBlock : IUpdateBlock
    {
        public TableOfContentsUpdateBlock()
        {
            TableOfContents = new Info();
        }

        [JsonProperty("table_of_contents")]
        public Info TableOfContents { get; set; }

        public bool InTrash { get; set; }

        public class Info
        {
        }
    }
}
