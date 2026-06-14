using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ToggleBlockRequest : BlockObjectRequest, IColumnChildrenBlockRequest, INonColumnBlockRequest
    {
        [JsonProperty("toggle")]
        public Info Toggle { get; set; }

        public override BlockType Type => BlockType.Toggle;

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBase> RichText { get; set; }

            [JsonProperty("color")]
            public Color? Color { get; set; }

            [JsonProperty("children")]
            public IEnumerable<INonColumnBlockRequest> Children { get; set; }
        }
    }
}
