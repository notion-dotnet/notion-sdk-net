using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ToggleUpdateBlock : UpdateBlock
    {
        [JsonProperty("toggle")]
        public Info Toggle { get; set; }

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBaseInput> RichText { get; set; }
        }
    }
}
