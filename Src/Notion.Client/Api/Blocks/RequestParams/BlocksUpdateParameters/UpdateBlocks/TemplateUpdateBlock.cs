using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class TemplateUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("template")]
        public Info Template { get; set; }

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBaseInput> RichText { get; set; }
        }
    }
}
