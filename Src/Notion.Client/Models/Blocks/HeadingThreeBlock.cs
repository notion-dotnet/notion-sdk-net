using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class HeadingThreeBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("heading_3")]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public Info Heading_3 { get; set; }

        public override BlockType Type => BlockType.Heading3;

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBase> RichText { get; set; }

            [JsonProperty("color")]
            public Color? Color { get; set; }

            [JsonProperty("is_toggleable")]
            public bool IsToggleable { get; set; }
        }
    }
}
