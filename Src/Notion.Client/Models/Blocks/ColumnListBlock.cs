using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
    public class ColumnListBlock : Block, INonColumnBlock
    {
        [JsonProperty("column_list")]
        public Info ColumnList { get; set; }

        public override BlockType Type => BlockType.ColumnList;

        public class Info
        {
            [JsonProperty("children")]
            public IEnumerable<ColumnBlock> Children { get; set; }
        }
    }
}
