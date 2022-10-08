using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class QuoteUpdateBlock : UpdateBlock
    {
        [JsonProperty("quote")]
        public Info Quote { get; set; }

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBaseInput> RichText { get; set; }
        }
    }
}
