using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class BookmarkUpdateBlock : IUpdateBlock
    {
        public bool Archived { get; set; }

        [JsonProperty("bookmark")]
        public Data Bookmark { get; set; }

        public class Data
        {
            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("caption")]
            public IEnumerable<RichTextBaseInput> Caption { get; set; }
        }
    }
}
