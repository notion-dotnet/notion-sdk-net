using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class TabBlockRequest : BlockObjectRequest, IColumnChildrenBlockRequest, INonColumnBlockRequest
    {
        public override BlockType Type => BlockType.Tab;

        [JsonProperty("tab")]
        public Data Tab { get; set; }

        public class Data
        {
            /// <summary>
            /// Paragraph blocks that represent individual tabs. Only paragraph blocks are valid children.
            /// </summary>
            [JsonProperty("children")]
            public IEnumerable<ParagraphBlockRequest> Children { get; set; }
        }
    }
}
