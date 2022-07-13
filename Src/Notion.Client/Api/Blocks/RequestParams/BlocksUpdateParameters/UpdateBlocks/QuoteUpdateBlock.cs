using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class QuoteUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("quote")]
        public Info Quote { get; set; }

        public class Info
        {
            [JsonProperty("text")]
            public IEnumerable<RichTextBaseInput> Text { get; set; }
        }
    }
}
