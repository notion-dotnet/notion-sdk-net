using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class BookmarkBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("bookmark")]
        public Info Bookmark { get; set; }

        public override BlockType Type => BlockType.Bookmark;

        public class Info
        {
            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("caption")]
            public IEnumerable<RichTextBase> Caption { get; set; }
        }
    }
}
