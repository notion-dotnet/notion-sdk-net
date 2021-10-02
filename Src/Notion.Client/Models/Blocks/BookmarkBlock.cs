using Newtonsoft.Json;

namespace Notion.Client
{
    public class BookmarkBlock : Block
    {
        public override BlockType Type => BlockType.Bookmark;

        [JsonProperty("bookmark")]
        public Info Bookmark { get; set; }

        public class Info
        {
            [JsonProperty("url")]
            public string Url { get; set; }
        }
    }
}
