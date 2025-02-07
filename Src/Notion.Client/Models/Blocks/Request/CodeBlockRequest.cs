using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class CodeBlockRequest : BlockObjectRequest, IColumnChildrenBlockRequest, INonColumnBlockRequest
    {
        [JsonProperty("code")]
        public Info Code { get; set; }

        public override BlockType Type => BlockType.Code;

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
