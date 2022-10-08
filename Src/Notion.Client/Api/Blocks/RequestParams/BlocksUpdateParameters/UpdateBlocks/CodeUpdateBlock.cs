using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CodeUpdateBlock : UpdateBlock
    {
        [JsonProperty("code")]
        public Info Code { get; set; }

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBase> RichText { get; set; }

            [JsonProperty("language")]
            public string Language { get; set; }

            [JsonProperty("caption")]
            public IEnumerable<RichTextBaseInput> Caption { get; set; }
        }
    }
}
