using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class HeadingFourUpdateBlock : UpdateBlock
    {
        [JsonProperty("heading_4")]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public Info Heading_4 { get; set; }

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBaseInput> RichText { get; set; }
        }
    }
}
