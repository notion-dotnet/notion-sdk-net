using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class TemplateBlockRequest : BlockObjectRequest, IColumnChildrenBlockRequest, INonColumnBlockRequest
    {
        [JsonProperty("template")]
        public Data Template { get; set; }

        public override BlockType Type => BlockType.Template;

        public class Data
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBase> RichText { get; set; }

            [JsonProperty("children")]
            public IEnumerable<ITemplateChildrenBlockRequest> Children { get; set; }
        }
    }
}
