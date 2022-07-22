using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CodeBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        public override BlockType Type => BlockType.Code;

        [JsonProperty("code")]
        public Info Code { get; set; }

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBase> RichText { get; set; }

            [JsonProperty("language")]
            public string Language { get; set; }

            [JsonProperty("caption")]
            public IEnumerable<RichTextBase> Caption { get; set; }
        }
    }
}
