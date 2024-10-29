using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class BookmarkUpdateBlock : IUpdateBlock
    {
        [JsonProperty("bookmark")]
        public Info Bookmark { get; set; }

        public bool InTrash { get; set; }

        public class Info
        {
            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("caption")]
            public IEnumerable<RichTextBaseInput> Caption { get; set; }
        }
    }
}
