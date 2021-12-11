using System.Collections.Generic;
using Newtonsoft.Json;

namespace Notion.Client
{
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
