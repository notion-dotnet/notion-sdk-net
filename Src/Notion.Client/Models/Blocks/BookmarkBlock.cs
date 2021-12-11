using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class BookmarkBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        public override BlockType Type => BlockType.Bookmark;

        [JsonProperty("bookmark")]
        public Info Bookmark { get; set; }

        public class Info
        {
            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("caption")]
            public IEnumerable<RichTextBase> Caption { get; set; }
        }
    }
}
