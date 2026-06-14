using Newtonsoft.Json;

namespace Notion.Client
{
    public class TableOfContentsBlockRequest : BlockObjectRequest, IColumnChildrenBlockRequest, INonColumnBlockRequest
    {
        [JsonProperty("table_of_contents")]
        public Data TableOfContents { get; set; }

        public override BlockType Type => BlockType.TableOfContents;

        public class Data
        {
            [JsonProperty("color")]
            public Color? Color { get; set; }
        }
    }
}
