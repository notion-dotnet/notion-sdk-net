using System.Collections.Generic;
using Newtonsoft.Json;

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
            public Color? Color { get; set; }

            [JsonProperty("children")]
            public IEnumerable<INonColumnBlockRequest> Children { get; set; }

            /// <summary>
            /// Optional icon for paragraph blocks that are direct children of a tab block.
            /// Setting an icon on other paragraphs results in a validation error from the API.
            /// </summary>
            [JsonProperty("icon")]
            public IPageIconRequest Icon { get; set; }
        }
    }
}
