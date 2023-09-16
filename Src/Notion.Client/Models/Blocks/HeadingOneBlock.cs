using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class HeadingOneBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        [JsonProperty("heading_1")]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public Info Heading_1 { get; set; }

        public override BlockType Type => BlockType.Heading_1;

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBase> RichText { get; set; }

            [JsonProperty("color")]
            [JsonConverter(typeof(StringEnumConverter))]
            public Color? Color { get; set; }

            [JsonProperty("is_toggleable")]
            public bool IsToggleable { get; set; }
        }
    }
}
