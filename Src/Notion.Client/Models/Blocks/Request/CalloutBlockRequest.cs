using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Notion.Client
{
    public class CalloutBlockRequest : BlockObjectRequest, IColumnChildrenBlockRequest, INonColumnBlockRequest
    {
        [JsonProperty("callout")]
        public Info Callout { get; set; }

        public override BlockType Type => BlockType.Callout;

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBase> RichText { get; set; }

            [JsonProperty("icon")]
            public IPageIcon Icon { get; set; }

            [JsonProperty("color")]
            [JsonConverter(typeof(StringEnumConverter))]
            public Color? Color { get; set; }

            [JsonProperty("children")]
            public IEnumerable<INonColumnBlockRequest> Children { get; set; }
        }
    }
}
