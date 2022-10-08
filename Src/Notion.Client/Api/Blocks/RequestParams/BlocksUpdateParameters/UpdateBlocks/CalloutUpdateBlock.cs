using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CalloutUpdateBlock : UpdateBlock
    {
        [JsonProperty("callout")]
        public Info Callout { get; set; }

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBaseInput> RichText { get; set; }

            [JsonProperty("icon")]
            public IPageIcon Icon { get; set; }
        }
    }
}
