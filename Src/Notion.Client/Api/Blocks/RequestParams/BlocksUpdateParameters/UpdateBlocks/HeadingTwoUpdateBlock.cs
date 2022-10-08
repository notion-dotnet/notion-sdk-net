using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class HeadingTwoUpdateBlock : UpdateBlock
    {
        [JsonProperty("heading_2")]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public Info Heading_2 { get; set; }

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBaseInput> RichText { get; set; }
        }
    }
}
