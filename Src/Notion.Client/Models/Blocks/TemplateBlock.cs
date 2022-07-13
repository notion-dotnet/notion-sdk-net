using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class TemplateBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        public override BlockType Type => BlockType.Template;

        [JsonProperty("template")]
        public Data Template { get; set; }

        public class Data
        {
            [JsonProperty("text")]
            public IEnumerable<RichTextBase> Text { get; set; }

            [JsonProperty("children")]
            public IEnumerable<ITemplateChildrendBlock> Children { get; set; }
        }
    }
}
