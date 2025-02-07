using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class ParagraphBlockRequest : Block, IColumnChildrenBlockRequest, INonColumnBlockRequest
    {
        [JsonProperty("paragraph")]
        public Info Paragraph { get; set; }

        public override BlockType Type => BlockType.Paragraph;

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBase> RichText { get; set; }

            [JsonProperty("color")]
            [JsonConverter(typeof(StringEnumConverter))]
            public Color? Color { get; set; }

            [JsonProperty("children")]
            public IEnumerable<INonColumnBlockRequest> Children { get; set; }
        }
    }
}
