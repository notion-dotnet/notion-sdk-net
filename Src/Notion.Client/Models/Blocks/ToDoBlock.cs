using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ToDoBlock : Block, IColumnChildrenBlock, INonColumnBlock
    {
        public override BlockType Type => BlockType.ToDo;

        [JsonProperty("to_do")]
        public Info ToDo { get; set; }

        public class Info
        {
            [JsonProperty("rich_text")]
            public IEnumerable<RichTextBase> RichText { get; set; }

            [JsonProperty("checked")]
            public bool IsChecked { get; set; }

            [JsonProperty("children")]
            public IEnumerable<INonColumnBlock> Children { get; set; }
        }
    }
}
