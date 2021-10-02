using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class HeadingThreeeBlock : Block
    {
        public override BlockType Type => BlockType.Heading_3;

        [JsonProperty("heading_3")]
        public Info Heading_3 { get; set; }

        public override bool HasChildren => false;

        public class Info
        {
            [JsonProperty("text")]
            public IEnumerable<RichTextBase> Text { get; set; }
        }
    }
}
