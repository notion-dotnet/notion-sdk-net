using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class HeadingThreeUpdateBlock : UpdateBlock
    {
        [JsonProperty("heading_3")]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public Info Heading_3 { get; set; }

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBaseInput> RichText { get; set; }
        }
    }
}
