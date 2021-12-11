using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ColumnBlock : Block
    {
        public override BlockType Type => BlockType.Column;

        [JsonProperty("column")]
        public Info Column { get; set; }

        public class Info
        {
            [JsonProperty("children")]
            public IEnumerable<IColumnChildrenBlock> Children { get; set; }
        }
    }

    public class ColumnListBlock : Block, INonColumnBlock
    {
        public override BlockType Type => BlockType.ColumnList;

        [JsonProperty("column_list")]
        public Info ColumnList { get; set; }

        public class Info
        {
            [JsonProperty("children")]
            public IEnumerable<ColumnBlock> Children { get; set; }
        }
    }
}
