using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class TemplateUpdateBlock : UpdateBlock, IUpdateBlock
    {
        [JsonProperty("template")]
        public Data Template { get; set; }

        public class Data
        {
            [JsonProperty("text")]
            public IEnumerable<RichTextBaseInput> Text { get; set; }
        }
    }
}
