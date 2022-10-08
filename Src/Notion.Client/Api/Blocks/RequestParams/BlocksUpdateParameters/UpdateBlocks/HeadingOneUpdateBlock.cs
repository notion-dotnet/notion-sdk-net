using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class HeadingOneUpdateBlock : UpdateBlock
    {
        [JsonProperty("heading_1")]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public Info Heading_1 { get; set; }

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBaseInput> RichText { get; set; }
        }
    }
}
