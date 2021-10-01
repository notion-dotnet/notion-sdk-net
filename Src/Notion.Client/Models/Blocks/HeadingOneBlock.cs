using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class HeadingOneBlock : Block
    {
        public override BlockType Type => BlockType.Heading_1;

        [JsonProperty("heading_1")]
        public Info Heading_1 { get; set; }

        public override bool HasChildren => false;

        public class Info
        {
            [JsonProperty("text")]
            public IEnumerable<RichTextBase> Text { get; set; }
        }
    }
}
